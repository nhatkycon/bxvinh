using System;
using System.Globalization;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;
public partial class lib_ajax_TruyThu_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();
        var Id = Request["Id"];
        var soChuyenDuocDuyet = Request["SoChuyenDuocDuyet"];
        var yKienChiDao = Request["YKienChiDao"];
        var KienNghi = Request["KienNghi"];
        var PHI_ConNo = Request["PHI_ConNo"];
        var PHI_Nop = Request["PHI_Nop"];
        switch (subAct)
        {
            case "duyet":
                if(loggedIn && !string.IsNullOrEmpty(Id))
                {
                    using(var con = DAL.con())
                    {
                        var item = TruyThuDal.SelectById(con, Convert.ToInt64(Id));
                        item.Duyet = true;
                        item.NgayDuyet = DateTime.Now;
                        item.LanhDaoDuyet = Security.Username;
                        item.SoChuyenDuocDuyet = Convert.ToInt16(soChuyenDuocDuyet);
                        item.YKienChiDao = yKienChiDao;
                        item.NgayCapNhat = item.NgayDuyet;
                        item.TrangThai = 2;
                        item = TruyThuDal.Update(item);

                        var phoi = PhoiDal.SelectById(con,item.PHOI_ID);                        
                        phoi.PHI_TruyThuGiam = phoi.PhiMotChuyenTruyThu * (phoi.ChuyenTruyThu - Convert.ToInt16(soChuyenDuocDuyet));
                        //phoi.PHI_Tong = phoi.PHI_Tong - phoi.PHI_TruyThuGiam;
                        phoi.NgayCapNhat = item.NgayDuyet;
                        
                        PhoiDal.Update(phoi);

                        var xvb = XeVaoBenDal.SelectByPhoiId(con, phoi.ID);
                        xvb.TrangThai = 510;
                        xvb.NgayCapNhat = DateTime.Now;
                        xvb.NguoiDuyetTruyThu = Security.Username;
                        xvb.NgayLanhDaoDuyetTruyThu = item.NgayDuyet;
                        xvb = XeVaoBenDal.Update(xvb);

                        rendertext(Id);
                    }
                }
                break;
            case "nhaXeChapNhan":
                if (loggedIn && !string.IsNullOrEmpty(Id))
                {
                    using (var con = DAL.con())
                    {
                        var item = TruyThuDal.SelectById(con, Convert.ToInt64(Id));
                        item.TrangThai = 4;
                        item.NgayCapNhat = DateTime.Now;
                        item = TruyThuDal.Update(item);
                        // Duyệt toàn bộ chấm công
                        ChamCongDal.UpdateDuyetByTruyThuId(con, item.ID);

                        var phoi = PhoiDal.SelectById(con, item.PHOI_ID);
                        if (!string.IsNullOrEmpty(PHI_ConNo))
                        {
                            phoi.PHI_ConNo = Convert.ToDouble(PHI_ConNo);
                        }
                        if (!string.IsNullOrEmpty(PHI_Nop))
                        {
                            phoi.PHI_Nop = Convert.ToDouble(PHI_Nop);
                        }
                        phoi.NgayCapNhat = DateTime.Now;
                        PhoiDal.Update(phoi);


                        var xvb = XeVaoBenDal.SelectByPhoiId(con, item.PHOI_ID);
                        xvb.TrangThai = 400;
                        xvb.NgayCapNhat = DateTime.Now;
                        xvb.NguoiDuyetTruyThu = Security.Username;
                        xvb.NgayLanhDaoDuyetTruyThu = item.NgayDuyet;
                        xvb = XeVaoBenDal.Update(xvb);

                        rendertext(Id);
                    }
                }
                break;
            case "khongDuyet":
                if (loggedIn && !string.IsNullOrEmpty(Id))
                {
                    using (var con = DAL.con())
                    {
                        var item = TruyThuDal.SelectById(con, Convert.ToInt64(Id));
                        item.Duyet = true;
                        item.NgayDuyet = DateTime.Now;
                        item.LanhDaoDuyet = Security.Username;
                        item.SoChuyenDuocDuyet = Convert.ToInt16(soChuyenDuocDuyet);
                        item.YKienChiDao = yKienChiDao;
                        item.NgayCapNhat = DateTime.Now;
                        item.TrangThai = 2;
                        item = TruyThuDal.Update(item);

                        var phoi = PhoiDal.SelectById(con, item.PHOI_ID);
                        phoi.NgayCapNhat = item.NgayDuyet;
                        PhoiDal.Update(phoi);

                        var xvb = XeVaoBenDal.SelectByPhoiId(con, phoi.ID);
                        xvb.TrangThai = 510;
                        xvb.NgayCapNhat = DateTime.Now;
                        xvb.NguoiDuyetTruyThu = Security.Username;
                        xvb.NgayLanhDaoDuyetTruyThu = item.NgayDuyet;
                        xvb = XeVaoBenDal.Update(xvb);
                        rendertext(Id);
                    }
                }
                break;
            case "nhaXeKienNghi":
                if (loggedIn && !string.IsNullOrEmpty(Id))
                {
                    using (var con = DAL.con())
                    {
                        var item = TruyThuDal.SelectById(con, Convert.ToInt64(Id));
                        item.NgayCapNhat = DateTime.Now;
                        item.TrangThai = 3;
                        item.Duyet = false;
                        item.KienNghi = KienNghi;
                        item = TruyThuDal.Update(item);

                        var phoi = PhoiDal.SelectById(item.PHOI_ID);
                        phoi.PHI_TruyThuGiam = 0;
                        phoi.NgayCapNhat = DateTime.Now;
                        PhoiDal.Update(phoi);

                        var xvb = XeVaoBenDal.SelectByPhoiId(con, item.PHOI_ID);
                        xvb.TrangThai = 500;
                        xvb.NgayCapNhat = DateTime.Now;
                        xvb = XeVaoBenDal.Update(xvb);

                        rendertext(Id);
                    }
                }
                break;
            case "huyTruyThu":
                if (loggedIn && !string.IsNullOrEmpty(Id))
                {
                    using (var con = DAL.con())
                    {
                        var item = TruyThuDal.SelectById(con, Convert.ToInt64(Id));
                        item.NgayCapNhat = DateTime.Now;
                        item.TrangThai = 5;
                        item.Duyet = false;
                        item = TruyThuDal.Update(item);
                        // Xóa bỏ hết chấm công
                        ChamCongDal.DeleteByTruyThuId(item.ID);
                        PhoiDal.DeleteById(item.PHOI_ID);

                        var xvb = XeVaoBenDal.SelectByPhoiId(con, item.PHOI_ID);
                        xvb.TrangThai = 200;
                        xvb.NgayCapNhat = DateTime.Now;
                        xvb = XeVaoBenDal.Update(xvb);

                        rendertext(Id);
                    }
                }
                break;
            case "remove":
                #region remove
                if (loggedIn)
                {
                    var Item = TruyThuDal.SelectById(Convert.ToInt32(Id));
                    if (Item.Username == Security.Username)
                    {
                        TruyThuDal.DeleteById(Item.ID);
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