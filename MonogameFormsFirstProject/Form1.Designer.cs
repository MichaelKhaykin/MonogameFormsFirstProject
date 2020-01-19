namespace MonogameFormsFirstProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.scaleXBox = new System.Windows.Forms.TextBox();
            this.scaleXButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleYBox = new System.Windows.Forms.TextBox();
            this.scaleYButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.monoGamePanel1 = new MonogameFormsFirstProject.MonoGamePanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.firstTabButton = new System.Windows.Forms.Button();
            this.secondTabButton = new System.Windows.Forms.Button();
            this.thirdTabButton = new System.Windows.Forms.Button();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // scaleXBox
            // 
            this.scaleXBox.Location = new System.Drawing.Point(800, 700);
            this.scaleXBox.Name = "scaleXBox";
            this.scaleXBox.Size = new System.Drawing.Size(100, 22);
            this.scaleXBox.TabIndex = 1;
            // 
            // scaleXButton
            // 
            this.scaleXButton.Location = new System.Drawing.Point(910, 700);
            this.scaleXButton.Name = "scaleXButton";
            this.scaleXButton.Size = new System.Drawing.Size(75, 23);
            this.scaleXButton.TabIndex = 2;
            this.scaleXButton.Text = "Scale";
            this.scaleXButton.UseVisualStyleBackColor = true;
            this.scaleXButton.Click += new System.EventHandler(this.scaleXButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(773, 703);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(773, 731);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y:";
            // 
            // scaleYBox
            // 
            this.scaleYBox.Location = new System.Drawing.Point(800, 728);
            this.scaleYBox.Name = "scaleYBox";
            this.scaleYBox.Size = new System.Drawing.Size(100, 22);
            this.scaleYBox.TabIndex = 5;
            // 
            // scaleYButton
            // 
            this.scaleYButton.Location = new System.Drawing.Point(910, 729);
            this.scaleYButton.Name = "scaleYButton";
            this.scaleYButton.Size = new System.Drawing.Size(75, 23);
            this.scaleYButton.TabIndex = 6;
            this.scaleYButton.Text = "Scale";
            this.scaleYButton.UseVisualStyleBackColor = true;
            this.scaleYButton.Click += new System.EventHandler(this.scaleYButton_Click);
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(1005, 712);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 7;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // currentImage
            // 
            this.currentImage.Location = new System.Drawing.Point(0, 0);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(100, 50);
            this.currentImage.TabIndex = 8;
            this.currentImage.TabStop = false;
            this.currentImage.Visible = false;
            // 
            // monoGamePanel1
            // 
            this.monoGamePanel1.indexToUse = 0;
            this.monoGamePanel1.Location = new System.Drawing.Point(0, 0);
            this.monoGamePanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.monoGamePanel1.MouseHoverUpdatesOnly = false;
            this.monoGamePanel1.Name = "monoGamePanel1";
            this.monoGamePanel1.Pixel = null;
            this.monoGamePanel1.Size = new System.Drawing.Size(2048, 1063);
            this.monoGamePanel1.TabIndex = 0;
            this.monoGamePanel1.Tabs = new MonogameFormsFirstProject.Tab[] {
        null,
        null,
        null};
            this.monoGamePanel1.Text = "monoGamePanel1";
            this.monoGamePanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.monoGamePanel1_MouseDown);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1389, 58);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // firstTabButton
            // 
            this.firstTabButton.Location = new System.Drawing.Point(126, 12);
            this.firstTabButton.Name = "firstTabButton";
            this.firstTabButton.Size = new System.Drawing.Size(75, 23);
            this.firstTabButton.TabIndex = 10;
            this.firstTabButton.Text = "1";
            this.firstTabButton.UseVisualStyleBackColor = true;
            this.firstTabButton.Click += new System.EventHandler(this.firstTabButton_Click);
            // 
            // secondTabButton
            // 
            this.secondTabButton.Location = new System.Drawing.Point(216, 12);
            this.secondTabButton.Name = "secondTabButton";
            this.secondTabButton.Size = new System.Drawing.Size(75, 23);
            this.secondTabButton.TabIndex = 11;
            this.secondTabButton.Text = "2";
            this.secondTabButton.UseVisualStyleBackColor = true;
            this.secondTabButton.Click += new System.EventHandler(this.secondTabButton_Click);
            // 
            // thirdTabButton
            // 
            this.thirdTabButton.Location = new System.Drawing.Point(310, 12);
            this.thirdTabButton.Name = "thirdTabButton";
            this.thirdTabButton.Size = new System.Drawing.Size(75, 23);
            this.thirdTabButton.TabIndex = 12;
            this.thirdTabButton.Text = "3";
            this.thirdTabButton.UseVisualStyleBackColor = true;
            this.thirdTabButton.Click += new System.EventHandler(this.thirdTabButton_Click);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("previewPictureBox.Image")));
            this.previewPictureBox.Location = new System.Drawing.Point(1000, 400);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(94, 94);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.previewPictureBox.TabIndex = 13;
            this.previewPictureBox.TabStop = false;
            this.previewPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.previewPictureBox_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 817);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.thirdTabButton);
            this.Controls.Add(this.secondTabButton);
            this.Controls.Add(this.firstTabButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.currentImage);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.scaleYButton);
            this.Controls.Add(this.scaleYBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scaleXButton);
            this.Controls.Add(this.scaleXBox);
            this.Controls.Add(this.monoGamePanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonoGamePanel monoGamePanel1;
        private System.Windows.Forms.TextBox scaleXBox;
        private System.Windows.Forms.Button scaleXButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox scaleYBox;
        private System.Windows.Forms.Button scaleYButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.PictureBox currentImage;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button firstTabButton;
        private System.Windows.Forms.Button secondTabButton;
        private System.Windows.Forms.Button thirdTabButton;
        private System.Windows.Forms.PictureBox previewPictureBox;
    }
}

