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
        var PHI_ChiThuBenBai = Request["PHI_ChiThuBenBai"];
        var saveType = Request["saveType"];
        var hopLe = Request["hopLe"];
        var Draff = Request["Draff"];
        var YKienQuanLy = Request["YKienQuanLy"];

        XeTangCuong = !string.IsNullOrEmpty(XeTangCuong)
                      ? "true"
                      : "false";

        PHI_ChiThuBenBai = !string.IsNullOrEmpty(PHI_ChiThuBenBai)
                      ? "true"
                      : "false";


        var XeThayThe = Request["XeThayThe"];

        XeThayThe = !string.IsNullOrEmpty(XeThayThe)
                      ? "true"
                      : "false";

        #endregion

        var Inserted = Convert.ToBoolean(Draff);
        if (string.IsNullOrEmpty(saveType)) saveType = "";

        switch (subAct)
        {
            case "save":
                #region save
                /////////////////////////////////////////
                // Ý tưởng cơ bản là check số NgayChamCong != Null => Có truy thu.
                // Nếu số chuyến đề nghị =0 nghĩa là tự nguyện truy thu. Ngược lại là có phát sinh đề nghị truy thu.
                ////////////////////////////////////////
                if (!loggedIn || !string.IsNullOrEmpty(STTBX) || !string.IsNullOrEmpty(XE_BienSo))
                {
                    var Item = Inserted
                                   ? PhoiDal.SelectLastest(Security.CqId.ToString(), true)
                                   : PhoiDal.SelectById(Convert.ToInt64(Id));

                    if (Inserted && !string.IsNullOrEmpty(Id))
                    {
                        Item.ID = Convert.ToInt64(Id);
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
                    // Truy thu
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
                    
                    Item.PHI_ChiThuBenBai = Convert.ToBoolean(PHI_ChiThuBenBai);
                    Item.XeThayThe = Convert.ToBoolean(XeThayThe);
                    Item.XeTangCuong = Convert.ToBoolean(XeTangCuong);
                    Item.CQ_ID = Security.CqId;

                    Item.PhiMotChuyenTruyThu = Item.PHI_ChiThuBenBai
                                            ? Item.PHI_BenBai
                                            : (Item.PHI_HoaHongBanVe + Item.PHI_BenBai);

                    Item.NgayCapNhat = DateTime.Now;

                    if (!string.IsNullOrEmpty(PHI_Tong))
                    {
                        Item.PHI_Tong = Convert.ToDouble(PHI_Tong);
                    }
                    // !imporant giả định là cứ cấp phơi mặc định nộp đủ
                    if (!string.IsNullOrEmpty(PHI_Tong))
                    {
                        Item.PHI_Nop = Item.PHI_Tong;
                    }
                    //if (!string.IsNullOrEmpty(PHI_ConNo))
                    //{
                    //    Item.PHI_ConNo = Convert.ToDouble(PHI_ConNo);
                    //}

                    // Trong trường hợp chỉ tiến hành Truy thu
                    if (saveType.ToLower().Contains("truythu"))
                    {
                        Item.PHI_Tong = Item.PhiMotChuyenTruyThu * Item.ChuyenTruyThu;
                        Item.PHI_Nop = Item.PHI_Tong;
                    }
                    Item.Draff = false;

                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        //Update Ca làm việc
                        var giaoCa = GiaoCaDal.Current(Security.CqId, Security.Username);
                        Item.GIAOCA_ID = giaoCa.ID;
                        giaoCa.TongSoPhoi += 1;
                        giaoCa.DoanhThu += Item.PHI_Tong;
                        giaoCa.NgayCapNhat = DateTime.Now;
                        GiaoCaDal.Update(giaoCa);

                    }
                    Item = PhoiDal.Update(Item);

                   

                    

                    var chamCong = new ChamCong();

                    if (Inserted)
                    {
                        if (!saveType.ToLower().Contains("truythu")) // Trong trường hợp không truy thu
                        {
                            // Thêm chấm công mới
                            short loaiChamCong = 1;
                            if (hopLe == "0") loaiChamCong = 2;
                            chamCong.Loai = loaiChamCong;
                            chamCong.Duyet = true;
                            chamCong.Ngay = new DateTime(Item.NgayXuatBen.Year, Item.NgayXuatBen.Month, Item.NgayXuatBen.Day);
                            chamCong.PHOI_ID = Item.ID;
                            chamCong.XE_ID = Item.XE_ID;
                            chamCong.CQ_ID = Security.CqId;
                            chamCong.TrangThaiNo = 0;                            
                            chamCong.NgayCapNhat = DateTime.Now;
                            chamCong.Username = Security.Username;
                            chamCong.NgayTao = DateTime.Now;
                            chamCong.RowId = Guid.NewGuid();
                            chamCong.Draff = false;
                            ChamCongDal.Insert(chamCong);
                        }
                    }
                    var idTruyThuNull = string.IsNullOrEmpty(TRUYTHU_ID);
                    var truyThu = idTruyThuNull ? TruyThuDal.SelectLastest(Security.CqId) : TruyThuDal.SelectById(Convert.ToInt64(TRUYTHU_ID));
                    if (!string.IsNullOrEmpty(DANHGIA_ID))
                    {
                        truyThu.DANHGIA_ID = new Guid(DANHGIA_ID);
                    }
                    if (!string.IsNullOrEmpty(NOIDUNG_ID))
                    {
                        truyThu.NOIDUNG_ID = new Guid(NOIDUNG_ID);
                    }
                    if (!string.IsNullOrEmpty(SoChuyenDeNghi))
                    {
                        truyThu.SoChuyenDeNghi = Convert.ToInt16(SoChuyenDeNghi);
                    }

                    truyThu.SoChuyenThieu = Item.ChuyenTruyThu;
                    truyThu.TongTruyThu = Item.PHI_ChuyenTruyThu;
                    truyThu.Duyet = truyThu.SoChuyenDeNghi == 0;
                    truyThu.CQ_ID = Security.CqId;
                    truyThu.PHOI_ID = Item.ID;
                    truyThu.DeNghiCuaNhaXe = DeNghiCuaNhaXe;
                    truyThu.PHOI_ID = Item.ID;
                    truyThu.XE_ID = Item.XE_ID;
                    truyThu.DeNghi = truyThu.SoChuyenDeNghi != 0;
                    truyThu.YKienQuanLy = YKienQuanLy;
                    if (truyThu.DeNghi)
                    {
                        truyThu.TrangThai = 1;
                    }
                    else
                    {
                        truyThu.TrangThai = 0;
                    }
                    truyThu.NgayCapNhat = DateTime.Now;
                    

                    if(idTruyThuNull)
                    {
                        truyThu.Username = Security.Username;
                        truyThu.NgayTao = DateTime.Now;
                        truyThu.RowId = Guid.NewGuid();
                        truyThu.NguoiLap = Security.Username;
                        truyThu = TruyThuDal.Insert(truyThu);
                    }
                    else
                    {
                        truyThu = TruyThuDal.Update(truyThu);
                        ChamCongDal.DeleteByTruyThuId(Convert.ToInt64(TRUYTHU_ID));
                    }


                    var chamCongByPhoiId = ChamCongDal.SelectByPhoiId(Item.ID);
                    foreach (var item in chamCongByPhoiId)
                    {
                        item.Tien = Item.PhiMotChuyenTruyThu;
                        item.XE_ID = Item.XE_ID;
                        item.TRUYTHU_ID = truyThu.ID;
                        item.NgayCapNhat = DateTime.Now;
                        //item.Draff = false;
                        ChamCongDal.Update(item);
                    }
                    

                    
                    // Xử lý phần XeVaoBen
                    if (!string.IsNullOrEmpty(XVB_ID))
                    {
                        var xvb = XeVaoBenDal.SelectById(Convert.ToInt64(XVB_ID));
                        xvb.NgayDuyetPhoi = xvb.NgayCapNhat = DateTime.Now;
                        xvb.NguoiDuyetPhoi = Security.Username;
                        xvb.PHOI_ID = Item.ID;
                        xvb.Tien = Item.PHI_Tong;
                        xvb.TrangThai = 400;
                        if (truyThu.SoChuyenDeNghi > 0 && !truyThu.Duyet) // Có đề nghị truy thu và truy thu này chưa duyệt
                        {
                            xvb.TrangThai = 500; // Chờ duyệt truy thu
                        }
                        xvb.TRUYTHU_ID = truyThu.ID;
                        XeVaoBenDal.Update(xvb);
                    }
                    else
                    {
                        var xvb = new XeVaoBen {TrangThai = 400};
                        xvb.NgayDuyetPhoi = xvb.NgayCapNhat = DateTime.Now;
                        xvb.NguoiDuyetPhoi = Security.Username;
                        xvb.PHOI_ID = Item.ID;
                        xvb.XE_ID = Item.XE_ID;
                        xvb.Loai = 300;
                        xvb.Username = Security.Username;
                        xvb.CQ_ID = Security.CqId;
                        xvb.TrangThai = 400;
                        xvb.Tien = Item.PHI_Tong;
                        if (truyThu.SoChuyenDeNghi > 0 && !truyThu.Duyet) // Có đề nghị truy thu và truy thu này chưa duyệt
                        {
                            xvb.TrangThai = 500; // Chờ duyệt truy thu
                        }
                        xvb.TRUYTHU_ID = truyThu.ID;
                        XeVaoBenDal.Insert(xvb);
                    }
                    rendertext(Item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion
            case "getLatest":
                #region getLatest
                if (loggedIn)
                {
                    var Item = PhoiDal.SelectLastest(Security.CqId.ToString());
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(Item)));
                }
                rendertext("-1");
                break;
                #endregion
            case "remove":
                #region remove
                if (loggedIn)
                {
                    var Item = PhoiDal.SelectById(Convert.ToInt32(Id));
                    if (Item.Username == Security.Username)
                    {
                        PhoiDal.DeleteById(Item.ID);
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