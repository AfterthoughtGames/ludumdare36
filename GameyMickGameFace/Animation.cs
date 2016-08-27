using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameyMickGameFace
{
    public class Animation
    {
        List<Texture2D> Frames { get; set; }
        int FrameIndex { get; set; }
        TimeSpan Rate { get; set; }
        TimeSpan LasstUpdate { get; set; }

        public Texture2D Frame
        {
            get
            {
                return Frames[FrameIndex];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate">Rate in milliseconds</param>
        public Animation(int rate)
        {
            Frames = new List<Texture2D>();
            Rate = new TimeSpan(0, 0, 0, 0, rate);
        }

        public void AddTexture(Texture2D textureToAdd)
        {
            Frames.Add(textureToAdd);
        }

        public void NextFrame(GameTime time)
        {
            if ((time.TotalGameTime - LasstUpdate) >= Rate)
            {
                LasstUpdate = time.TotalGameTime;

                if (FrameIndex >= Frames.Count - 1)
                {
                    FrameIndex = 0;
                }
                else
                {
                    FrameIndex++;
                }
            }
        }

        public void RemoveFrame(int index)
        {
            Frames.RemoveAt(index);
        }


    }
}
