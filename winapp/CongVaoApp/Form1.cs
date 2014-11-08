using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CongVaoApp.BxVinh.WebSrv;
using Emgu.CV;
using linh.common;

namespace CongVaoApp
{
    public partial class Form1 : Form
    {

        private List<Xe> XeList { get; set; }
        private String[] XeListStrArray;
        private List<LoaiXe> LoaiXeList { get; set; }
        private BxVinh.WebSrv.WebService Wsrv { get; set; }
        private long XeVaoBenInsertRs { get; set; }
        private string BienSoStr { get; set; }
        private int LoaiXeInt { get; set; }
        private long XeId { get; set; }
        public string Tien { get; set; }
        private string NgayStr { get; set; }
        private bool XeVangLai { get; set; }
        private Int16 Loai { get; set; }
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
            this.Text = string.Format("{0} - {1} - {2}", username, ten, donVi_Id);
            Wsrv = new WebService();
        }
        public Form1()
        {
            InitializeComponent();
            Wsrv = new WebService();
        }
        #endregion

        private void ProcessFrame(object sender, EventArgs arg)
        {
            var imageFrame = capture.QueryFrame();  //line 1
            imageBox1.Image = imageFrame;        //line 2
            imageBox3.Image = imageFrame;        //line 2
            imageBox4.Image = imageFrame;        //line 2
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            drlBienSo.Enabled = cbxLoaiXe.Enabled = false;
            KeyPreview = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtThoiGian.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var bHandled = false;
            
            switch (keyData)
            {
                case Keys.Alt | Keys.F:
                    #region View Camera
                    #region if capture is not created, create it now
                    if (capture == null)
                    {
                        try
                        {
                            capture = new Capture();
                        }
                        catch (NullReferenceException excpt)
                        {
                            MessageBox.Show(excpt.Message);
                        }
                    }
                    #endregion

                    if (capture != null)
                    {
                        Application.Idle += ProcessFrame;
                        captureInProgress = !captureInProgress;
                    }
                    return true;
                    #endregion
                    break;
                case Keys.F8:
                    this.btnCapLenh.PerformClick();
                    return true;
                    break;
                case Keys.F9:
                    this.btnTraKhach.PerformClick();
                    return true;
                    break;
                case Keys.F10:
                   this.btnVangLLai.PerformClick();
                   return true;
                    break;
                case Keys.F2: // Get fresh data from Server
                    backgroundWorker1.RunWorkerAsync();
                    return true;
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        #region binding combobox
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            XeList = Wsrv.XeGetAll(string.Empty,1000).ToList();
            XeListStrArray = XeList.Select(x => x.BienSo).ToArray();
            LoaiXeList = Wsrv.LoaiXeGetAll().ToList();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindingCombobox();
        }
        private void BindingCombobox()
        {
            #region bien So

            var xe = new Xe { ID = 0, BienSo = "" , LOAIXE_ID = 0 };
            XeList.Insert(0, xe);

            drlBienSo.AutoCompleteMode = AutoCompleteMode.Suggest;
            drlBienSo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            drlBienSo.DroppedDown = false;
            drlBienSo.Enabled = true;
         
            #endregion

            #region Loai xe

            var loaiXe = new LoaiXe { ID = 0, Ten = "" };
            LoaiXeList.Insert(0, loaiXe);

            cbxLoaiXe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxLoaiXe.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbxLoaiXe.DataSource = LoaiXeList;
            cbxLoaiXe.DroppedDown = false;
            cbxLoaiXe.DisplayMember = "Ten";
            cbxLoaiXe.ValueMember = "ID";
            cbxLoaiXe.Enabled = true;

            #endregion
            backgroundWorker1.Dispose();
            drlBienSo.Focus();
        }

        #endregion

       

        #region save xe vao ben
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            XeVaoBenInsertRs = Wsrv.XeVaoBenInsert(BienSoStr, LoaiXeInt, NgayStr, Username, DonVi_Id, Loai, GiaoCa.ID);

        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cbxLoaiXe.SelectedValue = 0;
            drlBienSo.Focus();

            Debug.WriteLine(XeVaoBenInsertRs == 0 ? string.Format("Lỗi: {0}", XeVaoBenInsertRs) : string.Format("ID: {0}", XeVaoBenInsertRs));
            backgroundWorker2.Dispose();

            // binding new item
            if (XeId == 0 && !backgroundWorker1.IsBusy)
            {
                #region Plain solution: Just add new item to exists list without update to server
                var xe = new Xe()
                {
                    BienSo = BienSoStr
                    ,
                    LOAIXE_ID = LoaiXeInt
                };
                XeList.Insert(1, xe);
                XeListStrArray = XeList.Select(x => x.BienSo.ToLower()).ToArray();

                #endregion

                #region Chance to get new list
                backgroundWorker1.RunWorkerAsync();
                #endregion
            }
        }
        #endregion

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
            backgroundWorker3.Dispose();
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }

        private void btnCapLenh_Click(object sender, EventArgs e)
        {
            BienSoStr = drlBienSo.Text;
            LoaiXeInt = Convert.ToInt32(cbxLoaiXe.SelectedValue);
            NgayStr = txtThoiGian.Text;
            Tien = txtTien.Text;
            Loai = 200;
            if (string.IsNullOrEmpty(BienSoStr) || LoaiXeInt == 0) return;
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            drlBienSo.Text = "";
            drlBienSo.DroppedDown = false;
        }

        private void btnTraKhach_Click(object sender, EventArgs e)
        {
            BienSoStr = drlBienSo.Text;
            LoaiXeInt = Convert.ToInt32(cbxLoaiXe.SelectedValue);
            var item = LoaiXeList.FirstOrDefault(x => x.ID == LoaiXeInt);
            if (item != null)
            {
                Tien = item.MucThu.ToString();
                GiaoCa.DoanhThu += item.MucThu;
                lblTongSo.Text = GiaoCa.DoanhThu.TienVietNam();
            }
            
            NgayStr = txtThoiGian.Text;
            Loai = 100;


            if (string.IsNullOrEmpty(BienSoStr) || LoaiXeInt == 0) return;
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            drlBienSo.Text = "";
            drlBienSo.DroppedDown = false;
        }

        private void btnVangLLai_Click(object sender, EventArgs e)
        {
            BienSoStr = drlBienSo.Text;
            LoaiXeInt = Convert.ToInt32(cbxLoaiXe.SelectedValue);
            NgayStr = txtThoiGian.Text;
            GiaoCa.DoanhThu += txtTien.Text.ToMoney();
            lblTongSo.Text = GiaoCa.DoanhThu.TienVietNam();
            Tien = txtTien.Text;
            Loai = 0;
            if (string.IsNullOrEmpty(BienSoStr) || LoaiXeInt == 0) return;
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            drlBienSo.Text = "";
            drlBienSo.DroppedDown = false;
        }
        private void cbxLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLoaiXe.SelectedIndex == 1) return;
            if (cbxLoaiXe.SelectedValue == null) return;
            var id = 0;
            Int32.TryParse(cbxLoaiXe.SelectedValue.ToString(), out id);
            var item = LoaiXeList.FirstOrDefault(x => x.ID == id);
            if (item != null)
            {
                txtTien.Text = item.MucThu.TienVietNam();
            }
        }

        private void drlBienSo_TextChanged(object sender, EventArgs e)
        {
            var term = drlBienSo.Text;
            Debug.WriteLine(term);
            if (term.Length == 0 || term.Length > 20) term = "";
            #region binding 
            var list = string.IsNullOrEmpty(term)
                           ? XeListStrArray
                           : XeListStrArray.Where(x => x.ToLower().Contains(term.ToLower())).ToArray();

            if (list==null || !list.Any())
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
            #endregion
            Debug.WriteLine(term);
            if(term.Length==0) return;
            var item = XeList.FirstOrDefault(x => x.BienSo.ToLower() == term.ToLower());
            XeId = 0;
            if (item == null) return;
            Console.WriteLine(item.BienSo);
            cbxLoaiXe.SelectedValue = item.LOAIXE_ID;
            XeId = item.ID;
            if (!item.XeVangLai)
            {
                txtTien.Text = string.Empty;
                return;
            }
            var loaiXe = LoaiXeList.FirstOrDefault(x => x.ID == item.LOAIXE_ID);
            if (loaiXe != null)
            {
                txtTien.Text = loaiXe.MucThu.TienVietNam();
            }

        }
    }
}

