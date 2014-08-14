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
    #region BanHang_PhienLamViec
    #region BO
    public class BanHang_PhienLamViec : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public String Username { get; set; }
        public Int32 CQ_ID { get; set; }
        public Int32 SoLuong { get; set; }
        public Int32 DoanhSo { get; set; }
        public DateTime Ngay { get; set; }
        #endregion
        #region Contructor
        public BanHang_PhienLamViec()
        { }
        #endregion
        #region Customs properties
        public string CQ_Ten { get; set; }

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BanHang_PhienLamViecDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BanHang_PhienLamViecCollection : BaseEntityCollection<BanHang_PhienLamViec>
    { }
    #endregion
    #region Dal
    public class BanHang_PhienLamViecDal
    {
        #region Methods

        public static void DeleteById(Int64 PLV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PLV_ID", PLV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Delete_DeleteById_linhnx", obj);
        }

        public static BanHang_PhienLamViec Insert(BanHang_PhienLamViec item)
        {
            var Item = new BanHang_PhienLamViec();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("PLV_ID", item.ID);
            obj[1] = new SqlParameter("PLV_Username", item.Username);
            obj[2] = new SqlParameter("PLV_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("PLV_SoLuong", item.SoLuong);
            obj[4] = new SqlParameter("PLV_DoanhSo", item.DoanhSo);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("PLV_Ngay", item.Ngay);
            }
            else
            {
                obj[5] = new SqlParameter("PLV_Ngay", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_PhienLamViec Update(BanHang_PhienLamViec item)
        {
            var Item = new BanHang_PhienLamViec();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("PLV_ID", item.ID);
            obj[1] = new SqlParameter("PLV_Username", item.Username);
            obj[2] = new SqlParameter("PLV_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("PLV_SoLuong", item.SoLuong);
            obj[4] = new SqlParameter("PLV_DoanhSo", item.DoanhSo);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("PLV_Ngay", item.Ngay);
            }
            else
            {
                obj[5] = new SqlParameter("PLV_Ngay", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_PhienLamViec SelectById(Int64 PLV_ID)
        {
            var Item = new BanHang_PhienLamViec();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PLV_ID", PLV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_PhienLamViecCollection SelectAll()
        {
            var List = new BanHang_PhienLamViecCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BanHang_PhienLamViec> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<BanHang_PhienLamViec>("sp_tblBanHang_PhienLamViec_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static BanHang_PhienLamViec getFromReader(IDataReader rd)
        {
            var Item = new BanHang_PhienLamViec();
            if (rd.FieldExists("PLV_ID"))
            {
                Item.ID = (Int64)(rd["PLV_ID"]);
            }
            if (rd.FieldExists("PLV_Username"))
            {
                Item.Username = (String)(rd["PLV_Username"]);
            }
            if (rd.FieldExists("PLV_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["PLV_CQ_ID"]);
            }
            if (rd.FieldExists("PLV_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["PLV_SoLuong"]);
            }
            if (rd.FieldExists("PLV_DoanhSo"))
            {
                Item.DoanhSo = (Int32)(rd["PLV_DoanhSo"]);
            }
            if (rd.FieldExists("PLV_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["PLV_Ngay"]);
            }
            if (rd.FieldExists("PLV_CQ_Ten"))
            {
                Item.CQ_Ten = (String)(rd["PLV_CQ_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static BanHang_PhienLamViec SelectByUsername(string Username)
        {
            var Item = new BanHang_PhienLamViec();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Select_SelectByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static BanHang_PhienLamViecCollection SelectByNgay(string Ngay, string Username)
        {
            var List = new BanHang_PhienLamViecCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Ngay", Ngay);
            obj[1] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Select_SelectByNgay_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static BanHang_PhienLamViecCollection SelectByCqId(string CqId)
        {
            var List = new BanHang_PhienLamViecCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CqId", CqId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienLamViec_Select_SelectByCqId_linhnx", obj))
            {
                while (rd.Read())
                {   
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion
}


