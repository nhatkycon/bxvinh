using System;
using System.Collections.Generic;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_ChamCong_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var XE_ID = Request["XE_ID"];
        var PHOI_ID = Request["PHOI_ID"];
        var NgayXuatBen = Request["NgayXuatBen"];
        if (string.IsNullOrEmpty(NgayXuatBen)) NgayXuatBen = DateTime.Now.ToString("dd/MM/yyyy");
        var q = Request["q"];
        switch (subAct)
        {
            case "BangChamCongTheoXe":
                #region BangChamCongTheoXe
                if(!string.IsNullOrEmpty(XE_ID))
                {
                    var month = DateTime.Now.Month;
                    var year = DateTime.Now.Year;
                    var prevMonth = month == 1 ? 12 : month - 1;
                    var tuNgay = new DateTime(year, prevMonth, 1).AddDays(-1);
                    var Xe = XeDal.SelectById(Convert.ToInt64(XE_ID));
                    var loaiBieuDo = LoaiBieuDoDal.SelectById(Xe.BIEUDO_ID);
                    var chamCongList = ChamCongDal.SelectByXeTuNgay(PHOI_ID, tuNgay.ToString("dd/MM/yyyy"), Xe.ID);
                    var chamCongListCurrent = new List<ChamCong>();

                    ChamCongCalendar_View.NgayXuatBen = NgayXuatBen;
                    ChamCongCalendar_View.ListChamCong = chamCongList;
                    ChamCongCalendar_View.ListChamCongCurrent = chamCongListCurrent;
                    ChamCongCalendar_View.LoaiBieuDo = loaiBieuDo;
                    ChamCongCalendar_View.Visible = true;
                }
                break;
                #endregion
            default:
                break;
        }
    }
}