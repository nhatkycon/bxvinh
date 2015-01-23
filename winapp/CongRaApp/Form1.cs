using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using CongRaApp.BxVinh.WebSrv;
using linh.common;
using Emgu.CV;
using Emgu.CV.CvEnum;
using SilverSea.Sockets;
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
        private void ProcessFrame(object sender, EventArgs arg)
        {
            var imageFrame = capture.QueryFrame();  //line 1
            imageBox1.Image = imageFrame;        //line 2
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if(this.ActiveControl==drlBienSo)
            //{
            //    return false;
            //}
            switch (keyData)
            {
                case Keys.Alt | Keys.F:
                    #region View Camera
                    #region if capture is not created, create it now
                    if (capture == null)
                    {
                        try
                        {
                            capture = new Capture(@"rtsp://192.168.1.11:554/rtsph264480p");
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
                case Keys.F4:
                    timer2.Enabled = true;
                    return true;
                    break;
                case Keys.F5:
                    XuLyBienSo();
                    return true;
                    break;
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
            picBienSo.Image = null;
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
            StopSocketClient();
            StopSocketClient();
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            drlBienSo.Enabled =  false;
            KeyPreview = true;
            timer2.Enabled = false;
            if (!IsServiceInstalled("ANPRService"))
            {
                MessageBox.Show("ANPR service chưa được cài đặt. Vui lòng cài đặt ANPR service trước");
                Application.Exit();
            }
            StartSocketClient();

        }


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
                }
            }
        }

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
                socketClient.DataReceivedInStringEvent += new DataReceivedInStringEventHandler(socketClient_DataReceivedEvent3);
                socketClient.DataReceivedInByteArrayEvent += socketClient_DataReceivedInByteArrayEvent3;
                socketClient.SocketErrorEvent += new SocketErrorEventHandler(socketClient_SocketErrorEvent3);
                socketClient.Connect();
                string message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " SOCKET CLIENT START";
                SetText(message);
            }
        }


        // socket data event
        private void socketClient_DataReceivedEvent3(string receivedString)
        {
            // Currently empty
        }

        private void socketClient_DataReceivedInByteArrayEvent3(byte[] dataReceived, int dataLength, string clientIP)
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
                }
                else
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
        private void socketClient_SocketErrorEvent3(string errorString)
        {
            SetText("ERROR: " + errorString);
        }

        // stop socket client
        private void StopSocketClient()
        {
            if (socketClient != null)
            {
                socketClient.DataReceivedInStringEvent -= new DataReceivedInStringEventHandler(socketClient_DataReceivedEvent3);
                socketClient.DataReceivedInByteArrayEvent -= socketClient_DataReceivedInByteArrayEvent3;
                socketClient.SocketErrorEvent -= new SocketErrorEventHandler(socketClient_SocketErrorEvent3);

                socketClient.Disconnect();
                string message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " SOCKET CLIENT STOPPED";
                SetText(message);
            }
        }

        // set text
        private void SetText(string text)
        {

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

        #endregion
    }
}
