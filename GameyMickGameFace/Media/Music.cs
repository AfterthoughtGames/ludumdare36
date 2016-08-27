using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Media
{
    public class Music
    {
        public static void Load(ContentManager cm)
        {
            Music1 = cm.Load<Song>("Music/AncientAnimals");
        }

        public static Song Music1;
    }
}
