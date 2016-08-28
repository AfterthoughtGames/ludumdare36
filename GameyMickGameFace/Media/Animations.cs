using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.Media
{
    public class Animations
    {
        public static void Load(ContentManager cm)
        {
             PlayerWalk = new Animation(50);
             PlayerIdel = new Animation(10);
            PotionSmoke = new Animation( 50 );


             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_000"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_001"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_002"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_003"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_004"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_005"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_006"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_007"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_008"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_009"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_010"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_011"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_012"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_013"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_014"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_015"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_016"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_017"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_018"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_019"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_020"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_021"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_022"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_023"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_024"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_025"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_026"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_027"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_028"));
             PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_EmptyHands_029"));

             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_000"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_001"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_002"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_003"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_004"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_005"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_006"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_007"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_008"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_009"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_010"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_011"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_012"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_013"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_014"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_015"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_016"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_017"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_018"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_019"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_020"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_021"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_022"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_023"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_024"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_025"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_026"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_027"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_028"));
             PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_EmptyHands_029"));

            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0000" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0006" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0012" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0018" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0024" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0030" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0036" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0042" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0048" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0054" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0060" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0066" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0072" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0078" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0084" ) );
            PotionSmoke.AddTexture( cm.Load<Texture2D>( "Animations/Smoke_15/0090" ) );
        }

        public static Animation PlayerWalk { get; set; }
        public static Animation PlayerIdel { get; set; }
        public static Animation PotionSmoke { get; set; }
    }
}
