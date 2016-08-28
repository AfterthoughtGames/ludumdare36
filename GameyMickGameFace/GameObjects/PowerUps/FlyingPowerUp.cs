using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameyMickGameFace.GameObjects.PowerUps
{
    class FlyingPowerUp : PowerUp
    {
        Texture2D flyingTexture;

        public FlyingPowerUp(Texture2D flyingTexture, Point position)
            : base(flyingTexture, position)
        {
            Name = "Flying";
            scale = .50f;
            this.flyingTexture = flyingTexture;
        }

        public override void OnPickup(Player effectedPlayer)
        {
            base.OnPickup(effectedPlayer);
        }

        public override void Draw(GameTime time, SpriteBatch batch)
        {
            base.Draw(time, batch);

            Vector2 animationScale = new Vector2(.18f);
            Vector2 pos = new Vector2(position.X, position.Y - 22);
            batch.Draw(flyingTexture, pos, null, null, null, default(float), animationScale);
        }

        public override void Update(GameTime time)
        {
            base.Update(time);

        }
    }
}
