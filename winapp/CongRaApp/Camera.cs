using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;

namespace CongRaApp
{
    public partial class Camera : Form
    {
        private Capture Capture;
        private DateTime StartTime;
        public Camera()
        {
            InitializeComponent();
            StartTime = DateTime.Now;
            //Capture = new Capture("rtsp://192.168.1.10:554/rtsph264480p"); //create a camera captue

            //Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
            //{  //run this until application closed (close button click on image viewer)

            //    //draw the image obtained from camera
            //    imageBox1.Image = Capture.QueryFrame();
            //});
            picBienSo.Image = Bitmap.FromFile(@"C:\Users\LINH\Desktop\Bien-so\a1069322-dbaa-4715-9b6e-7ab90a9f641a.jpg");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0:HH:mm:ss} - {1:HH:mm:ss} - {2}", StartTime, DateTime.Now,
                                        (DateTime.Now - StartTime).TotalMinutes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picBienSo.Image = Capture.QueryFrame().ToBitmap();
        }

        private void ProcessBienSo()
        {
            var host = IPAddress.Parse("127.0.0.1");
            var hostep = new IPEndPoint(host, 50000);
            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(hostep);

            var image = picBienSo.Image;
            byte[] fileNameByte = Encoding.UTF8.GetBytes("CM10");
            byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
            byte[] fileData = GetByteArray(image);

            byte[] byteToSends = new byte[4 + fileNameByte.Length + fileData.Length];

            fileNameLen.CopyTo(byteToSends, 0);
            fileNameByte.CopyTo(byteToSends, 4);
            fileData.CopyTo(byteToSends, 4 + fileNameByte.Length);

            sock.Send(byteToSends);


            var buffer = new byte[8012];
            int bytes = sock.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            int totalBytesRec = 0;
            
            if (buffer.Length > 1024)
            {
                // [file name length][file name][file data]
                int newFileNameLen = BitConverter.ToInt32(buffer, 0); // 4 byte dau tien
                string fileName = Encoding.UTF8.GetString(buffer, 4, newFileNameLen);

                byte[] buff = new byte[buffer.Length - 4 - newFileNameLen];
                Array.Copy(buffer, 4 + newFileNameLen, buff, 0, buff.Length);

                lblBienSo.Text = fileName.Substring(4);
                picRs.Image = GetImage(buff);
            }

            sock.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessBienSo();
        }
    }
}
