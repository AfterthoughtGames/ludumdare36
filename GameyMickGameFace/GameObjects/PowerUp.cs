using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.GameObjects
{
    public class PowerUp
    {
        public string Name { get; set; }
        public Texture2D Image { get; set; }
        public Body PhysicsBody { get; set; }

        public PowerUp()
        {
            PhysicsBody = new Body(new Point(100, 100), 95, 86, 0, 100, .85f);
        }

        public void OnPickup(Player effectedPlayer)
        {

        }

        public void draw(GameTime time, SpriteBatch batch)
        {

        }

        public void update(GameTime time)
        {

        }
    }
}
