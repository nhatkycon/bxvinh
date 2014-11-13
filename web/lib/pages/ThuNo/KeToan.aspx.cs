using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class lib_pages_ThuNo_KeToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var daThu = Request["DaThu"];
        var Size = Request["Size"];
        Size = string.IsNullOrEmpty(Size) ? "20" : Size;

        var url = string.Format(
            "?q={0}&DaThu={1}&Size={2}&"
            , q, daThu, Size) + "{1}={0}";

        var pg = ThuNoDal.PagerByCqId(url, false, "THUNO_ID desc", q, Convert.ToInt32(Size), Security.CqId, daThu);
        KeToan_List.Pg = pg;

    }
}