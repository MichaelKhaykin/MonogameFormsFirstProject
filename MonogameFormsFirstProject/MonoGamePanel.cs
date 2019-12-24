using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonogameFormsFirstProject
{
    public class MonoGamePanel : MonoGameControl
    {
        public Sprite[,] Grid = new Sprite[6, 3];
        SpriteFont spriteFont;

        Texture2D pixel;
        public CurrentMovingImageInfo NewImageInfo { get; set; }

        public Vector2 StartPosition { get; set; }

        public int SquareSize = 94;

        int count = 0;
        protected override void Initialize()
        {
            base.Initialize();
            LoadContent();

        }

        private void LoadContent()
        {

            Clipboard.Clear();

            NewImageInfo = new CurrentMovingImageInfo();

            var Content = Editor.Content;

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Microsoft.Xna.Framework.Color.White });

            var gridItemTexture = Content.Load<Texture2D>("SquareAddIcon-01");

            StartPosition = new Vector2(300, gridItemTexture.Height);

            for(int i = 0; i < Grid.GetLength(0); i++)
            {
                for(int j = 0; j < Grid.GetLength(1); j++)
                {
                    var newCalculatedPosition = new Vector2(StartPosition.X + j * gridItemTexture.Width + j * 5, StartPosition.Y + i * gridItemTexture.Height + i * 5);
                    Grid[i, j] = new Sprite(gridItemTexture, newCalculatedPosition, Microsoft.Xna.Framework.Color.White, Vector2.One);
                }
            }

          
          
            spriteFont = Content.Load<SpriteFont>("Font");
        }

        public (bool, int, int) DoesHitBoxContainMouse()
        {
            count++;
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (Grid[i, j].HitBox.Contains(Editor.GetRelativeMousePosition.X, Editor.GetRelativeMousePosition.Y))
                    {
                        return (true, i, j);
                    }
                }
            }
            return (false, 0, 0);
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(NewImageInfo.DataToSet != null && NewImageInfo.currentImageToMove == null)
            {
                var newTexture = new Texture2D(GraphicsDevice, NewImageInfo.Width, NewImageInfo.Height);
                newTexture.SetData(NewImageInfo.DataToSet);
                NewImageInfo.currentImageToMove = new Sprite(newTexture, new Vector2(1000, NewImageInfo.Height / 2), Microsoft.Xna.Framework.Color.White, Vector2.One);
            }
        }

        protected override void Draw()
        {

            base.Draw();
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.White);

            Editor.spriteBatch.Begin();

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j].Draw(Editor.spriteBatch);
                }
            }

            if(NewImageInfo.currentImageToMove != null)
            {
                NewImageInfo.currentImageToMove.Draw(Editor.spriteBatch);
            }


            Editor.spriteBatch.DrawString(spriteFont, $"Entered count:{count}", new Vector2(50, 50), Microsoft.Xna.Framework.Color.Black);

            Editor.spriteBatch.End();
        }
    }
}
