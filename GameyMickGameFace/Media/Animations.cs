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
            PotionSmoke = new Animation(50);

            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_000"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_001"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_002"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_003"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_004"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_005"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_006"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_007"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_008"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_009"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_010"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_011"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_012"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_013"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_014"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_015"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_016"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_017"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_018"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_019"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_020"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_021"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_022"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_023"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_024"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_025"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_026"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_027"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_028"));
            PlayerWalk.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_029"));

            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_000"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_001"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_002"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_003"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_004"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_005"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_006"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_007"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_008"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_009"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_010"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_011"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_012"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_013"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_014"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_015"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_016"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_017"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_018"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_019"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_020"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_021"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_022"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_023"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_024"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_025"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_026"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_027"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_028"));
            PlayerIdel.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_029"));

            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0000"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0006"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0012"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0018"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0024"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0030"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0036"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0042"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0048"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0054"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0060"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0066"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0072"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0078"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0084"));
            PotionSmoke.AddTexture(cm.Load<Texture2D>("Animations/Smoke_15/0090"));
        }

        public static Animation PlayerWalk { get; set; }
        public static Animation PlayerIdel { get; set; }
        public static Animation PotionSmoke { get; set; }
        public static Animation StandingWithSword { get; set; }
        public static Animation StandingWithTrident { get; set; }
        public static Animation AttackingWithSword { get; set; }
        public static Animation AttackingWithTrident { get; set; }
    }
}
