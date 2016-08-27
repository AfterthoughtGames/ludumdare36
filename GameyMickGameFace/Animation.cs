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

        public Texture2D Frame
        {
            get
            {
                return Frames[FrameIndex];
            }
        }

        public Animation()
        {
            Frames = new List<Texture2D>();
        }

        public void AddTexture(Texture2D textureToAdd)
        {
            Frames.Add(textureToAdd);
        }

        public void NextFrame()
        {
            if (FrameIndex >= Frames.Count)
            {
                FrameIndex = 0;
            }
            else
            {
                FrameIndex++;
            }
        }

        public void RemoveFrame(int index)
        {
            Frames.RemoveAt(index);
        }


    }
}
