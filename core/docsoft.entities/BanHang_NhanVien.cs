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
namespace docsoft.entities
{
    

    #region BanHang_NhanVien
    #region BO
    public class BanHang_NhanVien : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 PLV_ID { get; set; }
        public String NhanVien { get; set; }
        public Double Luong { get; set; }
        public DateTime Ngay { get; set; }
        #endregion
        #region Contructor
        public BanHang_NhanVien()
        { }
        #endregion
        #region Customs properties

        public bool LamViec { get; set; }
        public string Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BanHang_NhanVienDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BanHang_NhanVienCollection : BaseEntityCollection<BanHang_NhanVien>
    { }
    #endregion
    #region Dal
    public class BanHang_NhanVienDal
    {
        #region Methods

        public static void DeleteById(Int64 BHNV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BHNV_ID", BHNV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Delete_DeleteById_linhnx", obj);
        }

        public static BanHang_NhanVien Insert(BanHang_NhanVien item)
        {
            var Item = new BanHang_NhanVien();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("BHNV_ID", item.ID);
            obj[1] = new SqlParameter("BHNV_PLV_ID", item.PLV_ID);
            obj[2] = new SqlParameter("BHNV_NhanVien", item.NhanVien);
            obj[3] = new SqlParameter("BHNV_Luong", item.Luong);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("BHNV_Ngay", item.Ngay);
            }
            else
            {
                obj[4] = new SqlParameter("BHNV_Ngay", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_NhanVien Update(BanHang_NhanVien item)
        {
            var Item = new BanHang_NhanVien();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("BHNV_ID", item.ID);
            obj[1] = new SqlParameter("BHNV_PLV_ID", item.PLV_ID);
            obj[2] = new SqlParameter("BHNV_NhanVien", item.NhanVien);
            obj[3] = new SqlParameter("BHNV_Luong", item.Luong);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("BHNV_Ngay", item.Ngay);
            }
            else
            {
                obj[4] = new SqlParameter("BHNV_Ngay", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_NhanVien SelectById(Int64 BHNV_ID)
        {
            var Item = new BanHang_NhanVien();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BHNV_ID", BHNV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_NhanVienCollection SelectAll()
        {
            var List = new BanHang_NhanVienCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BanHang_NhanVien> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<BanHang_NhanVien>("sp_tblBanHang_NhanVien_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static BanHang_NhanVien getFromReader(IDataReader rd)
        {
            var Item = new BanHang_NhanVien();
            if (rd.FieldExists("BHNV_ID"))
            {
                Item.ID = (Int64)(rd["BHNV_ID"]);
            }
            if (rd.FieldExists("BHNV_PLV_ID"))
            {
                Item.PLV_ID = (Int64)(rd["BHNV_PLV_ID"]);
            }
            if (rd.FieldExists("BHNV_NhanVien"))
            {
                Item.NhanVien = (String)(rd["BHNV_NhanVien"]);
            }
            if (rd.FieldExists("BHNV_Luong"))
            {
                Item.Luong = (Double)(rd["BHNV_Luong"]);
            }
            if (rd.FieldExists("BHNV_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["BHNV_Ngay"]);
            }
            if (rd.FieldExists("BHNV_LamViec"))
            {
                Item.LamViec = (Boolean)(rd["BHNV_LamViec"]);
            }
            if (rd.FieldExists("BHNV_Ten"))
            {
                Item.Ten = (String)(rd["BHNV_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static BanHang_NhanVienCollection SelectByNhanVien(string Username)
        {
            var List = new BanHang_NhanVienCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Select_SelectByNhanVien_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static BanHang_NhanVienCollection SelectByPlvId(string PlvId)
        {
            var List = new BanHang_NhanVienCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PlvId", PlvId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Select_SelectByPlvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void DeleteByUsernamePlvId(string PlvId, string Username)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("PlvId", PlvId);
            obj[1] = new SqlParameter("Username", Username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_NhanVien_Delete_DeleteByUsernamePlvId_linhnx", obj);
        }
        #endregion
    }
    #endregion

    #endregion
}


