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
        }

        public void Update(GameTime gameTime, PhysicsManager physicsManager)
        {
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
        }
    }
}
