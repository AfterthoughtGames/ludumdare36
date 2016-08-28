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

        public PowerUp(Texture2D texture, Point position)
        {
            cleanMeUpBitches = false;
            scale = .25f;
            this.texture = texture;
            this.position = position;
            PhysicsBody = new Body(position, Convert.ToInt16(texture.Width * scale), Convert.ToInt16(texture.Height * scale), 0, 100, .85f, this);
        }

        public virtual void OnPickup(Player effectedPlayer)
        {
            cleanMeUpBitches = true;
        }

<<<<<<< eb5679f6af6838d240b6e5a5b0f10a89efad4567
        public virtual void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(texture, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        }

        public virtual void Update(GameTime time)
        {
=======
        public virtual void Draw(GameTime time, SpriteBatch batch, GameStates gameState)
        {
            if (gameState == GameStates.Title)
            {
                return;
            }

            batch.Draw(texture, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        }

        public virtual void Update(GameTime time, GameStates gameState)
        {
            if (gameState == GameStates.Title)
            {
                return;
            }
>>>>>>> added new powerup stuff and modified other powerup stuff
        }
    }
}
