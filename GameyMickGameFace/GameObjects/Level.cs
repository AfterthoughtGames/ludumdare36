using GameyMickGameFace.AI;
using GameyMickGameFace.GameObjects.PowerUps;
using GameyMickGameFace.GameObjects.Weapons;
using GameyMickGameFace.Particles;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameyMickGameFace.GameObjects
{
    public class Level
    {
        public Player Player1;
        public Player Player2;
        public Player Player3;
        public Player Player4;
        public static List<Particle> Particles = new List<Particle>();

        public static List<Player> Players = new List<Player>();
        public static List<Point> PlayerSpawnPoints = new List<Point>();
        public static List<Point> PickupSpots = new List<Point>();
        public List<Weapon> Weapons;
        public List<PowerUp> PowerUps;
        public List<Waypoint> Waypoints;

        private DateTime StartTime;
        public TimeSpan TimeSpent;
        double GameTimeSeconds = 60;//300;
        double TimeLeft;

        public Random rand = new Random();

        Tile LeftWall;
        Tile RightWall;
        Tile Ceiling;
        Tile Floor;
        Tile Platform1;
        Tile Platform2;
        Tile Platform3;

        int levelOne = 420;
        int levelTwo = 220;
        int levelFloor = 650;

        public static bool PhysicsDrawn = false;

        bool addPowerUps;

        PhysicsManager physicsManager = new PhysicsManager();

        public Level()
        {
            Weapons = new List<Weapon>();
            PowerUps = new List<PowerUp>();

            PlayerSpawnPoints.Add(new Point(100, 130));
            PlayerSpawnPoints.Add(new Point(800, 130));
            PlayerSpawnPoints.Add(new Point(100, 560));
            PlayerSpawnPoints.Add(new Point(800, 560));

            PickupSpots.Add(new Point(400, levelOne));
            PickupSpots.Add(new Point(890, levelOne));
            PickupSpots.Add(new Point(910, levelOne));
            PickupSpots.Add(new Point(740, levelOne));
            PickupSpots.Add(new Point(350, levelOne));
            PickupSpots.Add(new Point(450, levelOne));
            PickupSpots.Add(new Point(650, levelTwo));
            PickupSpots.Add(new Point(550, levelTwo));
            PickupSpots.Add(new Point(475, levelTwo));
            PickupSpots.Add(new Point(700, levelTwo));
            PickupSpots.Add(new Point(725, levelTwo));
            PickupSpots.Add(new Point(650, levelFloor));
            PickupSpots.Add(new Point(550, levelFloor));
            PickupSpots.Add(new Point(475, levelFloor));
            PickupSpots.Add(new Point(700, levelFloor));
            PickupSpots.Add(new Point(725, levelFloor));

            Player1 = new Player(rand.Next());
            Player1.PlayerNumber = 1;
            Player1.Health = 100;
            Player1.Human = true;
            Players.Add(Player1);
            physicsManager.AddBody(Player1.PhysicsBody);

            Player2 = new Player(rand.Next());
            Player2.PlayerNumber = 2;
            Player2.Health = 100;
            Players.Add(Player2);
            physicsManager.AddBody(Player2.PhysicsBody);

            Player3 = new Player(rand.Next());
            Player3.PlayerNumber = 3;
            Player3.Health = 100;
            Players.Add(Player3);
            physicsManager.AddBody(Player3.PhysicsBody);

            Player4 = new Player(rand.Next());
            Player4.PlayerNumber = 4;
            Player4.Health = 100;
            Players.Add(Player4);
            physicsManager.AddBody(Player4.PhysicsBody);

            Sword Sword = new Sword(Media.Textures.SwordTexture, rand.Next());
            physicsManager.AddBody(Sword.PhysicsBody);
            Weapons.Add(Sword);

            Trident Trident = new Trident(Media.Textures.TridentTexture, rand.Next());
            physicsManager.AddBody(Trident.PhysicsBody);
            Weapons.Add(Trident);

            Sword Sword2 = new Sword(Media.Textures.SwordTexture, rand.Next());
            physicsManager.AddBody(Sword2.PhysicsBody);
            Weapons.Add(Sword2);

            Trident Trident2 = new Trident(Media.Textures.TridentTexture, rand.Next());
            physicsManager.AddBody(Trident2.PhysicsBody);
            Weapons.Add(Trident2);

            Floor = new Tile(new Point(-100, levelFloor), 1800, 30, 0, 0);
            physicsManager.AddBody(Floor.Body);
            LeftWall = new Tile(new Point(-100, -100), 80, 1800, 0, 0);
            physicsManager.AddBody(LeftWall.Body);
            RightWall = new Tile(new Point(1300, -100), 30, 1800, 0, 0);
            physicsManager.AddBody(RightWall.Body);
            Ceiling = new Tile(new Point(-100, -20), 1800, 30, 0, 0);
            physicsManager.AddBody(Ceiling.Body);

            Platform1 = new Tile(new Point(150, levelTwo), Media.Textures.Platform1Texture.Width, Media.Textures.Platform1Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform1.Body);

            Platform2 = new Tile(new Point(50, levelOne), Media.Textures.Platform2Texture.Width, Media.Textures.Platform2Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform2.Body);

            Platform3 = new Tile(new Point(750, levelOne), Media.Textures.Platform3Texture.Width, Media.Textures.Platform3Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform3.Body);

            addWaypoints();
            addPowerUps = true;
        }

        public void Update(GameTime gameTime)
        {
            if (StartTime == new DateTime())
            {
                StartTime = DateTime.Now;
            }

            DateTime Now = DateTime.Now;
            TimeSpent = Now - StartTime;

            physicsManager.UpdatePhysics(gameTime);

            Player1.Update(gameTime, physicsManager);
            Player2.Update(gameTime, physicsManager);
            Player3.Update(gameTime, physicsManager);
            Player4.Update(gameTime, physicsManager);

            foreach (Weapon Weapon in Weapons)
            {
                Weapon.Update(gameTime);

                if (Weapon.cleanMeUpBitches)
                {
                    Weapons.Remove(Weapon);
                    physicsManager.RemoveBody(Weapon.PhysicsBody);
                    break;
                }
            }

            foreach (PowerUp PowerUp in PowerUps)
            {
                PowerUp.Update(gameTime);

                if (PowerUp.cleanMeUpBitches)
                {
                    PowerUps.Remove(PowerUp);
                    physicsManager.RemoveBody(PowerUp.PhysicsBody);
                    break;
                }
            }

            //update all blood particles
            for (int i = 0; i < Particles.Count; i++)
            {
                Particles[i].Update(gameTime, physicsManager);
            }

            if (TimeLeft % 30 == 0 && addPowerUps)
            {
                HealthPowerUp Health = new HealthPowerUp(Media.Textures.healthTexture, Media.Animations.PotionSmoke, rand.Next());
                physicsManager.AddBody(Health.PhysicsBody);
                PowerUps.Add(Health);


                FlyingPowerUp Flying = new FlyingPowerUp(Media.Textures.flyingTexture, rand.Next());
                physicsManager.AddBody(Flying.PhysicsBody);
                PowerUps.Add(Flying);

                addPowerUps = false;
            }
            else if (TimeLeft % 30 != 0)
            {
                addPowerUps = true;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Player1.Draw(gameTime, spriteBatch);
            Player2.Draw(gameTime, spriteBatch);
            Player3.Draw(gameTime, spriteBatch);
            Player4.Draw(gameTime, spriteBatch);

            foreach (Weapon Weapon in Weapons)
            {
                Weapon.Draw(gameTime, spriteBatch);
            }

            foreach (PowerUp PowerUp in PowerUps)
            {
                PowerUp.Draw(gameTime, spriteBatch);
            }

            spriteBatch.Draw(Media.Textures.BackGround, Vector2.Zero, Color.White);
            spriteBatch.Draw(Media.Textures.Platform1Texture, new Vector2(150, levelTwo), Color.White);
            spriteBatch.Draw(Media.Textures.Platform2Texture, new Vector2(50, levelOne), Color.White);
            spriteBatch.Draw(Media.Textures.Platform3Texture, new Vector2(750, levelOne), Color.White);

            TimeLeft = GameTimeSeconds - TimeSpent.Seconds - (TimeSpent.Minutes * 60);

            string str = "Time Left: " + (int)(TimeLeft / 60) + ":";
            if ((int)(TimeLeft % 60) < 10)
            {
                str = str + "0" + (int)(TimeLeft % 60);
            }
            else
            {
                str = str + (int)(TimeLeft % 60);
            }

            Vector2 strSize = Media.Fonts.GUI.MeasureString(str);
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(((spriteBatch.GraphicsDevice.Viewport.Width / 2) - strSize.X), 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            foreach (Waypoint waypoint in Waypoints)
            {
                waypoint.Draw(spriteBatch);
            }

            if (TimeLeft <= 0)
            {
                Game1.GameState = GameStates.EndGame;
            }

            Player1.Draw(gameTime, spriteBatch);
            Player2.Draw(gameTime, spriteBatch);
            Player3.Draw(gameTime, spriteBatch);
            Player4.Draw(gameTime, spriteBatch);

            foreach (Weapon Weapon in Weapons)
            {
                Weapon.Draw(gameTime, spriteBatch);
            }

            foreach (PowerUp PowerUp in PowerUps)
            {
                PowerUp.Draw(gameTime, spriteBatch);
            }

            str = "OST Games: Ludum Dare 36";
            strSize = Media.Fonts.GUI.MeasureString(str);
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(((spriteBatch.GraphicsDevice.Viewport.Width / 2) - strSize.X), spriteBatch.GraphicsDevice.Viewport.Height - 50), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Player 1: " + Player1.Health.ToString();
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Score:  " + Player1.Score.ToString();
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Player 2: " + Player2.Health.ToString();
            strSize = Media.Fonts.GUI.MeasureString(str);
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(spriteBatch.GraphicsDevice.Viewport.Width - strSize.X * 2.5f, 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Score:  " + Player2.Score.ToString();
            strSize = Media.Fonts.GUI.MeasureString(str);
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(spriteBatch.GraphicsDevice.Viewport.Width - strSize.X * 2.5f, 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Player 3: " + Player3.Health.ToString();
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, spriteBatch.GraphicsDevice.Viewport.Height - 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Score: " + Player3.Score.ToString();
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, spriteBatch.GraphicsDevice.Viewport.Height - 70), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Player 4: " + Player4.Health.ToString();
            strSize = Media.Fonts.GUI.MeasureString(str);
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(spriteBatch.GraphicsDevice.Viewport.Width - strSize.X * 2.5f, spriteBatch.GraphicsDevice.Viewport.Height - 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            str = "Score: " + Player4.Score.ToString();
            strSize = Media.Fonts.GUI.MeasureString(str);
            spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(spriteBatch.GraphicsDevice.Viewport.Width - strSize.X * 2.5f, spriteBatch.GraphicsDevice.Viewport.Height - 70), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

            if (PhysicsDrawn)
            {
                foreach (Body Body in physicsManager.GetBodies())
                {
                    if (Body.reactsToCollision)
                    {
                        spriteBatch.Draw(Media.Textures.PhysicsBox, new Rectangle((int)Body.Position.X, (int)Body.Position.Y, Body.width, Body.height), Color.White);
                    }
                }

                foreach (Body body in Player1.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(Media.Textures.PhysicsBox, new Rectangle((int)(Player1.PhysicsBody.Position.X + body.parentOffset.X),
                        (int)(Player1.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }

                foreach (Body body in Player2.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(Media.Textures.PhysicsBox, new Rectangle((int)(Player2.PhysicsBody.Position.X + body.parentOffset.X),
                        (int)(Player2.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }

                foreach (Body body in Player3.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(Media.Textures.PhysicsBox, new Rectangle((int)(Player3.PhysicsBody.Position.X + body.parentOffset.X),
                        (int)(Player3.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }

                foreach (Body body in Player4.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(Media.Textures.PhysicsBox, new Rectangle((int)(Player4.PhysicsBody.Position.X + body.parentOffset.X),
                        (int)(Player4.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }
            }

            foreach (Particle particle in Particles)
            {
                particle.Draw(gameTime, spriteBatch);
            }
        }

        private void addWaypoints()
        {
            Waypoints = new List<Waypoint>();

            //top level downs
            Waypoints.Add(new Waypoint(new Vector2(100, 150), false));
            Waypoints.Add(new Waypoint(new Vector2(1020, 150), false));
            //middle level downs
            Waypoints.Add(new Waypoint(new Vector2(0, 350), false));
            Waypoints.Add(new Waypoint(new Vector2(1220, 350), false));
            Waypoints.Add(new Waypoint(new Vector2(670, 350), false));
        }
    }
}
