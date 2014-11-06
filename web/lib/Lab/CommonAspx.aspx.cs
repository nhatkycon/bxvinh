using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_Lab_CommonAspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;
        var str = "22:25:34 13/10/2014";
        var d1 = Convert.ToDateTime(str, new CultureInfo("vi-Vn"));

        Response.Write(d.ToString());
        Response.Write("<hr/>");
        Response.Write(d1.ToString());
    }
}