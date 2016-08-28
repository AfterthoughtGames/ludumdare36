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

        public FlyingPowerUp(Texture2D flyingTexture, int seed)
            : base(flyingTexture, seed)
        {
            Name = "Flying";
            this.flyingTexture = flyingTexture;
        }

        public override void OnPickup(Player effectedPlayer)
        {
            base.OnPickup(effectedPlayer);
        }

        public override void Draw(GameTime time, SpriteBatch batch)
        {
            base.Draw(time, batch);
        }

        public override void Update(GameTime time)
        {
            base.Update(time);

        }
    }
}
