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
            this.scaleXBox = new System.Windows.Forms.TextBox();
            this.scaleXButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleYBox = new System.Windows.Forms.TextBox();
            this.scaleYButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.monoGamePanel1 = new MonogameFormsFirstProject.MonoGamePanel();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
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
            this.monoGamePanel1.Location = new System.Drawing.Point(0, 0);
            this.monoGamePanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.monoGamePanel1.MouseHoverUpdatesOnly = false;
            this.monoGamePanel1.Name = "monoGamePanel1";
            this.monoGamePanel1.NewImageInfo = null;
            this.monoGamePanel1.Size = new System.Drawing.Size(2048, 1063);
            this.monoGamePanel1.TabIndex = 0;
            this.monoGamePanel1.Text = "monoGamePanel1";
            this.monoGamePanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.monoGamePanel1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 817);
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
    }
}

