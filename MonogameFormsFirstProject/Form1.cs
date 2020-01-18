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
        CurrentMovingImageInfo currentThing = new CurrentMovingImageInfo();
        int count = 0;
        Queue<(int y, int x)> indexes = new Queue<(int y, int x)>();

        public static int SquareSize { get; } = 94;
        public Form1()
        {
            InitializeComponent();

            this.Width = Screen.FromControl(this).Bounds.Width;
            this.Height = Screen.FromControl(this).Bounds.Height;

        }

        private void GetData(Bitmap image)
        {
            Microsoft.Xna.Framework.Color[] colors = new Microsoft.Xna.Framework.Color[image.Width * image.Height];
            int count = 0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    var color = image.GetPixel(j, i);
                    colors[count] = new Microsoft.Xna.Framework.Color(color.R, color.G, color.B);
                    count++;
                }
            }

            currentThing.Width = image.Width;
            currentThing.Height = image.Height;

            currentThing.DataToSet = colors;
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
                            if (monoGamePanel1.Tab.Grid[i, j].isSetImage && monoGamePanel1.Tab.Grid[i, j].HitBox.Contains(new Microsoft.Xna.Framework.Point(e.X, e.Y)))
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

                    if (wasClicked == false || isSetImage)
                    {
                        return;
                    }

                    if (image == null)
                    {
                        MessageBox.Show("No image on clipboard");
                        return;
                    }

                    currentThing.GridIndex = (y, x);

                    currentImage.Width = image.Width;
                    currentImage.Height = image.Height;

                    currentImage.Image = image;
                    currentImage.Location = new System.Drawing.Point(600, 0);
                    currentImage.Visible = true;
                    break;

                case MouseButtons.Right:
                    if (wasClicked == false) return;

                    monoGamePanel1.Tab.Grid[y, x].Texture = MonoGamePanel.GridTexture;
                    monoGamePanel1.Tab.Grid[y, x].isSetImage = false;

                    break;
            }
        }

        private void scaleXButton_Click(object sender, EventArgs e)
        {
            if (currentImage.Image != null)
            {
                if (scaleXBox.Text.Length > 0)
                {
                    float scale;
                    if (!float.TryParse(scaleXBox.Text, out scale))
                    {
                        MessageBox.Show("Invalid input");
                        return;
                    }
                    currentImage.Width = (int)(currentImage.Image.Width * scale);
                    currentImage.Image = new Bitmap(currentImage.Image, (int)(currentImage.Image.Width * scale), currentImage.Image.Height);
                }
            }
        }

        private void scaleYButton_Click(object sender, EventArgs e)
        {
            if (currentImage.Image != null)
            {
                if (scaleYBox.Text.Length > 0)
                {
                    float scale;
                    if (!float.TryParse(scaleYBox.Text, out scale))
                    {
                        MessageBox.Show("Invalid input");
                        return;
                    }
                    currentImage.Height = (int)(currentImage.Image.Height * scale);
                    currentImage.Image = new Bitmap(currentImage.Image, currentImage.Image.Width, (int)(currentImage.Image.Height * scale));
                }
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (currentImage.Image == null) return;

            Bitmap croppedImage = new Bitmap(SquareSize, SquareSize);
            int overExtendedAmountX = currentImage.Width - SquareSize;
            int overExtendedAmountY = currentImage.Height - SquareSize;

            bool didEnterX = false;
            bool didEnterY = false;

            if (overExtendedAmountX < 0)
            {
                currentImage.Width = 94;
                currentImage.Image = new Bitmap(currentImage.Image, currentImage.Width, currentImage.Height);

                didEnterX = true;
            }
            if (overExtendedAmountY < 0)
            {
                currentImage.Height = 94;
                currentImage.Image = new Bitmap(currentImage.Image, currentImage.Width, currentImage.Height);

                didEnterY = true;
            }

            overExtendedAmountX = Math.Abs(overExtendedAmountX);
            overExtendedAmountY = Math.Abs(overExtendedAmountY);

            int startingX = didEnterX ? 0 : overExtendedAmountX / 2;
            int endingX = didEnterX ? currentImage.Width : currentImage.Width - overExtendedAmountX / 2 - 1;

            int startingY = didEnterY ? 0 : overExtendedAmountY / 2;
            int endingY = didEnterY ? currentImage.Height : currentImage.Height - overExtendedAmountY / 2 - 1;

            for (int i = startingX; i < endingX; i++)
            {
                for (int j = startingY; j < endingY; j++)
                {
                    var color = ((Bitmap)(currentImage.Image)).GetPixel(i, j);
                    croppedImage.SetPixel(i - startingX, j - startingY, color);
                }
            }

            currentImage.Image = croppedImage;
            currentImage.Width = croppedImage.Width;
            currentImage.Height = croppedImage.Height;

            currentImage.Location = new System.Drawing.Point((int)(SquareSize * currentThing.GridIndex.Item2 + monoGamePanel1.Tab.StartPosition.X) - SquareSize / 2 + 5 * currentThing.GridIndex.Item2, (int)(SquareSize * currentThing.GridIndex.Item1 + monoGamePanel1.Tab.StartPosition.Y - SquareSize / 2 + 5 * currentThing.GridIndex.Item1));

            GetData((Bitmap)currentImage.Image);

            monoGamePanel1.Tab.NewImageInfo = currentThing;

            currentThing = new CurrentMovingImageInfo();
            currentImage.Image = null;
            currentImage.Visible = false;

            scaleXBox.Clear();
            scaleYBox.Clear();



            Clipboard.Clear();
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
