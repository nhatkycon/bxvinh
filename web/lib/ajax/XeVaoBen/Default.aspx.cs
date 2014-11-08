using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;


public partial class lib_ajax_XeVaoBen_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();
        var Id = Request["Id"];
        var uname = Security.Username;
        switch (subAct)
        {
            case "GetNewers":
                if (loggedIn)
                {
                    var list = XeVaoBenDal.ListTsLenPhoi(DAL.con(), Security.CqId, 100);
                    if (list.Any())
                    {
                        ListTodayAjax.List = list;
                        ListTodayAjax.Visible = true;    
                    }
                    else
                    {
                        rendertext("");
                    }
                }
                break;
            case "GetChoThanhToan":
                if (loggedIn)
                {
                    var list = XeVaoBenDal.ListTsChoThanhToan(DAL.con(), Security.CqId, 100);
                    if (list.Any())
                    {
                        TS_XeChoThanhToanAjax.List = list;
                        TS_XeChoThanhToanAjax.Visible = true;
                    }
                    else
                    {
                        rendertext("");
                    }
                }
                break;
            case "GetDaThanhToan":
                if (loggedIn)
                {
                    var list = XeVaoBenDal.ListTsDaThanhToan(DAL.con(), Security.CqId, 100);
                    if (list.Any())
                    {
                        TS_XeDaThanhToanAjax.List = list;
                        TS_XeDaThanhToanAjax.Visible = true;
                    }
                    else
                    {
                        rendertext("");
                    }
                }
                break;
            case "GetYeuCauThanhToan":
                if (loggedIn)
                {
                    var list = XeVaoBenDal.ListTsChoThanhToan(DAL.con(), Security.CqId, 100).OrderByDescending(x => x.TrangThai).
                            ThenByDescending(x => x.ID).ToList();
                    if (list.Any())
                    {
                        AjaxListYeuCauThanhToanHangDoi.List = list;
                        AjaxListYeuCauThanhToanHangDoi.Visible = true;
                    }
                    else
                    {
                        rendertext("");
                    }
                }
                break;
            case "ListDuyetDeNghiTruyThu":
                if (loggedIn)
                {
                    var list = XeVaoBenDal.ListTruyThu(DAL.con(), Security.CqId, 100).OrderByDescending(x => x.TrangThai).
                            ThenByDescending(x => x.ID).ToList();
                    if (list.Any())
                    {
                        AjaxListDuyetDeNghiTruyThu.List = list;
                        AjaxListDuyetDeNghiTruyThu.Visible = true;
                    }
                    else
                    {
                        rendertext("");
                    }
                }
                break;
            case "GetYeuCauXuLyListByUsername":
                if (loggedIn)
                {
                    var list =
                        XeVaoBenDal.ListTsLenPhoi(DAL.con(), Security.CqId, 100).OrderByDescending(x => x.TrangThai).
                            ThenByDescending(x => x.ID).ToList();
                    if(!list.Any())
                    {
                        rendertext("");
                    }
                    AjaxListYeuCauXuLyHangDoi.List = list;
                    AjaxListYeuCauXuLyHangDoi.Visible = true;
                }
                break;
            case "YeuCauXuLy":
                if (!string.IsNullOrEmpty(Id))
                {
                    var item = XeVaoBenDal.SelectById(Convert.ToInt64(Id));
                    item.TrangThai = 200;
                    item.NgayYeuCauXuLy = DateTime.Now;
                    item = XeVaoBenDal.Update(item);
                }
                break;
            case "YeuCauThanhToan":
                if (!string.IsNullOrEmpty(Id))
                {
                    var item = XeVaoBenDal.SelectById(Convert.ToInt64(Id));
                    item.TrangThai = 600;
                    item.NgayYeuCauThanhToan = item.NgayCapNhat = DateTime.Now;
                    item = XeVaoBenDal.Update(item);
                }
                break;
            case "RestoreXeChuaXuLy":
                if (!string.IsNullOrEmpty(Id))
                {
                    var xvb = XeVaoBenDal.SelectById(Convert.ToInt64(Id));
                    xvb.TrangThai = 100;
                    xvb.NgayCapNhat = DateTime.Now;
                    xvb = XeVaoBenDal.Update(xvb);
                }
                break;
            case "NhanYeuCauThanhToan":
                if (!string.IsNullOrEmpty(Id))
                {
                    var xvb = XeVaoBenDal.SelectById(Convert.ToInt64(Id));
                    xvb.TrangThai = 700;
                    xvb.NgayNhanYeuCauThanhToan = xvb.NgayCapNhat = DateTime.Now;
                    xvb = XeVaoBenDal.Update(xvb);
                    var thuChi = ThuChiDal.SelectByLastest(DAL.con(), Security.CqId);
                    var phoi = PhoiDal.SelectById(xvb.PHOI_ID);
                    var xe = XeDal.SelectById(phoi.XE_ID);
                    phoi.Xe = xe;
                    thuChi.Phoi = phoi;
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(thuChi)));
                }
                break;
            case "GetCurrentCapPhoi":
                if (loggedIn)
                {
                    var item = XeVaoBenDal.ListByTrangThaiCqId(DAL.con(), Security.CqId, 300, 1, 200).FirstOrDefault();
                    if(item!=null)
                    {
                        rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(item)));                        
                    }
                    rendertext("");
                }
                break;
            default:
                break;
        }
    }
}