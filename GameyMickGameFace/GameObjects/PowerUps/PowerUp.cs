using System;
using System.Net.Mime;
using GameyMickGameFace.Media;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.PowerUps
{
    public class PowerUp
    {
        public string Name { get; set; }
        public Texture2D texture { get; set; }
        public Body PhysicsBody { get; set; }
        public Point position { get; set; }
        public float scale { get; set; }
        public bool cleanMeUpBitches { get; set; }
        Random rand;

        public PowerUp(Texture2D texture, int seed)
        {
            cleanMeUpBitches = false;
            if (texture.Name.Equals("Images/potionSmall"))
            {
                scale = .5f;
            }
            else if (texture.Name.Equals("Images/speedcrystals"))
            {
                scale = .1f;
            }
            else
            {
                scale = .1f;
            }

            rand = new Random(seed);
            this.texture = texture;
            position = Level.PickupSpots[rand.Next(0, Level.PickupSpots.Count)];
            position = position - new Point(0, (int)(this.texture.Height * scale));
            PhysicsBody = new Body(position, Convert.ToInt16(this.texture.Width * scale), Convert.ToInt16(this.texture.Height * scale), 0, 100, .85f, this);
        }

        public virtual void OnPickup(Player effectedPlayer)
        {
            cleanMeUpBitches = true;
        }

        public virtual void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(texture, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        }

        public virtual void Update(GameTime time)
        {
        }
    }
}
