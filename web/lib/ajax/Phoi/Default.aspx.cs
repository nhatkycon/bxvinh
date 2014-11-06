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
        #region Variables
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
        var XVB_ID = Request["XVB_ID"];
        var XeTangCuong = Request["XeTangCuong"];

        XeTangCuong = !string.IsNullOrEmpty(XeTangCuong)
                      ? "true"
                      : "false";

        var XeThayThe = Request["XeThayThe"];

        XeThayThe = !string.IsNullOrEmpty(XeThayThe)
                      ? "true"
                      : "false";

        #endregion

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
                        var xe = XeDal.SelectById(Convert.ToInt64(XE_ID));
                        Item.DONVI_ID = xe.DONVI_ID;
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
                    Item.CQ_ID = Security.CqId;
                    

                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                    }

                    Item.NgayCapNhat = DateTime.Now;
                    Item = Inserted ? PhoiDal.Insert(Item) : PhoiDal.Update(Item);

                    var chamCong = new ChamCong();

                    if (Inserted)
                    {
                        // Thêm chấm công mới
                        chamCong.Loai = 1;
                        chamCong.Duyet = true;
                        chamCong.Ngay = new DateTime(Item.NgayXuatBen.Year, Item.NgayXuatBen.Month, Item.NgayXuatBen.Day);
                        chamCong.PHOI_ID = Item.ID;
                        chamCong.XE_ID = Item.XE_ID;

                        chamCong.NgayCapNhat = DateTime.Now;
                        chamCong.Username = Security.Username;
                        chamCong.NgayTao = DateTime.Now;
                        chamCong.RowId = Guid.NewGuid();
                        chamCong = ChamCongDal.Insert(chamCong);

                        if (!string.IsNullOrEmpty(XVB_ID))
                        {
                            var xvb = XeVaoBenDal.SelectById(Convert.ToInt64(XVB_ID));
                            xvb.TrangThai = 400;
                            xvb.NgayDuyetPhoi=xvb.NgayCapNhat = DateTime.Now;
                            xvb.NguoiDuyetPhoi = Security.Username;
                            xvb.PHOI_ID = Item.ID;
                            xvb = XeVaoBenDal.Update(xvb);
                        }
                        else
                        {
                            var xvb=new XeVaoBen();
                            xvb.TrangThai = 400;
                            xvb.NgayDuyetPhoi = xvb.NgayCapNhat = DateTime.Now;
                            xvb.NguoiDuyetPhoi = Security.Username;
                            xvb.PHOI_ID = Item.ID;
                            xvb.XE_ID = Item.XE_ID;
                            xvb.Ao = true;
                            xvb.Username = Security.Username;
                            xvb.CQ_ID = Security.CqId;
                            xvb = XeVaoBenDal.Insert(xvb);
                        }
                        
                    }

                    var idTruyThuNull = string.IsNullOrEmpty(TRUYTHU_ID);

                    if (idTruyThuNull)
                    {
                        if (!string.IsNullOrEmpty(NgayChamCong))
                        {
                            var truyThu = new TruyThu();
                            if (!string.IsNullOrEmpty(DANHGIA_ID))
                            {
                                truyThu.DANHGIA_ID = new Guid(DANHGIA_ID);
                            }
                            if (!string.IsNullOrEmpty(NOIDUNG_ID))
                            {
                                truyThu.DANHGIA_ID = new Guid(NOIDUNG_ID);
                            }
                            if (!string.IsNullOrEmpty(SoChuyenDeNghi))
                            {
                                truyThu.SoChuyenDeNghi = Convert.ToInt16(SoChuyenDeNghi);
                            }
                            truyThu.PHOI_ID = Item.ID;
                            truyThu.DeNghiCuaNhaXe = DeNghiCuaNhaXe;
                            truyThu.PHOI_ID = Item.ID;
                            truyThu.XE_ID = Item.XE_ID;
                            truyThu.DeNghi = truyThu.SoChuyenDeNghi != 0;
                            truyThu.Duyet = false;
                            truyThu.NgayCapNhat = DateTime.Now;
                            truyThu.Username = Security.Username;
                            truyThu.NgayTao = DateTime.Now;
                            truyThu.RowId = Guid.NewGuid();
                            truyThu = TruyThuDal.Insert(truyThu);
                            truyThu.NguoiLap = Security.Username;

                            var ngayChamCongArray = NgayChamCong.Split(new char[] { ',' });
                            foreach (var NgayDuyetTruyThuDate in from NgayDuyetTruyThu in ngayChamCongArray
                                                                 where NgayDuyetTruyThu.Length > 2
                                                                 select Convert.ToDateTime(NgayDuyetTruyThu,
                                                                                           new CultureInfo("Vi-vn")))
                            {
                                chamCong = new ChamCong();
                                if (truyThu.DeNghi)
                                {
                                    chamCong.Loai = 3;
                                }
                                else
                                {
                                    chamCong.Loai = 2;
                                }
                                chamCong.Duyet = false;
                                chamCong.Ngay = new DateTime(NgayDuyetTruyThuDate.Year, NgayDuyetTruyThuDate.Month, NgayDuyetTruyThuDate.Day);
                                chamCong.PHOI_ID = Item.ID;
                                chamCong.XE_ID = Item.XE_ID;
                                chamCong.TRUYTHU_ID = truyThu.ID;

                                chamCong.NgayCapNhat = DateTime.Now;
                                chamCong.Username = Security.Username;
                                chamCong.NgayTao = DateTime.Now;
                                chamCong.RowId = Guid.NewGuid();
                                chamCong = ChamCongDal.Insert(chamCong);
                            }
                        }                                                
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(NgayChamCong))
                        {
                            var truyThu = TruyThuDal.SelectById(Convert.ToInt64(TRUYTHU_ID));
                            if (!string.IsNullOrEmpty(DANHGIA_ID))
                            {
                                truyThu.DANHGIA_ID = new Guid(DANHGIA_ID);
                            }
                            if (!string.IsNullOrEmpty(NOIDUNG_ID))
                            {
                                truyThu.DANHGIA_ID = new Guid(NOIDUNG_ID);
                            }
                            if (!string.IsNullOrEmpty(SoChuyenDeNghi))
                            {
                                truyThu.SoChuyenDeNghi = Convert.ToInt16(SoChuyenDeNghi);
                            }
                            truyThu.DeNghiCuaNhaXe = DeNghiCuaNhaXe;
                            truyThu.PHOI_ID = Item.ID;
                            truyThu.XE_ID = Item.XE_ID;
                            truyThu.DeNghi = truyThu.SoChuyenDeNghi != 0;
                            truyThu.Duyet = false;
                            truyThu.NgayCapNhat = DateTime.Now;
                            truyThu.Username = Security.Username;
                            truyThu.NgayTao = DateTime.Now;
                            truyThu.RowId = Guid.NewGuid();
                            truyThu = TruyThuDal.Update(truyThu);

                            ChamCongDal.DeleteByTruyThuId(Convert.ToInt64(TRUYTHU_ID));

                            var ngayChamCongArray = NgayChamCong.Split(new char[] { ',' });
                            foreach (var ngayDuyetTruyThuDate in from NgayDuyetTruyThu in ngayChamCongArray
                                                                 where NgayDuyetTruyThu.Length > 2
                                                                 select Convert.ToDateTime(NgayDuyetTruyThu,
                                                                                           new CultureInfo("Vi-vn")))
                            {
                                chamCong = new ChamCong();
                                if (truyThu.DeNghi)
                                {
                                    chamCong.Loai = 3;
                                }
                                else
                                {
                                    chamCong.Loai = 2;
                                }
                                chamCong.Duyet = false;
                                chamCong.Ngay = new DateTime(ngayDuyetTruyThuDate.Year, ngayDuyetTruyThuDate.Month, ngayDuyetTruyThuDate.Day);
                                chamCong.PHOI_ID = Item.ID;
                                chamCong.XE_ID = Item.XE_ID;
                                chamCong.TRUYTHU_ID = truyThu.ID;

                                chamCong.NgayCapNhat = DateTime.Now;
                                chamCong.Username = Security.Username;
                                chamCong.NgayTao = DateTime.Now;
                                chamCong.RowId = Guid.NewGuid();
                                chamCong = ChamCongDal.Insert(chamCong);
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
            default:
                break;
        }

    }
}