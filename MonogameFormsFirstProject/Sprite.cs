using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFormsFirstProject
{
    public class Sprite
    {
        [JsonIgnore]
        public Texture2D Texture { get; set; }

        public Color[] TextureData { get; set; }
        
        [JsonProperty("Position")]
        private Vector2 position;

        [JsonIgnore]
        public ref Vector2 Position
        {
            get
            {
                return ref position;
            }
        }
        public Color Color { get; set; }

        [JsonProperty("Scale")]
        private Vector2 scale;

        [JsonIgnore]
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

        public bool isSetImage { get; set; } = false;

        [JsonIgnore]
        public Dictionary<Keys, Action<GameTime>> Movements; 
        public Sprite(Texture2D texture, Vector2 position, Color color, Vector2 scale)
        {
            Texture = texture;
            Position = position;
            Color = color;
            Scale = scale;

            SourceRectangle = null;

            Movements = new Dictionary<Keys, Action<GameTime>>()
            {
                [Keys.W] = (g) => Position.Y--,
                [Keys.S] = (g) => Position.Y++,
                [Keys.A] = (g) => Position.X--,
                [Keys.D] = (g) => Position.X++
            };
        }

        public void SetTextureData()
        {
            TextureData = new Color[Form1.SquareSize * Form1.SquareSize];
            Texture.GetData(TextureData);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            var pressedKeys = keyboard.GetPressedKeys();
           
            foreach(var key in pressedKeys)
            {
                if (!Movements.ContainsKey(key)) continue;

                Movements[key](gameTime);
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Position, SourceRectangle, Color, 0f, Origin, Scale, SpriteEffects.None, 1f);
        }

        public void Draw(SpriteBatch sb, Texture2D pixel)
        {
            sb.Draw(Texture, Position, null, Color, 0f, Origin, Scale, SpriteEffects.None, 1f);

            if(HitBox.Y < 0)
            {

            }
            sb.Draw(pixel, HitBox, Color.Red);
        }
    }
}
