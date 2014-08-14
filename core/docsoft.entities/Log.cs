using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{

    #region Log
    #region BO
    public class Log : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int16 LLOG_ID { get; set; }
        public String Ten { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public String RequestIp { get; set; }
        public String GiaTriCu { get; set; }
        public String GiaTriMoi { get; set; }
        public String RawUrl { get; set; }
        public String Info { get; set; }
        public Boolean Checked { get; set; }
        public Guid PRowId { get; set; }
        public String PTen { get; set; }
        #endregion
        #region Contructor
        public Log()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LogDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LogCollection : BaseEntityCollection<Log>
    { }
    #endregion
    #region Dal
    public class LogDal
    {
        #region Methods

        public static void DeleteById(Int32 LOG_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LOG_ID", LOG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Delete_DeleteById_linhnx", obj);
        }

        public static Log Insert(Log item)
        {
            var Item = new Log();
            var obj = new SqlParameter[13];
            obj[1] = new SqlParameter("LOG_LLOG_ID", item.LLOG_ID);
            obj[2] = new SqlParameter("LOG_Ten", item.Ten);
            obj[3] = new SqlParameter("LOG_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("LOG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("LOG_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("LOG_RequestIp", item.RequestIp);
            obj[6] = new SqlParameter("LOG_GiaTriCu", item.GiaTriCu);
            obj[7] = new SqlParameter("LOG_GiaTriMoi", item.GiaTriMoi);
            obj[8] = new SqlParameter("LOG_RawUrl", item.RawUrl);
            obj[9] = new SqlParameter("LOG_Info", item.Info);
            obj[10] = new SqlParameter("LOG_Checked", item.Checked);
            obj[11] = new SqlParameter("LOG_PRowId", item.PRowId);
            obj[12] = new SqlParameter("LOG_PTen", item.PTen);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Log Update(Log item)
        {
            var Item = new Log();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("LOG_ID", item.ID);
            obj[1] = new SqlParameter("LOG_LLOG_ID", item.LLOG_ID);
            obj[2] = new SqlParameter("LOG_Ten", item.Ten);
            obj[3] = new SqlParameter("LOG_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("LOG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("LOG_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("LOG_RequestIp", item.RequestIp);
            obj[6] = new SqlParameter("LOG_GiaTriCu", item.GiaTriCu);
            obj[7] = new SqlParameter("LOG_GiaTriMoi", item.GiaTriMoi);
            obj[8] = new SqlParameter("LOG_RawUrl", item.RawUrl);
            obj[9] = new SqlParameter("LOG_Info", item.Info);
            obj[10] = new SqlParameter("LOG_Checked", item.Checked);
            obj[11] = new SqlParameter("LOG_PRowId", item.PRowId);
            obj[12] = new SqlParameter("LOG_PTen", item.PTen);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Log SelectById(Int32 LOG_ID)
        {
            return SelectById(DAL.con(), LOG_ID);
        }
        public static Log SelectById(SqlConnection con, Int32 LOG_ID)
        {
            var Item = new Log();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LOG_ID", LOG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblLog_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LogCollection SelectAll()
        {
            var List = new LogCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        
        }
        public static Pager<Log> pagerNormal(string url, bool rewrite, string sort, string q, int size, string Username)
        {
            return pagerNormal(DAL.con(), url, rewrite, sort, q, size, Username);
        }
        public static Pager<Log> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string Username)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[2] = new SqlParameter("Username", DBNull.Value);
            }
            var pg = new Pager<Log>(con, "sp_tblLog_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Log getFromReader(IDataReader rd)
        {
            var Item = new Log();
            if (rd.FieldExists("LOG_ID"))
            {
                Item.ID = (Int32)(rd["LOG_ID"]);
            }
            if (rd.FieldExists("LOG_LLOG_ID"))
            {
                Item.LLOG_ID = (Int16)(rd["LOG_LLOG_ID"]);
            }
            if (rd.FieldExists("LOG_Ten"))
            {
                Item.Ten = (String)(rd["LOG_Ten"]);
            }
            if (rd.FieldExists("LOG_Username"))
            {
                Item.Username = (String)(rd["LOG_Username"]);
            }
            if (rd.FieldExists("LOG_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LOG_NgayTao"]);
            }
            if (rd.FieldExists("LOG_RequestIp"))
            {
                Item.RequestIp = (String)(rd["LOG_RequestIp"]);
            }
            if (rd.FieldExists("LOG_GiaTriCu"))
            {
                Item.GiaTriCu = (String)(rd["LOG_GiaTriCu"]);
            }
            if (rd.FieldExists("LOG_GiaTriMoi"))
            {
                Item.GiaTriMoi = (String)(rd["LOG_GiaTriMoi"]);
            }
            if (rd.FieldExists("LOG_RawUrl"))
            {
                Item.RawUrl = (String)(rd["LOG_RawUrl"]);
            }
            if (rd.FieldExists("LOG_Info"))
            {
                Item.Info = (String)(rd["LOG_Info"]);
            }
            if (rd.FieldExists("LOG_Checked"))
            {
                Item.Checked = (Boolean)(rd["LOG_Checked"]);
            }
            if (rd.FieldExists("LOG_PRowId"))
            {
                Item.PRowId = (Guid)(rd["LOG_PRowId"]);
            }
            if (rd.FieldExists("LOG_PTen"))
            {
                Item.PTen = (String)(rd["LOG_PTen"]);
            }
            return Item;
        }
        #endregion
        public  delegate  Log logDele(Log item);
        public static void log(object obj, Log item)
        {
            item.GiaTriMoi = Lib.XmlSerializeToString(obj);
            Insert(item);
            //var dele = new logDele(Insert);
            //dele.BeginInvoke(item, null, null);
        }
        #region Extend
        
        #endregion
    }
    #endregion

    #endregion
}


