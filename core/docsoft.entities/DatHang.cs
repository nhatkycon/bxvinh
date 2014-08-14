using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
#region DatHang
#region BO
public class DatHang : BaseEntity
{
    #region Properties
    public Guid ID { get; set; }
    public String KH_Ten { get; set; }
    public String Ma { get; set; }
    public String KH_Email { get; set; }
    public String KH_Mobile { get; set; }
    public String KH_DiaChi { get; set; }
    public Guid KH_ID { get; set; }
    public String KH_Facebook { get; set; }
    public String Facebook { get; set; }
    public Int32 GiaTri { get; set; }
    public Int32 PhiVanChuyen { get; set; }
    public Int32 Tong { get; set; }
    public Boolean GiaoHang { get; set; }
    public DateTime NgayGiao { get; set; }
    public DateTime NgayTao { get; set; }
    public Boolean ThanhToan { get; set; }
    public String UPS_Code { get; set; }
    public String PaypalTx { get; set; }
    public String Username { get; set; }
    public DateTime NgayDat { get; set; }
    public Guid TT_ID { get; set; }
    public Guid NguonGoc_ID { get; set; }
    public Boolean Readed { get; set; }
    public String FacebookUrl { get; set; }
    public String GhiChu { get; set; }
    public Int32 UuTien { get; set; }
    public DateTime NgayGiaoYeuCau { get; set; }
    public string Map { get; set; }
    public Boolean Huy { get; set; }
    public Int32 TraLai { get; set; }
    public Boolean KhachBuon { get; set; }
    public Int32 TienThuVe { get; set; }

    #endregion
    #region Contructor
    public DatHang()
    { }
    #endregion
    #region Customs properties

    public string TT_Ten { get; set; }
    public string NguonGoc_Ten { get; set; }
    public int SoLuong { get; set; }
    #endregion
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return DatHangDal.getFromReader(rd);
    }
}
#endregion
#region Collection
public class DatHangCollection : BaseEntityCollection<DatHang>
{ }
#endregion
#region Dal
public class DatHangDal
{
    #region Methods

