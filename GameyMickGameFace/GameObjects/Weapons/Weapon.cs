using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameyMickGameFace.GameObjects
{
    public enum WeaponType
    {
        Ranged, Stabbing, Slashing
    }

    public class Weapon
    {
        public int Damage;
        public WeaponType weaponType { get; set; }
        public string WeaponName { get; set; }
        public Texture2D Texture { get; set; }
        public Body PhysicsBody { get; set; }
        public Point Position { get; set; }
        public float Scale { get; set; }
        public bool cleanMeUpBitches { get; set; }
        Random rand;

        public Weapon(Texture2D texture, int seed)
        {
            cleanMeUpBitches = false;
            rand = new Random(seed);
            Scale = 0.1f;
            Texture = texture;
            Position = Game1.PickupSpots[rand.Next(0, Game1.PickupSpots.Count)];
            Position = Position - new Point(0, (int)(Texture.Height * Scale));
            PhysicsBody = new Body(Position, Convert.ToInt16(texture.Width * Scale), Convert.ToInt16(texture.Height * Scale), 0, 100, .85f, this);
        }

        public virtual void OnPickUp(Player player)
        {
            player.Weapon = this;
            cleanMeUpBitches = true;
        }

        public virtual void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(Texture, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0.0f);
        }

        public virtual void Update(GameTime time)
        {
        }
    }
}