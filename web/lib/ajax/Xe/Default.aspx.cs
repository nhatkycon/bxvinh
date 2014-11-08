using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using docsoft;
using docsoft.entities;
using linh.json;


public partial class lib_ajax_Xe_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var BienSo_Chu = Request["BienSo_Chu"];
        var BienSo_So = Request["BienSo_So"];
        var LOAIXE_ID = Request["LOAIXE_ID"];
        var TUYEN_ID = Request["TUYEN_ID"];
        var DONVI_ID = Request["DONVI_ID"];

        var LOAIXE_Ten = Request["LOAIXE_Ten"];
        var TUYEN_Ten = Request["TUYEN_Ten"];
        var DONVI_Ten = Request["DONVI_Ten"];
        var NamSanXuat = Request["NamSanXuat"];
        var NgayXuatBen = Request["NgayXuatBen"];
        var TuyenCoDinh = Request["TuyenCoDinh"];
        var LuuHanh = Request["LuuHanh"];
        var Ghe = Request["Ghe"];
        var SoKhach = Request["SoKhach"];
        var MucPhi = Request["MucPhi"];
        var GiaVe = Request["GiaVe"];
        var GioXuatBen = Request["GioXuatBen"];
        var XeVangLai = Request["XeVangLai"];
        var XeTai = Request["XeTai"];
        var BaoHiem = Request["BaoHiem"];
        var BIEUDO_ID = Request["BIEUDO_ID"];
        var ChuaDangKy = Request["ChuaDangKy"];
        var Khoa = Request["Khoa"];
        var XVB_ID = Request["XVB_ID"];
        var q = Request["q"];

        //For search
        var VangLai = Request["XeVangLai"];

        XeVangLai = !string.IsNullOrEmpty(XeVangLai)
                      ? "true"
                      : "false";

        XeTai = !string.IsNullOrEmpty(XeTai)
                      ? "true"
                      : "false";

        Khoa = !string.IsNullOrEmpty(Khoa)
                      ? "true"
                      : "false";

        ChuaDangKy = !string.IsNullOrEmpty(ChuaDangKy)
                      ? "true"
                      : "false";

        var Inserted = string.IsNullOrEmpty(Id);

        switch (subAct)
        {
            case "save":
                #region save

                if (!loggedIn || !string.IsNullOrEmpty(BienSo_Chu) || !string.IsNullOrEmpty(BienSo_So))
                {
                    var Item = Inserted ? new Xe() : XeDal.SelectById(Convert.ToInt32(Id));

                    Item.BienSo_Chu = BienSo_Chu;
                    Item.BienSo_So = BienSo_So;
                    Item.LOAIXE_ID = Convert.ToInt32(LOAIXE_ID);
                    Item.TUYEN_ID = Convert.ToInt32(TUYEN_ID);
                    Item.DONVI_ID = Convert.ToInt32(DONVI_ID);
                    Item.TuyenCoDinh = Convert.ToDateTime(TuyenCoDinh, new CultureInfo("vi-vn"));
                    Item.LuuHanh = Convert.ToDateTime(LuuHanh, new CultureInfo("vi-vn"));
                    Item.BaoHiem = Convert.ToDateTime(BaoHiem, new CultureInfo("vi-vn"));

                    Item.Ghe = Convert.ToInt16(Ghe);
                    Item.SoKhach = Convert.ToInt16(SoKhach);
                    Item.MucPhi = Convert.ToDouble(MucPhi);
                    Item.GiaVe = Convert.ToDouble(GiaVe);
                    Item.NamSanXuat = Convert.ToInt16(NamSanXuat);
                    Item.GioXuatBen = GioXuatBen;
                    Item.BIEUDO_ID = Convert.ToInt32(BIEUDO_ID);

                    Item.XeTai = Convert.ToBoolean(XeTai);
                    Item.XeVangLai = Convert.ToBoolean(XeVangLai);
                    Item.Khoa = Convert.ToBoolean(Khoa);
                    
                    if(Item.ID != 0 && Item.ChuaDangKy && Convert.ToBoolean(ChuaDangKy)) // Đăng ký mới lần đầu
                    {
                        XeVaoBenDal.UpdateXeChuaDangKy(Item.ID);
                    }

                    Item.ChuaDangKy = !Convert.ToBoolean(ChuaDangKy);
                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        SearchManager.Add(string.Format("{0} {1}", Item.BienSo_Chu, Item.BienSo_So)
                            , string.Format("{0} {1} {2} {3} {4}", Item.BienSo_Chu, Item.BienSo_So, DONVI_Ten, TUYEN_Ten, LOAIXE_Ten)
                            , string.Format("{0} {1}", Item.BienSo_Chu, Item.BienSo_So)
                            , Item.RowId.ToString()
                            , Item.Url
                            , typeof(Xe).Name);
                    }

                    Item.NgayCapNhat = DateTime.Now;
                    Item = Inserted ? XeDal.Insert(Item) : XeDal.Update(Item);
                    rendertext(Item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion
            case "remove":
                #region remove
                if (loggedIn)
                {
                    var Item = XeDal.SelectById(Convert.ToInt32(Id));
                    if (Item.Username == Security.Username)
                    {
                        XeDal.DeleteById(Item.ID);
                        rendertext("0");
                    }
                }
                rendertext("-1");
                break;
                #endregion
            case "GetById":
                #region GetById
                if (!string.IsNullOrEmpty(Id))
                {
                    var Item = XeDal.SelectById(Convert.ToInt32(Id));
                    Item.Tuyen = TuyenDal.SelectById(Item.TUYEN_ID);
                    Item.LoaiBieuDo = LoaiBieuDoDal.SelectById(Item.BIEUDO_ID);
                    Item.LaiXe = LaiXeDal.SelectByXeId(Item.ID);
                    
                    var ngay = DateTime.Now;
                    if(!string.IsNullOrEmpty(NgayXuatBen))
                    {
                        ngay = Convert.ToDateTime(ngay, new CultureInfo("Vi-vn"));
                    }
                    var ngaySoSanh = ngay.AddDays(BxVinhConfig.SoNgayHetHan);
                    Item.HopLeAll = (ngaySoSanh < Item.BaoHiem) && (ngaySoSanh < Item.LuuHanh) &&
                                    (ngaySoSanh < Item.BaoHiem);

                    if(!string.IsNullOrEmpty(XVB_ID))
                    {
                        var xvb = XeVaoBenDal.SelectById(Convert.ToInt64(XVB_ID));
                        xvb.TrangThai = 300;
                        xvb.NgayXuLyYeuCau = DateTime.Now;
                        xvb.NgayCapNhat = DateTime.Now;
                        xvb = XeVaoBenDal.Update(xvb);
                    }

                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(Item)));
                }
                rendertext("-1");
                break;
                #endregion
            case "search":
                #region search
                var pgResult = XeTinyDal.SearchSQL(q, VangLai);
                rendertext(JavaScriptConvert.SerializeObject(pgResult), "text/javascript");
                break;
                #endregion
            default:
                break;
        }
    }
}