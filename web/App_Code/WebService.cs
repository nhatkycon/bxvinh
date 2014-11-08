using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using docsoft;
using docsoft.entities;
using linh.core.dal;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Xe
    [WebMethod]
    public List<Xe> XeGetAll(string q, int Top)
    {
        return XeDal.WSRVGetAll(q, Top);
    }
    [WebMethod]
    public List<String> XeGetBienSo()
    {
        return XeDal.SearchSQLString(string.Empty);
    }
    #endregion

    #region LoaiXe
    [WebMethod]
    public List<LoaiXe> LoaiXeGetAll()
    {
        return LoaiXeDal.SelectAll();
    }
    #endregion

    #region XeVaoBen
    [WebMethod]
    public long XeVaoBenInsert(string BienSo, int LoaiXe, string Ngay, string Username, int Cq_Id, Int16 loai, int giaoCa_Id)
    {
        if (string.IsNullOrEmpty(BienSo)) return 0;// Không cung cấp biển số xe
        var spaceCharIndex = BienSo.IndexOf(" ", System.StringComparison.Ordinal);
        if (spaceCharIndex == 0) return 0;// Biển số xe không đúng định dạng
        if (LoaiXe == 0) return 0;// Không cung cấp loại xe

        var bienSo_Chu = BienSo.Substring(0, spaceCharIndex);
        var bienSo_So = BienSo.Substring(spaceCharIndex + 1);
        var NgayTao = Convert.ToDateTime(Ngay, new CultureInfo("vi-Vn"));
        using(var con = DAL.con())
        {
            var giaoCa = GiaoCaDal.SelectById(giaoCa_Id);
            giaoCa.TongSoPhoi += 1;

            var xe = XeDal.SelectByBienSo(con, bienSo_Chu, bienSo_So);
            var loaiXe = LoaiXeDal.SelectById(con, LoaiXe);

            var xeVaoBen = XeVaoBenDal.SelectLastest(Cq_Id);

            if (xe.ID == 0) // Xe chưa có trong hệ thống
            {
                xeVaoBen.TrangThai = 110;

                xe.BienSo_So = bienSo_So;
                xe.BienSo_Chu = bienSo_Chu;
                xe.LOAIXE_ID = Convert.ToInt32(LoaiXe);
                xe.NgayTao = NgayTao;
                xe.Username = Username;
                xe.XeVangLai = loai==0;
                xe.ChuaDangKy = true;
                xe = XeDal.Insert(xe);
            }
            else
            {
                xeVaoBen.TrangThai = 100;
            }
            if (loai == 0 || loai==100)
            {
                xeVaoBen.Tien = loaiXe.MucThu;
                giaoCa.DoanhThu += xeVaoBen.Tien;
            }
            else
            {
                xeVaoBen.Tien = 0;
                
            }
            // Thêm xe vào bến
            xeVaoBen.XE_ID = xe.ID;
            xeVaoBen.NgayTao = DateTime.Now;
            xeVaoBen.NgayVao = NgayTao;
            xeVaoBen.CQ_ID = Cq_Id;
            xeVaoBen.Username = Username;
            xeVaoBen.Loai = loai;
            xeVaoBen.GIAOCA_ID = giaoCa_Id;
            xeVaoBen = XeVaoBenDal.Insert(xeVaoBen);

            giaoCa.NgayCapNhat = DateTime.Now;
            GiaoCaDal.Update(giaoCa);
            return xeVaoBen.ID;
        }
        return 0;
    }
    #endregion

    #region Login
    [WebMethod]
    public bool Login(string username, string password)
    {
        return Security.LoginApi(username, password);
    }
    [WebMethod]
    public Member MemberGetByUsername(string username)
    {
        var mem = MemberDal.SelectByUser(username);
        mem.GiaoCa = GiaoCaDal.SelectByCqIdUsername(mem.CQ_ID, username);
        return mem;
    }
    #endregion
}
