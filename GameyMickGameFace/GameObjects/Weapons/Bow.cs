using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.Weapons
{
    class Bow : Weapon
    {
        public Bow(Texture2D texture, int seed) : base(texture, seed)
        {
            Damage = 4;
            weaponType = WeaponType.Ranged;
            WeaponName = "Bow";
        }
    }
}
