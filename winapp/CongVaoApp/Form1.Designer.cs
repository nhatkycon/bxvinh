namespace CongVaoApp
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
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.txtThoiGian = new System.Windows.Forms.TextBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLoaiXe = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.drlBienSo = new System.Windows.Forms.ComboBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.lblTien = new System.Windows.Forms.Label();
            this.btnCapLenh = new System.Windows.Forms.Button();
            this.btnTraKhach = new System.Windows.Forms.Button();
            this.btnVangLLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(13, 13);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(646, 442);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThoiGian.Location = new System.Drawing.Point(672, 88);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(103, 27);
            this.lblThoiGian.TabIndex = 3;
            this.lblThoiGian.Text = "Thời gian:";
            this.lblThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtThoiGian.Location = new System.Drawing.Point(785, 88);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Size = new System.Drawing.Size(219, 29);
            this.txtThoiGian.TabIndex = 0;
            this.txtThoiGian.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // imageBox2
            // 
            this.imageBox2.BackColor = System.Drawing.Color.DarkGray;
            this.imageBox2.Location = new System.Drawing.Point(676, 173);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(328, 93);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // lblBienSo
            // 
            this.lblBienSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBienSo.Location = new System.Drawing.Point(672, 129);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(103, 25);
            this.lblBienSo.TabIndex = 6;
            this.lblBienSo.Text = "Biển số:";
            this.lblBienSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(672, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loại xe:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxLoaiXe
            // 
            this.cbxLoaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbxLoaiXe.FormattingEnabled = true;
            this.cbxLoaiXe.Location = new System.Drawing.Point(785, 279);
            this.cbxLoaiXe.Name = "cbxLoaiXe";
            this.cbxLoaiXe.Size = new System.Drawing.Size(219, 32);
            this.cbxLoaiXe.TabIndex = 2;
            this.cbxLoaiXe.SelectedIndexChanged += new System.EventHandler(this.cbxLoaiXe_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTongSo);
            this.panel1.Location = new System.Drawing.Point(676, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 49);
            this.panel1.TabIndex = 12;
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
            this.lblTongSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // drlBienSo
            // 
            this.drlBienSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.drlBienSo.FormattingEnabled = true;
            this.drlBienSo.Location = new System.Drawing.Point(785, 129);
            this.drlBienSo.Name = "drlBienSo";
            this.drlBienSo.Size = new System.Drawing.Size(219, 32);
            this.drlBienSo.TabIndex = 1;
            this.drlBienSo.TextChanged += new System.EventHandler(this.drlBienSo_TextChanged);
            // 
            // imageBox4
            // 
            this.imageBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox4.Location = new System.Drawing.Point(350, 471);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(309, 258);
            this.imageBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox4.TabIndex = 15;
            this.imageBox4.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox3.Location = new System.Drawing.Point(12, 471);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(328, 258);
            this.imageBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox3.TabIndex = 2;
            this.imageBox3.TabStop = false;
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(676, 665);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 57);
            this.button1.TabIndex = 7;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTien
            // 
            this.txtTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTien.Location = new System.Drawing.Point(785, 335);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(219, 29);
            this.txtTien.TabIndex = 3;
            this.txtTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTien
            // 
            this.lblTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTien.Location = new System.Drawing.Point(672, 335);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(103, 27);
            this.lblTien.TabIndex = 18;
            this.lblTien.Text = "Tiền:";
            this.lblTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCapLenh
            // 
            this.btnCapLenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCapLenh.ForeColor = System.Drawing.Color.Black;
            this.btnCapLenh.Location = new System.Drawing.Point(676, 385);
            this.btnCapLenh.Name = "btnCapLenh";
            this.btnCapLenh.Size = new System.Drawing.Size(99, 70);
            this.btnCapLenh.TabIndex = 4;
            this.btnCapLenh.Text = "Cấp lệnh (F8)";
            this.btnCapLenh.UseVisualStyleBackColor = true;
            this.btnCapLenh.Click += new System.EventHandler(this.btnCapLenh_Click);
            // 
            // btnTraKhach
            // 
            this.btnTraKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTraKhach.ForeColor = System.Drawing.Color.Black;
            this.btnTraKhach.Location = new System.Drawing.Point(791, 385);
            this.btnTraKhach.Name = "btnTraKhach";
            this.btnTraKhach.Size = new System.Drawing.Size(99, 70);
            this.btnTraKhach.TabIndex = 5;
            this.btnTraKhach.Text = "Trả khách (F9)";
            this.btnTraKhach.UseVisualStyleBackColor = true;
            this.btnTraKhach.Click += new System.EventHandler(this.btnTraKhach_Click);
            // 
            // btnVangLLai
            // 
            this.btnVangLLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnVangLLai.ForeColor = System.Drawing.Color.Black;
            this.btnVangLLai.Location = new System.Drawing.Point(905, 385);
            this.btnVangLLai.Name = "btnVangLLai";
            this.btnVangLLai.Size = new System.Drawing.Size(99, 70);
            this.btnVangLLai.TabIndex = 6;
            this.btnVangLLai.Text = "Vãng lai (F10)";
            this.btnVangLLai.UseVisualStyleBackColor = true;
            this.btnVangLLai.Click += new System.EventHandler(this.btnVangLLai_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.btnVangLLai);
            this.Controls.Add(this.btnTraKhach);
            this.Controls.Add(this.btnCapLenh);
            this.Controls.Add(this.txtTien);
            this.Controls.Add(this.lblTien);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox4);
            this.Controls.Add(this.drlBienSo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxLoaiXe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBienSo);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.txtThoiGian);
            this.Controls.Add(this.lblThoiGian);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "CỔNG VÀO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.TextBox txtThoiGian;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLoaiXe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox drlBienSo;
        private Emgu.CV.UI.ImageBox imageBox4;
        private Emgu.CV.UI.ImageBox imageBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.TextBox txtTien;
        private System.Windows.Forms.Label lblTien;
        private System.Windows.Forms.Button btnCapLenh;
        private System.Windows.Forms.Button btnTraKhach;
        private System.Windows.Forms.Button btnVangLLai;
    }
}

