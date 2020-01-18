using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFormsFirstProject
{
    public class Tab
    {
        public Sprite[,] Grid { get; set; } = new Sprite[6, 3]; 
        
        [JsonIgnore]
        public SpriteFont SpriteFont { get; set; }
        public CurrentMovingImageInfo NewImageInfo { get; set; }
        public Vector2 StartPosition { get; set; }
        public int Offset { get; } = 5;

        public int count = 0;
    }
}
