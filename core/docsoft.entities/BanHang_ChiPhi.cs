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
    #region BanHang_ChiPhi
    #region BO
    public class BanHang_ChiPhi : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 PLV_ID { get; set; }
        public Double Tong { get; set; }
        public DateTime Ngay { get; set; }
        public String Username { get; set; }
        #endregion
        #region Contructor
        public BanHang_ChiPhi()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BanHang_ChiPhiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BanHang_ChiPhiCollection : BaseEntityCollection<BanHang_ChiPhi>
    { }
    #endregion
    #region Dal
    public class BanHang_ChiPhiDal
    {
        #region Methods

        public static void DeleteById(Int64 BHCP_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BHCP_ID", BHCP_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhi_Delete_DeleteById_linhnx", obj);
        }

        public static BanHang_ChiPhi Insert(BanHang_ChiPhi item)
        {
            var Item = new BanHang_ChiPhi();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("BHCP_ID", item.ID);
            obj[1] = new SqlParameter("BHCP_PLV_ID", item.PLV_ID);
            obj[2] = new SqlParameter("BHCP_Tong", item.Tong);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("BHCP_Ngay", item.Ngay);
            }
            else
            {
                obj[3] = new SqlParameter("BHCP_Ngay", DBNull.Value);
            }
            obj[4] = new SqlParameter("BHCP_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_ChiPhi Update(BanHang_ChiPhi item)
        {
            var Item = new BanHang_ChiPhi();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("BHCP_ID", item.ID);
            obj[1] = new SqlParameter("BHCP_PLV_ID", item.PLV_ID);
            obj[2] = new SqlParameter("BHCP_Tong", item.Tong);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("BHCP_Ngay", item.Ngay);
            }
            else
            {
                obj[3] = new SqlParameter("BHCP_Ngay", DBNull.Value);
            }
            obj[4] = new SqlParameter("BHCP_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_ChiPhi SelectById(SqlConnection con, Int64 BHCP_ID)
        {
            var Item = new BanHang_ChiPhi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BHCP_ID", BHCP_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBanHang_ChiPhi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_ChiPhiCollection SelectAll()
        {
            var List = new BanHang_ChiPhiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BanHang_ChiPhi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<BanHang_ChiPhi>("sp_tblBanHang_ChiPhi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static BanHang_ChiPhi getFromReader(IDataReader rd)
        {
            var Item = new BanHang_ChiPhi();
            if (rd.FieldExists("BHCP_ID"))
            {
                Item.ID = (Int64)(rd["BHCP_ID"]);
            }
            if (rd.FieldExists("BHCP_PLV_ID"))
            {
                Item.PLV_ID = (Int64)(rd["BHCP_PLV_ID"]);
            }
            if (rd.FieldExists("BHCP_Tong"))
            {
                Item.Tong = (Double)(rd["BHCP_Tong"]);
            }
            if (rd.FieldExists("BHCP_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["BHCP_Ngay"]);
            }
            if (rd.FieldExists("BHCP_Username"))
            {
                Item.Username = (String)(rd["BHCP_Username"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static BanHang_ChiPhi SelectByPLVId(SqlConnection con, Int64 PLV_ID)
        {
            var Item = new BanHang_ChiPhi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PLV_ID", PLV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBanHang_ChiPhi_Select_SelectByPLVId_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}


