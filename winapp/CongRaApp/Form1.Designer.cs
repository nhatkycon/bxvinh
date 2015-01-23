namespace CongRaApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.drlBienSo = new System.Windows.Forms.ComboBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.lblTien = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtGioVao = new System.Windows.Forms.TextBox();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.btnMoCong = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picBienSo = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBienSo)).BeginInit();
            this.SuspendLayout();
            // 
            // drlBienSo
            // 
            this.drlBienSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.drlBienSo.FormattingEnabled = true;
            this.drlBienSo.Location = new System.Drawing.Point(785, 89);
            this.drlBienSo.Name = "drlBienSo";
            this.drlBienSo.Size = new System.Drawing.Size(219, 32);
            this.drlBienSo.TabIndex = 1;
            this.drlBienSo.TextChanged += new System.EventHandler(this.drlBienSo_TextChanged);
            // 
            // lblBienSo
            // 
            this.lblBienSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBienSo.Location = new System.Drawing.Point(672, 89);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(103, 25);
            this.lblBienSo.TabIndex = 14;
            this.lblBienSo.Text = "Biển số:";
            this.lblBienSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongSo
            // 
            this.lblTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongSo.ForeColor = System.Drawing.Color.Red;
            this.lblTongSo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTongSo.Location = new System.Drawing.Point(10, 14);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(300, 24);
            this.lblTongSo.TabIndex = 0;
            this.lblTongSo.Text = "259";
            this.lblTongSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTongSo);
            this.panel1.Location = new System.Drawing.Point(676, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 49);
            this.panel1.TabIndex = 0;
            // 
            // txtTien
            // 
            this.txtTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTien.Location = new System.Drawing.Point(785, 308);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(219, 29);
            this.txtTien.TabIndex = 3;
            this.txtTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTien
            // 
            this.lblTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTien.Location = new System.Drawing.Point(708, 310);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(103, 27);
            this.lblTien.TabIndex = 21;
            this.lblTien.Text = "Tiền:";
            this.lblTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(676, 672);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 57);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtGioVao
            // 
            this.txtGioVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGioVao.Location = new System.Drawing.Point(785, 267);
            this.txtGioVao.Name = "txtGioVao";
            this.txtGioVao.Size = new System.Drawing.Size(219, 29);
            this.txtGioVao.TabIndex = 2;
            this.txtGioVao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGioVao
            // 
            this.lblGioVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGioVao.Location = new System.Drawing.Point(672, 267);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(103, 27);
            this.lblGioVao.TabIndex = 23;
            this.lblGioVao.Text = "Vào:";
            this.lblGioVao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMoCong
            // 
            this.btnMoCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnMoCong.ForeColor = System.Drawing.Color.Black;
            this.btnMoCong.Location = new System.Drawing.Point(676, 359);
            this.btnMoCong.Name = "btnMoCong";
            this.btnMoCong.Size = new System.Drawing.Size(328, 70);
            this.btnMoCong.TabIndex = 4;
            this.btnMoCong.Text = "Mở cổng (F8)";
            this.btnMoCong.UseVisualStyleBackColor = true;
            this.btnMoCong.Click += new System.EventHandler(this.btnMoCong_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(12, 22);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(640, 490);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.Red;
            this.lblTrangThai.Location = new System.Drawing.Point(675, 436);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(332, 20);
            this.lblTrangThai.TabIndex = 25;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picBienSo
            // 
            this.picBienSo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBienSo.Location = new System.Drawing.Point(676, 132);
            this.picBienSo.Name = "picBienSo";
            this.picBienSo.Size = new System.Drawing.Size(328, 127);
            this.picBienSo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBienSo.TabIndex = 26;
            this.picBienSo.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.picBienSo);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.btnMoCong);
            this.Controls.Add(this.txtGioVao);
            this.Controls.Add(this.lblGioVao);
            this.Controls.Add(this.txtTien);
            this.Controls.Add(this.lblTien);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drlBienSo);
            this.Controls.Add(this.lblBienSo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBienSo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox drlBienSo;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTien;
        private System.Windows.Forms.Label lblTien;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtGioVao;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.Button btnMoCong;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picBienSo;
        private System.Windows.Forms.Timer timer2;
    }
}

