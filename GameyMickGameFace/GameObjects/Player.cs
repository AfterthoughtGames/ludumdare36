using GameyMickGameFace.GameObjects.PowerUps;
using GameyMickGameFace.AI;
using GameyMickGameFace.Media;
using GameyMickGameFace.Particles;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameyMickGameFace.GameObjects
{
    public enum PlayerAnimationState
    {
        StandingLeft, StandingRight, Jummping, Falling, WalkingLeft, WalkingRight,
        WalkingWithSwordLeft, WalkingWithSwordRight, WalkingWithTridentLeft, WalkingWithTridentRight,
        StandingWithSwordLeft, StandingWithSwordRight, StandingWithTridentLeft, StandingWithTridentRight,
        AttackingWithSwordLeft, AttackingWithSwordRight, AttackingWithTridentLeft, AttackingWithTridentRight
    }

    public class Player
    {
        public int Score = 0;
        public int Health { get; set; }
        public string Name { get; set; }
        // public Vector2 Position { get; set; }
        public bool Human = false;

        public float SpeedBonus = 1;
        float scale = 0.4f;

        public Weapon Weapon { get; set; }
        bool jumping = false;
        Random rand;

        public Body PhysicsBody { get; set; }

        public int PlayerNumber { get; set; }
        public GamePadState PreviousState { get; set; }
        public GamePadState PreviousPadState { get; set; }
        public KeyboardState PreviousKeyState { get; set; }

        public PlayerAnimationState AnimationState { get; set; }
        public PlayerAnimationState PreviousAnimationState { get; set; }
        public List<Body> DetectionPhysicsBodies;
        public long lastTime = 0;

        private static int gravityVelo = 100;
        private static int jumpVelo = -1790;

        TimeSpan AILastAttack;
        int SecBetweenAttack = 200;

        public Player(int seed)
        {
            rand = new Random(seed);
            Point position = Level.PlayerSpawnPoints[rand.Next(0, Level.PlayerSpawnPoints.Count)];

            AnimationState = PlayerAnimationState.StandingRight;
            PreviousAnimationState = PlayerAnimationState.StandingRight;
            PhysicsBody = new Body(position, 95, 86, 0, 100, .85f, this);
            PhysicsBody.reactsToCollision = false;

            DetectionPhysicsBodies = new List<Body>();

            Body leftDetectionBody = new Body(new Point(0, 0), (int)(25 * scale), (int)(140 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            leftDetectionBody.parentOffset = new Vector2(145, 35) * scale;
            leftDetectionBody.bodyType = BodyDetectionType.Left;
            DetectionPhysicsBodies.Add(leftDetectionBody);

            Body rightDetectionBody = new Body(new Point(0, 0), (int)(25 * scale), (int)(140 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            rightDetectionBody.parentOffset = new Vector2(170, 35) * scale;
            DetectionPhysicsBodies.Add(rightDetectionBody);
            rightDetectionBody.bodyType = BodyDetectionType.Right;

            Body topDetectionBody = new Body(new Point(0, 0), (int)(40 * scale), (int)(20 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            topDetectionBody.parentOffset = new Vector2(150, 25) * scale;
            topDetectionBody.bodyType = BodyDetectionType.Top;
            DetectionPhysicsBodies.Add(topDetectionBody);

            Body bottomDetectionBody = new Body(new Point(0, 0), (int)(40 * scale), (int)(20 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            bottomDetectionBody.parentOffset = new Vector2(150, 205) * scale;
            bottomDetectionBody.bodyType = BodyDetectionType.Bottom;
            DetectionPhysicsBodies.Add(bottomDetectionBody);
        }

        public void Update(GameTime time, PhysicsManager manager)
        {
            if (Health > 0)
            {
                GamePadState currentPadState = GamePad.GetState(PlayerNumber - 1);
                KeyboardState currentState = Keyboard.GetState();

                bool keyboardControlled = false;
                provideGravity(time, manager);

                if (Human)
                {
                    if (PlayerNumber == 1)
                    {
                        if (currentState.IsKeyDown(Keys.Enter) && !PreviousKeyState.IsKeyDown(Keys.Enter))
                        {
                            //TODO: attack animation state
                            AnimationState = PlayerAnimationState.WalkingRight;
                            keyboardControlled = true;
                            Attack();
                        }
                        else if (currentState.IsKeyDown(Keys.Right) || currentState.IsKeyDown(Keys.D))
                        {
                            moveRight();
                            keyboardControlled = true;
                        }
                        else if (currentState.IsKeyDown(Keys.Left) || currentState.IsKeyDown(Keys.A))
                        {
                            moveLeft();
                            keyboardControlled = true;
                        }
                        else
                        {
                            AnimationState = PlayerAnimationState.StandingRight;
                        }

                        if (currentState.IsKeyDown(Keys.Down) || currentState.IsKeyDown(Keys.S))
                        {
                            moveDown();
                            keyboardControlled = true;
                        }
                        else if (!jumping && currentState.IsKeyDown(Keys.Space))
                        {
                            jump();
                            keyboardControlled = true;
                        }
                    }

                    if (!keyboardControlled)
                    {
                        AnimationState = PlayerAnimationState.StandingRight;

                        if (currentPadState.Triggers.Right > 0 && !(PreviousPadState.Triggers.Right > 0))
                        {
                            //TODO: attack animation state
                            AnimationState = PlayerAnimationState.WalkingRight;
                            Attack();
                        }
                        else if (!jumping && currentPadState.Buttons.A == ButtonState.Pressed)
                        {
                            jump();
                        }
                        else if (currentPadState.DPad.Right == ButtonState.Pressed || currentPadState.ThumbSticks.Left.X > 0.0f)
                        {
                            moveRight();
                        }
                        else if (currentPadState.DPad.Left == ButtonState.Pressed || currentPadState.ThumbSticks.Left.X < 0.0f)
                        {
                            moveLeft();
                        }
                        else
                        {
                            AnimationState = PlayerAnimationState.StandingRight;
                        }
                    }

                    keyboardControlled = false;

                    PreviousPadState = currentPadState;
                    PreviousKeyState = currentState;
                }
                else
                {
                    processAI(time);
                }

                UpdateBodyPhysicsDetection();
                collisionDetection(manager);
            }
            else //Dead
            {
                Health = 100;
                PhysicsBody.Position = Level.PlayerSpawnPoints[rand.Next(0, Level.PlayerSpawnPoints.Count)].ToVector2();

                //remove 5 points for death
                Score -= 5;
            }
        }

        private void moveRight()
        {
            AnimationState = PlayerAnimationState.WalkingRight;
            PhysicsBody.AddVelocity(new Vector2(100 * SpeedBonus, 0));
        }

        private void moveLeft()
        {
            AnimationState = PlayerAnimationState.WalkingLeft;
            PhysicsBody.AddVelocity(new Vector2(-100 * SpeedBonus, 0));
        }

        private void moveDown()
        {
            AnimationState = PlayerAnimationState.StandingRight;
            PhysicsBody.AddVelocity(new Vector2(0, 100 * SpeedBonus));
        }

        private void jump()
        {
            AnimationState = PlayerAnimationState.StandingRight;
            PhysicsBody.AddVelocity(new Vector2(0, jumpVelo));
            jumping = true;
        }

        private void processAI(GameTime time)
        {
            //get AI to move toward player walking

            int distance = 999999;

            //find the closest player
            if (Weapon != null)
            {

                Player target = null;
                //find the closest player
                foreach (Player enemy in Level.Players)
                {


                    if (enemy != this)
                    {
                        int enemydistance = (int)(enemy.PhysicsBody.Position - PhysicsBody.Position).Length();
                        if (enemydistance < distance)
                        {
                            distance = enemydistance;
                            target = enemy;
                        }
                    }
                }

                //figure out what level the target is on compared to player
                bool onLevel = Math.Abs(target.PhysicsBody.Position.Y - PhysicsBody.Position.Y) < 200;
                float waypointDistance;

                bool up = false;

                if (!onLevel)
                {
                    Waypoint point = null;
                    if (target != null && target.PhysicsBody.Position.Y < PhysicsBody.Position.Y)
                    {
                        //it is up
                        waypointDistance = 99999999;
                        up = true;
                        foreach (Waypoint waypoint in Game1.Level.Waypoints)
                        {
                            if (waypoint.Up)
                            {
                                onLevel = Math.Abs(waypoint.Location.Y - PhysicsBody.Position.Y) > 180;
                                if (onLevel && (waypoint.Location - PhysicsBody.Position).Length() < waypointDistance)
                                {
                                    point = waypoint;
                                    waypointDistance = (waypoint.Location - PhysicsBody.Position).Length();
                                }
                            }
                        }
                    }
                    else
                    {
                        //it is down
                        waypointDistance = 99999999;

                        foreach (Waypoint waypoint in Game1.Level.Waypoints)
                        {
                            if (!waypoint.Up)
                                onLevel = Math.Abs(waypoint.Location.Y - PhysicsBody.Position.Y) < 180;
                            if (onLevel && (waypoint.Location - PhysicsBody.Position).Length() < waypointDistance)
                            {
                                point = waypoint;
                                waypointDistance = (waypoint.Location - PhysicsBody.Position).Length();
                            }
                        }
                    }

                    bool Left = false;

                    if (point != null)
                    {

                        if (waypointDistance > 250)
                        {
                            //find enemy direction
                            if (point.Location.X - 50 < PhysicsBody.Position.X)
                            {
                                Left = true;
                            }

                            if (this.PhysicsBody.Position.X > point.Location.X - 10 && this.PhysicsBody.Position.X > point.Location.X + 10)
                            {
                                jump();
                            }

                            //we have the enemy that is closest so walk to him
                            if (!Left)
                            {
                                moveRight();
                            }
                            else if (Left)
                            {
                                moveLeft();
                            }
                        }
                        else
                        {
                            if (up)
                            {
                                //jump
                                jump();
                            }
                        }
                    }
                }
                else
                {
                    //needs to match weapon distance
                    if (Weapon == null || distance > Weapon.AttackDistance)
                    {
                        bool Left = false;
                        //find enemy direction
                        if (target.PhysicsBody.Position.X < PhysicsBody.Position.X)
                        {
                            Left = true;
                        }

                        //we have the enemy that is closest so walk to him
                        if (!Left)
                        {
                            moveRight();
                        }
                        else if (Left)
                        {
                            moveLeft();
                        }
                    }
                    else
                    {
                        if ((time.TotalGameTime - AILastAttack).Milliseconds >= SecBetweenAttack)
                        {
                            AILastAttack = time.TotalGameTime;
                            Attack();
                        }
                    }
                }
            }
            else //need a weapon
            {
                Weapon target = null;
                bool foundOnLevel = false;
                bool onLevel;
                //find the closest player
                foreach (Weapon weapon in Game1.Level.Weapons)
                {
                    int Weapondistance = (int)((weapon.PhysicsBody.Position - new Vector2(50, 50)) - PhysicsBody.Position).Length();
                    onLevel = Math.Abs(weapon.PhysicsBody.Position.Y - PhysicsBody.Position.Y) < 250;
                    if (Weapondistance < distance && (!foundOnLevel || (foundOnLevel == onLevel)))
                    {
                        if (Math.Abs(weapon.PhysicsBody.Position.Y - PhysicsBody.Position.Y) < 250)
                        {
                            foundOnLevel = true;
                            distance = Weapondistance;
                            target = weapon;
                        }
                        else if (!foundOnLevel)
                        {
                            distance = Weapondistance;
                            target = weapon;
                        }
                    }
                }

                //figure out what level the target is on compared to player
                if (target != null)
                {
                    onLevel = Math.Abs(target.PhysicsBody.Position.Y - PhysicsBody.Position.Y) < 200;
                }
                else
                {
                    onLevel = false;
                }

                float waypointDistance = 0;

                if (!onLevel)
                {
                    Waypoint point = null;
                    if (target != null && target.PhysicsBody.Position.Y < PhysicsBody.Position.Y)
                    {
                        //it is up
                        waypointDistance = 99999999;

                        foreach (Waypoint waypoint in Game1.Level.Waypoints)
                        {
                            if ((waypoint.Location - PhysicsBody.Position).Length() < waypointDistance)
                            {
                                point = waypoint;
                                waypointDistance = (waypoint.Location - PhysicsBody.Position).Length();
                            }
                        }
                    }
                    else
                    {
                        //it is down
                        waypointDistance = 99999999;

                        foreach (Waypoint waypoint in Game1.Level.Waypoints)
                        {
                            if ((waypoint.Location - PhysicsBody.Position).Length() < waypointDistance)
                            {
                                point = waypoint;
                                waypointDistance = (waypoint.Location - PhysicsBody.Position).Length();
                            }
                        }
                    }

                    bool Left = false;

                    if (point != null)
                    {
                        if (waypointDistance > 10)
                        {
                            //find enemy direction
                            if (point.Location.X - 50 < PhysicsBody.Position.X)
                            {
                                Left = true;
                            }

                            //we have the enemy that is closest so walk to him
                            if (!Left)
                            {
                                moveRight();
                            }
                            else if (Left)
                            {
                                moveLeft();
                            }
                        }
                        else
                        {
                            jump();
                        }
                    }
                }
                else
                {
                    bool Left = false;
                    //find enemy direction
                    if (target != null && target.PhysicsBody.Position.X - 50 < PhysicsBody.Position.X)
                    {
                        Left = true;
                    }

                    //we have the enemy that is closest so walk to him
                    if (!Left)
                    {
                        moveRight();
                    }
                    else if (Left)
                    {
                        moveLeft();
                    }
                }
            }
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            //WalkingWithSwordLeft, WalkingWithSwordRight, WalkingWithTridentLeft, WalkingWithTridentRight,
            if (AnimationState == PlayerAnimationState.WalkingRight)
            {
                Animations.PlayerWalk.NextFrame(time);
                batch.Draw(Animations.PlayerWalk.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.WalkingLeft)
            {
                Animations.PlayerWalk.NextFrame(time);
                batch.Draw(Animations.PlayerWalk.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (AnimationState == PlayerAnimationState.StandingWithSwordRight)
            {
                Animations.StandingWithSword.NextFrame(time);
                batch.Draw(Animations.StandingWithSword.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.StandingWithSwordLeft)
            {
                Animations.StandingWithSword.NextFrame(time);
                batch.Draw(Animations.StandingWithSword.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (AnimationState == PlayerAnimationState.StandingWithTridentRight)
            {
                Animations.StandingWithTrident.NextFrame(time);
                batch.Draw(Animations.StandingWithTrident.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.StandingWithTridentLeft)
            {
                Animations.StandingWithTrident.NextFrame(time);
                batch.Draw(Animations.StandingWithTrident.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (AnimationState == PlayerAnimationState.AttackingWithSwordRight)
            {
                Animations.AttackingWithSword.NextFrame(time);
                batch.Draw(Animations.AttackingWithSword.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.AttackingWithSwordLeft)
            {
                Animations.AttackingWithSword.NextFrame(time);
                batch.Draw(Animations.AttackingWithSword.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (AnimationState == PlayerAnimationState.AttackingWithTridentRight)
            {
                Animations.AttackingWithTrident.NextFrame(time);
                batch.Draw(Animations.AttackingWithTrident.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.AttackingWithTridentLeft)
            {
                Animations.AttackingWithTrident.NextFrame(time);
                batch.Draw(Animations.AttackingWithTrident.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (AnimationState == PlayerAnimationState.WalkingWithSwordRight)
            {
                Animations.WalkingWithSword.NextFrame(time);
                batch.Draw(Animations.WalkingWithSword.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.WalkingWithSwordLeft)
            {
                Animations.WalkingWithSword.NextFrame(time);
                batch.Draw(Animations.WalkingWithSword.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (AnimationState == PlayerAnimationState.WalkingWithTridentRight)
            {
                Animations.WalkingWithTrident.NextFrame(time);
                batch.Draw(Animations.WalkingWithTrident.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.WalkingWithTridentLeft)
            {
                Animations.WalkingWithTrident.NextFrame(time);
                batch.Draw(Animations.WalkingWithTrident.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (PreviousAnimationState == PlayerAnimationState.WalkingLeft || PreviousAnimationState == PlayerAnimationState.StandingLeft)
            {
                Animations.PlayerIdel.NextFrame(time);
                batch.Draw(Animations.PlayerIdel.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
                AnimationState = PlayerAnimationState.StandingLeft;
            }
            else
            {
                Animations.PlayerIdel.NextFrame(time);
                batch.Draw(Animations.PlayerIdel.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }

            PreviousAnimationState = AnimationState;
        }

        public void Attack()
        {
            foreach (Player player in Level.Players)
            {
                if (player != this && (Weapon == null || (PhysicsBody.Position - player.PhysicsBody.Position).Length() <= Weapon.AttackDistance))
                {
                    //hit
                    if (Weapon != null)
                    {
                        player.Health = player.Health - Weapon.Damage;
                    }
                    else if ((PhysicsBody.Position - player.PhysicsBody.Position).Length() <= 10)
                    {
                        player.Health = player.Health - 1;
                    }

                    Vector2 initialVelocity = new Vector2(rand.Next(-100, 100), rand.Next(-100, 100));
                    float currentRotation = 0;
                    Matrix rotation;
                    Point location = new Point(rand.Next(player.DetectionPhysicsBodies[0].MotionPhysicsBody.Left, player.DetectionPhysicsBodies[0].MotionPhysicsBody.Right),
                           rand.Next(player.DetectionPhysicsBodies[0].MotionPhysicsBody.Top, player.DetectionPhysicsBodies[0].MotionPhysicsBody.Bottom));


                    //score crap
                    if (player.Health <= 0)
                    {
                        Score += 10; //add 10 points you murdered him
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        rotation = Matrix.CreateRotationZ(currentRotation);
                        Particle particle = new Particle(location, .5f, Textures.bloodParticle, Vector2.Transform(initialVelocity, rotation));
                        Level.Particles.Add(particle);
                        currentRotation += .15f;
                    }
                }
            }
        }

        public void provideGravity(GameTime time, PhysicsManager manager)
        {
            PhysicsBody.AddVelocity(new Vector2(0, gravityVelo));
        }

        public void UpdateBodyPhysicsDetection()
        {
            foreach (Body body in DetectionPhysicsBodies)
            {
                body.MotionPhysicsBody = new Rectangle((int)(PhysicsBody.Position.X + body.parentOffset.X),
                    (int)(PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height);
            }
        }

        private void collisionDetection(PhysicsManager manager)
        {
            //detect collisions
            foreach (Body body in DetectionPhysicsBodies)
            {
                foreach (Body body2 in manager.GetBodies())
                {
                    if (body != body2 && body.MotionPhysicsBody.Intersects(body2.MotionPhysicsBody)
                        && (body.reactsToCollision && body2.reactsToCollision))
                    {
                        if (body.objRef is Player && body2.objRef is PowerUp)
                        {
                            ((PowerUp)body2.objRef).OnPickup((Player)body.objRef);
                        }
                        else if (body.objRef is PowerUp && body2.objRef is Player)
                        {
                            ((PowerUp)body.objRef).OnPickup((Player)body2.objRef);
                        }
                        else if (body.objRef is Player && body2.objRef is Weapon)
                        {
                            if (((Player)body.objRef).Weapon == null)
                            {
                                ((Weapon)body2.objRef).OnPickUp((Player)body.objRef);
                            }
                        }
                        else if (body.objRef is Weapon && body2.objRef is Player)
                        {
                            if (((Player)body.objRef).Weapon == null)
                            {
                                ((Weapon)body.objRef).OnPickUp((Player)body2.objRef);
                            }
                        }
                        else
                        {
                            switch (body.bodyType)
                            {
                                case BodyDetectionType.Left:
                                    {
                                        if (PhysicsBody.Velocity.X < 0)
                                        {
                                            PhysicsBody.Velocity.X = 0;
                                        }
                                        break;
                                    }
                                case BodyDetectionType.Right:
                                    {
                                        if (PhysicsBody.Velocity.X > 0)
                                        {
                                            PhysicsBody.Velocity.X = 0;
                                        }
                                        break;
                                    }
                                case BodyDetectionType.Top:
                                    {
                                        if (PhysicsBody.Velocity.Y < 0)
                                        {
                                            PhysicsBody.Velocity.Y = 0;
                                        }
                                        break;
                                    }
                                case BodyDetectionType.Bottom:
                                    {
                                        if (PhysicsBody.Velocity.Y > 0)
                                        {
                                            PhysicsBody.Velocity.Y = 0;
                                            jumping = false;
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
        }
    }
}
