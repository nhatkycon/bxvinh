using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region TimKiem
    #region BO
    public class TimKiem : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PRowId { get; set; }
        public String Loai { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public TimKiem()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TimKiemDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TimKiemCollection : BaseEntityCollection<TimKiem>
    { }
    #endregion
    #region Dal
    public class TimKiemDal
    {
        #region Methods

        public static void DeleteById(Guid TK_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TK_ID", TK_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTimKiem_Delete_DeleteById_linhnx", obj);
        }
        public static void DeleteByPRowId(SqlConnection con, Guid PRowId)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TK_PRowId", PRowId);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_tblTimKiem_Delete_DeleteByTK_PRowId_linhnx", obj);
        }
        public static TimKiem Insert(TimKiem item)
        {
            return Insert(DAL.con(), item);
        }
        public static TimKiem Insert(SqlConnection con, TimKiem item)
        {
            var Item = new TimKiem();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("TK_ID", item.ID);
            obj[1] = new SqlParameter("TK_PRowId", item.PRowId);
            obj[2] = new SqlParameter("TK_Loai", item.Loai);
            obj[3] = new SqlParameter("TK_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("TK_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("TK_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTimKiem_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TimKiem Update(TimKiem item)
        {
            var Item = new TimKiem();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("TK_ID", item.ID);
            obj[1] = new SqlParameter("TK_PRowId", item.PRowId);
            obj[2] = new SqlParameter("TK_Loai", item.Loai);
            obj[3] = new SqlParameter("TK_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("TK_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("TK_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTimKiem_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TimKiem SelectById(Guid TK_ID)
        {
            var Item = new TimKiem();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TK_ID", TK_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTimKiem_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TimKiemCollection SelectAll()
        {
            var List = new TimKiemCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTimKiem_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TimKiem> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<TimKiem>("sp_tblTimKiem_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TimKiem getFromReader(IDataReader rd)
        {
            var Item = new TimKiem();
            if (rd.FieldExists("TK_ID"))
            {
                Item.ID = (Guid)(rd["TK_ID"]);
            }
            if (rd.FieldExists("TK_PRowId"))
            {
                Item.PRowId = (Guid)(rd["TK_PRowId"]);
            }
            if (rd.FieldExists("TK_Loai"))
            {
                Item.Loai = (String)(rd["TK_Loai"]);
            }
            if (rd.FieldExists("TK_NoiDung"))
            {
                Item.NoiDung = (String)(rd["TK_NoiDung"]);
            }
            if (rd.FieldExists("TK_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TK_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend

        public delegate void AddDele(object obj, Guid key);
        public static void Add(object obj, Guid key)
        {
            var list = obj.GetType().GetProperties().Where(p => (p.PropertyType == typeof(String) || p.PropertyType == typeof(string))).ToList();
            DeleteByPRowId(DAL.con(), key);
            using(var con = DAL.con())
            {
                foreach (var p in list)
                {
                    try
                    {
                        if (p.GetValue(obj, null) != null)
                        {
                            if (string.IsNullOrEmpty(p.GetValue(obj, null).ToString()))
                                continue;
                            Insert(con, new TimKiem()
                            {
                                ID = Guid.NewGuid()
                                ,
                                Loai = obj.GetType().Name
                                ,
                                NgayTao = DateTime.Now
                                ,
                                NoiDung = p.GetValue(obj, null).ToString()
                                ,
                                PRowId = key
                            });
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        Insert(con, new TimKiem()
                        {
                            ID = Guid.NewGuid()
                            ,
                            Loai = p.Name
                            ,
                            NgayTao = DateTime.Now
                            ,
                            NoiDung = "Lỗi"
                            ,
                            PRowId = key
                        });
                    }
                    
                }
            }
            
        }
        public static void AddObject(object obj,Guid key)
        {
            var dele = new AddDele(Add);
            dele.BeginInvoke(obj, key,null,null);
        }

        #endregion
    }
    #endregion

    #endregion
    
}


