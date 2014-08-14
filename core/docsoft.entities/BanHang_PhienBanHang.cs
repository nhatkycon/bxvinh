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
    #region BanHang_PhienBanHang
    #region BO
    public class BanHang_PhienBanHang : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public String Username { get; set; }
        public Int32 CQ_ID { get; set; }
        public Guid HH_ID { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Checked { get; set; }
        public Int64 PLV_ID { get; set; }
        #endregion
        #region Contructor
        public BanHang_PhienBanHang()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BanHang_PhienBanHangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BanHang_PhienBanHangCollection : BaseEntityCollection<BanHang_PhienBanHang>
    { }
    #endregion
    #region Dal
    public class BanHang_PhienBanHangDal
    {
        #region Methods

        public static void DeleteById(Int64 PBH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PBH_ID", PBH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienBanHang_Delete_DeleteById_linhnx", obj);
        }

        public static BanHang_PhienBanHang Insert(BanHang_PhienBanHang item)
        {
            var Item = new BanHang_PhienBanHang();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("PBH_ID", item.ID);
            obj[1] = new SqlParameter("PBH_Username", item.Username);
            obj[2] = new SqlParameter("PBH_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("PBH_HH_ID", item.HH_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PBH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("PBH_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("PBH_Checked", item.Checked);
            obj[6] = new SqlParameter("PBH_PLV_ID", item.PLV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienBanHang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_PhienBanHang Update(BanHang_PhienBanHang item)
        {
            var Item = new BanHang_PhienBanHang();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("PBH_ID", item.ID);
            obj[1] = new SqlParameter("PBH_Username", item.Username);
            obj[2] = new SqlParameter("PBH_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("PBH_HH_ID", item.HH_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PBH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("PBH_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("PBH_Checked", item.Checked);
            obj[6] = new SqlParameter("PBH_PLV_ID", item.PLV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienBanHang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_PhienBanHang SelectById(Int64 PBH_ID)
        {
            var Item = new BanHang_PhienBanHang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PBH_ID", PBH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienBanHang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_PhienBanHangCollection SelectAll()
        {
            var List = new BanHang_PhienBanHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_PhienBanHang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BanHang_PhienBanHang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<BanHang_PhienBanHang>("sp_tblBanHang_PhienBanHang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static BanHang_PhienBanHang getFromReader(IDataReader rd)
        {
            var Item = new BanHang_PhienBanHang();
            if (rd.FieldExists("PBH_ID"))
            {
                Item.ID = (Int64)(rd["PBH_ID"]);
            }
            if (rd.FieldExists("PBH_Username"))
            {
                Item.Username = (String)(rd["PBH_Username"]);
            }
            if (rd.FieldExists("PBH_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["PBH_CQ_ID"]);
            }
            if (rd.FieldExists("PBH_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["PBH_HH_ID"]);
            }
            if (rd.FieldExists("PBH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PBH_NgayTao"]);
            }
            if (rd.FieldExists("PBH_Checked"))
            {
                Item.Checked = (Boolean)(rd["PBH_Checked"]);
            }
            if (rd.FieldExists("PBH_PLV_ID"))
            {
                Item.PLV_ID = (Int64)(rd["PBH_PLV_ID"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        
        #endregion
    }
    #endregion

    #endregion
}


