using System;
using docsoft;
public partial class lib_master_Admin_Blank : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
        {
            Response.Redirect("~/lib/pages/Login.aspx?ret=" + Server.UrlEncode(Request.Url.PathAndQuery));
        }
    }
   
}
