using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.Weapons
{
    class Trident : Weapon
    {
        public Trident(Texture2D texture, Point position) : base(texture, position)
        {
            Damage = 5;
            weaponType = WeaponType.Stabbing;
            WeaponName = "Trident";
        }
    }
}
