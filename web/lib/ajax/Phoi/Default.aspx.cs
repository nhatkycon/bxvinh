using System;
using System.Globalization;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_Phoi_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var STTBX = Request["STTBX"];
        var STTALL = Request["STTALL"];
        var NgayXuatBen = Request["NgayXuatBen"];
        var XE_BienSo = Request["XE_BienSo"];
        var XE_ID = Request["XE_ID"];
        var LAIXE_Ten = Request["LAIXE_Ten"];
        var LAIXE_ID = Request["LAIXE_ID"];
        var DONVI_Ten = Request["DONVI_Ten"];
        var DI_Ten = Request["DI_Ten"];
        var DEN_Ten = Request["DEN_Ten"];
        var GioXuatBen = Request["GioXuatBen"];
        var XeThayThe_BienSo = Request["XeThayThe_BienSo"];
        var XeThayThe_ID = Request["XeThayThe_ID"];
        var PHI_BenBai = Request["PHI_BenBai"];
        var PHI_XeDauDem = Request["PHI_XeDauDem"];
        var PHI_VeSinhBenBai = Request["PHI_VeSinhBenBai"];
        var GiaVe = Request["GiaVe"];
        var HoaHongBanVe = Request["HoaHongBanVe"];
        var PhiTrenMotVe = Request["PhiTrenMotVe"];
        var Ve = Request["Ve"];
        var PHI_HoaHongBanVe = Request["PHI_HoaHongBanVe"];
        var KhachTruyThu = Request["KhachTruyThu"];
        var PHI_KhachTruyThu = Request["PHI_KhachTruyThu"];
        var PHI_XeLuuBen = Request["PHI_XeLuuBen"];
        var PHI_ChuyenTruyThu = Request["PHI_ChuyenTruyThu"];
        var ChuyenTruyThu = Request["ChuyenTruyThu"];
        var PHI_TruyThuGiam = Request["PHI_TruyThuGiam"];
        var PHI_Khac = Request["PHI_Khac"];
        var PHI_Tong = Request["PHI_Tong"];
        var PHI_Nop = Request["PHI_Nop"];
        var PHI_ConNo = Request["PHI_ConNo"];
        var SoChuyenBieuDo = Request["SoChuyenBieuDo"];
        var DeNghi = Request["DeNghi"];
        var SoChuyenDeNghi = Request["SoChuyenDeNghi"];
        var NOIDUNG_Ten = Request["NOIDUNG_Ten"];
        var NOIDUNG_ID = Request["NOIDUNG_ID"];
        var DANHGIA_Ten = Request["DANHGIA_Ten"];
        var DANHGIA_ID = Request["DANHGIA_ID"];
        var TRUYTHU_ID = Request["TRUYTHU_ID"];
        var DeNghiCuaNhaXe = Request["DeNghiCuaNhaXe"];
        var GiaTienDichVuTrongHopDong = Request["GiaTienDichVuTrongHopDong"];
        var TongTruyThu = Request["TongTruyThu"];
        var GiamTru = Request["GiamTru"];
        var ConLai = Request["ConLai"];
        var q = Request["q"];
        var NgayChamCong = Request["NgayChamCong"];

        var XeTangCuong = Request["XeTangCuong"];

        XeTangCuong = !string.IsNullOrEmpty(XeTangCuong)
                      ? "true"
                      : "false";

        var XeThayThe = Request["XeThayThe"];

        XeThayThe = !string.IsNullOrEmpty(XeThayThe)
                      ? "true"
                      : "false";



        var Inserted = string.IsNullOrEmpty(Id);

        switch (subAct)
        {
            case "save":

                #region save

                if (!loggedIn || !string.IsNullOrEmpty(STTBX) || !string.IsNullOrEmpty(XE_BienSo))
                {
                    var Item = Inserted ? new Phoi() : PhoiDal.SelectById(Convert.ToInt64(Id));

                    if (!string.IsNullOrEmpty(STTBX))
                    {
                        Item.STTBX = Convert.ToInt64(STTBX);
                    }
                    if (!string.IsNullOrEmpty(STTALL))
                    {
                        Item.STTALL = Convert.ToInt64(STTALL);
                    }
                    if (!string.IsNullOrEmpty(NgayXuatBen))
                    {
                        Item.NgayXuatBen = Convert.ToDateTime(NgayXuatBen, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(XE_ID))
                    {
                        Item.XE_ID = Convert.ToInt64(XE_ID);
                    }
                    if (!string.IsNullOrEmpty(LAIXE_ID))
                    {
                        Item.LAIXE_ID = Convert.ToInt64(LAIXE_ID);
                    }
                    if (!string.IsNullOrEmpty(XeThayThe_ID))
                    {
                        Item.XeThayThe_ID = Convert.ToInt64(XeThayThe_ID);
                    }
                    // PHI
                    if (!string.IsNullOrEmpty(PHI_BenBai))
                    {
                        Item.PHI_BenBai = Convert.ToDouble(PHI_BenBai);
                    }
                    if (!string.IsNullOrEmpty(PHI_XeDauDem))
                    {
                        Item.PHI_XeDauDem = Convert.ToDouble(PHI_XeDauDem);
                    }
                    if (!string.IsNullOrEmpty(PHI_VeSinhBenBai))
                    {
                        Item.PHI_VeSinhBenBai = Convert.ToDouble(PHI_VeSinhBenBai);
                    }
                    if (!string.IsNullOrEmpty(GiaVe))
                    {
                        Item.GiaVe = Convert.ToDouble(GiaVe);
                    }
                    if (!string.IsNullOrEmpty(Ve))
                    {
                        Item.Ve = Convert.ToInt16(Ve);
                    }
                    if (!string.IsNullOrEmpty(PHI_HoaHongBanVe))
                    {
                        Item.PHI_HoaHongBanVe = Convert.ToDouble(PHI_HoaHongBanVe);
                    }
                    if (!string.IsNullOrEmpty(KhachTruyThu))
                    {
                        Item.KhachTruyThu = Convert.ToInt16(KhachTruyThu);
                    }
                    if (!string.IsNullOrEmpty(PHI_KhachTruyThu))
                    {
                        Item.PHI_KhachTruyThu = Convert.ToDouble(PHI_KhachTruyThu);
                    }
                    if (!string.IsNullOrEmpty(PHI_XeLuuBen))
                    {
                        Item.PHI_XeLuuBen = Convert.ToDouble(PHI_XeLuuBen);
                    }
                    if (!string.IsNullOrEmpty(ChuyenTruyThu))
                    {
                        Item.ChuyenTruyThu = Convert.ToInt16(ChuyenTruyThu);
                    }
                    if (!string.IsNullOrEmpty(PHI_ChuyenTruyThu))
                    {
                        Item.PHI_ChuyenTruyThu = Convert.ToDouble(PHI_ChuyenTruyThu);
                    }

                    if (!string.IsNullOrEmpty(PHI_TruyThuGiam))
                    {
                        Item.PHI_TruyThuGiam = Convert.ToDouble(PHI_TruyThuGiam);
                    }
                    if (!string.IsNullOrEmpty(PHI_Khac))
                    {
                        Item.PHI_Khac = Convert.ToDouble(PHI_Khac);
                    }
                    if (!string.IsNullOrEmpty(PHI_Tong))
                    {
                        Item.PHI_Tong = Convert.ToDouble(PHI_Tong);
                    }
                    if (!string.IsNullOrEmpty(PHI_Nop))
                    {
                        Item.PHI_Nop = Convert.ToDouble(PHI_Nop);
                    }
                    if (!string.IsNullOrEmpty(PHI_ConNo))
                    {
                        Item.PHI_ConNo = Convert.ToDouble(PHI_ConNo);
                    }
                    Item.XeThayThe = Convert.ToBoolean(XeThayThe);
                    Item.XeTangCuong = Convert.ToBoolean(XeTangCuong);

                    

                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        //SearchManager.Add(string.Format("{0} {1}", Item.BienSo_Chu, Item.BienSo_So)
                        //    , string.Format("{0} {1} {2} {3} {4}", Item.BienSo_Chu, Item.BienSo_So, DONVI_Ten, TUYEN_Ten, LOAIXE_Ten)
                        //    , string.Format("{0} {1}", Item.BienSo_Chu, Item.BienSo_So)
                        //    , Item.RowId.ToString()
                        //    , Item.Url
                        //    , typeof(Xe).Name);
                    }

                    Item.NgayCapNhat = DateTime.Now;
                    Item = Inserted ? PhoiDal.Insert(Item) : PhoiDal.Update(Item);

                    var ChamCong = new ChamCong();

                    if (Inserted)
                    {
                        ChamCong.Loai = 1;
                        ChamCong.Duyet = true;
                        ChamCong.Ngay = new DateTime(Item.NgayXuatBen.Year, Item.NgayXuatBen.Month, Item.NgayXuatBen.Day);
                        ChamCong.PHOI_ID = Item.ID;
                        ChamCong.XE_ID = Item.XE_ID;

                        ChamCong.NgayCapNhat = DateTime.Now;
                        ChamCong.Username = Security.Username;
                        ChamCong.NgayTao = DateTime.Now;
                        ChamCong.RowId = Guid.NewGuid();
                        ChamCong = ChamCongDal.Insert(ChamCong);   
                    }

                    var idTruyThuNull = string.IsNullOrEmpty(TRUYTHU_ID);

                    if (idTruyThuNull)
                    {
                        if (!string.IsNullOrEmpty(NgayChamCong))
                        {
                            var TruyThu = new TruyThu();
                            if (!string.IsNullOrEmpty(DANHGIA_ID))
                            {
                                TruyThu.DANHGIA_ID = new Guid(DANHGIA_ID);
                            }
                            if (!string.IsNullOrEmpty(NOIDUNG_ID))
                            {
                                TruyThu.DANHGIA_ID = new Guid(NOIDUNG_ID);
                            }
                            if (!string.IsNullOrEmpty(SoChuyenDeNghi))
                            {
                                TruyThu.SoChuyenDeNghi = Convert.ToInt16(SoChuyenDeNghi);
                            }
                            TruyThu.DeNghiCuaNhaXe = DeNghiCuaNhaXe;
                            TruyThu.PHOI_ID = Item.ID;
                            TruyThu.DeNghi = TruyThu.SoChuyenDeNghi != 0;
                            TruyThu.Duyet = false;
                            TruyThu.NgayCapNhat = DateTime.Now;
                            TruyThu.Username = Security.Username;
                            TruyThu.NgayTao = DateTime.Now;
                            TruyThu.RowId = Guid.NewGuid();
                            TruyThu = TruyThuDal.Insert(TruyThu);

                            var NgayChamCongArray = NgayChamCong.Split(new char[] { ',' });
                            foreach (var NgayDuyetTruyThuDate in from NgayDuyetTruyThu in NgayChamCongArray
                                                                 where NgayDuyetTruyThu.Length > 2
                                                                 select Convert.ToDateTime(NgayDuyetTruyThu,
                                                                                           new CultureInfo("Vi-vn")))
                            {
                                ChamCong = new ChamCong();
                                if (TruyThu.DeNghi)
                                {
                                    ChamCong.Loai = 3;
                                }
                                else
                                {
                                    ChamCong.Loai = 2;
                                }
                                ChamCong.Duyet = false;
                                ChamCong.Ngay = new DateTime(NgayDuyetTruyThuDate.Year, NgayDuyetTruyThuDate.Month, NgayDuyetTruyThuDate.Day);
                                ChamCong.PHOI_ID = Item.ID;
                                ChamCong.XE_ID = Item.XE_ID;
                                ChamCong.TRUYTHU_ID = TruyThu.ID;

                                ChamCong.NgayCapNhat = DateTime.Now;
                                ChamCong.Username = Security.Username;
                                ChamCong.NgayTao = DateTime.Now;
                                ChamCong.RowId = Guid.NewGuid();
                                ChamCong = ChamCongDal.Insert(ChamCong);
                            }
                        }                                                
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(NgayChamCong))
                        {
                            var TruyThu = TruyThuDal.SelectById(Convert.ToInt64(TRUYTHU_ID));
                            if (!string.IsNullOrEmpty(DANHGIA_ID))
                            {
                                TruyThu.DANHGIA_ID = new Guid(DANHGIA_ID);
                            }
                            if (!string.IsNullOrEmpty(NOIDUNG_ID))
                            {
                                TruyThu.DANHGIA_ID = new Guid(NOIDUNG_ID);
                            }
                            if (!string.IsNullOrEmpty(SoChuyenDeNghi))
                            {
                                TruyThu.SoChuyenDeNghi = Convert.ToInt16(SoChuyenDeNghi);
                            }
                            TruyThu.DeNghiCuaNhaXe = DeNghiCuaNhaXe;
                            TruyThu.PHOI_ID = Item.ID;
                            TruyThu.DeNghi = TruyThu.SoChuyenDeNghi != 0;
                            TruyThu.Duyet = false;
                            TruyThu.NgayCapNhat = DateTime.Now;
                            TruyThu.Username = Security.Username;
                            TruyThu.NgayTao = DateTime.Now;
                            TruyThu.RowId = Guid.NewGuid();
                            TruyThu = TruyThuDal.Update(TruyThu);

                            ChamCongDal.DeleteByTruyThuId(Convert.ToInt64(TRUYTHU_ID));

                            var NgayChamCongArray = NgayChamCong.Split(new char[] { ',' });
                            foreach (var NgayDuyetTruyThuDate in from NgayDuyetTruyThu in NgayChamCongArray
                                                                 where NgayDuyetTruyThu.Length > 2
                                                                 select Convert.ToDateTime(NgayDuyetTruyThu,
                                                                                           new CultureInfo("Vi-vn")))
                            {
                                ChamCong = new ChamCong();
                                if (TruyThu.DeNghi)
                                {
                                    ChamCong.Loai = 3;
                                }
                                else
                                {
                                    ChamCong.Loai = 2;
                                }
                                ChamCong.Duyet = false;
                                ChamCong.Ngay = new DateTime(NgayDuyetTruyThuDate.Year, NgayDuyetTruyThuDate.Month, NgayDuyetTruyThuDate.Day);
                                ChamCong.PHOI_ID = Item.ID;
                                ChamCong.XE_ID = Item.XE_ID;
                                ChamCong.TRUYTHU_ID = TruyThu.ID;

                                ChamCong.NgayCapNhat = DateTime.Now;
                                ChamCong.Username = Security.Username;
                                ChamCong.NgayTao = DateTime.Now;
                                ChamCong.RowId = Guid.NewGuid();
                                ChamCong = ChamCongDal.Insert(ChamCong);
                            }
                        }
                        else
                        {
                            TruyThuDal.DeleteById(Convert.ToInt64(TRUYTHU_ID));
                            ChamCongDal.DeleteByTruyThuId(Convert.ToInt64(TRUYTHU_ID));

                        }
                    }

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

                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(Item)));
                }
                rendertext("-1");
                break;
                #endregion
            case "search":
                #region search
                var pgResult = XeDal.SearchSQL(q);
                rendertext(JavaScriptConvert.SerializeObject(pgResult), "text/javascript");
                break;
                #endregion
            default:
                break;
        }

    }
}