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
    #region BanHang_ChiPhiChiTiet
    #region BO
    public class BanHang_ChiPhiChiTiet : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 BHCP_ID { get; set; }
        public Guid HH_ID { get; set; }
        public Double Xuat { get; set; }
        public Double XuatGia { get; set; }
        public Double XuatTien { get; set; }
        public Double Nhap { get; set; }
        public Double NhapGia { get; set; }
        public Double NhapTien { get; set; }
        public Boolean HeThong { get; set; }
        public String Username { get; set; }
        #endregion
        #region Contructor
        public BanHang_ChiPhiChiTiet()
        { }
        #endregion
        #region Customs properties

        public string HH_Ten { get; set; }
        public string HH_DonVi_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BanHang_ChiPhiChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BanHang_ChiPhiChiTietCollection : BaseEntityCollection<BanHang_ChiPhiChiTiet>
    { }
    #endregion
    #region Dal
    public class BanHang_ChiPhiChiTietDal
    {
        #region Methods

        public static void DeleteById(Int64 CPCT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CPCT_ID", CPCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhiChiTiet_Delete_DeleteById_linhnx", obj);
        }

        public static BanHang_ChiPhiChiTiet Insert(BanHang_ChiPhiChiTiet item)
        {
            var Item = new BanHang_ChiPhiChiTiet();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("CPCT_ID", item.ID);
            obj[1] = new SqlParameter("CPCT_BHCP_ID", item.BHCP_ID);
            obj[2] = new SqlParameter("CPCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("CPCT_Xuat", item.Xuat);
            obj[4] = new SqlParameter("CPCT_XuatGia", item.XuatGia);
            obj[5] = new SqlParameter("CPCT_XuatTien", item.XuatTien);
            obj[6] = new SqlParameter("CPCT_Nhap", item.Nhap);
            obj[7] = new SqlParameter("CPCT_NhapGia", item.NhapGia);
            obj[8] = new SqlParameter("CPCT_NhapTien", item.NhapTien);
            obj[9] = new SqlParameter("CPCT_HeThong", item.HeThong);
            obj[10] = new SqlParameter("CPCT_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhiChiTiet_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_ChiPhiChiTiet Update(BanHang_ChiPhiChiTiet item)
        {
            var Item = new BanHang_ChiPhiChiTiet();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("CPCT_ID", item.ID);
            obj[1] = new SqlParameter("CPCT_BHCP_ID", item.BHCP_ID);
            obj[2] = new SqlParameter("CPCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("CPCT_Xuat", item.Xuat);
            obj[4] = new SqlParameter("CPCT_XuatGia", item.XuatGia);
            obj[5] = new SqlParameter("CPCT_XuatTien", item.XuatTien);
            obj[6] = new SqlParameter("CPCT_Nhap", item.Nhap);
            obj[7] = new SqlParameter("CPCT_NhapGia", item.NhapGia);
            obj[8] = new SqlParameter("CPCT_NhapTien", item.NhapTien);
            obj[9] = new SqlParameter("CPCT_HeThong", item.HeThong);
            obj[10] = new SqlParameter("CPCT_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhiChiTiet_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_ChiPhiChiTiet SelectById(Int64 CPCT_ID)
        {
            var Item = new BanHang_ChiPhiChiTiet();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CPCT_ID", CPCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhiChiTiet_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BanHang_ChiPhiChiTietCollection SelectAll()
        {
            var List = new BanHang_ChiPhiChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBanHang_ChiPhiChiTiet_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BanHang_ChiPhiChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<BanHang_ChiPhiChiTiet>("sp_tblBanHang_ChiPhiChiTiet_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static BanHang_ChiPhiChiTiet getFromReader(IDataReader rd)
        {
            var Item = new BanHang_ChiPhiChiTiet();
            if (rd.FieldExists("CPCT_ID"))
            {
                Item.ID = (Int64)(rd["CPCT_ID"]);
            }
            if (rd.FieldExists("CPCT_BHCP_ID"))
            {
                Item.BHCP_ID = (Int64)(rd["CPCT_BHCP_ID"]);
            }
            if (rd.FieldExists("CPCT_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["CPCT_HH_ID"]);
            }
            if (rd.FieldExists("CPCT_Xuat"))
            {
                Item.Xuat = (Double)(rd["CPCT_Xuat"]);
            }
            if (rd.FieldExists("CPCT_XuatGia"))
            {
                Item.XuatGia = (Double)(rd["CPCT_XuatGia"]);
            }
            if (rd.FieldExists("CPCT_XuatTien"))
            {
                Item.XuatTien = (Double)(rd["CPCT_XuatTien"]);
            }
            if (rd.FieldExists("CPCT_Nhap"))
            {
                Item.Nhap = (Double)(rd["CPCT_Nhap"]);
            }
            if (rd.FieldExists("CPCT_NhapGia"))
            {
                Item.NhapGia = (Double)(rd["CPCT_NhapGia"]);
            }
            if (rd.FieldExists("CPCT_NhapTien"))
            {
                Item.NhapTien = (Double)(rd["CPCT_NhapTien"]);
            }
            if (rd.FieldExists("CPCT_HeThong"))
            {
                Item.HeThong = (Boolean)(rd["CPCT_HeThong"]);
            }
            if (rd.FieldExists("CPCT_Username"))
            {
                Item.Username = (String)(rd["CPCT_Username"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("HH_DonVi_Ten"))
            {
                Item.HH_DonVi_Ten = (String)(rd["HH_DonVi_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static BanHang_ChiPhiChiTietCollection SelectByBHCP(SqlConnection con, Int64 BHCP)
        {
            var List = new BanHang_ChiPhiChiTietCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BHCP", BHCP);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBanHang_ChiPhiChiTiet_Select_SelectByBHCP_linhnx", obj))
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


