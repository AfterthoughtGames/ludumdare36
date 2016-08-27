using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.GameObjects
{
    public class Player
    {
        public int Heath { get; set; }
        public string Name { get; set; }
        public Vector2 Position { get; set; }

        public void Update(GameTime time)
        {

        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(Media.Textures.PlayerTemp, Position, Color.White);
        }
    }
}
