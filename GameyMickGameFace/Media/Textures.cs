using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Media
{
    public class Textures
    {
        public static void Load(ContentManager cm)
        {
            TitleScreen = cm.Load<Texture2D>("Images/Title");
        }

        public static Texture2D PlayerTemp { get; set; }
        public static Texture2D TitleScreen { get; set; }
    }
}
