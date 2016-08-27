using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameyMickGameFace.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.PowerUps
{
    class healthPowerUp : PowerUp
    {
        public int healthAmount { get; set; }

        public healthPowerUp(Texture2D healthTexture)
            : base(healthTexture)
        {
            healthAmount = 3;
            Name = "Health";
        }

        public override void OnPickup(Player effectedPlayer)
        {
            base.OnPickup(effectedPlayer);
            effectedPlayer.Health += healthAmount;
        }
    }
}
