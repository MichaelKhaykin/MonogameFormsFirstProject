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
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace MonogameFormsFirstProject
{
    public class MonoGamePanel : MonoGameControl
    {
        public Tab[] Tabs { get; set; } = new Tab[3];
        public int indexToUse { get; set; } = 0;
        public Tab Tab => Tabs[indexToUse];

        public Texture2D Pixel { get; set; }
        protected override void Initialize()
        {
            base.Initialize();
            LoadContent();

        }

        private void LoadContent()
        {
            Clipboard.Clear();

            for(int i = 0; i < Tabs.Length; i++)
            {
                Tabs[i] = new Tab();
            }

            var Content = Editor.Content;

            Pixel = new Texture2D(GraphicsDevice, 1, 1);
            Pixel.SetData(new[] { Microsoft.Xna.Framework.Color.White });

            var actualJson = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data.txt"));

            if (actualJson.Length == 0)
            {
                InitTab(indexToUse);
            }
            else
            {
                Tabs = JsonConvert.DeserializeObject<Tab[]>(actualJson);

                for (int i = 0; i < Tabs.Length; i++)
                {
                    Tabs[i].SpriteFont = Editor.Content.Load<SpriteFont>("Font");

                    foreach (var gridCell in Tabs[i].Grid)
                    {
                        //this means this grid has yet to be used
                        if (gridCell == null)
                        {
                            InitTab(i);
                            break;
                        }

                        gridCell.Texture = new Texture2D(GraphicsDevice, Form1.SquareSize, Form1.SquareSize);
                        gridCell.Texture.SetData(gridCell.TextureData);
                    }

                    foreach(var button in Tabs[i].Buttons)
                    {
                        if (button == null) break;

                        button.Texture = new Texture2D(GraphicsDevice, Form1.SquareSize, Form1.SquareSize);
                        button.Texture.SetData(button.TextureData);
                    }
                }
            }
        }

        private void InitTab(int index)
        {
            Tabs[index] = new Tab()
            {
                NewImageInfo = new CurrentMovingImageInfo()
            };

            var gridItemTexture = Editor.Content.Load<Texture2D>("SquareAddIcon-01");

            Tabs[index].StartPosition = new Vector2(300, gridItemTexture.Height);

            for (int i = 0; i < Tabs[index].Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Tabs[index].Grid.GetLength(1); j++)
                {
                    var newCalculatedPosition = new Vector2(Tabs[index].StartPosition.X + j * gridItemTexture.Width + j * 5, Tabs[index].StartPosition.Y + i * gridItemTexture.Height + i * 5);

                    var gridCellSprite = new Sprite(gridItemTexture, newCalculatedPosition, Microsoft.Xna.Framework.Color.White, Vector2.One);
                    gridCellSprite.SetTextureData();
                    Tabs[index].Grid[i, j] = gridCellSprite;
                }
            }


            Tabs[index].SpriteFont = Editor.Content.Load<SpriteFont>("Font");
        }

        public (bool, int, int) DoesHitBoxContainMouse()
        {
            Tab.count++;
            for (int i = 0; i < Tab.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Tab.Grid.GetLength(1); j++)
                {
                    if (Tab.Grid[i, j].HitBox.Contains(Editor.GetRelativeMousePosition.X, Editor.GetRelativeMousePosition.Y))
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

            if(Tab.NewImageInfo.DataToSet != null)
            {
                var newTexture = new Texture2D(GraphicsDevice, Tab.NewImageInfo.Width, Tab.NewImageInfo.Height);
                newTexture.SetData(Tab.NewImageInfo.DataToSet);

                var button = new Sprite(newTexture, new Vector2(Tab.NewImageInfo.GridIndex.Item2 * Form1.SquareSize + Tab.StartPosition.X + Tab.Offset * Tab.NewImageInfo.GridIndex.Item2, Tab.NewImageInfo.GridIndex.Item1 * Form1.SquareSize + Tab.StartPosition.Y + Tab.Offset * Tab.NewImageInfo.GridIndex.Item1), Microsoft.Xna.Framework.Color.White, Vector2.One);
                button.SetTextureData();
                Tab.Buttons.Add(button);

                Tab.NewImageInfo.DataToSet = null;
            }
        }
        
        internal void SaveButton_Click(object sender, EventArgs e)
        {
            var dataToSave = JsonConvert.SerializeObject(Tabs);

            var path = Path.Combine(Environment.CurrentDirectory, "data.txt");
            File.WriteAllText(path, dataToSave);
        }


        protected override void Draw()
        {

            base.Draw();
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.White);

            Editor.spriteBatch.Begin();

            for (int i = 0; i < Tab.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Tab.Grid.GetLength(1); j++)
                {
                    Tab.Grid[i, j].Draw(Editor.spriteBatch);
                }
            }

            foreach(var item in Tab.Buttons)
            {
                item.Draw(Editor.spriteBatch);
            }

            Editor.spriteBatch.DrawString(Tab.SpriteFont, $"Entered count:{Tab.count}", new Vector2(50, 50), Microsoft.Xna.Framework.Color.Black);

            Editor.spriteBatch.End();
        }
    }
}
