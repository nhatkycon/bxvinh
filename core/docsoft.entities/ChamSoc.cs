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
    #region ChamSoc
    #region BO
    public class ChamSoc : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ma { get; set; }
        public Guid KH_ID { get; set; }
        public Guid TT_ID { get; set; }
        public Guid LOAI_ID { get; set; }
        public String NoiDung { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public ChamSoc()
        { }
        #endregion
        #region Customs properties

        public string TT_Ten { get; set; }
        public string LOAI_Ten { get; set; }
        public string KH_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ChamSocDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ChamSocCollection : BaseEntityCollection<ChamSoc>
    { }
    #endregion
    #region Dal
    public class ChamSocDal
    {
        #region Methods

        public static void DeleteById(Guid CS_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CS_ID", CS_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblChamSoc_Delete_DeleteById_linhnx", obj);
        }

        public static ChamSoc Insert(ChamSoc item)
        {
            var Item = new ChamSoc();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("CS_ID", item.ID);
            obj[1] = new SqlParameter("CS_Ma", item.Ma);
            obj[2] = new SqlParameter("CS_KH_ID", item.KH_ID);
            obj[3] = new SqlParameter("CS_TT_ID", item.TT_ID);
            obj[4] = new SqlParameter("CS_LOAI_ID", item.LOAI_ID);
            obj[5] = new SqlParameter("CS_NoiDung", item.NoiDung);
            obj[6] = new SqlParameter("CS_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("CS_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("CS_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChamSoc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChamSoc Update(ChamSoc item)
        {
            var Item = new ChamSoc();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("CS_ID", item.ID);
            obj[1] = new SqlParameter("CS_Ma", item.Ma);
            obj[2] = new SqlParameter("CS_KH_ID", item.KH_ID);
            obj[3] = new SqlParameter("CS_TT_ID", item.TT_ID);
            obj[4] = new SqlParameter("CS_LOAI_ID", item.LOAI_ID);
            obj[5] = new SqlParameter("CS_NoiDung", item.NoiDung);
            obj[6] = new SqlParameter("CS_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("CS_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("CS_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChamSoc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChamSoc SelectById(Guid CS_ID)
        {
            return SelectById(DAL.con(),CS_ID);
        }

        public static ChamSocCollection SelectAll()
        {
            var List = new ChamSocCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChamSoc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ChamSoc> pagerNormal(SqlConnection con, string url, bool rewrite, string sort
            , string q, int size, string TT_ID, string LOAI_ID)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TT_ID))
            {
                obj[2] = new SqlParameter("TT_ID", TT_ID);
            }
            else
            {
                obj[2] = new SqlParameter("TT_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(LOAI_ID))
            {
                obj[3] = new SqlParameter("LOAI_ID", LOAI_ID);
            }
            else
            {
                obj[3] = new SqlParameter("LOAI_ID", DBNull.Value);
            }

            var pg = new Pager<ChamSoc>(con, "sp_tblChamSoc_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ChamSoc getFromReader(IDataReader rd)
        {
            var Item = new ChamSoc();
            if (rd.FieldExists("CS_ID"))
            {
                Item.ID = (Guid)(rd["CS_ID"]);
            }
            if (rd.FieldExists("CS_Ma"))
            {
                Item.Ma = (String)(rd["CS_Ma"]);
            }
            if (rd.FieldExists("CS_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["CS_KH_ID"]);
            }
            if (rd.FieldExists("CS_TT_ID"))
            {
                Item.TT_ID = (Guid)(rd["CS_TT_ID"]);
            }
            if (rd.FieldExists("CS_LOAI_ID"))
            {
                Item.LOAI_ID = (Guid)(rd["CS_LOAI_ID"]);
            }
            if (rd.FieldExists("CS_NoiDung"))
            {
                Item.NoiDung = (String)(rd["CS_NoiDung"]);
            }
            if (rd.FieldExists("CS_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["CS_NguoiTao"]);
            }
            if (rd.FieldExists("CS_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["CS_NgayTao"]);
            }
            if (rd.FieldExists("TT_Ten"))
            {
                Item.TT_Ten = (String)(rd["TT_Ten"]);
            }
            if (rd.FieldExists("LOAI_Ten"))
            {
                Item.LOAI_Ten = (String)(rd["LOAI_Ten"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["KH_Ten"]);
            }
            return Item;
        }
        public static ChamSocCollection SelectByKhId(SqlConnection con,string KhId)
        {
            var List = new ChamSocCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("KH_ID", KhId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChamSoc_Select_SelectByKhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static ChamSoc SelectById(SqlConnection con, Guid CS_ID)
        {
            var Item = new ChamSoc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CS_ID", CS_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChamSoc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
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


