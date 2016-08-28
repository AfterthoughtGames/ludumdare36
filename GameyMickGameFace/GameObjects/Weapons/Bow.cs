using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.Weapons
{
    class Bow : Weapon
    {
        public Bow(Texture2D texture, Point position) : base(texture, position)
        {
            Damage = 4;
            weaponType = WeaponType.Ranged;
            WeaponName = "Bow";
        }
    }
}
