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

        var Ngay = Request["Ngay"];
        var TangCuong = Request["TangCuong"];
        var PhoiId = Request["PhoiId"];

        var CHAMCONG_ID = Request["CHAMCONG_ID"];
        var CHAMCONG_GhiChu = Request["CHAMCONG_GhiChu"];
        var CHAMCONG_Tien = Request["CHAMCONG_Tien"];
        var CHAMCONG_TrangThaiNo = Request["CHAMCONG_TrangThaiNo"];

        var ChamCongTruyChuCkb = Request["ChamCongTruyChuCkb"];
        var GhiChu = Request["GhiChu"];
        var Loai = Request["Loai"];

        Loai = string.IsNullOrEmpty(Loai)
                                   ? "4"
                                   : "3";
        if (string.IsNullOrEmpty(NgayXuatBen)) NgayXuatBen = DateTime.Now.ToString("dd/MM/yyyy");
        var q = Request["q"];
        switch (subAct)
        {
            case "BangChamCongTheoXe":
                #region BangChamCongTheoXe
                if(!string.IsNullOrEmpty(XE_ID))
                {
                    using(var con = DAL.con())
                    {
                        var month = DateTime.Now.Month;
                        var year = DateTime.Now.Year;
                        var prevMonth = month == 1 ? 12 : month - 1;
                        var tuNgay = new DateTime(year, prevMonth, 1);
                        var Xe = XeDal.SelectById(con, Convert.ToInt64(XE_ID));
                        var loaiBieuDo = LoaiBieuDoDal.SelectById(con, Xe.BIEUDO_ID);
                        var chamCongList = ChamCongDal.SelectByXeTuNgay(con, PHOI_ID, tuNgay.ToString("dd/MM/yyyy"), Xe.ID);
                        var chamCongListCurrent = new List<ChamCong>();
                        var phoi = new Phoi() { XE_ID = Xe.ID };
                        phoi.Xe = Xe;
                        ChamCongCalendar_View.Item = phoi;
                        ChamCongCalendar_View.NgayXuatBen = NgayXuatBen;
                        ChamCongCalendar_View.ListChamCong = chamCongList;
                        ChamCongCalendar_View.ListChamCongCurrent = chamCongListCurrent;
                        ChamCongCalendar_View.LoaiBieuDo = loaiBieuDo;
                        ChamCongCalendar_View.Visible = true;
                        ChamCongCalendar_View.TuNgay = tuNgay;
                        ChamCongCalendar_View.DenNgay = DateTime.Now;
                    }
                   

                }
                break;
                #endregion
            case "LuuChamCongDraff":
                #region LuuChamCongDraff
                if (!string.IsNullOrEmpty(PhoiId) && loggedIn)
                {
                    var item = new ChamCong();
                    item.PHOI_ID = Convert.ToInt64(PhoiId);
                    item.Ngay = Convert.ToDateTime(Ngay, new CultureInfo("Vi-vn"));
                    item.TangCuong = Convert.ToBoolean(TangCuong);
                    item.Draff = true;
                    item.NgayTao = DateTime.Now;
                    item.Username = Security.Username;
                    item.CQ_ID = Security.CqId;
                    item.Loai = 3;
                    item = ChamCongDal.Insert(item);
                    AddPhoiListItem.Item = item;
                    AddPhoiListItem.Visible = true;

                }
                break;
                #endregion
            case "UpdateChamCongDraff":
                #region UpdateChamCongDraff
                if (!string.IsNullOrEmpty(Id) && loggedIn)
                {
                    var item = ChamCongDal.SelectById(Convert.ToInt64(Id));
                    item.GhiChu = GhiChu;
                    if(!string.IsNullOrEmpty(ChamCongTruyChuCkb))
                    {
                        item.Loai = 3;
                    }
                    else
                    {
                        item.Loai = 2;
                    }
                    item.NgayCapNhat = DateTime.Now;
                    ChamCongDal.Update(item);
                }
                break;
                #endregion
            case "XoaChamCongDraff":
                #region XoaChamCongDraff
                if (!string.IsNullOrEmpty(Id) && loggedIn)
                {
                    ChamCongDal.DeleteById(Convert.ToInt64(Id));
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
                    item.Loai = Convert.ToInt16(Loai);
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