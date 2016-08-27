using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Media
{
    public class Fonts
    {
        public static void Load(ContentManager contentLoader)
        {
            GUI = contentLoader.Load<SpriteFont>("GUIFont");
        }

        public static SpriteFont GUI { get; set; }
    }
}
