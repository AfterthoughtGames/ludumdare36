using GameyMickGameFace.AI;
using GameyMickGameFace.GameObjects.PowerUps;
using GameyMickGameFace.GameObjects.Weapons;
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

        public List<Weapon> Weapons;
        public List<PowerUp> PowerUps;
        public List<Waypoint> Waypoints;

        private DateTime StartTime;
        public TimeSpan TimeSpent;

        public Random rand = new Random();

        public Level(PhysicsManager physicsManager)
        {
            Weapons = new List<Weapon>();
            PowerUps = new List<PowerUp>();

            Player1 = new Player(rand.Next());
            Player1.PlayerNumber = 1;
            Player1.Health = 100;
            Player1.Human = true;
            Game1.Players.Add(Player1);
            physicsManager.AddBody(Player1.PhysicsBody);
            Player2 = new Player(rand.Next());
            Player2.PlayerNumber = 2;
            Player2.Health = 100;
            Game1.Players.Add(Player2);
            physicsManager.AddBody(Player2.PhysicsBody);
            Player3 = new Player(rand.Next());
            Player3.PlayerNumber = 3;
            Player3.Health = 100;
            Game1.Players.Add(Player3);
            physicsManager.AddBody(Player3.PhysicsBody);
            Player4 = new Player(rand.Next());
            Player4.PlayerNumber = 4;
            Player4.Health = 100;
            Game1.Players.Add(Player4);
            physicsManager.AddBody(Player4.PhysicsBody);

            HealthPowerUp Health = new HealthPowerUp(Media.Textures.healthTexture, Media.Animations.PotionSmoke, new Point(550, 150));
            physicsManager.AddBody(Health.PhysicsBody);
            PowerUps.Add(Health);

            Sword Sword = new Sword(Media.Textures.SwordTexture, rand.Next());
            physicsManager.AddBody(Sword.PhysicsBody);
            Weapons.Add(Sword);

            Trident Trident = new Trident(Media.Textures.TridentTexture, rand.Next());
            physicsManager.AddBody(Trident.PhysicsBody);
            Weapons.Add(Trident);

            Bow Bow = new Bow(Media.Textures.BowTexture, rand.Next());
            physicsManager.AddBody(Bow.PhysicsBody);
            Weapons.Add(Bow);

            addWaypoints();
        }

        public void Update(GameTime gameTime, PhysicsManager physicsManager)
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
                }
            }

            foreach (PowerUp PowerUp in PowerUps)
            {
                PowerUp.Update(gameTime);

                if (PowerUp.cleanMeUpBitches)
                {
                    PowerUps.Remove(PowerUp);
                }
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

            foreach(Waypoint waypoint in Waypoints)
            {
                waypoint.Draw(spriteBatch);
            }

            string str = "OST Games: Ludum Dare 36";
            Vector2 strSize = Media.Fonts.GUI.MeasureString(str);
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
