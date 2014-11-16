using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
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

        var CHAMCONG_ID = Request["CHAMCONG_ID"];
        var CHAMCONG_GhiChu = Request["CHAMCONG_GhiChu"];
        var CHAMCONG_Tien = Request["CHAMCONG_Tien"];
        var CHAMCONG_TrangThaiNo = Request["CHAMCONG_TrangThaiNo"];

        //CHAMCONG_TrangThaiNo = string.IsNullOrEmpty(CHAMCONG_TrangThaiNo)
        //                           ? "true"
        //                           : "false";
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
                    var phoi = new Phoi() {XE_ID = Xe.ID};
                    ChamCongCalendar_View.Item = phoi;
                    ChamCongCalendar_View.NgayXuatBen = NgayXuatBen;
                    ChamCongCalendar_View.ListChamCong = chamCongList;
                    ChamCongCalendar_View.ListChamCongCurrent = chamCongListCurrent;
                    ChamCongCalendar_View.LoaiBieuDo = loaiBieuDo;
                    ChamCongCalendar_View.Visible = true;
                    ChamCongCalendar_View.TuNgay = tuNgay;
                    ChamCongCalendar_View.DenNgay = DateTime.Now;

                }
                break;
                #endregion
            case "BangCongNoTheoXe":
                #region BangCongNoTheoXe
                if (!string.IsNullOrEmpty(XE_ID))
                {
                    var chamCongList = ChamCongDal.NoByXeTuNgay(DAL.con(), null, Convert.ToInt64(XE_ID));
                    ThuNoList.XE_ID = XE_ID;
                    ThuNoList.List = chamCongList;
                    ThuNoList.Visible = chamCongList.Any();

                }
                break;
                #endregion
            case "updateAjaxTruyThuDuyetKetQua":
                #region updateAjaxTruyThuDuyetKetQua
                if(loggedIn && !string.IsNullOrEmpty(CHAMCONG_ID))
                {
                    var item = ChamCongDal.SelectById(Convert.ToInt64(CHAMCONG_ID));
                    if(!string.IsNullOrEmpty(CHAMCONG_Tien))
                    {
                        item.Tien = CHAMCONG_Tien.ToMoney();
                    }
                    item.TrangThaiNo = Convert.ToInt16(string.IsNullOrEmpty(CHAMCONG_TrangThaiNo) ? 2 : 1);
                    item.NgayCapNhat = DateTime.Now;
                    item.GhiChu = CHAMCONG_GhiChu;
                    item = ChamCongDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                rendertext("0");
                break;
                #endregion
            default:
                break;
        }
    }
}