using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFormsFirstProject
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }

        private Vector2 position;
        public ref Vector2 Position
        {
            get
            {
                return ref position;
            }
        }
        public Color Color { get; set; }

        private Vector2 scale;
        public ref Vector2 Scale
        {
            get
            {
                return ref scale;
            }
        }
        public Vector2 Origin
        {
            get
            {
                return new Vector2(ScaledWidth / 2, ScaledHeight / 2);
            }
        }

        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)(Position.X - Origin.X), (int)(Position.Y - Origin.Y), (int)(Texture.Width * Scale.X), (int)(Texture.Height * Scale.Y));
            }
        }

        public Rectangle? SourceRectangle { get; set; }

        public int ScaledWidth
        {
            get
            {
                return (int)(Texture.Width * Scale.X);
            }
        }

        public int ScaledHeight
        {
            get
            {
                return (int)(Texture.Height * Scale.Y);
            }
        }
    
        public Sprite(Texture2D texture, Vector2 position, Color color, Vector2 scale)
        {
            Texture = texture;
            Position = position;
            Color = color;
            Scale = scale;

          
         
            SourceRectangle = null;
        }

        public void Draw(SpriteBatch sb)
        {
               
            sb.Draw(Texture, Position, SourceRectangle, Color, 0f, Origin, Scale, SpriteEffects.None, 0f);
        }

        public void Draw(SpriteBatch sb, Texture2D pixel)
        {
            sb.Draw(Texture, Position, null, Color, 0f, Origin, Scale, SpriteEffects.None, 0f);

            if(HitBox.Y < 0)
            {

            }
            sb.Draw(pixel, HitBox, Color.Red);
        }
    }
}
