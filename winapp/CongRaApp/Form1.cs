using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CongRaApp.BxVinh.WebSrv;
using linh.common;

namespace CongRaApp
{
    public partial class Form1 : Form
    {
        private List<XeVaoBen> XeList { get; set; }
        private String[] XeListStrArray;
        private List<LoaiXe> LoaiXeList { get; set; }
        private BxVinh.WebSrv.WebService Wsrv { get; set; }
        private long XvbId { get; set; }
        public double Tien { get; set; }
        public double DoanhThu { get; set; }
        public string Username { get; set; }
        public string Ten { get; set; }
        public int DonVi_Id { get; set; }
        public GiaoCa GiaoCa { get; set; }
        //declaring global variables
        private Capture capture;        //takes images from camera as image frames
        private bool captureInProgress; // checks if capture is executing
        
        #region contructors
        public Form1(string username, string ten, int donVi_Id)
        {
            InitializeComponent();
            Username = username;
            Ten = ten;
            DonVi_Id = donVi_Id;
            this.Text = string.Format("{0} - {1} - {2}", username, ten, donVi_Id);
            Wsrv = new WebService();
        }
        public Form1(string username, string ten, int donVi_Id, GiaoCa giaoCa)
        {
            InitializeComponent();
            Username = username;
            Ten = ten;
            DonVi_Id = donVi_Id;
            GiaoCa = giaoCa;
            lblTongSo.Text = GiaoCa.DoanhThu.TienVietNam();
            DoanhThu = giaoCa.DoanhThu;
            this.Text = string.Format("{0} - {1} - {2}", username, ten, donVi_Id);
            Wsrv = new WebService();
        }
        public Form1()
        {
            InitializeComponent();
            Wsrv = new WebService();
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            XeList = Wsrv.XeVaoBenGetXeRaCong(DonVi_Id).ToList();
            XeListStrArray = XeList.Select(x => x.BienSo).ToArray();
            LoaiXeList = Wsrv.LoaiXeGetAll().ToList();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindingCombobox();
        }
        private void BindingCombobox()
        {
            drlBienSo.AutoCompleteMode = AutoCompleteMode.Suggest;
            drlBienSo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            drlBienSo.DroppedDown = false;
            drlBienSo.Enabled = true;
            drlBienSo.Focus();
            PopulateResult("");
            backgroundWorker2.Dispose();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if(this.ActiveControl==drlBienSo)
            //{
            //    return false;
            //}
            switch (keyData)
            {
                case Keys.F8:
                    btnMoCong.PerformClick();
                    return true;
                    break;
                case Keys.F2: // Get fresh data from Server
                    backgroundWorker1.RunWorkerAsync();
                    return true;
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void drlBienSo_TextChanged(object sender, EventArgs e)
        {
            var term = drlBienSo.Text;
            PopulateResult(term);

            if (term.Length == 0) return;
            var item = XeList.FirstOrDefault(x => x.BienSo.ToLower() == term.ToLower());
            #region reset value
            XvbId = 0;
            lblTrangThai.Text = string.Empty;
            txtTien.Text = string.Empty;
            txtGioVao.Text = string.Empty;
            Tien = 0;
            #endregion
            if (item == null) return;
            XvbId = item.ID;
            txtGioVao.Text = item.NgayVao.ToString("HH:mm dd/MM/yyyy");
            if(item.Loai!=200)
            {
                txtTien.Text = item.Tien.TienVietNam();
                lblTrangThai.Text = item.Loai == 0 ? "Xe vãng lai" : "Xe vào trả khách";
                Tien = item.Tien;
            }
            else
            {
                lblTrangThai.Text = "Xe đã cấp lệnh";
            }


            var loaiXe = LoaiXeList.FirstOrDefault(x => x.ID == item.LOAIXE_ID);
            if (loaiXe == null) return;
        }
        private void PopulateResult(string term)
        {
            if (term.Length == 0 || term.Length > 20) term = "";
            var list = string.IsNullOrEmpty(term)
                           ? XeListStrArray
                           : XeListStrArray.Where(x => x.ToLower().Contains(term.ToLower())).ToArray();

            if (list == null || !list.Any())
            {
                drlBienSo.DroppedDown = false;
                return;
            }
            drlBienSo.Items.Clear();
            foreach (var s in list)
            {
                drlBienSo.Items.Add(s);
            }
            drlBienSo.Select(term.Length, 1);
            drlBienSo.DroppedDown = true;
        }
        private void btnMoCong_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
            {
                lblTien.Text = "Đang xử lý";
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (XvbId==0) return;
            Wsrv.XeVaoBenUpdateRaCong(XvbId);
            // do stuffs here to open gate
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DoanhThu += Tien;
            lblTien.Text = DoanhThu.TienVietNam();
            var removedItem = XeList.FirstOrDefault(x => x.ID == XvbId);
            if(removedItem!=null)
            {
                XeList.Remove(removedItem);
                XeListStrArray = XeList.Select(x => x.BienSo.ToLower()).ToArray();
            }
            drlBienSo.Text = "";
            txtTien.Text = "";
            txtGioVao.Text = "";
            XvbId = 0;
            Tien = 0;
            if(!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            backgroundWorker2.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new Login();
            frm.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundWorker1.Dispose();
            backgroundWorker2.Dispose();
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            drlBienSo.Enabled =  false;
            KeyPreview = true;
        }
    }
}
