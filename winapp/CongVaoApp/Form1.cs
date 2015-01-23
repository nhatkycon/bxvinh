using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using CongVaoApp.BxVinh.WebSrv;
using Emgu.CV;
using linh.common;
using System.IO;
using SilverSea.Sockets;
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


        private SocketClient socketClient = null;
        private string serverIP = "127.0.0.1";
        private int serverPort = 50000;


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
            //imageBox3.Image = imageFrame;        //line 2
            //imageBox4.Image = imageFrame;        //line 2
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            drlBienSo.Enabled = cbxLoaiXe.Enabled = false;
            KeyPreview = true;
            timer2.Enabled = false;
            if (!IsServiceInstalled("ANPRService"))
            {
                MessageBox.Show("ANPR service chưa được cài đặt. Vui lòng cài đặt ANPR service trước");
                Application.Exit();
            }
            StartSocketClient();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtThoiGian.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            this.Name = string.Format("{0}-{1}", socketClient.IsRunning, GetServiceStatus());
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
                            //capture = new Capture();
                            capture = new Capture(@"rtsp://192.168.1.10:554/rtsph264480p");
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
                case Keys.F5:
                    XuLyBienSo();
                    return true;
                    break;
                case Keys.F4:
                    timer2.Enabled = true;
                    return true;
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
            backgroundWorker4.RunWorkerAsync();
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
                //backgroundWorker1.RunWorkerAsync();
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
            StopSocketClient();
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
            SetControlPropertyValue(drlBienSo, "Text", "");
            SetControlPropertyValue(drlBienSo, "DroppedDown", false);
            SetControlPropertyValue(cbxLoaiXe, "Text", "");
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
            cbxLoaiXe.Text = "";
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
            cbxLoaiXe.Text = "";
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

        #region socket
        private void XuLyBienSo()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //var image = capture.QueryFrame().ToBitmap();
                var image = Bitmap.FromFile(openFileDialog1.FileName);
                if (image != null)
                {
                    if (socketClient != null && socketClient.IsRunning)
                    {
                        // [file name length][file name] [file data]
                        // Buffering ...
                        var fileNameByte = Encoding.UTF8.GetBytes("CM10");
                        var fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                        var fileData = GetByteArray(image);

                        var byteToSends = new byte[4 + fileNameByte.Length + fileData.Length];

                        fileNameLen.CopyTo(byteToSends, 0);
                        fileNameByte.CopyTo(byteToSends, 4);
                        fileData.CopyTo(byteToSends, 4 + fileNameByte.Length);
                        socketClient.SendMessage(byteToSends);
                    }
                    else
                    {
                        MessageBox.Show("ANPR service chưa chạy, thử lại trong vài giây");
                        StartService("ANPRService",1000);
                    }
                }
            }
        }
        public static byte[] GetByteArray(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            byte[] bytearray = ms.ToArray();
            return bytearray;
        }
        // Get image from byte array
        public static Image GetImage(byte[] bytearray)
        {
            try
            {
                if (bytearray != null)
                {
                    MemoryStream mem = new MemoryStream();
                    mem.Write(bytearray, 0, bytearray.Length);
                    Image image = Image.FromStream(mem);
                    return image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occur while get image from byte array: " + ex.Message);
            }
            return null;
        }
        #endregion



        #region ARPN
        private bool IsServiceInstalled(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
                if (service.ServiceName == serviceName) return true;
            return false;
        }

        // get service status
        private string GetServiceStatus()
        {
            try
            {
                ServiceController sc = new ServiceController("ANPRService");

                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        return "Running";
                    case ServiceControllerStatus.Stopped:
                        return "Stopped";
                    case ServiceControllerStatus.Paused:
                        return "Paused";
                    case ServiceControllerStatus.StopPending:
                        return "Stopping";
                    case ServiceControllerStatus.StartPending:
                        return "Starting";
                    default:
                        return "Status Changing";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return "Get Status Fail";
        }
        #endregion

        #region socket client
        // start socket client
        private void StartSocketClient()
        {
            socketClient = new SocketClient();
            if (socketClient != null)
            {
                socketClient.ServerIP = serverIP;
                socketClient.ServerPort = serverPort;
                socketClient.DataReceivedInStringEvent += new DataReceivedInStringEventHandler(socketClient_DataReceivedEvent5);
                socketClient.DataReceivedInByteArrayEvent += socketClient_DataReceivedInByteArrayEvent5;
                socketClient.SocketErrorEvent += new SocketErrorEventHandler(socketClient_SocketErrorEvent5);
                socketClient.Connect();
                string message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " SOCKET CLIENT START";
                SetText(message);
            }
        }


        // socket data event
        private void socketClient_DataReceivedEvent5(string receivedString)
        {
            // Currently empty
        }

        private void socketClient_DataReceivedInByteArrayEvent5(byte[] dataReceived, int dataLength, string clientIP)
        {
            try
            {
                if (dataReceived.Length > 1024)
                {
                    // [file name length][file name][file data]
                    int fileNameLen = BitConverter.ToInt32(dataReceived, 0); // 4 byte dau tien
                    string fileName = Encoding.UTF8.GetString(dataReceived, 4, fileNameLen);

                    string message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " RECV: " + fileName + "[image data]";
                    SetText(message);

                    byte[] buff = new byte[dataReceived.Length - 4 - fileNameLen];
                    Array.Copy(dataReceived, 4 + fileNameLen, buff, 0, buff.Length);

                    if (string.IsNullOrEmpty(fileName))
                    {
                        MessageBox.Show("Không nhận diễn được biển số, vui lòng thử lại");
                        return;
                    }
                    var bienSoStr = fileName.Substring(4);
                    var count = bienSoStr.Count(f => f == '-');
                    if (count > 1)
                    {
                        var firstIndex = bienSoStr.IndexOf("-");
                        bienSoStr = bienSoStr.Substring(0, firstIndex) + bienSoStr.Substring(firstIndex + 1);
                    }
                    bienSoStr = bienSoStr.Replace("-", " ");
                    SetControlPropertyValue(drlBienSo, "Text", bienSoStr);
                    SetControlPropertyValue(picBienSo, "Image", GetImage(buff));
                }else
                {
                    //MessageBox.Show("Không nhận diễn được biển số, vui lòng thử lại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // set Image
        private void SetImage(PictureBox pic, string text)
        {
            if (pic.InvokeRequired)
            {
                pic.Invoke(new MethodInvoker(delegate { SetImage(pic, text); }));
                return;
            }
            pic.Image = Image.FromFile(text);
        }

        // socket error event
        private void socketClient_SocketErrorEvent5(string errorString)
        {
            SetText("ERROR: " + errorString);
        }

        // stop socket client
        private void StopSocketClient()
        {
            if (socketClient != null)
            {
                socketClient.DataReceivedInStringEvent -= new DataReceivedInStringEventHandler(socketClient_DataReceivedEvent5);
                socketClient.DataReceivedInByteArrayEvent -= socketClient_DataReceivedInByteArrayEvent5;
                socketClient.SocketErrorEvent -= new SocketErrorEventHandler(socketClient_SocketErrorEvent5);

                socketClient.Disconnect();
                string message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " SOCKET CLIENT STOPPED";
                SetText(message);
            }
        }

        // set text
        private void SetText(string text)
        {
            
        }

        #region Set Control Value (Using in Thread Safe)
        delegate void SetControlValueCallback(Control control, string propertyName, object propertyValue);
        public void SetControlPropertyValue(Control control, string propertyName, object propertyValue)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                    control.Invoke(d, new object[] { control, propertyName, propertyValue });
                }
                else
                {
                    Type t = control.GetType();
                    System.Reflection.PropertyInfo[] props = t.GetProperties();
                    foreach (System.Reflection.PropertyInfo p in props)
                    {
                        if (p.Name.ToUpper() == propertyName.ToUpper())
                        {
                            p.SetValue(control, propertyValue, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #endregion

        private void StartService(string serviceName, int timeoutMilliseconds)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void StopService(string serviceName, int timeoutMilliseconds)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                if (service.Status == ServiceControllerStatus.Running)
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void RestartService(string serviceName, int timeoutMilliseconds)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);

                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {           
            var image = capture.QueryFrame().ToBitmap();
            //var image = Bitmap.FromFile(openFileDialog1.FileName);
            if (image != null)
            {
                if (socketClient != null && socketClient.IsRunning)
                {
                    // [file name length][file name] [file data]
                    // Buffering ...
                    var fileNameByte = Encoding.UTF8.GetBytes("CM10");
                    var fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                    var fileData = GetByteArray(image);

                    var byteToSends = new byte[4 + fileNameByte.Length + fileData.Length];

                    fileNameLen.CopyTo(byteToSends, 0);
                    fileNameByte.CopyTo(byteToSends, 4);
                    fileData.CopyTo(byteToSends, 4 + fileNameByte.Length);
                    socketClient.SendMessage(byteToSends);
                }
                else
                {
                    MessageBox.Show("ANPR service chưa chạy, thử lại trong vài giây");
                    StartService("ANPRService", 1000);
                }
            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            var img = picBienSo.Image;
            var bytes = GetByteArray(img);
            var ten = string.Format("{0:yyMMddHHmm}-{1}-{2}-{3}-{4}-in.jpg", DateTime.Now, DonVi_Id, Username, BienSoStr, XeVaoBenInsertRs);
            Wsrv.LuuBienSo(bytes, ten);
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControlPropertyValue(picBienSo, "Image", null);
            backgroundWorker4.Dispose();
        }
    }
}

