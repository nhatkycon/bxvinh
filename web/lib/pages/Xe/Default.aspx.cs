using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_pages_Xe_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var LOAIXE_ID = Request["LOAIXE_ID"];
        var DONVI_ID = Request["DONVI_ID"];
        var TUYEN_ID = Request["TUYEN_ID"];
        var LuuHanh = Request["LuuHanh"];
        var TuyenCoDinh = Request["TuyenCoDinh"];
        var ChuaDangKy = Request["ChuaDangKy"];
        var XeVangLai = Request["XeVangLai"];
        var Ghe = Request["Ghe"];
        var Size = Request["Size"];
        Size = string.IsNullOrEmpty(Size) ? "20" : Size;

        var url = string.Format(
            "?q={0}&LOAIXE_ID={1}&DONVI_ID={2}&TUYEN_ID={3}&LuuHanh={4}&TuyenCoDinh={5}&Ghe={6}&Size={7}&ChuaDangKy={8}&XeVangLai={9}&"
            , q, LOAIXE_ID, DONVI_ID, TUYEN_ID, LuuHanh, TuyenCoDinh, Ghe, Size, ChuaDangKy, XeVangLai) + "{1}={0}";

        var pg = XeDal.pagerNormal(url, false, null, q, Convert.ToInt32(Size), TUYEN_ID, DONVI_ID, LOAIXE_ID, Ghe,
                                   LuuHanh, TuyenCoDinh, XeVangLai, ChuaDangKy);
        List.Pager = pg;
    }
}