    public static void DeleteById(Guid DH_ID)
    {
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("DH_ID", DH_ID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Delete_DeleteById_linhnx", obj);
    }

    public static DatHang Insert(DatHang item)
    {
        var Item = new DatHang();
        var obj = new SqlParameter[32];
        obj[0] = new SqlParameter("DH_ID", item.ID);
        obj[1] = new SqlParameter("DH_Ma", item.Ma);
        obj[2] = new SqlParameter("DH_KH_Ten", item.KH_Ten);
        obj[3] = new SqlParameter("DH_KH_Email", item.KH_Email);
        obj[4] = new SqlParameter("DH_KH_Mobile", item.KH_Mobile);
        obj[5] = new SqlParameter("DH_KH_DiaChi", item.KH_DiaChi);
        obj[6] = new SqlParameter("DH_KH_ID", item.KH_ID);
        obj[7] = new SqlParameter("DH_KH_Facebook", item.KH_Facebook);
        obj[8] = new SqlParameter("DH_Facebook", item.Facebook);
        obj[9] = new SqlParameter("DH_GiaTri", item.GiaTri);
        obj[10] = new SqlParameter("DH_PhiVanChuyen", item.PhiVanChuyen);
        obj[11] = new SqlParameter("DH_Tong", item.Tong);
        obj[12] = new SqlParameter("DH_GiaoHang", item.GiaoHang);
        if (item.NgayGiao > DateTime.MinValue)
        {
            obj[13] = new SqlParameter("DH_NgayGiao", item.NgayGiao);
        }
        else
        {
            obj[13] = new SqlParameter("DH_NgayGiao", DBNull.Value);
        }
        if (item.NgayTao > DateTime.MinValue)
        {
            obj[14] = new SqlParameter("DH_NgayTao", item.NgayTao);
        }
        else
        {
            obj[14] = new SqlParameter("DH_NgayTao", DBNull.Value);
        }
        obj[15] = new SqlParameter("DH_ThanhToan", item.ThanhToan);
        obj[16] = new SqlParameter("DH_UPS_Code", item.UPS_Code);
        obj[17] = new SqlParameter("DH_PaypalTx", item.PaypalTx);
        obj[18] = new SqlParameter("DH_Username", item.Username);
        if (item.NgayDat > DateTime.MinValue)
        {
            obj[19] = new SqlParameter("DH_NgayDat", item.NgayDat);
        }
        else
        {
            obj[19] = new SqlParameter("DH_NgayDat", DBNull.Value);
        }
        obj[20] = new SqlParameter("DH_TT_ID", item.TT_ID);
        obj[21] = new SqlParameter("DH_NguonGoc_ID", item.NguonGoc_ID);
        obj[22] = new SqlParameter("DH_Readed", item.Readed);
        obj[23] = new SqlParameter("DH_FacebookUrl", item.FacebookUrl);
        obj[24] = new SqlParameter("DH_GhiChu", item.GhiChu);
        obj[25] = new SqlParameter("DH_UuTien", item.UuTien);
        if (item.NgayGiaoYeuCau > DateTime.MinValue)
        {
            obj[26] = new SqlParameter("DH_NgayGiaoYeuCau", item.NgayGiaoYeuCau);
        }
        else
        {
            obj[26] = new SqlParameter("DH_NgayGiaoYeuCau", DBNull.Value);
        }
        obj[27] = new SqlParameter("DH_Map", item.Map);
        obj[28] = new SqlParameter("DH_Huy", item.Huy);
        obj[29] = new SqlParameter("DH_TraLai", item.TraLai);
        obj[30] = new SqlParameter("DH_KhachBuon", item.KhachBuon);
        obj[31] = new SqlParameter("DH_TienThuVe", item.TienThuVe);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Insert_InsertNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHang Update(DatHang item)
    {
        var Item = new DatHang();
        var obj = new SqlParameter[32];
        obj[0] = new SqlParameter("DH_ID", item.ID);
        obj[1] = new SqlParameter("DH_Ma", item.Ma);
        obj[2] = new SqlParameter("DH_KH_Ten", item.KH_Ten);
        obj[3] = new SqlParameter("DH_KH_Email", item.KH_Email);
        obj[4] = new SqlParameter("DH_KH_Mobile", item.KH_Mobile);
        obj[5] = new SqlParameter("DH_KH_DiaChi", item.KH_DiaChi);
        obj[6] = new SqlParameter("DH_KH_ID", item.KH_ID);
        obj[7] = new SqlParameter("DH_KH_Facebook", item.KH_Facebook);
        obj[8] = new SqlParameter("DH_Facebook", item.Facebook);
        obj[9] = new SqlParameter("DH_GiaTri", item.GiaTri);
        obj[10] = new SqlParameter("DH_PhiVanChuyen", item.PhiVanChuyen);
        obj[11] = new SqlParameter("DH_Tong", item.Tong);
        obj[12] = new SqlParameter("DH_GiaoHang", item.GiaoHang);
        if (item.NgayGiao > DateTime.MinValue)
        {
            obj[13] = new SqlParameter("DH_NgayGiao", item.NgayGiao);
        }
        else
        {
            obj[13] = new SqlParameter("DH_NgayGiao", DBNull.Value);
        }
        if (item.NgayTao > DateTime.MinValue)
        {
            obj[14] = new SqlParameter("DH_NgayTao", item.NgayTao);
        }
        else
        {
            obj[14] = new SqlParameter("DH_NgayTao", DBNull.Value);
        }
        obj[15] = new SqlParameter("DH_ThanhToan", item.ThanhToan);
        obj[16] = new SqlParameter("DH_UPS_Code", item.UPS_Code);
        obj[17] = new SqlParameter("DH_PaypalTx", item.PaypalTx);
        obj[18] = new SqlParameter("DH_Username", item.Username);
        if (item.NgayDat > DateTime.MinValue)
        {
            obj[19] = new SqlParameter("DH_NgayDat", item.NgayDat);
        }
        else
        {
            obj[19] = new SqlParameter("DH_NgayDat", DBNull.Value);
        }
        obj[20] = new SqlParameter("DH_TT_ID", item.TT_ID);
        obj[21] = new SqlParameter("DH_NguonGoc_ID", item.NguonGoc_ID);
        obj[22] = new SqlParameter("DH_Readed", item.Readed);
        obj[23] = new SqlParameter("DH_FacebookUrl", item.FacebookUrl);
        obj[24] = new SqlParameter("DH_GhiChu", item.GhiChu);
        obj[25] = new SqlParameter("DH_UuTien", item.UuTien);
        if (item.NgayGiaoYeuCau > DateTime.MinValue)
        {
            obj[26] = new SqlParameter("DH_NgayGiaoYeuCau", item.NgayGiaoYeuCau);
        }
        else
        {
            obj[26] = new SqlParameter("DH_NgayGiaoYeuCau", DBNull.Value);
        }
        obj[27] = new SqlParameter("DH_Map", item.Map);
        obj[28] = new SqlParameter("DH_Huy", item.Huy);
        obj[29] = new SqlParameter("DH_TraLai", item.TraLai);
        obj[30] = new SqlParameter("DH_KhachBuon", item.KhachBuon);
        obj[31] = new SqlParameter("DH_TienThuVe", item.TienThuVe);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Update_UpdateNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHang SelectById(Guid DH_ID)
    {
        var Item = new DatHang();
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("DH_ID", DH_ID);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Select_SelectById_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHangCollection SelectAll()
    {
        var List = new DatHangCollection();
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Select_SelectAll_linhnx"))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }
    public static Pager<DatHang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
    {
        return pagerNormal(DAL.con(), url, rewrite, sort, q, size);
    }
    public static Pager<DatHang> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size)
    {
        var obj = new SqlParameter[2];
        obj[0] = new SqlParameter("Sort", sort);
        obj[1] = new SqlParameter("q", q);
        var pg = new Pager<DatHang>(con, "sp_tblDatHang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
        return pg;
    }
    #endregion

    #region Utilities
    public static DatHang getFromReader(IDataReader rd)
    {
        var Item = new DatHang();
        if (rd.FieldExists("DH_ID"))
        {
            Item.ID = (Guid)(rd["DH_ID"]);
        }
        if (rd.FieldExists("DH_Ma"))
        {
            Item.Ma = (String)(rd["DH_Ma"]);
        }
        if (rd.FieldExists("DH_KH_Ten"))
        {
            Item.KH_Ten = (String)(rd["DH_KH_Ten"]);
        }
        if (rd.FieldExists("DH_KH_Email"))
        {
            Item.KH_Email = (String)(rd["DH_KH_Email"]);
        }
        if (rd.FieldExists("DH_KH_Mobile"))
        {
            Item.KH_Mobile = (String)(rd["DH_KH_Mobile"]);
        }
        if (rd.FieldExists("DH_KH_DiaChi"))
        {
            Item.KH_DiaChi = (String)(rd["DH_KH_DiaChi"]);
        }
        if (rd.FieldExists("DH_KH_ID"))
        {
            Item.KH_ID = (Guid)(rd["DH_KH_ID"]);
        }
        if (rd.FieldExists("DH_KH_Facebook"))
        {
            Item.KH_Facebook = (String)(rd["DH_KH_Facebook"]);
        }
        if (rd.FieldExists("DH_Facebook"))
        {
            Item.Facebook = (String)(rd["DH_Facebook"]);
        }
        if (rd.FieldExists("DH_GiaTri"))
        {
            Item.GiaTri = (Int32)(rd["DH_GiaTri"]);
        }
        if (rd.FieldExists("DH_PhiVanChuyen"))
        {
            Item.PhiVanChuyen = (Int32)(rd["DH_PhiVanChuyen"]);
        }
        if (rd.FieldExists("DH_Tong"))
        {
            Item.Tong = (Int32)(rd["DH_Tong"]);
        }
        if (rd.FieldExists("DH_GiaoHang"))
        {
            Item.GiaoHang = (Boolean)(rd["DH_GiaoHang"]);
        }
        if (rd.FieldExists("DH_NgayGiao"))
        {
            Item.NgayGiao = (DateTime)(rd["DH_NgayGiao"]);
        }
        if (rd.FieldExists("DH_NgayTao"))
        {
            Item.NgayTao = (DateTime)(rd["DH_NgayTao"]);
        }
        if (rd.FieldExists("DH_ThanhToan"))
        {
            Item.ThanhToan = (Boolean)(rd["DH_ThanhToan"]);
        }
        if (rd.FieldExists("DH_UPS_Code"))
        {
            Item.UPS_Code = (String)(rd["DH_UPS_Code"]);
        }
        if (rd.FieldExists("DH_PaypalTx"))
        {
            Item.PaypalTx = (String)(rd["DH_PaypalTx"]);
        }
        if (rd.FieldExists("DH_Username"))
        {
            Item.Username = (String)(rd["DH_Username"]);
        }
        if (rd.FieldExists("DH_NgayDat"))
        {
            Item.NgayDat = (DateTime)(rd["DH_NgayDat"]);
        }
        if (rd.FieldExists("DH_TT_ID"))
        {
            Item.TT_ID = (Guid)(rd["DH_TT_ID"]);
        }
        if (rd.FieldExists("DH_NguonGoc_ID"))
        {
            Item.NguonGoc_ID = (Guid)(rd["DH_NguonGoc_ID"]);
        }
        if (rd.FieldExists("DH_Readed"))
        {
            Item.Readed = (Boolean)(rd["DH_Readed"]);
        }
        if (rd.FieldExists("DH_FacebookUrl"))
        {
            Item.FacebookUrl = (String)(rd["DH_FacebookUrl"]);
        }
        if (rd.FieldExists("DH_GhiChu"))
        {
            Item.GhiChu = (String)(rd["DH_GhiChu"]);
        }
        if (rd.FieldExists("DH_UuTien"))
        {
            Item.UuTien = (Int32)(rd["DH_UuTien"]);
        }
        if (rd.FieldExists("DH_NgayGiaoYeuCau"))
        {
            Item.NgayGiaoYeuCau = (DateTime)(rd["DH_NgayGiaoYeuCau"]);
        }

        if (rd.FieldExists("TT_Ten"))
        {
            Item.TT_Ten = (String)(rd["TT_Ten"]);
        }
        if (rd.FieldExists("NguonGoc_Ten"))
        {
            Item.NguonGoc_Ten = (String)(rd["NguonGoc_Ten"]);
        }
        if (rd.FieldExists("DH_SoLuong"))
        {
            Item.SoLuong = (Int32)(rd["DH_SoLuong"]);
        }
        if (rd.FieldExists("DH_Map"))
        {
            Item.Map = (String)(rd["DH_Map"]);
        }
        if (rd.FieldExists("DH_Huy"))
        {
            Item.Huy = (Boolean)(rd["DH_Huy"]);
        }
        if (rd.FieldExists("DH_TraLai"))
        {
            Item.TraLai = (Int32)(rd["DH_TraLai"]);
        }
        if (rd.FieldExists("DH_TienThuVe"))
        {
            Item.TienThuVe = (Int32)(rd["DH_TienThuVe"]);
        }
        if (rd.FieldExists("DH_KhachBuon"))
        {
            Item.KhachBuon = (Boolean)(rd["DH_KhachBuon"]);
        }
        return Item;
    }
    #endregion

    #region Extend
    public static Pager<DatHang> pagerNormalChuaGiao(string url, bool rewrite, string sort, int size)
    {
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("Sort", sort);
        var pg = new Pager<DatHang>("sp_tblDatHang_Pager_pagerNormalChuaGiao_linhnx", "page", size, 10, rewrite, url, obj);
        return pg;
    }
    public static void GiaoById(string DH_ID)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("ID", DH_ID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Update_GiaoById_linhnx", obj);
    }
    public static DatHangCollection SelectByUser(SqlConnection con, string Username, int Top)
    {
        var List = new DatHangCollection();
        SqlParameter[] obj = new SqlParameter[2];
        obj[0] = new SqlParameter("Username", Username);
        obj[1] = new SqlParameter("Top", Top);
        using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDatHang_Select_ByUsername_linhnx", obj))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }
    public static DatHangCollection SelectByKhId(SqlConnection con, string KhId, int Top)
    {
        var List = new DatHangCollection();
        var obj = new SqlParameter[2];
        obj[0] = new SqlParameter("KH_ID", KhId);
        obj[1] = new SqlParameter("Top", Top);
        using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDatHang_Select_SelectByKhId_linhnx", obj))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }

    public static Pager<DatHang> pagerAll(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TT_ID, string GiaoHang, string Username)
    {
        var obj = new SqlParameter[5];
        obj[0] = new SqlParameter("Sort", sort);
        obj[1] = new SqlParameter("q", q);
        if (string.IsNullOrEmpty(TT_ID))
        {
            obj[2] = new SqlParameter("TT_ID", DBNull.Value);
        }
        else
        {
            obj[2] = new SqlParameter("TT_ID", TT_ID);
        }
        if (string.IsNullOrEmpty(GiaoHang))
        {
            obj[3] = new SqlParameter("GiaoHang", DBNull.Value);
        }
        else
        {
            obj[3] = new SqlParameter("GiaoHang", GiaoHang);
        }
        if (string.IsNullOrEmpty(Username))
        {
            obj[4] = new SqlParameter("Username", DBNull.Value);
        }
        else
        {
            obj[4] = new SqlParameter("Username", Username);
        }
        var pg = new Pager<DatHang>(con, "sp_tblDatHang_Pager_pagerAll_linhnx", "page", size, 10, rewrite, url, obj);
        return pg;
    }
    #endregion
}
#endregion

#endregion