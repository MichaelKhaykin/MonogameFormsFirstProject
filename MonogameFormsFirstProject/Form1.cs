using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace MonogameFormsFirstProject
{
    public partial class Form1 : Form
    {
        int count = 0;
        Queue<(int y, int x)> indexes = new Queue<(int y, int x)>();

        public static int SquareSize { get; } = 94;
        public Form1()
        {
            InitializeComponent();

            this.Width = Screen.FromControl(this).Bounds.Width;
            this.Height = Screen.FromControl(this).Bounds.Height;

        }

        private void monoGamePanel1_MouseDown(object sender, MouseEventArgs e)
        {
            var (wasClicked, y, x, isSetImage) = monoGamePanel1.DoesHitBoxContainMouse();

            switch (e.Button)
            {
                case MouseButtons.Left:
                    var image = (Bitmap)Clipboard.GetImage();

                    for (int i = 0; i < monoGamePanel1.Tab.Grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < monoGamePanel1.Tab.Grid.GetLength(1); j++)
                        {
                            if (image == null && monoGamePanel1.Tab.Grid[i, j].HitBox.Contains(new Microsoft.Xna.Framework.Point(e.X, e.Y)))
                            {
                                if (indexes.Contains((i, j))) continue;

                                count++;
                                indexes.Enqueue((i, j));

                                break;
                            }
                        }
                    }

                    if (indexes.Count == 2)
                    {
                        var index1 = indexes.Dequeue();
                        var index2 = indexes.Dequeue();

                        var temp = monoGamePanel1.Tab.Grid[index1.y, index1.x].Position;
                        monoGamePanel1.Tab.Grid[index1.y, index1.x].Position = monoGamePanel1.Tab.Grid[index2.y, index2.x].Position;
                        monoGamePanel1.Tab.Grid[index2.y, index2.x].Position = temp;

                        count = 0;
                    }
              
                    
                    if (image == null) return;

                    Texture2D texture;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        texture = Texture2D.FromStream(monoGamePanel1.GraphicsDevice, stream);
                    }

                    if (wasClicked == false || isSetImage)
                    {
                        return;
                    }

                    monoGamePanel1.Tab.NewImageInfo.GridIndex = (y, x);
                
                    var position = new Vector2(monoGamePanel1.PreviewBox.Position.X, monoGamePanel1.PreviewBox.Position.Y);
                    monoGamePanel1.Tab.NewImageInfo.Sprite = new Sprite(texture, position, Microsoft.Xna.Framework.Color.White, Vector2.One);

                    break;

                case MouseButtons.Right:
                    if (wasClicked == false) return;

                    monoGamePanel1.Tab.Grid[y, x].Texture = MonoGamePanel.GridTexture;
                    monoGamePanel1.Tab.Grid[y, x].SetTextureData();
                    monoGamePanel1.Tab.Grid[y, x].isSetImage = false;

                    break;
            }
        }

        private void scaleXButton_Click(object sender, EventArgs e)
        {
            if (monoGamePanel1.Tab.NewImageInfo.Sprite != null)
            {
                if (scaleXBox.Text.Length > 0)
                {
                    float scale;
                    if (!float.TryParse(scaleXBox.Text, out scale))
                    {
                        MessageBox.Show("Invalid input");
                        return;
                    }
                    monoGamePanel1.Tab.NewImageInfo.Sprite.Scale.X = scale;
                }
            }
        }

        private void scaleYButton_Click(object sender, EventArgs e)
        {
            if (monoGamePanel1.Tab.NewImageInfo.Sprite != null)
            {
                if (scaleYBox.Text.Length > 0)
                {
                    float scale;
                    if (!float.TryParse(scaleYBox.Text, out scale))
                    {
                        MessageBox.Show("Invalid input");
                        return;
                    }
                    monoGamePanel1.Tab.NewImageInfo.Sprite.Scale.Y = scale;
                }
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (monoGamePanel1.Tab.NewImageInfo.Sprite == null) return;

            var startX = (int)(monoGamePanel1.PreviewBox.Position.X - monoGamePanel1.PreviewBox.ScaledWidth / 2) - (int)(monoGamePanel1.Tab.NewImageInfo.Sprite.Position.X - monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledWidth / 2);
            var startY = (int)(monoGamePanel1.PreviewBox.Position.Y - monoGamePanel1.PreviewBox.ScaledHeight / 2) - (int)(monoGamePanel1.Tab.NewImageInfo.Sprite.Position.Y - monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledHeight / 2);
            var endX = (int)(monoGamePanel1.PreviewBox.Position.X + monoGamePanel1.PreviewBox.ScaledWidth / 2) - (int)(monoGamePanel1.Tab.NewImageInfo.Sprite.Position.X - monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledWidth / 2);
            var endY = (int)(monoGamePanel1.PreviewBox.Position.Y + monoGamePanel1.PreviewBox.ScaledHeight / 2) - (int)(monoGamePanel1.Tab.NewImageInfo.Sprite.Position.Y - monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledHeight / 2);
            

            Bitmap tempOgBitMap = null;
            using (MemoryStream stream = new MemoryStream())
            {
                var width = monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledWidth;
                var height = monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledHeight;
                monoGamePanel1.Tab.NewImageInfo.Sprite.Texture.SaveAsPng(stream, width, height);

                tempOgBitMap = new Bitmap(stream);
            }

            Bitmap croppedImage = new Bitmap(94, 94);
            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    var color = tempOgBitMap.GetPixel(i, j);
                    croppedImage.SetPixel(i - startX, j - startY, color);
                }
            }

            using (MemoryStream stream = new MemoryStream())
            {
                croppedImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png); ;
                monoGamePanel1.Tab.NewImageInfo.Sprite.Texture = Texture2D.FromStream(monoGamePanel1.GraphicsDevice, stream);
            }
            
            monoGamePanel1.Tab.NewImageInfo.Sprite.Position = new Vector2((SquareSize * monoGamePanel1.Tab.NewImageInfo.GridIndex.Item2 + monoGamePanel1.Tab.StartPosition.X) - SquareSize / 2 + monoGamePanel1.Tab.Offset * monoGamePanel1.Tab.NewImageInfo.GridIndex.Item2 + monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledWidth / 2, (SquareSize * monoGamePanel1.Tab.NewImageInfo.GridIndex.Item1 + monoGamePanel1.Tab.StartPosition.Y - SquareSize / 2 + monoGamePanel1.Tab.Offset * monoGamePanel1.Tab.NewImageInfo.GridIndex.Item1) + monoGamePanel1.Tab.NewImageInfo.Sprite.ScaledHeight / 2);
            monoGamePanel1.Tab.NewImageInfo.isReadyToSet = true;

            scaleXBox.Clear();
            scaleYBox.Clear();

            Clipboard.Clear();
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            var dataToSave = JsonConvert.SerializeObject(monoGamePanel1.Tabs);

            var path = Path.Combine(Environment.CurrentDirectory, "data.txt");
            File.WriteAllText(path, dataToSave);
        }

        private void firstTabButton_Click(object sender, EventArgs e)
        {
            monoGamePanel1.indexToUse = 0;
        }

        private void secondTabButton_Click(object sender, EventArgs e)
        {
            monoGamePanel1.indexToUse = 1;
        }

        private void thirdTabButton_Click(object sender, EventArgs e)
        {
            monoGamePanel1.indexToUse = 2;
        }
   }
}
