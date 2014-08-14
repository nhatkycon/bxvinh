using System;
using System.Collections.Generic;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;

namespace docsoft.entities
{
    public class BxVinhConfig
    {
        public const Int32 SoNgayHetHan = -1;
    }

    public class ListThang
    {
        public int Thang { get; set; }
        public List<LichItem> Ngay { get; set; }
        public int Tong { get; set; }
        public int TongBieuDo { get; set; }
        public ListThang()
        {
            Ngay = new List<LichItem>();
        }
    }

    public class LichItem
    {
        public DateTime Day { get; set; }
        public int SoChuyen { get; set; }
        /// <summary>
        /// Có 3 kiểu: 1- Chấm công bình thường. 2- Chấm công do quản lý điều độ duyệt. 3- Chấm công do lãnh đạo duyệt truy thu.
        /// </summary>
        public int KieuChamCong { get; set; }
        public string KieuChamCongClass
        {
            get
            {
                switch (KieuChamCong)
                {
                    case 1:
                        return "success";
                        break;
                    case 2:
                        return "warning";
                        break;
                    case 3:
                        return "danger";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }

        public bool Clickable
        {
            get { return Day < DateTime.Now.AddDays(-1); }
        }
        public bool Clickactive { get; set; }
        public Int64 TRUYTHU_ID { get; set; }
        public Int64 PHOI_ID { get; set; }
        public List<ChamCong> List { get; set; }

        public LichItem()
        {
            List = new List<ChamCong>();
        }
    }

    #region LoaiBieuDo
    #region BO
    public class LoaiBieuDo : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Int16 SoTuyenKhoan { get; set; }
        public Int16 CachNgay { get; set; }
        public Boolean KhoanTuyen { get; set; }
        public Boolean HaiTuyenTrenNgay { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public LoaiBieuDo()
        { }
        #endregion
        #region Customs properties
        public string Url
        {
            get { return string.Format("/lib/pages/LoaiBieuDo/Add.aspx?ID={0}", ID); }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LoaiBieuDoDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LoaiBieuDoCollection : BaseEntityCollection<LoaiBieuDo>
    { }
    #endregion
    #region Dal
    public class LoaiBieuDoDal
    {
        #region Methods

        public static void DeleteById(Int32 LBD_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LBD_ID", LBD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiBieuDo_Delete_DeleteById_linhnx", obj);
        }

        public static LoaiBieuDo Insert(LoaiBieuDo item)
        {
            var Item = new LoaiBieuDo();
            var obj = new SqlParameter[10];
            obj[1] = new SqlParameter("LBD_Ten", item.Ten);
            obj[2] = new SqlParameter("LBD_SoTuyenKhoan", item.SoTuyenKhoan);
            obj[3] = new SqlParameter("LBD_CachNgay", item.CachNgay);
            obj[4] = new SqlParameter("LBD_KhoanTuyen", item.KhoanTuyen);
            obj[5] = new SqlParameter("LBD_HaiTuyenTrenNgay", item.HaiTuyenTrenNgay);
            obj[6] = new SqlParameter("LBD_Username", item.Username);
            obj[7] = new SqlParameter("LBD_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LBD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("LBD_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("LBD_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("LBD_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("LBD_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("LBD_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiBieuDo_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiBieuDo Update(LoaiBieuDo item)
        {
            var Item = new LoaiBieuDo();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("LBD_ID", item.ID);
            obj[1] = new SqlParameter("LBD_Ten", item.Ten);
            obj[2] = new SqlParameter("LBD_SoTuyenKhoan", item.SoTuyenKhoan);
            obj[3] = new SqlParameter("LBD_CachNgay", item.CachNgay);
            obj[4] = new SqlParameter("LBD_KhoanTuyen", item.KhoanTuyen);
            obj[5] = new SqlParameter("LBD_HaiTuyenTrenNgay", item.HaiTuyenTrenNgay);
            obj[6] = new SqlParameter("LBD_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LBD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("LBD_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("LBD_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("LBD_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("LBD_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiBieuDo_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiBieuDo SelectById(Int32 LBD_ID)
        {
            var Item = new LoaiBieuDo();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LBD_ID", LBD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiBieuDo_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiBieuDoCollection SelectAll()
        {
            var List = new LoaiBieuDoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiBieuDo_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LoaiBieuDo> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<LoaiBieuDo>("sp_tblBx_LoaiBieuDo_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LoaiBieuDo getFromReader(IDataReader rd)
        {
            var Item = new LoaiBieuDo();
            if (rd.FieldExists("LBD_ID"))
            {
                Item.ID = (Int32)(rd["LBD_ID"]);
            }
            if (rd.FieldExists("LBD_Ten"))
            {
                Item.Ten = (String)(rd["LBD_Ten"]);
            }
            if (rd.FieldExists("LBD_SoTuyenKhoan"))
            {
                Item.SoTuyenKhoan = (Int16)(rd["LBD_SoTuyenKhoan"]);
            }
            if (rd.FieldExists("LBD_CachNgay"))
            {
                Item.CachNgay = (Int16)(rd["LBD_CachNgay"]);
            }
            if (rd.FieldExists("LBD_KhoanTuyen"))
            {
                Item.KhoanTuyen = (Boolean)(rd["LBD_KhoanTuyen"]);
            }
            if (rd.FieldExists("LBD_HaiTuyenTrenNgay"))
            {
                Item.HaiTuyenTrenNgay = (Boolean)(rd["LBD_HaiTuyenTrenNgay"]);
            }
            if (rd.FieldExists("LBD_Username"))
            {
                Item.Username = (String)(rd["LBD_Username"]);
            }
            if (rd.FieldExists("LBD_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LBD_NgayTao"]);
            }
            if (rd.FieldExists("LBD_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LBD_NgayCapNhat"]);
            }
            if (rd.FieldExists("LBD_RowId"))
            {
                Item.RowId = (Guid)(rd["LBD_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region ChamCong
    #region BO
    public class ChamCong : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 XE_ID { get; set; }
        public DateTime Ngay { get; set; }
        public Int64 TRUYTHU_ID { get; set; }
        public Int64 PHOI_ID { get; set; }
        public Int16 Loai { get; set; }
        public Boolean Duyet { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public ChamCong()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ChamCongDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ChamCongCollection : BaseEntityCollection<ChamCong>
    { }
    #endregion
    #region Dal
    public class ChamCongDal
    {
        #region Methods

        public static void DeleteById(Int64 CONG_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CONG_ID", CONG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Delete_DeleteById_linhnx", obj);
        }

        public static ChamCong Insert(ChamCong item)
        {
            var Item = new ChamCong();
            var obj = new SqlParameter[11];
            obj[1] = new SqlParameter("CONG_XE_ID", item.XE_ID);
            obj[2] = new SqlParameter("CONG_Ngay", item.Ngay);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("CONG_Ngay", item.Ngay);
            }
            else
            {
                obj[2] = new SqlParameter("CONG_Ngay", DBNull.Value);
            }
            obj[3] = new SqlParameter("CONG_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[4] = new SqlParameter("CONG_PHOI_ID", item.PHOI_ID);
            obj[5] = new SqlParameter("CONG_Loai", item.Loai);
            obj[6] = new SqlParameter("CONG_Duyet", item.Duyet);
            obj[7] = new SqlParameter("CONG_Username", item.Username);
            obj[8] = new SqlParameter("CONG_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("CONG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("CONG_NgayTao", DBNull.Value);
            }
            obj[9] = new SqlParameter("CONG_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("CONG_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("CONG_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("CONG_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChamCong Update(ChamCong item)
        {
            var Item = new ChamCong();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("CONG_ID", item.ID);
            obj[1] = new SqlParameter("CONG_XE_ID", item.XE_ID);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("CONG_Ngay", item.Ngay);
            }
            else
            {
                obj[2] = new SqlParameter("CONG_Ngay", DBNull.Value);
            }
            obj[3] = new SqlParameter("CONG_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[4] = new SqlParameter("CONG_PHOI_ID", item.PHOI_ID);
            obj[5] = new SqlParameter("CONG_Loai", item.Loai);
            obj[6] = new SqlParameter("CONG_Duyet", item.Duyet);
            obj[7] = new SqlParameter("CONG_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("CONG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("CONG_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("CONG_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("CONG_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("CONG_RowId", item.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChamCong SelectById(Int64 CONG_ID)
        {
            var Item = new ChamCong();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CONG_ID", CONG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChamCongCollection SelectAll()
        {
            var List = new ChamCongCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ChamCong> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<ChamCong>("sp_tblBx_ChamCong_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ChamCong getFromReader(IDataReader rd)
        {
            var Item = new ChamCong();
            if (rd.FieldExists("CONG_ID"))
            {
                Item.ID = (Int64)(rd["CONG_ID"]);
            }
            if (rd.FieldExists("CONG_XE_ID"))
            {
                Item.XE_ID = (Int64)(rd["CONG_XE_ID"]);
            }
            if (rd.FieldExists("CONG_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["CONG_Ngay"]);
            }
            if (rd.FieldExists("CONG_TRUYTHU_ID"))
            {
                Item.TRUYTHU_ID = (Int64)(rd["CONG_TRUYTHU_ID"]);
            }
            if (rd.FieldExists("CONG_PHOI_ID"))
            {
                Item.PHOI_ID = (Int64)(rd["CONG_PHOI_ID"]);
            }
            if (rd.FieldExists("CONG_Loai"))
            {
                Item.Loai = (Int16)(rd["CONG_Loai"]);
            }
            if (rd.FieldExists("CONG_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["CONG_Duyet"]);
            }
            if (rd.FieldExists("CONG_Username"))
            {
                Item.Username = (String)(rd["CONG_Username"]);
            }
            if (rd.FieldExists("CONG_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["CONG_NgayTao"]);
            }
            if (rd.FieldExists("CONG_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["CONG_NgayCapNhat"]);
            }
            if (rd.FieldExists("CONG_RowId"))
            {
                Item.RowId = (Guid)(rd["CONG_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static ChamCongCollection SelectByXeTuNgay(string PHOI_ID, string TuNgay, long XE_ID)
        {
            var List = new ChamCongCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("XE_ID", XE_ID);
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[1] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(PHOI_ID))
            {
                obj[2] = new SqlParameter("PHOI_ID", PHOI_ID);
            }
            else
            {
                obj[2] = new SqlParameter("PHOI_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectByXeTuNgay_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static ChamCongCollection SelectByTruyThuId(long TRUYTHU_ID)
        {
            var List = new ChamCongCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TRUYTHU_ID", TRUYTHU_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectByTruyThuId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static void DeleteByTruyThuId(Int64 TRUYTHU_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TRUYTHU_ID", TRUYTHU_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ChamCong_Delete_DeleteByTruyThuId_linhnx", obj);
        }
        #endregion
    }
    #endregion

    #endregion

    #region DonVi
    #region BO
    public class DonVi : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Mobile { get; set; }
        public String Phone { get; set; }
        public String DiaChi { get; set; }
        public String GPS_Website { get; set; }
        public String GPS_Username { get; set; }
        public String GPS_Password { get; set; }
        public Boolean Khoa { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        #endregion
        #region Contructor
        public DonVi()
        { }
        #endregion
        #region Customs properties
        public string Url
        {
            get { return string.Format("/lib/pages/DonVi/Add.aspx?ID={0}", ID); }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DonViDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DonViCollection : BaseEntityCollection<DonVi>
    { }
    #endregion
    #region Dal
    public class DonViDal
    {
        #region Methods

        public static void DeleteById(Int32 DONVI_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DONVI_ID", DONVI_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_DonVi_Delete_DeleteById_linhnx", obj);
        }

        public static DonVi Insert(DonVi item)
        {
            var Item = new DonVi();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("DONVI_ID", item.ID);
            obj[1] = new SqlParameter("DONVI_Ten", item.Ten);
            obj[2] = new SqlParameter("DONVI_Mobile", item.Mobile);
            obj[3] = new SqlParameter("DONVI_Phone", item.Phone);
            obj[4] = new SqlParameter("DONVI_DiaChi", item.DiaChi);
            obj[5] = new SqlParameter("DONVI_GPS_Website", item.GPS_Website);
            obj[6] = new SqlParameter("DONVI_GPS_Username", item.GPS_Username);
            obj[7] = new SqlParameter("DONVI_GPS_Password", item.GPS_Password);
            obj[8] = new SqlParameter("DONVI_Khoa", item.Khoa);
            obj[9] = new SqlParameter("DONVI_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("DONVI_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("DONVI_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("DONVI_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("DONVI_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("DONVI_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_DonVi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DonVi Update(DonVi item)
        {
            var Item = new DonVi();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("DONVI_ID", item.ID);
            obj[1] = new SqlParameter("DONVI_Ten", item.Ten);
            obj[2] = new SqlParameter("DONVI_Mobile", item.Mobile);
            obj[3] = new SqlParameter("DONVI_Phone", item.Phone);
            obj[4] = new SqlParameter("DONVI_DiaChi", item.DiaChi);
            obj[5] = new SqlParameter("DONVI_GPS_Website", item.GPS_Website);
            obj[6] = new SqlParameter("DONVI_GPS_Username", item.GPS_Username);
            obj[7] = new SqlParameter("DONVI_GPS_Password", item.GPS_Password);
            obj[8] = new SqlParameter("DONVI_Khoa", item.Khoa);
            obj[9] = new SqlParameter("DONVI_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("DONVI_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("DONVI_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("DONVI_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("DONVI_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("DONVI_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_DonVi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DonVi SelectById(Int32 DONVI_ID)
        {
            var Item = new DonVi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DONVI_ID", DONVI_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_DonVi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DonViCollection SelectAll()
        {
            var List = new DonViCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_DonVi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DonVi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<DonVi>("sp_tblBx_DonVi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DonVi getFromReader(IDataReader rd)
        {
            var Item = new DonVi();
            if (rd.FieldExists("DONVI_ID"))
            {
                Item.ID = (Int32)(rd["DONVI_ID"]);
            }
            if (rd.FieldExists("DONVI_Ten"))
            {
                Item.Ten = (String)(rd["DONVI_Ten"]);
            }
            if (rd.FieldExists("DONVI_Mobile"))
            {
                Item.Mobile = (String)(rd["DONVI_Mobile"]);
            }
            if (rd.FieldExists("DONVI_Phone"))
            {
                Item.Phone = (String)(rd["DONVI_Phone"]);
            }
            if (rd.FieldExists("DONVI_DiaChi"))
            {
                Item.DiaChi = (String)(rd["DONVI_DiaChi"]);
            }
            if (rd.FieldExists("DONVI_GPS_Website"))
            {
                Item.GPS_Website = (String)(rd["DONVI_GPS_Website"]);
            }
            if (rd.FieldExists("DONVI_GPS_Username"))
            {
                Item.GPS_Username = (String)(rd["DONVI_GPS_Username"]);
            }
            if (rd.FieldExists("DONVI_GPS_Password"))
            {
                Item.GPS_Password = (String)(rd["DONVI_GPS_Password"]);
            }
            if (rd.FieldExists("DONVI_Khoa"))
            {
                Item.Khoa = (Boolean)(rd["DONVI_Khoa"]);
            }
            if (rd.FieldExists("DONVI_RowId"))
            {
                Item.RowId = (Guid)(rd["DONVI_RowId"]);
            }
            if (rd.FieldExists("DONVI_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DONVI_NgayTao"]);
            }
            if (rd.FieldExists("DONVI_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DONVI_NgayCapNhat"]);
            }
            if (rd.FieldExists("DONVI_Username"))
            {
                Item.Username = (String)(rd["DONVI_Username"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region LaiXe
    #region BO
    public class LaiXe : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int32 DONVI_ID { get; set; }
        public Int32 XE_ID { get; set; }
        public String Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public String BangLai { get; set; }
        public String LoaiBang { get; set; }
        public DateTime NgayHetHanBangLai { get; set; }
        public DateTime NgayHetHanGiayKhamSucKhoe { get; set; }
        public Boolean Khoa { get; set; }
        public String Anh { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        #endregion
        #region Contructor
        public LaiXe()
        { }
        #endregion
        #region Customs properties
        public string Url
        {
            get { return string.Format("/lib/pages/LaiXe/Add.aspx?ID={0}", ID); }
        }
        public string NgayHetHanBangLaiStr
        {
            get { return NgayHetHanBangLai == DateTime.MinValue ? string.Empty : NgayHetHanBangLai.ToString("dd/MM/yyyy"); }
        }
        public string NgayHetHanGiayKhamSucKhoeStr
        {
            get { return NgayHetHanGiayKhamSucKhoe == DateTime.MinValue ? string.Empty : NgayHetHanGiayKhamSucKhoe.ToString("dd/MM/yyyy"); }
        }
        public string DONVI_Ten { get; set; }
        public string XE_BienSo { get; set; }

        public bool NgayHetHanBangLaiOk
        {
            get { return DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan) < NgayHetHanBangLai; }
        }
        public bool NgayHetHanGiayKhamSucKhoeOk
        {
            get { return DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan) < NgayHetHanGiayKhamSucKhoe; }
        }
        
        public bool HopLe
        {
            get
            {
                var d = DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan);
                return (d < NgayHetHanBangLai && !Khoa);
            }
        }
        public string HopLeThongBao
        {
            get
            {
                var sb = new StringBuilder();
                var d = DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan);
                if (NgayHetHanBangLai < d)
                {
                    sb.Append("Hết hạn.");
                }
                if (Khoa)
                {
                    sb.Append("Tạm khóa.");
                }
                return sb.ToString();
            }
        }
        
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LaiXeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LaiXeCollection : BaseEntityCollection<LaiXe>
    { }
    #endregion
    #region Dal
    public class LaiXeDal
    {
        #region Methods

        public static void DeleteById(Int64 LAIXE_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LAIXE_ID", LAIXE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LaiXe_Delete_DeleteById_linhnx", obj);
        }

        public static LaiXe Insert(LaiXe item)
        {
            var Item = new LaiXe();
            var obj = new SqlParameter[15];
            obj[1] = new SqlParameter("LAIXE_DONVI_ID", item.DONVI_ID);
            obj[2] = new SqlParameter("LAIXE_XE_ID", item.XE_ID);
            obj[3] = new SqlParameter("LAIXE_Ten", item.Ten);
            obj[4] = new SqlParameter("LAIXE_NgaySinh", item.NgaySinh);
            if (item.NgaySinh > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("LAIXE_NgaySinh", item.NgaySinh);
            }
            else
            {
                obj[4] = new SqlParameter("LAIXE_NgaySinh", DBNull.Value);
            }
            obj[5] = new SqlParameter("LAIXE_BangLai", item.BangLai);
            obj[6] = new SqlParameter("LAIXE_LoaiBang", item.LoaiBang);
            obj[7] = new SqlParameter("LAIXE_NgayHetHanBangLai", item.NgayHetHanBangLai);
            if (item.NgayHetHanBangLai > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LAIXE_NgayHetHanBangLai", item.NgayHetHanBangLai);
            }
            else
            {
                obj[7] = new SqlParameter("LAIXE_NgayHetHanBangLai", DBNull.Value);
            }
            obj[8] = new SqlParameter("LAIXE_NgayHetHanGiayKhamSucKhoe", item.NgayHetHanGiayKhamSucKhoe);
            if (item.NgayHetHanGiayKhamSucKhoe > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("LAIXE_NgayHetHanGiayKhamSucKhoe", item.NgayHetHanGiayKhamSucKhoe);
            }
            else
            {
                obj[8] = new SqlParameter("LAIXE_NgayHetHanGiayKhamSucKhoe", DBNull.Value);
            }
            obj[9] = new SqlParameter("LAIXE_Khoa", item.Khoa);
            obj[10] = new SqlParameter("LAIXE_Anh", item.Anh);
            obj[11] = new SqlParameter("LAIXE_RowId", item.RowId);
            obj[12] = new SqlParameter("LAIXE_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("LAIXE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("LAIXE_NgayTao", DBNull.Value);
            }
            obj[13] = new SqlParameter("LAIXE_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("LAIXE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("LAIXE_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("LAIXE_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LaiXe_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LaiXe Update(LaiXe item)
        {
            var Item = new LaiXe();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("LAIXE_ID", item.ID);
            obj[1] = new SqlParameter("LAIXE_DONVI_ID", item.DONVI_ID);
            obj[2] = new SqlParameter("LAIXE_XE_ID", item.XE_ID);
            obj[3] = new SqlParameter("LAIXE_Ten", item.Ten);
            if (item.NgaySinh > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("LAIXE_NgaySinh", item.NgaySinh);
            }
            else
            {
                obj[4] = new SqlParameter("LAIXE_NgaySinh", DBNull.Value);
            }
            obj[5] = new SqlParameter("LAIXE_BangLai", item.BangLai);
            obj[6] = new SqlParameter("LAIXE_LoaiBang", item.LoaiBang);
            if (item.NgayHetHanBangLai > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LAIXE_NgayHetHanBangLai", item.NgayHetHanBangLai);
            }
            else
            {
                obj[7] = new SqlParameter("LAIXE_NgayHetHanBangLai", DBNull.Value);
            }
            if (item.NgayHetHanGiayKhamSucKhoe > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("LAIXE_NgayHetHanGiayKhamSucKhoe", item.NgayHetHanGiayKhamSucKhoe);
            }
            else
            {
                obj[8] = new SqlParameter("LAIXE_NgayHetHanGiayKhamSucKhoe", DBNull.Value);
            }
            obj[9] = new SqlParameter("LAIXE_Khoa", item.Khoa);
            obj[10] = new SqlParameter("LAIXE_Anh", item.Anh);
            obj[11] = new SqlParameter("LAIXE_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("LAIXE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("LAIXE_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("LAIXE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("LAIXE_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("LAIXE_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LaiXe_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LaiXe SelectById(Int64 LAIXE_ID)
        {
            var Item = new LaiXe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LAIXE_ID", LAIXE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LaiXe_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LaiXeCollection SelectAll()
        {
            var List = new LaiXeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LaiXe_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LaiXe> pagerNormal(string url, bool rewrite, string sort, string q, int size
            , string DONVI_ID
            , string LoaiBang
            , string XE_ID)
        {
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(DONVI_ID))
            {
                obj[2] = new SqlParameter("DONVI_ID", DONVI_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DONVI_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(LoaiBang))
            {
                obj[3] = new SqlParameter("LoaiBang", LoaiBang);
            }
            else
            {
                obj[3] = new SqlParameter("LoaiBang", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(XE_ID))
            {
                obj[4] = new SqlParameter("XE_ID", XE_ID);
            }
            else
            {
                obj[4] = new SqlParameter("XE_ID", DBNull.Value);
            }

            var pg = new Pager<LaiXe>("sp_tblBx_LaiXe_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LaiXe getFromReader(IDataReader rd)
        {
            var Item = new LaiXe();
            if (rd.FieldExists("LAIXE_ID"))
            {
                Item.ID = (Int64)(rd["LAIXE_ID"]);
            }
            if (rd.FieldExists("LAIXE_DONVI_ID"))
            {
                Item.DONVI_ID = (Int32)(rd["LAIXE_DONVI_ID"]);
            }
            if (rd.FieldExists("LAIXE_XE_ID"))
            {
                Item.XE_ID = (Int32)(rd["LAIXE_XE_ID"]);
            }
            if (rd.FieldExists("LAIXE_Ten"))
            {
                Item.Ten = (String)(rd["LAIXE_Ten"]);
            }
            if (rd.FieldExists("LAIXE_NgaySinh"))
            {
                Item.NgaySinh = (DateTime)(rd["LAIXE_NgaySinh"]);
            }
            if (rd.FieldExists("LAIXE_BangLai"))
            {
                Item.BangLai = (String)(rd["LAIXE_BangLai"]);
            }
            if (rd.FieldExists("LAIXE_LoaiBang"))
            {
                Item.LoaiBang = (String)(rd["LAIXE_LoaiBang"]);
            }
            if (rd.FieldExists("LAIXE_NgayHetHanBangLai"))
            {
                Item.NgayHetHanBangLai = (DateTime)(rd["LAIXE_NgayHetHanBangLai"]);
            }
            if (rd.FieldExists("LAIXE_NgayHetHanGiayKhamSucKhoe"))
            {
                Item.NgayHetHanGiayKhamSucKhoe = (DateTime)(rd["LAIXE_NgayHetHanGiayKhamSucKhoe"]);
            }
            if (rd.FieldExists("LAIXE_Khoa"))
            {
                Item.Khoa = (Boolean)(rd["LAIXE_Khoa"]);
            }
            if (rd.FieldExists("LAIXE_Anh"))
            {
                Item.Anh = (String)(rd["LAIXE_Anh"]);
            }
            if (rd.FieldExists("LAIXE_RowId"))
            {
                Item.RowId = (Guid)(rd["LAIXE_RowId"]);
            }
            if (rd.FieldExists("LAIXE_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LAIXE_NgayTao"]);
            }
            if (rd.FieldExists("LAIXE_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LAIXE_NgayCapNhat"]);
            }
            if (rd.FieldExists("LAIXE_Username"))
            {
                Item.Username = (String)(rd["LAIXE_Username"]);
            }
            if (rd.FieldExists("DONVI_Ten"))
            {
                Item.DONVI_Ten = (String)(rd["DONVI_Ten"]);
            }
            if (rd.FieldExists("XE_BienSo"))
            {
                Item.XE_BienSo = (String)(rd["XE_BienSo"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static LaiXe SelectByXeId(Int64 XE_ID)
        {
            var Item = new LaiXe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XE_ID", XE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LaiXe_Select_SelectByXeId_linhnx", obj))
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

    #region LoaiXe
    #region BO
    public class LoaiXe : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Int32 SoGhe { get; set; }
        public Double MucThu { get; set; }
        public String BangLai { get; set; }
        public Guid RowId { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 ThuTu { get; set; }
        #endregion
        #region Contructor
        public LoaiXe()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LoaiXeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LoaiXeCollection : BaseEntityCollection<LoaiXe>
    { }
    #endregion
    #region Dal
    public class LoaiXeDal
    {
        #region Methods

        public static void DeleteById(Int32 LOAIXE_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LOAIXE_ID", LOAIXE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiXe_Delete_DeleteById_linhnx", obj);
        }

        public static LoaiXe Insert(LoaiXe item)
        {
            var Item = new LoaiXe();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("LOAIXE_ID", item.ID);
            obj[1] = new SqlParameter("LOAIXE_Ten", item.Ten);
            obj[2] = new SqlParameter("LOAIXE_SoGhe", item.SoGhe);
            obj[3] = new SqlParameter("LOAIXE_MucThu", item.MucThu);
            obj[4] = new SqlParameter("LOAIXE_BangLai", item.BangLai);
            obj[5] = new SqlParameter("LOAIXE_RowId", item.RowId);
            obj[6] = new SqlParameter("LOAIXE_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LOAIXE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("LOAIXE_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("LOAIXE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("LOAIXE_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("LOAIXE_ThuTu", item.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiXe_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiXe Update(LoaiXe item)
        {
            var Item = new LoaiXe();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("LOAIXE_ID", item.ID);
            obj[1] = new SqlParameter("LOAIXE_Ten", item.Ten);
            obj[2] = new SqlParameter("LOAIXE_SoGhe", item.SoGhe);
            obj[3] = new SqlParameter("LOAIXE_MucThu", item.MucThu);
            obj[4] = new SqlParameter("LOAIXE_BangLai", item.BangLai);
            obj[5] = new SqlParameter("LOAIXE_RowId", item.RowId);
            obj[6] = new SqlParameter("LOAIXE_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LOAIXE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("LOAIXE_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("LOAIXE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("LOAIXE_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("LOAIXE_ThuTu", item.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiXe_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiXe SelectById(Int32 LOAIXE_ID)
        {
            var Item = new LoaiXe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LOAIXE_ID", LOAIXE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiXe_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiXeCollection SelectAll()
        {
            var List = new LoaiXeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_LoaiXe_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LoaiXe> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<LoaiXe>("sp_tblBx_LoaiXe_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LoaiXe getFromReader(IDataReader rd)
        {
            var Item = new LoaiXe();
            if (rd.FieldExists("LOAIXE_ID"))
            {
                Item.ID = (Int32)(rd["LOAIXE_ID"]);
            }
            if (rd.FieldExists("LOAIXE_Ten"))
            {
                Item.Ten = (String)(rd["LOAIXE_Ten"]);
            }
            if (rd.FieldExists("LOAIXE_SoGhe"))
            {
                Item.SoGhe = (Int32)(rd["LOAIXE_SoGhe"]);
            }
            if (rd.FieldExists("LOAIXE_MucThu"))
            {
                Item.MucThu = (Double)(rd["LOAIXE_MucThu"]);
            }
            if (rd.FieldExists("LOAIXE_BangLai"))
            {
                Item.BangLai = (String)(rd["LOAIXE_BangLai"]);
            }
            if (rd.FieldExists("LOAIXE_RowId"))
            {
                Item.RowId = (Guid)(rd["LOAIXE_RowId"]);
            }
            if (rd.FieldExists("LOAIXE_Username"))
            {
                Item.Username = (String)(rd["LOAIXE_Username"]);
            }
            if (rd.FieldExists("LOAIXE_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LOAIXE_NgayTao"]);
            }
            if (rd.FieldExists("LOAIXE_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LOAIXE_NgayCapNhat"]);
            }
            if (rd.FieldExists("LOAIXE_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["LOAIXE_ThuTu"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region Phoi
    #region BO
    public class Phoi : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 XE_ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public Int64 LAIXE_ID { get; set; }
        public Int64 STTBX { get; set; }
        public Int64 STTALL { get; set; }
        public DateTime NgayXuatBen { get; set; }
        public DateTime NgayXuatThucTe { get; set; }
        public Double PHI_BenBai { get; set; }
        public Double PHI_XeDauDem { get; set; }
        public Double PHI_VeSinhBenBai { get; set; }
        public Double PHI_XeLuuBen { get; set; }
        public Double PHI_HoaHongBanVe { get; set; }
        public Double PHI_ChuyenTruyThu { get; set; }
        public Double PHI_KhachTruyThu { get; set; }
        public Double PHI_TruyThuGiam { get; set; }
        public Double PHI_Khac { get; set; }
        public Double PHI_Tong { get; set; }
        public Double PHI_Nop { get; set; }
        public Double PHI_ConNo { get; set; }
        public Int16 HanhKhach { get; set; }
        public Int16 Ve { get; set; }
        public Int16 ChuyenTruyThu { get; set; }
        public Int16 KhachTruyThu { get; set; }
        public Boolean TruyThu { get; set; }
        public Boolean HopLe { get; set; }
        public Byte TINHTRANG { get; set; }
        public Boolean XeThayThe { get; set; }
        public Int64 XeThayThe_ID { get; set; }
        public Boolean XeTangCuong { get; set; }
        public Guid RowId { get; set; }
        public Boolean ChoDuyet { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        public Double GiaVe { get; set; }
        #endregion
        #region Contructor
        public Phoi()
        { }
        #endregion
        #region Customs properties
        public string Url
        {
            get { return string.Format("/lib/pages/Phoi/Add.aspx?ID={0}", ID); }
        }

        public Xe Xe { get; set; }
        public LaiXe LaiXe { get; set; }
        public string XE_BienSo { get; set; }
        public string CQ_Ten { get; set; }
        public string LAIXE_Ten { get; set; }
        public string XeThayThe_BienSo { get; set; }
        public List<ChamCong> ChamCongList { get; set; }
        public List<ChamCong> ChamCongListCurrent { get; set; }
        public TruyThu TruyThuItem { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhoiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhoiCollection : BaseEntityCollection<Phoi>
    { }
    #endregion
    #region Dal
    public class PhoiDal
    {
        #region Methods

        public static void DeleteById(Int64 PHOI_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PHOI_ID", PHOI_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Phoi_Delete_DeleteById_linhnx", obj);
        }

        public static Phoi Insert(Phoi item)
        {
            var Item = new Phoi();
            var obj = new SqlParameter[36];
            obj[1] = new SqlParameter("PHOI_XE_ID", item.XE_ID);
            obj[2] = new SqlParameter("PHOI_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("PHOI_LAIXE_ID", item.LAIXE_ID);
            obj[4] = new SqlParameter("PHOI_STTBX", item.STTBX);
            obj[5] = new SqlParameter("PHOI_STTALL", item.STTALL);
            obj[6] = new SqlParameter("PHOI_NgayXuatBen", item.NgayXuatBen);
            if (item.NgayXuatBen > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("PHOI_NgayXuatBen", item.NgayXuatBen);
            }
            else
            {
                obj[6] = new SqlParameter("PHOI_NgayXuatBen", DBNull.Value);
            }
            obj[7] = new SqlParameter("PHOI_NgayXuatThucTe", item.NgayXuatThucTe);
            if (item.NgayXuatThucTe > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("PHOI_NgayXuatThucTe", item.NgayXuatThucTe);
            }
            else
            {
                obj[7] = new SqlParameter("PHOI_NgayXuatThucTe", DBNull.Value);
            }
            obj[8] = new SqlParameter("PHOI_PHI_BenBai", item.PHI_BenBai);
            obj[9] = new SqlParameter("PHOI_PHI_XeDauDem", item.PHI_XeDauDem);
            obj[10] = new SqlParameter("PHOI_PHI_VeSinhBenBai", item.PHI_VeSinhBenBai);
            obj[11] = new SqlParameter("PHOI_PHI_XeLuuBen", item.PHI_XeLuuBen);
            obj[12] = new SqlParameter("PHOI_PHI_HoaHongBanVe", item.PHI_HoaHongBanVe);
            obj[13] = new SqlParameter("PHOI_PHI_ChuyenTruyThu", item.PHI_ChuyenTruyThu);
            obj[14] = new SqlParameter("PHOI_PHI_KhachTruyThu", item.PHI_KhachTruyThu);
            obj[15] = new SqlParameter("PHOI_PHI_TruyThuGiam", item.PHI_TruyThuGiam);
            obj[16] = new SqlParameter("PHOI_PHI_Khac", item.PHI_Khac);
            obj[17] = new SqlParameter("PHOI_PHI_Tong", item.PHI_Tong);
            obj[18] = new SqlParameter("PHOI_PHI_Nop", item.PHI_Nop);
            obj[19] = new SqlParameter("PHOI_PHI_ConNo", item.PHI_ConNo);
            obj[20] = new SqlParameter("PHOI_HanhKhach", item.HanhKhach);
            obj[21] = new SqlParameter("PHOI_Ve", item.Ve);
            obj[22] = new SqlParameter("PHOI_GiaVe", item.GiaVe);
            obj[23] = new SqlParameter("PHOI_ChuyenTruyThu", item.ChuyenTruyThu);
            obj[24] = new SqlParameter("PHOI_KhachTruyThu", item.KhachTruyThu);
            obj[25] = new SqlParameter("PHOI_TruyThu", item.TruyThu);
            obj[26] = new SqlParameter("PHOI_HopLe", item.HopLe);
            obj[27] = new SqlParameter("PHOI_ChoDuyet", item.ChoDuyet);
            obj[28] = new SqlParameter("PHOI_TINHTRANG", item.TINHTRANG);
            obj[29] = new SqlParameter("PHOI_XeThayThe", item.XeThayThe);
            obj[30] = new SqlParameter("PHOI_XeThayThe_ID", item.XeThayThe_ID);
            obj[31] = new SqlParameter("PHOI_XeTangCuong", item.XeTangCuong);
            obj[32] = new SqlParameter("PHOI_RowId", item.RowId);
            obj[33] = new SqlParameter("PHOI_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[33] = new SqlParameter("PHOI_NgayTao", item.NgayTao);
            }
            else
            {
                obj[33] = new SqlParameter("PHOI_NgayTao", DBNull.Value);
            }
            obj[34] = new SqlParameter("PHOI_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[34] = new SqlParameter("PHOI_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[34] = new SqlParameter("PHOI_NgayCapNhat", DBNull.Value);
            }
            obj[35] = new SqlParameter("PHOI_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Phoi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Phoi Update(Phoi item)
        {
            var Item = new Phoi();
            var obj = new SqlParameter[36];
            obj[0] = new SqlParameter("PHOI_ID", item.ID);
            obj[1] = new SqlParameter("PHOI_XE_ID", item.XE_ID);
            obj[2] = new SqlParameter("PHOI_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("PHOI_LAIXE_ID", item.LAIXE_ID);
            obj[4] = new SqlParameter("PHOI_STTBX", item.STTBX);
            obj[5] = new SqlParameter("PHOI_STTALL", item.STTALL);
            if (item.NgayXuatBen > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("PHOI_NgayXuatBen", item.NgayXuatBen);
            }
            else
            {
                obj[6] = new SqlParameter("PHOI_NgayXuatBen", DBNull.Value);
            }
            if (item.NgayXuatThucTe > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("PHOI_NgayXuatThucTe", item.NgayXuatThucTe);
            }
            else
            {
                obj[7] = new SqlParameter("PHOI_NgayXuatThucTe", DBNull.Value);
            }
            obj[8] = new SqlParameter("PHOI_PHI_BenBai", item.PHI_BenBai);
            obj[9] = new SqlParameter("PHOI_PHI_XeDauDem", item.PHI_XeDauDem);
            obj[10] = new SqlParameter("PHOI_PHI_VeSinhBenBai", item.PHI_VeSinhBenBai);
            obj[11] = new SqlParameter("PHOI_PHI_XeLuuBen", item.PHI_XeLuuBen);
            obj[12] = new SqlParameter("PHOI_PHI_HoaHongBanVe", item.PHI_HoaHongBanVe);
            obj[13] = new SqlParameter("PHOI_PHI_ChuyenTruyThu", item.PHI_ChuyenTruyThu);
            obj[14] = new SqlParameter("PHOI_PHI_KhachTruyThu", item.PHI_KhachTruyThu);
            obj[15] = new SqlParameter("PHOI_PHI_TruyThuGiam", item.PHI_TruyThuGiam);
            obj[16] = new SqlParameter("PHOI_PHI_Khac", item.PHI_Khac);
            obj[17] = new SqlParameter("PHOI_PHI_Tong", item.PHI_Tong);
            obj[18] = new SqlParameter("PHOI_PHI_Nop", item.PHI_Nop);
            obj[19] = new SqlParameter("PHOI_PHI_ConNo", item.PHI_ConNo);
            obj[20] = new SqlParameter("PHOI_HanhKhach", item.HanhKhach);
            obj[21] = new SqlParameter("PHOI_Ve", item.Ve);
            obj[22] = new SqlParameter("PHOI_GiaVe", item.GiaVe);
            obj[23] = new SqlParameter("PHOI_ChuyenTruyThu", item.ChuyenTruyThu);
            obj[24] = new SqlParameter("PHOI_KhachTruyThu", item.KhachTruyThu);
            obj[25] = new SqlParameter("PHOI_TruyThu", item.TruyThu);
            obj[26] = new SqlParameter("PHOI_HopLe", item.HopLe);
            obj[27] = new SqlParameter("PHOI_ChoDuyet", item.ChoDuyet);
            obj[28] = new SqlParameter("PHOI_TINHTRANG", item.TINHTRANG);
            obj[29] = new SqlParameter("PHOI_XeThayThe", item.XeThayThe);
            obj[30] = new SqlParameter("PHOI_XeThayThe_ID", item.XeThayThe_ID);
            obj[31] = new SqlParameter("PHOI_XeTangCuong", item.XeTangCuong);
            obj[32] = new SqlParameter("PHOI_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[33] = new SqlParameter("PHOI_NgayTao", item.NgayTao);
            }
            else
            {
                obj[33] = new SqlParameter("PHOI_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[34] = new SqlParameter("PHOI_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[34] = new SqlParameter("PHOI_NgayCapNhat", DBNull.Value);
            }
            obj[35] = new SqlParameter("PHOI_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Phoi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
                

        public static Phoi SelectById(Int64 PHOI_ID)
        {
            var Item = new Phoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PHOI_ID", PHOI_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Phoi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Phoi SelectLastest(string CQ_ID)
        {
            var Item = new Phoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Phoi_Select_SelectLastest_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhoiCollection SelectAll()
        {
            var List = new PhoiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Phoi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Phoi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Phoi>("sp_tblBx_Phoi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Phoi getFromReader(IDataReader rd)
        {
            var Item = new Phoi();
            if (rd.FieldExists("PHOI_ID"))
            {
                Item.ID = (Int64)(rd["PHOI_ID"]);
            }
            if (rd.FieldExists("PHOI_XE_ID"))
            {
                Item.XE_ID = (Int64)(rd["PHOI_XE_ID"]);
            }
            if (rd.FieldExists("PHOI_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["PHOI_CQ_ID"]);
            }
            if (rd.FieldExists("PHOI_LAIXE_ID"))
            {
                Item.LAIXE_ID = (Int64)(rd["PHOI_LAIXE_ID"]);
            }
            if (rd.FieldExists("PHOI_STTBX"))
            {
                Item.STTBX = (Int64)(rd["PHOI_STTBX"]);
            }
            if (rd.FieldExists("PHOI_STTALL"))
            {
                Item.STTALL = (Int64)(rd["PHOI_STTALL"]);
            }
            if (rd.FieldExists("PHOI_NgayXuatBen"))
            {
                Item.NgayXuatBen = (DateTime)(rd["PHOI_NgayXuatBen"]);
            }
            if (rd.FieldExists("PHOI_ChoDuyet"))
            {
                Item.ChoDuyet = (Boolean)(rd["PHOI_ChoDuyet"]);
            }
            if (rd.FieldExists("PHOI_NgayXuatThucTe"))
            {
                Item.NgayXuatThucTe = (DateTime)(rd["PHOI_NgayXuatThucTe"]);
            }
            if (rd.FieldExists("PHOI_PHI_BenBai"))
            {
                Item.PHI_BenBai = (Double)(rd["PHOI_PHI_BenBai"]);
            }
            if (rd.FieldExists("PHOI_PHI_XeDauDem"))
            {
                Item.PHI_XeDauDem = (Double)(rd["PHOI_PHI_XeDauDem"]);
            }
            if (rd.FieldExists("PHOI_PHI_VeSinhBenBai"))
            {
                Item.PHI_VeSinhBenBai = (Double)(rd["PHOI_PHI_VeSinhBenBai"]);
            }
            if (rd.FieldExists("PHOI_PHI_XeLuuBen"))
            {
                Item.PHI_XeLuuBen = (Double)(rd["PHOI_PHI_XeLuuBen"]);
            }
            if (rd.FieldExists("PHOI_PHI_HoaHongBanVe"))
            {
                Item.PHI_HoaHongBanVe = (Double)(rd["PHOI_PHI_HoaHongBanVe"]);
            }
            if (rd.FieldExists("PHOI_PHI_ChuyenTruyThu"))
            {
                Item.PHI_ChuyenTruyThu = (Double)(rd["PHOI_PHI_ChuyenTruyThu"]);
            }
            if (rd.FieldExists("PHOI_PHI_KhachTruyThu"))
            {
                Item.PHI_KhachTruyThu = (Double)(rd["PHOI_PHI_KhachTruyThu"]);
            }
            if (rd.FieldExists("PHOI_PHI_TruyThuGiam"))
            {
                Item.PHI_TruyThuGiam = (Double)(rd["PHOI_PHI_TruyThuGiam"]);
            }
            if (rd.FieldExists("PHOI_PHI_Khac"))
            {
                Item.PHI_Khac = (Double)(rd["PHOI_PHI_Khac"]);
            }
            if (rd.FieldExists("PHOI_PHI_Tong"))
            {
                Item.PHI_Tong = (Double)(rd["PHOI_PHI_Tong"]);
            }
            if (rd.FieldExists("PHOI_PHI_Nop"))
            {
                Item.PHI_Nop = (Double)(rd["PHOI_PHI_Nop"]);
            }
            if (rd.FieldExists("PHOI_PHI_ConNo"))
            {
                Item.PHI_ConNo = (Double)(rd["PHOI_PHI_ConNo"]);
            }
            if (rd.FieldExists("PHOI_HanhKhach"))
            {
                Item.HanhKhach = (Int16)(rd["PHOI_HanhKhach"]);
            }
            if (rd.FieldExists("PHOI_Ve"))
            {
                Item.Ve = (Int16)(rd["PHOI_Ve"]);
            }
            if (rd.FieldExists("PHOI_PHI_ChuyenTruyThu"))
            {
                Item.PHI_ChuyenTruyThu = (Double)(rd["PHOI_PHI_ChuyenTruyThu"]);
            }
            if (rd.FieldExists("PHOI_KhachTruyThu"))
            {
                Item.KhachTruyThu = (Int16)(rd["PHOI_KhachTruyThu"]);
            }
            if (rd.FieldExists("PHOI_TruyThu"))
            {
                Item.TruyThu = (Boolean)(rd["PHOI_TruyThu"]);
            }
            if (rd.FieldExists("PHOI_HopLe"))
            {
                Item.HopLe = (Boolean)(rd["PHOI_HopLe"]);
            }
            if (rd.FieldExists("PHOI_TINHTRANG"))
            {
                Item.TINHTRANG = (Byte)(rd["PHOI_TINHTRANG"]);
            }
            if (rd.FieldExists("PHOI_RowId"))
            {
                Item.RowId = (Guid)(rd["PHOI_RowId"]);
            }
            if (rd.FieldExists("PHOI_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PHOI_NgayTao"]);
            }
            if (rd.FieldExists("PHOI_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PHOI_NgayCapNhat"]);
            }
            if (rd.FieldExists("PHOI_Username"))
            {
                Item.Username = (String)(rd["PHOI_Username"]);
            }
            if (rd.FieldExists("CQ_Ten"))
            {
                Item.CQ_Ten = (String)(rd["CQ_Ten"]);
            }
            if (rd.FieldExists("XE_BienSo"))
            {
                Item.XE_BienSo = (String)(rd["XE_BienSo"]);
            }
            if (rd.FieldExists("PHOI_XeThayThe"))
            {
                Item.XeThayThe = (Boolean)(rd["PHOI_XeThayThe"]);
            }
            if (rd.FieldExists("PHOI_XeThayThe_ID"))
            {
                Item.XeThayThe_ID = (Int64)(rd["PHOI_XeThayThe_ID"]);
            }
            if (rd.FieldExists("PHOI_XeTangCuong"))
            {
                Item.XeTangCuong = (Boolean)(rd["PHOI_XeTangCuong"]);
            }
            if (rd.FieldExists("LAIXE_Ten"))
            {
                Item.LAIXE_Ten = (String)(rd["LAIXE_Ten"]);
            }
            if (rd.FieldExists("XeThayThe_BienSo"))
            {
                Item.XeThayThe_BienSo = (String)(rd["XeThayThe_BienSo"]);
            }
            if (rd.FieldExists("PHOI_GiaVe"))
            {
                Item.GiaVe = (Double)(rd["PHOI_GiaVe"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region TruyThu
    #region BO
    public class TruyThu : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 STTBX { get; set; }
        public Int64 STTALL { get; set; }
        public Int64 PHOI_ID { get; set; }
        public Int64 XE_ID { get; set; }
        public String NguoiLap { get; set; }
        public DateTime ThoiGianNghi_TuNgay { get; set; }
        public DateTime ThoiGianNghi_DenNgay { get; set; }
        public Int32 SoChuyenThucHien { get; set; }
        public Int32 SoChuyenBieuDo { get; set; }
        public Int32 SoChuyenThieu { get; set; }
        public Int32 SoChuyenDeNghi { get; set; }
        public Double GiaTienDichVuTrongHopDong { get; set; }
        public Double TongTruyThu { get; set; }
        public Double GiamTru { get; set; }
        public Guid NOIDUNG_ID { get; set; }
        public Guid DANHGIA_ID { get; set; }
        public String DeNghiCuaNhaXe { get; set; }
        public String YKienChiDao { get; set; }
        public Int32 SoChuyenDuocDuyet { get; set; }
        public Boolean Duyet { get; set; }
        public DateTime NgayDuyet { get; set; }
        public String LanhDaoDuyet { get; set; }
        public Boolean DeNghi { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public String Username { get; set; }
        #endregion
        #region Contructor
        public TruyThu()
        { }
        #endregion
        #region Customs properties

        public string DANHGIA_Ten { get; set; }
        public string NOIDUNG_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TruyThuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TruyThuCollection : BaseEntityCollection<TruyThu>
    { }
    #endregion
    #region Dal
    public class TruyThuDal
    {
        #region Methods

        public static void DeleteById(Int64 TRUYTHU_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TRUYTHU_ID", TRUYTHU_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_TruyThu_Delete_DeleteById_linhnx", obj);
        }

        public static TruyThu Insert(TruyThu item)
        {
            var Item = new TruyThu();
            var obj = new SqlParameter[28];
            obj[1] = new SqlParameter("TRUYTHU_STTBX", item.STTBX);
            obj[2] = new SqlParameter("TRUYTHU_STTALL", item.STTALL);
            obj[3] = new SqlParameter("TRUYTHU_PHOI_ID", item.PHOI_ID);
            obj[4] = new SqlParameter("TRUYTHU_XE_ID", item.XE_ID);
            obj[5] = new SqlParameter("TRUYTHU_NguoiLap", item.NguoiLap);
            obj[6] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", item.ThoiGianNghi_TuNgay);
            if (item.ThoiGianNghi_TuNgay > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", item.ThoiGianNghi_TuNgay);
            }
            else
            {
                obj[6] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", DBNull.Value);
            }
            obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", item.ThoiGianNghi_DenNgay);
            if (item.ThoiGianNghi_DenNgay > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", item.ThoiGianNghi_DenNgay);
            }
            else
            {
                obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", DBNull.Value);
            }
            obj[8] = new SqlParameter("TRUYTHU_SoChuyenThucHien", item.SoChuyenThucHien);
            obj[9] = new SqlParameter("TRUYTHU_SoChuyenBieuDo", item.SoChuyenBieuDo);
            obj[10] = new SqlParameter("TRUYTHU_SoChuyenThieu", item.SoChuyenThieu);
            obj[11] = new SqlParameter("TRUYTHU_SoChuyenDeNghi", item.SoChuyenDeNghi);
            obj[12] = new SqlParameter("TRUYTHU_GiaTienDichVuTrongHopDong", item.GiaTienDichVuTrongHopDong);
            obj[13] = new SqlParameter("TRUYTHU_TongTruyThu", item.TongTruyThu);
            obj[14] = new SqlParameter("TRUYTHU_GiamTru", item.GiamTru);
            obj[15] = new SqlParameter("TRUYTHU_NOIDUNG_ID", item.NOIDUNG_ID);
            obj[16] = new SqlParameter("TRUYTHU_DANHGIA_ID", item.DANHGIA_ID);
            obj[17] = new SqlParameter("TRUYTHU_DeNghiCuaNhaXe", item.DeNghiCuaNhaXe);
            obj[18] = new SqlParameter("TRUYTHU_YKienChiDao", item.YKienChiDao);
            obj[19] = new SqlParameter("TRUYTHU_SoChuyenDuocDuyet", item.SoChuyenDuocDuyet);
            obj[20] = new SqlParameter("TRUYTHU_NgayDuyet", item.NgayDuyet);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("TRUYTHU_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[20] = new SqlParameter("TRUYTHU_NgayDuyet", DBNull.Value);
            }
            obj[21] = new SqlParameter("TRUYTHU_LanhDaoDuyet", item.LanhDaoDuyet);
            obj[22] = new SqlParameter("TRUYTHU_Duyet", item.Duyet);
            obj[23] = new SqlParameter("TRUYTHU_DeNghi", item.DeNghi);
            obj[24] = new SqlParameter("TRUYTHU_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("TRUYTHU_NgayTao", item.NgayTao);
            }
            else
            {
                obj[24] = new SqlParameter("TRUYTHU_NgayTao", DBNull.Value);
            }
            obj[25] = new SqlParameter("TRUYTHU_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[25] = new SqlParameter("TRUYTHU_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[25] = new SqlParameter("TRUYTHU_NgayCapNhat", DBNull.Value);
            }
            obj[26] = new SqlParameter("TRUYTHU_RowId", item.RowId);
            obj[27] = new SqlParameter("TRUYTHU_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_TruyThu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TruyThu Update(TruyThu item)
        {
            var Item = new TruyThu();
            var obj = new SqlParameter[28];
            obj[0] = new SqlParameter("TRUYTHU_ID", item.ID);
            obj[1] = new SqlParameter("TRUYTHU_STTBX", item.STTBX);
            obj[2] = new SqlParameter("TRUYTHU_STTALL", item.STTALL);
            obj[3] = new SqlParameter("TRUYTHU_PHOI_ID", item.PHOI_ID);
            obj[4] = new SqlParameter("TRUYTHU_XE_ID", item.XE_ID);
            obj[5] = new SqlParameter("TRUYTHU_NguoiLap", item.NguoiLap);
            if (item.ThoiGianNghi_TuNgay > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", item.ThoiGianNghi_TuNgay);
            }
            else
            {
                obj[6] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", DBNull.Value);
            }
            if (item.ThoiGianNghi_DenNgay > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", item.ThoiGianNghi_DenNgay);
            }
            else
            {
                obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", DBNull.Value);
            }
            obj[8] = new SqlParameter("TRUYTHU_SoChuyenThucHien", item.SoChuyenThucHien);
            obj[9] = new SqlParameter("TRUYTHU_SoChuyenBieuDo", item.SoChuyenBieuDo);
            obj[10] = new SqlParameter("TRUYTHU_SoChuyenThieu", item.SoChuyenThieu);
            obj[11] = new SqlParameter("TRUYTHU_SoChuyenDeNghi", item.SoChuyenDeNghi);
            obj[12] = new SqlParameter("TRUYTHU_GiaTienDichVuTrongHopDong", item.GiaTienDichVuTrongHopDong);
            obj[13] = new SqlParameter("TRUYTHU_TongTruyThu", item.TongTruyThu);
            obj[14] = new SqlParameter("TRUYTHU_GiamTru", item.GiamTru);
            obj[15] = new SqlParameter("TRUYTHU_NOIDUNG_ID", item.NOIDUNG_ID);
            obj[16] = new SqlParameter("TRUYTHU_DANHGIA_ID", item.DANHGIA_ID);
            obj[17] = new SqlParameter("TRUYTHU_DeNghiCuaNhaXe", item.DeNghiCuaNhaXe);
            obj[18] = new SqlParameter("TRUYTHU_YKienChiDao", item.YKienChiDao);
            obj[19] = new SqlParameter("TRUYTHU_SoChuyenDuocDuyet", item.SoChuyenDuocDuyet);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("TRUYTHU_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[20] = new SqlParameter("TRUYTHU_NgayDuyet", DBNull.Value);
            }
            obj[21] = new SqlParameter("TRUYTHU_LanhDaoDuyet", item.LanhDaoDuyet);
            obj[22] = new SqlParameter("TRUYTHU_Duyet", item.Duyet);
            obj[23] = new SqlParameter("TRUYTHU_DeNghi", item.DeNghi);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("TRUYTHU_NgayTao", item.NgayTao);
            }
            else
            {
                obj[24] = new SqlParameter("TRUYTHU_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[25] = new SqlParameter("TRUYTHU_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[25] = new SqlParameter("TRUYTHU_NgayCapNhat", DBNull.Value);
            }
            obj[26] = new SqlParameter("TRUYTHU_RowId", item.RowId);
            obj[27] = new SqlParameter("TRUYTHU_Username", item.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_TruyThu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
                

        public static TruyThu SelectById(Int64 TRUYTHU_ID)
        {
            var Item = new TruyThu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TRUYTHU_ID", TRUYTHU_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_TruyThu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TruyThuCollection SelectAll()
        {
            var List = new TruyThuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_TruyThu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TruyThu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<TruyThu>("sp_tblBx_TruyThu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TruyThu getFromReader(IDataReader rd)
        {
            var Item = new TruyThu();
            if (rd.FieldExists("TRUYTHU_ID"))
            {
                Item.ID = (Int64)(rd["TRUYTHU_ID"]);
            }
            if (rd.FieldExists("TRUYTHU_STTBX"))
            {
                Item.STTBX = (Int64)(rd["TRUYTHU_STTBX"]);
            }
            if (rd.FieldExists("TRUYTHU_STTALL"))
            {
                Item.STTALL = (Int64)(rd["TRUYTHU_STTALL"]);
            }
            if (rd.FieldExists("TRUYTHU_PHOI_ID"))
            {
                Item.PHOI_ID = (Int64)(rd["TRUYTHU_PHOI_ID"]);
            }
            if (rd.FieldExists("TRUYTHU_XE_ID"))
            {
                Item.XE_ID = (Int64)(rd["TRUYTHU_XE_ID"]);
            }
            if (rd.FieldExists("TRUYTHU_NguoiLap"))
            {
                Item.NguoiLap = (String)(rd["TRUYTHU_NguoiLap"]);
            }
            if (rd.FieldExists("TRUYTHU_ThoiGianNghi_TuNgay"))
            {
                Item.ThoiGianNghi_TuNgay = (DateTime)(rd["TRUYTHU_ThoiGianNghi_TuNgay"]);
            }
            if (rd.FieldExists("TRUYTHU_ThoiGianNghi_DenNgay"))
            {
                Item.ThoiGianNghi_DenNgay = (DateTime)(rd["TRUYTHU_ThoiGianNghi_DenNgay"]);
            }
            if (rd.FieldExists("TRUYTHU_SoChuyenThucHien"))
            {
                Item.SoChuyenThucHien = (Int32)(rd["TRUYTHU_SoChuyenThucHien"]);
            }
            if (rd.FieldExists("TRUYTHU_SoChuyenBieuDo"))
            {
                Item.SoChuyenBieuDo = (Int32)(rd["TRUYTHU_SoChuyenBieuDo"]);
            }
            if (rd.FieldExists("TRUYTHU_SoChuyenThieu"))
            {
                Item.SoChuyenThieu = (Int32)(rd["TRUYTHU_SoChuyenThieu"]);
            }
            if (rd.FieldExists("TRUYTHU_SoChuyenDeNghi"))
            {
                Item.SoChuyenDeNghi = (Int32)(rd["TRUYTHU_SoChuyenDeNghi"]);
            }
            if (rd.FieldExists("TRUYTHU_GiaTienDichVuTrongHopDong"))
            {
                Item.GiaTienDichVuTrongHopDong = (Double)(rd["TRUYTHU_GiaTienDichVuTrongHopDong"]);
            }
            if (rd.FieldExists("TRUYTHU_TongTruyThu"))
            {
                Item.TongTruyThu = (Double)(rd["TRUYTHU_TongTruyThu"]);
            }
            if (rd.FieldExists("TRUYTHU_GiamTru"))
            {
                Item.GiamTru = (Double)(rd["TRUYTHU_GiamTru"]);
            }
            if (rd.FieldExists("TRUYTHU_NOIDUNG_ID"))
            {
                Item.NOIDUNG_ID = (Guid)(rd["TRUYTHU_NOIDUNG_ID"]);
            }
            if (rd.FieldExists("TRUYTHU_DANHGIA_ID"))
            {
                Item.DANHGIA_ID = (Guid)(rd["TRUYTHU_DANHGIA_ID"]);
            }
            if (rd.FieldExists("TRUYTHU_DeNghiCuaNhaXe"))
            {
                Item.DeNghiCuaNhaXe = (String)(rd["TRUYTHU_DeNghiCuaNhaXe"]);
            }
            if (rd.FieldExists("TRUYTHU_YKienChiDao"))
            {
                Item.YKienChiDao = (String)(rd["TRUYTHU_YKienChiDao"]);
            }
            if (rd.FieldExists("TRUYTHU_SoChuyenDuocDuyet"))
            {
                Item.SoChuyenDuocDuyet = (Int32)(rd["TRUYTHU_SoChuyenDuocDuyet"]);
            }
            if (rd.FieldExists("TRUYTHU_NgayDuyet"))
            {
                Item.NgayDuyet = (DateTime)(rd["TRUYTHU_NgayDuyet"]);
            }
            if (rd.FieldExists("TRUYTHU_LanhDaoDuyet"))
            {
                Item.LanhDaoDuyet = (String)(rd["TRUYTHU_LanhDaoDuyet"]);
            }
            if (rd.FieldExists("TRUYTHU_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["TRUYTHU_Duyet"]);
            }
            if (rd.FieldExists("TRUYTHU_DeNghi"))
            {
                Item.DeNghi = (Boolean)(rd["TRUYTHU_DeNghi"]);
            }
            if (rd.FieldExists("TRUYTHU_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TRUYTHU_NgayTao"]);
            }
            if (rd.FieldExists("TRUYTHU_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TRUYTHU_NgayCapNhat"]);
            }
            if (rd.FieldExists("TRUYTHU_RowId"))
            {
                Item.RowId = (Guid)(rd["TRUYTHU_RowId"]);
            }
            if (rd.FieldExists("TRUYTHU_Username"))
            {
                Item.Username = (String)(rd["TRUYTHU_Username"]);
            }
            if (rd.FieldExists("NOIDUNG_Ten"))
            {
                Item.NOIDUNG_Ten = (String)(rd["NOIDUNG_Ten"]);
            }
            if (rd.FieldExists("DANHGIA_Ten"))
            {
                Item.DANHGIA_Ten = (String)(rd["DANHGIA_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static TruyThu SelectByPhoiId(Int64 PHOI_ID)
        {
            var Item = new TruyThu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PHOI_ID", PHOI_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_TruyThu_Select_SelectByPhoiId_linhnx", obj))
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

    #region Tuyen
    #region BO
    public class Tuyen : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Guid DI_ID { get; set; }
        public Guid DEN_ID { get; set; }
        public Boolean NoiTinh { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        public Double HoaHongBanVe { get; set; }
        public Double VeSinhLuuBen { get; set; }
        #endregion
        #region Contructor
        public Tuyen()
        { }
        #endregion
        #region Customs properties

        public string DI_Ten { get; set; }
        public string DEN_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TuyenDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TuyenCollection : BaseEntityCollection<Tuyen>
    { }
    #endregion
    #region Dal
    public class TuyenDal
    {
        #region Methods

        public static void DeleteById(Int32 TUYEN_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TUYEN_ID", TUYEN_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Tuyen_Delete_DeleteById_linhnx", obj);
        }

        public static Tuyen Insert(Tuyen item)
        {
            var Item = new Tuyen();
            var obj = new SqlParameter[11];
            obj[1] = new SqlParameter("TUYEN_Ten", item.Ten);
            obj[2] = new SqlParameter("TUYEN_DI_ID", item.DI_ID);
            obj[3] = new SqlParameter("TUYEN_DEN_ID", item.DEN_ID);
            obj[4] = new SqlParameter("TUYEN_NoiTinh", item.NoiTinh);
            obj[5] = new SqlParameter("TUYEN_RowId", item.RowId);
            obj[6] = new SqlParameter("TUYEN_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TUYEN_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("TUYEN_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("TUYEN_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TUYEN_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("TUYEN_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("TUYEN_Username", item.Username);
            obj[9] = new SqlParameter("TUYEN_HoaHongBanVe", item.HoaHongBanVe);
            obj[10] = new SqlParameter("TUYEN_VeSinhLuuBen", item.VeSinhLuuBen);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Tuyen_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Tuyen Update(Tuyen item)
        {
            var Item = new Tuyen();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("TUYEN_ID", item.ID);
            obj[1] = new SqlParameter("TUYEN_Ten", item.Ten);
            obj[2] = new SqlParameter("TUYEN_DI_ID", item.DI_ID);
            obj[3] = new SqlParameter("TUYEN_DEN_ID", item.DEN_ID);
            obj[4] = new SqlParameter("TUYEN_NoiTinh", item.NoiTinh);
            obj[5] = new SqlParameter("TUYEN_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TUYEN_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("TUYEN_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TUYEN_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("TUYEN_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("TUYEN_Username", item.Username);
            obj[9] = new SqlParameter("TUYEN_HoaHongBanVe", item.HoaHongBanVe);
            obj[10] = new SqlParameter("TUYEN_VeSinhLuuBen", item.VeSinhLuuBen);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Tuyen_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Tuyen SelectById(Int32 TUYEN_ID)
        {
            var Item = new Tuyen();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TUYEN_ID", TUYEN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Tuyen_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuyenCollection SelectAll()
        {
            var List = new TuyenCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Tuyen_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tuyen> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Tuyen>("sp_tblBx_Tuyen_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Tuyen getFromReader(IDataReader rd)
        {
            var Item = new Tuyen();
            if (rd.FieldExists("TUYEN_ID"))
            {
                Item.ID = (Int32)(rd["TUYEN_ID"]);
            }
            if (rd.FieldExists("TUYEN_Ten"))
            {
                Item.Ten = (String)(rd["TUYEN_Ten"]);
            }
            if (rd.FieldExists("TUYEN_DI_ID"))
            {
                Item.DI_ID = (Guid)(rd["TUYEN_DI_ID"]);
            }
            if (rd.FieldExists("TUYEN_DEN_ID"))
            {
                Item.DEN_ID = (Guid)(rd["TUYEN_DEN_ID"]);
            }
            if (rd.FieldExists("TUYEN_NoiTinh"))
            {
                Item.NoiTinh = (Boolean)(rd["TUYEN_NoiTinh"]);
            }
            if (rd.FieldExists("TUYEN_RowId"))
            {
                Item.RowId = (Guid)(rd["TUYEN_RowId"]);
            }
            if (rd.FieldExists("TUYEN_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TUYEN_NgayTao"]);
            }
            if (rd.FieldExists("TUYEN_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TUYEN_NgayCapNhat"]);
            }
            if (rd.FieldExists("TUYEN_Username"))
            {
                Item.Username = (String)(rd["TUYEN_Username"]);
            }
            if (rd.FieldExists("TUYEN_HoaHongBanVe"))
            {
                Item.HoaHongBanVe = (Double)(rd["TUYEN_HoaHongBanVe"]);
            }
            if (rd.FieldExists("TUYEN_VeSinhLuuBen"))
            {
                Item.VeSinhLuuBen = (Double)(rd["TUYEN_VeSinhLuuBen"]);
            }
            if (rd.FieldExists("DEN_Ten"))
            {
                Item.DEN_Ten = (String)(rd["DEN_Ten"]);
            }
            if (rd.FieldExists("DI_Ten"))
            {
                Item.DI_Ten = (String)(rd["DI_Ten"]);
            }

            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region Xe
    #region BO
    public class Xe : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int32 TUYEN_ID { get; set; }
        public Int32 DONVI_ID { get; set; }
        public Int32 LOAIXE_ID { get; set; }
        public String BienSo_Chu { get; set; }
        public String BienSo_So { get; set; }
        public DateTime LuuHanh { get; set; }
        public DateTime TuyenCoDinh { get; set; }
        public Int16 Ghe { get; set; }
        public Int16 SoKhach { get; set; }
        public Double MucPhi { get; set; }
        public Boolean XeTai { get; set; }
        public Boolean XeVangLai { get; set; }
        public Int32 HanhKhachHopDong { get; set; }
        public Double GiaVe { get; set; }
        public String Anh { get; set; }
        public Int32 CQ_ID { get; set; }
        public String GioXuatBen { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        public Boolean Khoa { get; set; }
        public Int32 BIEUDO_ID { get; set; }
        public DateTime BaoHiem { get; set; }

        #endregion
        #region Contructor
        public Xe()
        { }
        #endregion
        #region Customs properties
        public string Url
        {
            get { return string.Format("/lib/pages/Xe/Add.aspx?ID={0}", ID); }
        }
        public string Ten
        {
            get { return string.Format("{0} {1}", BienSo_Chu, BienSo_So); }
        }
        public string LuuHanhStr
        {
            get { return LuuHanh == DateTime.MinValue ? string.Empty : LuuHanh.ToString("dd/MM/yyyy"); }
        }
        public string TuyenCoDinhStr
        {
            get { return TuyenCoDinh == DateTime.MinValue ? string.Empty : TuyenCoDinh.ToString("dd/MM/yyyy"); }
        }
        public string BaoHiemStr
        {
            get { return BaoHiem == DateTime.MinValue ? string.Empty : BaoHiem.ToString("dd/MM/yyyy"); }
        }

        public bool LuuHanhOk
        {
            get { return DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan) < LuuHanh; }
        }
        
        public bool TuyenCoDinhOk
        {
            get { return DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan) < TuyenCoDinh; }
        }

        public bool BaoHiemOk
        {
            get { return DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan) < BaoHiem; }
        }


        public Tuyen Tuyen { get; set; }
        public string LOAIXE_Ten { get; set; }
        public string DONVI_Ten { get; set; }
        public string TUYEN_Ten { get; set; }
        public string BIEUDO_Ten { get; set; }
        public LoaiBieuDo LoaiBieuDo { get; set; }
        public LaiXe LaiXe { get; set; }
        public bool HopLe
        {
            get
            {
                var d = DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan);
                return (d < BaoHiem) && (d < LuuHanh) && (d < BaoHiem);
            }
        }
        public string HopLeThongBao
        {
            get { 
                var sb = new StringBuilder();
                var d = DateTime.Now.AddDays(BxVinhConfig.SoNgayHetHan);
                if(LuuHanh < d)
                {
                    sb.Append("Hết hạn lưu hành.");
                }
                if (BaoHiem < d)
                {
                    sb.Append("Hết hạn bảo hiểm.");
                }
                if (TuyenCoDinh < d)
                {
                    sb.Append("Hết hạn tuyến cố định.");
                }
                return sb.ToString();
            }
        }

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XeCollection : BaseEntityCollection<Xe>
    { }
    #endregion
    #region Dal
    public class XeDal
    {
        #region Methods

        public static void DeleteById(Int64 XE_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XE_ID", XE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Delete_DeleteById_linhnx", obj);
        }

        public static Xe Insert(Xe item)
        {
            var Item = new Xe();
            var obj = new SqlParameter[25];
            obj[1] = new SqlParameter("XE_TUYEN_ID", item.TUYEN_ID);
            obj[2] = new SqlParameter("XE_DONVI_ID", item.DONVI_ID);
            obj[3] = new SqlParameter("XE_LOAIXE_ID", item.LOAIXE_ID);
            obj[4] = new SqlParameter("XE_BienSo_Chu", item.BienSo_Chu);
            obj[5] = new SqlParameter("XE_BienSo_So", item.BienSo_So);
            obj[6] = new SqlParameter("XE_LuuHanh", item.LuuHanh);
            if (item.LuuHanh > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("XE_LuuHanh", item.LuuHanh);
            }
            else
            {
                obj[6] = new SqlParameter("XE_LuuHanh", DBNull.Value);
            }
            obj[7] = new SqlParameter("XE_TuyenCoDinh", item.TuyenCoDinh);
            if (item.TuyenCoDinh > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("XE_TuyenCoDinh", item.TuyenCoDinh);
            }
            else
            {
                obj[7] = new SqlParameter("XE_TuyenCoDinh", DBNull.Value);
            }
            obj[8] = new SqlParameter("XE_BaoHiem", item.BaoHiem);
            if (item.BaoHiem > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("XE_BaoHiem", item.BaoHiem);
            }
            else
            {
                obj[8] = new SqlParameter("XE_BaoHiem", DBNull.Value);
            }
            obj[9] = new SqlParameter("XE_Ghe", item.Ghe);
            obj[10] = new SqlParameter("XE_SoKhach", item.SoKhach);
            obj[11] = new SqlParameter("XE_MucPhi", item.MucPhi);
            obj[12] = new SqlParameter("XE_XeTai", item.XeTai);
            obj[13] = new SqlParameter("XE_XeVangLai", item.XeVangLai);
            obj[14] = new SqlParameter("XE_BIEUDO_ID", item.BIEUDO_ID);
            obj[15] = new SqlParameter("XE_HanhKhachHopDong", item.HanhKhachHopDong);
            obj[16] = new SqlParameter("XE_GiaVe", item.GiaVe);
            obj[17] = new SqlParameter("XE_Anh", item.Anh);
            obj[18] = new SqlParameter("XE_CQ_ID", item.CQ_ID);
            obj[19] = new SqlParameter("XE_GioXuatBen", item.GioXuatBen);
            obj[20] = new SqlParameter("XE_RowId", item.RowId);
            obj[21] = new SqlParameter("XE_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("XE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[21] = new SqlParameter("XE_NgayTao", DBNull.Value);
            }
            obj[22] = new SqlParameter("XE_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("XE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[22] = new SqlParameter("XE_NgayCapNhat", DBNull.Value);
            }
            obj[23] = new SqlParameter("XE_Username", item.Username);
            obj[24] = new SqlParameter("XE_Khoa", item.Khoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Xe Update(Xe item)
        {
            var Item = new Xe();
            var obj = new SqlParameter[25];
            obj[0] = new SqlParameter("XE_ID", item.ID);
            obj[1] = new SqlParameter("XE_TUYEN_ID", item.TUYEN_ID);
            obj[2] = new SqlParameter("XE_DONVI_ID", item.DONVI_ID);
            obj[3] = new SqlParameter("XE_LOAIXE_ID", item.LOAIXE_ID);
            obj[4] = new SqlParameter("XE_BienSo_Chu", item.BienSo_Chu);
            obj[5] = new SqlParameter("XE_BienSo_So", item.BienSo_So);
            if (item.LuuHanh > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("XE_LuuHanh", item.LuuHanh);
            }
            else
            {
                obj[6] = new SqlParameter("XE_LuuHanh", DBNull.Value);
            }
            if (item.TuyenCoDinh > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("XE_TuyenCoDinh", item.TuyenCoDinh);
            }
            else
            {
                obj[7] = new SqlParameter("XE_TuyenCoDinh", DBNull.Value);
            }
            if (item.BaoHiem > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("XE_BaoHiem", item.BaoHiem);
            }
            else
            {
                obj[8] = new SqlParameter("XE_BaoHiem", DBNull.Value);
            }
            obj[9] = new SqlParameter("XE_Ghe", item.Ghe);
            obj[10] = new SqlParameter("XE_SoKhach", item.SoKhach);
            obj[11] = new SqlParameter("XE_MucPhi", item.MucPhi);
            obj[12] = new SqlParameter("XE_XeTai", item.XeTai);
            obj[13] = new SqlParameter("XE_XeVangLai", item.XeVangLai);
            obj[14] = new SqlParameter("XE_BIEUDO_ID", item.BIEUDO_ID);
            obj[15] = new SqlParameter("XE_HanhKhachHopDong", item.HanhKhachHopDong);
            obj[16] = new SqlParameter("XE_GiaVe", item.GiaVe);
            obj[17] = new SqlParameter("XE_Anh", item.Anh);
            obj[18] = new SqlParameter("XE_CQ_ID", item.CQ_ID);
            obj[19] = new SqlParameter("XE_GioXuatBen", item.GioXuatBen);
            obj[20] = new SqlParameter("XE_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("XE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[21] = new SqlParameter("XE_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("XE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[22] = new SqlParameter("XE_NgayCapNhat", DBNull.Value);
            }
            obj[23] = new SqlParameter("XE_Username", item.Username);
            obj[24] = new SqlParameter("XE_Khoa", item.Khoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Xe SelectById(Int64 XE_ID)
        {
            var Item = new Xe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XE_ID", XE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XeCollection SelectAll()
        {
            var List = new XeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Xe> pagerNormal(string url, bool rewrite, string sort, string q, int size
            , string TUYEN_ID, string DONVI_ID, string LOAIXE_ID, string Ghe, string LuuHanh, string TuyenCoDinh)
        {
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TUYEN_ID))
            {
                obj[2] = new SqlParameter("TUYEN_ID", TUYEN_ID);
            }
            else
            {
                obj[2] = new SqlParameter("TUYEN_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(DONVI_ID))
            {
                obj[3] = new SqlParameter("DONVI_ID", DONVI_ID);
            }
            else
            {
                obj[3] = new SqlParameter("DONVI_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(LOAIXE_ID))
            {
                obj[4] = new SqlParameter("LOAIXE_ID", LOAIXE_ID);
            }
            else
            {
                obj[4] = new SqlParameter("LOAIXE_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Ghe))
            {
                obj[5] = new SqlParameter("Ghe", Ghe);
            }
            else
            {
                obj[5] = new SqlParameter("Ghe", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(LuuHanh))
            {
                obj[6] = new SqlParameter("LuuHanh", LuuHanh);
            }
            else
            {
                obj[6] = new SqlParameter("LuuHanh", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(TuyenCoDinh))
            {
                obj[7] = new SqlParameter("TuyenCoDinh", TuyenCoDinh);
            }
            else
            {
                obj[7] = new SqlParameter("TuyenCoDinh", DBNull.Value);
            }
            var pg = new Pager<Xe>("sp_tblBx_Xe_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Xe getFromReader(IDataReader rd)
        {
            var Item = new Xe();
            if (rd.FieldExists("XE_ID"))
            {
                Item.ID = (Int64)(rd["XE_ID"]);
            }
            if (rd.FieldExists("XE_TUYEN_ID"))
            {
                Item.TUYEN_ID = (Int32)(rd["XE_TUYEN_ID"]);
            }
            if (rd.FieldExists("XE_DONVI_ID"))
            {
                Item.DONVI_ID = (Int32)(rd["XE_DONVI_ID"]);
            }
            if (rd.FieldExists("XE_LOAIXE_ID"))
            {
                Item.LOAIXE_ID = (Int32)(rd["XE_LOAIXE_ID"]);
            }
            if (rd.FieldExists("XE_BienSo_Chu"))
            {
                Item.BienSo_Chu = (String)(rd["XE_BienSo_Chu"]);
            }
            if (rd.FieldExists("XE_BienSo_So"))
            {
                Item.BienSo_So = (String)(rd["XE_BienSo_So"]);
            }
            if (rd.FieldExists("XE_LuuHanh"))
            {
                Item.LuuHanh = (DateTime)(rd["XE_LuuHanh"]);
            }
            if (rd.FieldExists("XE_TuyenCoDinh"))
            {
                Item.TuyenCoDinh = (DateTime)(rd["XE_TuyenCoDinh"]);
            }
            if (rd.FieldExists("XE_Ghe"))
            {
                Item.Ghe = (Int16)(rd["XE_Ghe"]);
            }
            if (rd.FieldExists("XE_SoKhach"))
            {
                Item.SoKhach = (Int16)(rd["XE_SoKhach"]);
            }
            if (rd.FieldExists("XE_MucPhi"))
            {
                Item.MucPhi = (Double)(rd["XE_MucPhi"]);
            }
            if (rd.FieldExists("XE_XeTai"))
            {
                Item.XeTai = (Boolean)(rd["XE_XeTai"]);
            }
            if (rd.FieldExists("XE_XeVangLai"))
            {
                Item.XeVangLai = (Boolean)(rd["XE_XeVangLai"]);
            }
            if (rd.FieldExists("XE_HanhKhachHopDong"))
            {
                Item.HanhKhachHopDong = (Int32)(rd["XE_HanhKhachHopDong"]);
            }
            if (rd.FieldExists("XE_GiaVe"))
            {
                Item.GiaVe = (Double)(rd["XE_GiaVe"]);
            }
            if (rd.FieldExists("XE_Anh"))
            {
                Item.Anh = (String)(rd["XE_Anh"]);
            }
            if (rd.FieldExists("XE_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["XE_CQ_ID"]);
            }
            if (rd.FieldExists("XE_GioXuatBen"))
            {
                Item.GioXuatBen = (String)(rd["XE_GioXuatBen"]);
            }
            if (rd.FieldExists("XE_RowId"))
            {
                Item.RowId = (Guid)(rd["XE_RowId"]);
            }
            if (rd.FieldExists("XE_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["XE_NgayTao"]);
            }
            if (rd.FieldExists("XE_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["XE_NgayCapNhat"]);
            }
            if (rd.FieldExists("XE_Username"))
            {
                Item.Username = (String)(rd["XE_Username"]);
            }
            if (rd.FieldExists("XE_Khoa"))
            {
                Item.Khoa = (Boolean)(rd["XE_Khoa"]);
            }
            if (rd.FieldExists("LOAIXE_Ten"))
            {
                Item.LOAIXE_Ten = (String)(rd["LOAIXE_Ten"]);
            }
            if (rd.FieldExists("TUYEN_Ten"))
            {
                Item.TUYEN_Ten = (String)(rd["TUYEN_Ten"]);
            }
            if (rd.FieldExists("DONVI_Ten"))
            {
                Item.DONVI_Ten = (String)(rd["DONVI_Ten"]);
            }
            if (rd.FieldExists("XE_BIEUDO_ID"))
            {
                Item.BIEUDO_ID = (Int32)(rd["XE_BIEUDO_ID"]);
            }
            if (rd.FieldExists("XE_BaoHiem"))
            {
                Item.BaoHiem = (DateTime)(rd["XE_BaoHiem"]);
            }
            if (rd.FieldExists("BIEUDO_Ten"))
            {
                Item.BIEUDO_Ten = (String)(rd["BIEUDO_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static XeCollection SearchSQL(string q)
        {
            var List = new XeCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(q))
            {
                obj[0] = new SqlParameter("q", q);
            }
            else
            {
                obj[0] = new SqlParameter("q", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Tuyen_Select_SearchSQL_linhnx", obj))
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
