using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using CongVaoApp.BxVinh.WebSrv;

namespace CongVaoApp
{
    public partial class Login : Form
    {
        private string Username { get; set; }
        private string Pwd { get; set; }
        private bool IsCorrect { get; set; }
        private WebService Wsrv { get; set; }
        private Member User { get; set; }
        public Login()
        {
            InitializeComponent();
            Wsrv = new WebService();
            KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoLogin();
        }
        private void DoLogin()
        {
            Username = txtUsername.Text;
            Pwd = txtPwd.Text;
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Pwd))
            {
                if (!backgroundWorker1.IsBusy)
                {
                    button1.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Nhập Username và Password");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IsCorrect = Wsrv.Login(Username, Pwd);
                if (IsCorrect)
                {
                    User = Wsrv.MemberGetByUsername(Username);
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dịch vụ đang tạm lỗi, vui lòng kiểm tra máy chủ");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    DoLogin();
                    break;
            }
            return false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(IsCorrect)
            {
                this.Hide();
                var frm = new Form1(Username, User.Ten, User.CQ_ID, User.GiaoCa);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Username và Password không hợp lệ, vui lòng thử lại");
            }
            button1.Enabled = true;            
            backgroundWorker1.Dispose();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }
    }
}
