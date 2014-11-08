using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Phoi_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            var q = Request["q"];
            var size = Request["Size"];
            size = string.IsNullOrEmpty(size) ? "20" : size;
            var uname = Security.Username;
            var donVi_id = Request["donVi_id"];
            var xe_id = Request["xe_id"];
            var nguoiTao = Request["nguoiTao"];
            var tuNgay = Request["tuNgay"];
            var denNgay = Request["denNgay"];
            var url = string.Format(
                "?q={0}&Size={2}&donVi_id={3}&xe_id={4}&nguoiTao={5}&tuNgay={6}&denNgay={7}&"
                , q, "", size, donVi_id, xe_id, nguoiTao, tuNgay, denNgay) + "{1}={0}";
            var giaoCa = Request["GiaoCa"];
            var pg = PhoiDal.PagerByUser(con, url, false, "PHOI_ID desc", q
                , Convert.ToInt32(size), uname, giaoCa
                , donVi_id, xe_id, nguoiTao, tuNgay, denNgay);
            List.Pager = pg;
        }
    }
}