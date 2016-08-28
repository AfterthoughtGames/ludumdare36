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
            SwordTexture = cm.Load<Texture2D>("Images/sword");
            TridentTexture = cm.Load<Texture2D>("Images/Trident");
            BowTexture = cm.Load<Texture2D>("Images/Bow");
            bloodParticle = cm.Load<Texture2D>("Images/BloodParticle");
            ScoreBoard = cm.Load<Texture2D>("Images/scoreboard");
            BackGround = cm.Load<Texture2D>("Images/woodenwallwithfloor");
            Platform1Texture = cm.Load<Texture2D>("Images/longshelf");
            Platform2Texture = cm.Load<Texture2D>("Images/mediumshelf");
            Platform3Texture = cm.Load<Texture2D>("Images/shortshelf");
            PhysicsBox = cm.Load<Texture2D>("Images/blacksquare");

            //powerup textures
            healthTexture = cm.Load<Texture2D>("Images/potionSmall");
            flyingTexture = cm.Load<Texture2D>("Images/speedcrystals");
        }

        public static Texture2D TitleScreen { get; set; }
        public static Texture2D SwordTexture { get; set; }
        public static Texture2D TridentTexture { get; set; }
        public static Texture2D BowTexture { get; set; }
        public static Texture2D bloodParticle { get; set; }
        public static Texture2D ScoreBoard { get; set; }
        public static Texture2D BackGround { get; set; }
        public static Texture2D Platform1Texture { get; set; }
        public static Texture2D Platform2Texture { get; set; }
        public static Texture2D Platform3Texture { get; set; }
        public static Texture2D PhysicsBox { get; set; }

        //powerups
        public static Texture2D healthTexture { get; set; }
        public static Texture2D flyingTexture { get; set; }

    }
}
