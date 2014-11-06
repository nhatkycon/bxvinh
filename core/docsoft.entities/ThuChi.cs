using System;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;

namespace docsoft.entities
{
    #region ThuChi
    #region BO
    public class ThuChi : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public Int32 GIAOCA_ID { get; set; }
        public Int64 XVB_ID { get; set; }
        public Int64 STTBX { get; set; }
        public Int64 STTALL { get; set; }
        public Double Tien { get; set; }
        public String MoTa { get; set; }
        public DateTime Ngay { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public Guid NDTC_ID { get; set; }
        public Boolean Thu { get; set; }
        public Int64 PHOI_ID { get; set; }
        public Int64 TRUYTHU_ID { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public ThuChi()
        { }
        #endregion
        #region Customs properties
        public string STTBXStr
        {
            get { return Lib.FormatMa(STTBX); }
        }
        public string STTALLStr
        {
            get { return Lib.FormatMa(STTALL); }
        }

        public Phoi Phoi { get; set; }
        public Int64 XE_ID { get; set; }
        public string XE_BienSo { get; set; }
        public Int64 PHOI_STTBX { get; set; }
        public string PHOI_STTStr{get { return Lib.FormatMa(PHOI_STTBX, "000000"); }}
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuChiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuChiCollection : BaseEntityCollection<ThuChi>
    { }
    #endregion
    #region Dal
    public class ThuChiDal
    {
        #region Methods

        public static void DeleteById(Int64 TC_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ID", TC_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuChi_Delete_DeleteById_linhnx", obj);
        }

        public static ThuChi Insert(ThuChi item)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[18];
            obj[1] = new SqlParameter("TC_CQ_ID", item.CQ_ID);
            obj[2] = new SqlParameter("TC_GIAOCA_ID", item.GIAOCA_ID);
            obj[3] = new SqlParameter("TC_XVB_ID", item.XVB_ID);
            obj[4] = new SqlParameter("TC_STTBX", item.STTBX);
            obj[5] = new SqlParameter("TC_STTALL", item.STTALL);
            obj[6] = new SqlParameter("TC_Tien", item.Tien);
            obj[7] = new SqlParameter("TC_MoTa", item.MoTa);
            obj[8] = new SqlParameter("TC_Ngay", item.Ngay);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TC_Ngay", item.Ngay);
            }
            else
            {
                obj[8] = new SqlParameter("TC_Ngay", DBNull.Value);
            }
            obj[9] = new SqlParameter("TC_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("TC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("TC_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("TC_NguoiTao", item.NguoiTao);
            obj[11] = new SqlParameter("TC_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("TC_NguoiCapNhat", item.NguoiCapNhat);
            obj[13] = new SqlParameter("TC_NDTC_ID", item.NDTC_ID);
            obj[14] = new SqlParameter("TC_Thu", item.Thu);
            obj[15] = new SqlParameter("TC_PHOI_ID", item.PHOI_ID);
            obj[16] = new SqlParameter("TC_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[17] = new SqlParameter("TC_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuChi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChi Update(ThuChi item)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[18];
            obj[0] = new SqlParameter("TC_ID", item.ID);
            obj[1] = new SqlParameter("TC_CQ_ID", item.CQ_ID);
            obj[2] = new SqlParameter("TC_GIAOCA_ID", item.GIAOCA_ID);
            obj[3] = new SqlParameter("TC_XVB_ID", item.XVB_ID);
            obj[4] = new SqlParameter("TC_STTBX", item.STTBX);
            obj[5] = new SqlParameter("TC_STTALL", item.STTALL);
            obj[6] = new SqlParameter("TC_Tien", item.Tien);
            obj[7] = new SqlParameter("TC_MoTa", item.MoTa);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TC_Ngay", item.Ngay);
            }
            else
            {
                obj[8] = new SqlParameter("TC_Ngay", DBNull.Value);
            }
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("TC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("TC_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("TC_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("TC_NguoiCapNhat", item.NguoiCapNhat);
            obj[13] = new SqlParameter("TC_NDTC_ID", item.NDTC_ID);
            obj[14] = new SqlParameter("TC_Thu", item.Thu);
            obj[15] = new SqlParameter("TC_PHOI_ID", item.PHOI_ID);
            obj[16] = new SqlParameter("TC_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[17] = new SqlParameter("TC_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuChi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChi SelectById(Int64 TC_ID)
        {
            return SelectById(DAL.con(), TC_ID);
        }
        public static ThuChi SelectById(SqlConnection con, Int64 TC_ID)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ID", TC_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ThuChi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChiCollection SelectAll()
        {
            var List = new ThuChiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuChi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuChi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<ThuChi>("sp_tblBx_ThuChi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ThuChi getFromReader(IDataReader rd)
        {
            var Item = new ThuChi();
            if (rd.FieldExists("TC_ID"))
            {
                Item.ID = (Int64)(rd["TC_ID"]);
            }
            if (rd.FieldExists("TC_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["TC_CQ_ID"]);
            }
            if (rd.FieldExists("TC_GIAOCA_ID"))
            {
                Item.GIAOCA_ID = (Int32)(rd["TC_GIAOCA_ID"]);
            }
            if (rd.FieldExists("TC_XVB_ID"))
            {
                Item.XVB_ID = (Int64)(rd["TC_XVB_ID"]);
            }
            if (rd.FieldExists("TC_STTBX"))
            {
                Item.STTBX = (Int64)(rd["TC_STTBX"]);
            }
            if (rd.FieldExists("TC_STTALL"))
            {
                Item.STTALL = (Int64)(rd["TC_STTALL"]);
            }
            if (rd.FieldExists("TC_Tien"))
            {
                Item.Tien = (Double)(rd["TC_Tien"]);
            }
            if (rd.FieldExists("TC_MoTa"))
            {
                Item.MoTa = (String)(rd["TC_MoTa"]);
            }
            if (rd.FieldExists("TC_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["TC_Ngay"]);
            }
            if (rd.FieldExists("TC_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TC_NgayTao"]);
            }
            if (rd.FieldExists("TC_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TC_NguoiTao"]);
            }
            if (rd.FieldExists("TC_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TC_NgayCapNhat"]);
            }
            if (rd.FieldExists("TC_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TC_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TC_NDTC_ID"))
            {
                Item.NDTC_ID = (Guid)(rd["TC_NDTC_ID"]);
            }
            if (rd.FieldExists("TC_Thu"))
            {
                Item.Thu = (Boolean)(rd["TC_Thu"]);
            }
            if (rd.FieldExists("TC_PHOI_ID"))
            {
                Item.PHOI_ID = (Int64)(rd["TC_PHOI_ID"]);
            }
            if (rd.FieldExists("TC_TRUYTHU_ID"))
            {
                Item.TRUYTHU_ID = (Int64)(rd["TC_TRUYTHU_ID"]);
            }
            if (rd.FieldExists("TC_RowId"))
            {
                Item.RowId = (Guid)(rd["TC_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static ThuChi SelectByLastest(SqlConnection con, Int32 CQ_ID)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ThuChi_Select_SelectByLastest_linhnx", obj))
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
