using System;
using docsoft;

public partial class lib_ui_HeThong_LoginForm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Pwd.Text))
        {
            msg.Visible = true;
            return;

        }
        var ok = Security.Login(Username.Text, Pwd.Text, ckb.Checked.ToString());
        if (ok)
        {
            var ret = Request["ret"];
            Response.Redirect(string.IsNullOrEmpty(ret) ? "/KhachHang/" : Server.UrlDecode(ret));
        }
        else
        {
            msg.Visible = true;
        }
    }

}