using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Media
{
    public class Audio
    {
        public static void Load(ContentManager cm)
        {
            Damage = cm.Load<SoundEffect>("Sounds/Generic_Cowboy_Hurt");
        }

        public static SoundEffect Damage;


    }
}
