using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.GameObjects
{
    public class PowerUp
    {
        public string Name { get; set; }
        public Texture2D Image { get; set; }

        public void OnPickup(Player effectedPlayer)
        {

        }
    }
}
