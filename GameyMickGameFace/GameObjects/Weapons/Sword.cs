using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.Weapons
{
    class Sword : Weapon
    {
        public Sword(Texture2D texture, Point position) : base(texture, position)
        {
            Damage = 6;
            weaponType = WeaponType.Slashing;
            WeaponName = "Sword";
        }
    }
}
