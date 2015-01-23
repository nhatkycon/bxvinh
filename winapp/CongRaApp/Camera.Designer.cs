namespace CongRaApp
{
    partial class Camera
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
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.picBienSo = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.picRs = new System.Windows.Forms.PictureBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBienSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRs)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(12, 34);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(931, 534);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 620);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 77);
            this.button1.TabIndex = 4;
            this.button1.Text = "btnCapture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBienSo
            // 
            this.picBienSo.Location = new System.Drawing.Point(949, 34);
            this.picBienSo.Name = "picBienSo";
            this.picBienSo.Size = new System.Drawing.Size(365, 201);
            this.picBienSo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBienSo.TabIndex = 5;
            this.picBienSo.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 620);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 77);
            this.button2.TabIndex = 6;
            this.button2.Text = "Doc bien";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // picRs
            // 
            this.picRs.Location = new System.Drawing.Point(949, 242);
            this.picRs.Name = "picRs";
            this.picRs.Size = new System.Drawing.Size(365, 179);
            this.picRs.TabIndex = 7;
            this.picRs.TabStop = false;
            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBienSo.Location = new System.Drawing.Point(949, 428);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(0, 26);
            this.lblBienSo.TabIndex = 8;
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 697);
            this.Controls.Add(this.lblBienSo);
            this.Controls.Add(this.picRs);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.picBienSo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox1);
            this.Name = "Camera";
            this.Text = "Camera";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBienSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picBienSo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox picRs;
        private System.Windows.Forms.Label lblBienSo;
    }
}