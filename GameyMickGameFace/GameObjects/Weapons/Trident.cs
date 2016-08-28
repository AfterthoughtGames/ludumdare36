using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.Weapons
{
    class Trident : Weapon
    {
        public Trident(Texture2D texture, int seed) : base(texture, seed)
        {
            Damage = 5;
            weaponType = WeaponType.Stabbing;
            WeaponName = "Trident";
            AttackDistance = 60;
        }
    }
}
