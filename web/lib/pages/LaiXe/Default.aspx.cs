using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_pages_LaiXe_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var DONVI_ID = Request["DONVI_ID"];
        var Size = Request["Size"];
        var LoaiBang = Request["LoaiBang"];
        Size = string.IsNullOrEmpty(Size) ? "20" : Size;
        var url = string.Format(
            "?q={0}&DONVI_ID={1}&LoaiBang={2}&Size={3}&"
            , q, DONVI_ID, LoaiBang, Size) + "{1}={0}";

        var pg = LaiXeDal.pagerNormal(url, false, null, q, Convert.ToInt32(Size), DONVI_ID, LoaiBang, null);
        List.Pager = pg;

    }
}