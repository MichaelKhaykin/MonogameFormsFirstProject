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

namespace MonogameFormsFirstProject
{
    public partial class Form1 : Form
    {

        CurrentMovingImageInfo currentThing = new CurrentMovingImageInfo();
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
            var result = monoGamePanel1.DoesHitBoxContainMouse();
            var image = (Bitmap)Clipboard.GetImage();

            if (result.Item1 == false)
            {
                return;
            }
            if (image == null)
            {
                MessageBox.Show("No image on clipboard");
                return;
            }

            currentThing.GridIndex = (result.Item2, result.Item3);

            currentImage.Width = image.Width;
            currentImage.Height = image.Height;

            currentImage.Image = image;
            currentImage.Location = new System.Drawing.Point(600, 0);
            currentImage.Visible = true;
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
            Bitmap croppedImage = new Bitmap(monoGamePanel1.SquareSize, monoGamePanel1.SquareSize);
            int overExtendedAmountX = currentImage.Width - monoGamePanel1.SquareSize;
            int overExtendedAmountY = currentImage.Height - monoGamePanel1.SquareSize;

            for(int i = overExtendedAmountX / 2; i < currentImage.Width - overExtendedAmountX / 2 - 1; i++)
            {
                for(int j = overExtendedAmountY / 2; j < currentImage.Height - overExtendedAmountY / 2 - 1; j++)
                {
                    var color = ((Bitmap)(currentImage.Image)).GetPixel(i, j);
                    croppedImage.SetPixel(i - overExtendedAmountX / 2, j - overExtendedAmountY / 2, color);
                }
            }



            currentImage.Image = croppedImage;
            currentImage.Width = croppedImage.Width;
            currentImage.Height = croppedImage.Height;

            currentImage.Location = new System.Drawing.Point((int)(monoGamePanel1.SquareSize * currentThing.GridIndex.Item2 + monoGamePanel1.StartPosition.X) - monoGamePanel1.SquareSize / 2 + 5 * currentThing.GridIndex.Item2, (int)(monoGamePanel1.SquareSize * currentThing.GridIndex.Item1 + monoGamePanel1.StartPosition.Y - monoGamePanel1.SquareSize / 2 + 5 * currentThing.GridIndex.Item1));

            
            GetData((Bitmap)currentImage.Image);

            monoGamePanel1.NewImageInfo = currentThing;

            currentThing = new CurrentMovingImageInfo();
            currentImage.Image = null;
            currentImage.Visible = false;

            

            Clipboard.Clear();
        }
    }
}
