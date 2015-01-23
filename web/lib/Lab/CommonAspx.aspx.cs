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
        //var d = DateTime.Now;
        //var str = "22:25:34 13/10/2014";
        //var d1 = Convert.ToDateTime(str, new CultureInfo("vi-Vn"));

        //Response.Write(d.ToString());
        //Response.Write("<hr/>");
        //Response.Write(d1.ToString());

        var docname = "1412011142-30P 6688-16-in";
        var firtsIndex = docname.IndexOf("-", System.StringComparison.Ordinal);
        var d = docname.Substring(0, firtsIndex);
        var y = d.Substring(0, 2);
        var m = d.Substring(2, 2);
        var day = d.Substring(4, 2);
        var file = docname.Substring(firtsIndex + 1);
        Response.Write(string.Format("{0}-{1}-{2}-{3}", file, y, m, day));
    }
}