using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_TruyThu_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con = DAL.con())
        {
            var q = Request["q"];
            var deNghi = Request["deNghi"];
            var Size = Request["Size"];
            Size = string.IsNullOrEmpty(Size) ? "20" : Size;
            var uname = Security.Username;
            var duyet = Request["duyet"];
            var url = string.Format(
                "?q={0}&duyet={1}&Size={2}&DeNghi={3}"
                , q, duyet, Size, deNghi) + "{1}={0}";
            var pg = TruyThuDal.PagerByUserDuyet(con, url, false, "TRUYTHU_ID desc", q, Convert.ToInt32(Size), uname,
                                                 duyet, deNghi);
            List.Pager = pg;
        }
    }
}