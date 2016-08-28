using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.Media
{
    public class Animations
    {
        public static void Load(ContentManager cm)
        {
            PlayerWalk = new Animation(30);
            PlayerIdel = new Animation(10);
            PotionSmoke = new Animation(30);
            StandingWithSword = new Animation(30);
            StandingWithTrident = new Animation(30);
            AttackingWithSword = new Animation(30);
            AttackingWithTrident = new Animation(30);
            WalkingWithSword = new Animation(30);
            WalkingWithTrident = new Animation(30);

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

            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_000"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_001"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_002"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_003"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_004"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_005"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_006"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_007"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_008"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_009"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_010"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_011"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_012"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_013"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_014"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_015"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_016"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_017"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_018"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_019"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_020"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_021"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_022"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_023"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_024"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_025"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_026"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_027"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_028"));
            StandingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Swords_029"));

            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_000"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_001"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_002"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_003"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_004"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_005"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_006"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_007"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_008"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_009"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_010"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_011"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_012"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_013"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_014"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_015"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_016"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_017"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_018"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_019"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_020"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_021"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_022"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_023"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_024"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_025"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_026"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_027"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_028"));
            StandingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Idle_Trident_029"));

            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_000"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_001"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_002"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_003"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_004"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_005"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_006"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_007"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_008"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_009"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_010"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_011"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_012"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_013"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_014"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_015"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_016"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_017"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_018"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_019"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_020"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_021"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_022"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_023"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_024"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_025"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_026"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_027"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_028"));
            WalkingWithSword.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Sword_029"));

            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_000"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_001"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_002"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_003"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_004"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_005"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_006"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_007"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_008"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_009"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_010"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_011"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_012"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_013"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_014"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_015"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_016"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_017"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_018"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_019"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_020"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_021"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_022"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_023"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_024"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_025"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_026"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_027"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_028"));
            WalkingWithTrident.AddTexture(cm.Load<Texture2D>("Characters/OtterFrames/Otter_Otter_Walking_Trident_029"));

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
        public static Animation WalkingWithSword { get; set; }
        public static Animation WalkingWithTrident { get; set; }
    }
}
