using GameyMickGameFace.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameyMickGameFace.AI
{
    public class Waypoint
    {

        public bool Up;
        public Vector2 Location;

        public Waypoint(Vector2 location, bool up)
        {
            Up = up;
            Location = location;
        }

        public void Draw(SpriteBatch batch)
        {
            if (Up)
            {
                batch.Draw(Textures.Waypoints, Location, null, Color.Blue, 0.0f, Vector2.Zero, 1, SpriteEffects.None, 0.0f);
            }
            else
            {
                batch.Draw(Textures.Waypoints, Location, null, Color.White, 0.0f, Vector2.Zero, 1, SpriteEffects.None, 0.0f);
            }
        }
    }
}
