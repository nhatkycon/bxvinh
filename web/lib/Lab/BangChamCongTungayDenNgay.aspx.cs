using System;
using System.Collections.Generic;
using docsoft.entities;
public partial class lib_Lab_BangChamCongTungayDenNgay : System.Web.UI.Page
{
    public LoaiBieuDo BieuDo { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var XE_ID = Request["XE_ID"];
        var PHOI_ID = Request["PHOI_ID"];
        if (!string.IsNullOrEmpty(XE_ID))
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var prevMonth = month == 1 ? 12 : month - 1;
            var tuNgay = new DateTime(year, prevMonth, 1).AddDays(-1);
            var Xe = XeDal.SelectById(Convert.ToInt64(XE_ID));
            var LoaiBieuDo = LoaiBieuDoDal.SelectById(Xe.BIEUDO_ID);
            var chamCongList = ChamCongDal.SelectByXeTuNgay(PHOI_ID, tuNgay.ToString("dd/MM/yyyy"), Xe.ID);
            var chamCongListCurrent = new List<ChamCong>();

            ChamCongCalendar_View.ListChamCong = chamCongList;
            ChamCongCalendar_View.ListChamCongCurrent = chamCongListCurrent;
            ChamCongCalendar_View.LoaiBieuDo = LoaiBieuDo;
            ChamCongCalendar_View.Visible = true;
            ChamCongCalendar_View.TuNgay = tuNgay;
            ChamCongCalendar_View.DenNgay = DateTime.Now;
            BieuDo = LoaiBieuDo;
        }
    }
}