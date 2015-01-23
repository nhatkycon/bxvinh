using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace docsoft.entities
{
    public class BxVinhConfig
    {
        public const Int32 SoNgayHetHan = -1;
    }

    #region GiaoCa
    #region BO
    public class GiaoCa : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public Double DoanhThu { get; set; }
        public Int32 TongSoPhoi { get; set; }
        public String NguoiGiao { get; set; }
        public String NguoiNhan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        public Guid RowId { get; set; }
        public Boolean Duyet { get; set; }
        public Boolean KetThuc { get; set; }
        public DateTime NgayKetThuc { get; set; }
        #endregion
        #region Contructor
        public GiaoCa()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return GiaoCaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class GiaoCaCollection : BaseEntityCollection<GiaoCa>
    { }
    #endregion
    #region Dal
    public class GiaoCaDal
    {
        #region Methods

        public static void DeleteById(Int32 GIAOCA_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GIAOCA_ID", GIAOCA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_GiaoCa_Delete_DeleteById_linhnx", obj);
        }

        public static GiaoCa Insert(GiaoCa item)
        {
            var Item = new GiaoCa();
            var obj = new SqlParameter[13];
            obj[1] = new SqlParameter("GIAOCA_CQ_ID", item.CQ_ID);
            obj[2] = new SqlParameter("GIAOCA_DoanhThu", item.DoanhThu);
            obj[3] = new SqlParameter("GIAOCA_TongSoPhoi", item.TongSoPhoi);
            obj[4] = new SqlParameter("GIAOCA_NguoiGiao", item.NguoiGiao);
            obj[5] = new SqlParameter("GIAOCA_NguoiNhan", item.NguoiNhan);
            obj[6] = new SqlParameter("GIAOCA_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("GIAOCA_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("GIAOCA_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("GIAOCA_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("GIAOCA_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("GIAOCA_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("GIAOCA_Username", item.Username);
            obj[9] = new SqlParameter("GIAOCA_RowId", item.RowId);
            obj[10] = new SqlParameter("GIAOCA_Duyet", item.Duyet);
            obj[11] = new SqlParameter("GIAOCA_KetThuc", item.KetThuc);
            obj[12] = new SqlParameter("GIAOCA_NgayKetThuc", item.NgayKetThuc);
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("GIAOCA_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[12] = new SqlParameter("GIAOCA_NgayKetThuc", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_GiaoCa_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaoCa Update(GiaoCa item)
        {
            var Item = new GiaoCa();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("GIAOCA_ID", item.ID);
            obj[1] = new SqlParameter("GIAOCA_CQ_ID", item.CQ_ID);
            obj[2] = new SqlParameter("GIAOCA_DoanhThu", item.DoanhThu);
            obj[3] = new SqlParameter("GIAOCA_TongSoPhoi", item.TongSoPhoi);
            obj[4] = new SqlParameter("GIAOCA_NguoiGiao", item.NguoiGiao);
            obj[5] = new SqlParameter("GIAOCA_NguoiNhan", item.NguoiNhan);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("GIAOCA_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("GIAOCA_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("GIAOCA_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("GIAOCA_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("GIAOCA_Username", item.Username);
            obj[9] = new SqlParameter("GIAOCA_RowId", item.RowId);
            obj[10] = new SqlParameter("GIAOCA_Duyet", item.Duyet);
            obj[11] = new SqlParameter("GIAOCA_KetThuc", item.KetThuc);
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("GIAOCA_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[12] = new SqlParameter("GIAOCA_NgayKetThuc", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_GiaoCa_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GiaoCa SelectById(SqlConnection con, Int32 GIAOCA_ID)
        {
            var Item = new GiaoCa();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GIAOCA_ID", GIAOCA_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_GiaoCa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GiaoCa SelectById(Int32 GIAOCA_ID)
        {
            return SelectById(DAL.con(), GIAOCA_ID);
        }

        public static GiaoCaCollection SelectAll()
        {
            var List = new GiaoCaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_GiaoCa_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<GiaoCa> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<GiaoCa>("sp_tblBx_GiaoCa_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static GiaoCa getFromReader(IDataReader rd)
        {
            var Item = new GiaoCa();
            if (rd.FieldExists("GIAOCA_ID"))
            {
                Item.ID = (Int32)(rd["GIAOCA_ID"]);
            }
            if (rd.FieldExists("GIAOCA_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["GIAOCA_CQ_ID"]);
            }
            if (rd.FieldExists("GIAOCA_DoanhThu"))
            {
                Item.DoanhThu = (Double)(rd["GIAOCA_DoanhThu"]);
            }
            if (rd.FieldExists("GIAOCA_TongSoPhoi"))
            {
                Item.TongSoPhoi = (Int32)(rd["GIAOCA_TongSoPhoi"]);
            }
            if (rd.FieldExists("GIAOCA_NguoiGiao"))
            {
                Item.NguoiGiao = (String)(rd["GIAOCA_NguoiGiao"]);
            }
            if (rd.FieldExists("GIAOCA_NguoiNhan"))
            {
                Item.NguoiNhan = (String)(rd["GIAOCA_NguoiNhan"]);
            }
            if (rd.FieldExists("GIAOCA_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["GIAOCA_NgayTao"]);
            }
            if (rd.FieldExists("GIAOCA_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["GIAOCA_NgayCapNhat"]);
            }
            if (rd.FieldExists("GIAOCA_Username"))
            {
                Item.Username = (String)(rd["GIAOCA_Username"]);
            }
            if (rd.FieldExists("GIAOCA_RowId"))
            {
                Item.RowId = (Guid)(rd["GIAOCA_RowId"]);
            }
            if (rd.FieldExists("GIAOCA_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["GIAOCA_Duyet"]);
            }
            if (rd.FieldExists("GIAOCA_KetThuc"))
            {
                Item.KetThuc = (Boolean)(rd["GIAOCA_KetThuc"]);
            }
            if (rd.FieldExists("GIAOCA_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["GIAOCA_NgayKetThuc"]);
            }
            return Item;
        }
        public static GiaoCa SelectByCqIdUsername(Int32 CQ_ID, string Username)
        {
            var Item = new GiaoCa();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            obj[1] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_GiaoCa_Select_SelectByCqIdUsername_linhnx", obj))
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
        public static GiaoCa Current(int cqId, string username)
        {
            var c = HttpContext.Current;
            var obj = c.Session["GiaoCa-Current"];
            if(obj==null)
            {
                var item = SelectByCqIdUsername(cqId, username);
                c.Session["GiaoCa-Current"] = item;
                return item;
            }
            return (GiaoCa) obj;
        }
        #endregion
    }
    #endregion

    #endregion

    public class ListThang
    {
        public int Thang { get; set; }
        public List<LichItem> Ngay { get; set; }
        public List<LichItem> NgayTangCuong { get; set; }
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
        public bool TangCuong { get; set; }

        /// <summary>
        /// Có 5 kiểu: 
        /// 1- Chấm công bình thường. 
        /// 2- Chấm công do quản lý điều độ duyệt. 
        /// 3- Chấm công + đề nghị truy thu lãnh đạo đã duyệt. 
        /// 4 - Báo ngày cần truy thu
        /// 5 - Châm công + đề nghị truy thu chưa duyệt
        /// 6- Nợ tiền
        /// </summary>
        public int KieuChamCong { get; set; }
        public string KieuChamCongStr
        {
            get
            {
                switch (KieuChamCong)
                {
                    case 1:
                        return "1.Chấm công";
                        break;
                    case 2:
                        return "2.Truy thu do điều độ duyệt";
                        break;
                    case 3:
                        return "3.Truy thu lãnh đạo bến đã duyệt";
                        break;
                    case 4:
                        return "4. Truy thu lãnh đạo bỏ thu tiền";
                        break;
                    case 5:
                        return "5.Truy thu lãnh đạo bến chưa duyệt";
                        break;
                    case 6:
                        return "6.Nợ";
                        break;
                    case 7:
                        return "4.Ngày cần truy thu";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }
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
                    case 4:
                        return "danger";
                        break;
                    case 5:
                        return "danger";
                        break;
                    case 6:
                        return "";
                        break;
                    case 7:
                        return "info";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }

        public string Txt
        {
            get
            {
                if (KieuChamCong == 6) return "Nợ";
                if(!string.IsNullOrEmpty(GhiChu)) return GhiChu;
                return SoChuyen.ChamCongHienThiStr();
            }
        }

        public bool Clickable { get; set; }
        public bool Clickactive { get; set; }
        public Int64 TRUYTHU_ID { get; set; }
        public Int64 PHOI_ID { get; set; }
        public List<ChamCong> List { get; set; }
        public ChamCong Item { get; set; }
        public string GhiChu { get; set; }
        public LichItem()
        {
            List = new List<ChamCong>();
            Item=new ChamCong();
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
        public string Hint
        {
            get { return Ten; }
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
            return SelectById(DAL.con(), LBD_ID);
        }
        public static LoaiBieuDo SelectById(SqlConnection con, Int32 LBD_ID)
        {
            var Item = new LoaiBieuDo();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LBD_ID", LBD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_LoaiBieuDo_Select_SelectById_linhnx", obj))
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
        public Boolean TangCuong { get; set; }
        public Int64 ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public Int64 XE_ID { get; set; }
        public DateTime Ngay { get; set; }
        public Int64 TRUYTHU_ID { get; set; }
        public Int64 PHOI_ID { get; set; }
        /// <summary>
        /// 1: Chấm công hợp lệ dựa trên phơi. 2: Chấm công truy thu do quản lý điều độ làm. 3: Chấm công truy thu do lãnh đạo duyệt. 4: Chấm công được lãnh đạo duyệt không thu tiền.
        /// </summary>
        public Int16 Loai { get; set; }
        public Boolean Duyet { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }

        public Double Tien { get; set; }
        /// <summary>
        /// 0: Không nợ. 1: Có nợ - chưa trả. 2: Có nợ - đã trả.
        /// </summary>
        public Int16 TrangThaiNo { get; set; }
        public String GhiChu { get; set; }
        public DateTime NgayThanhToan { get; set; }

        public bool DaThuNo { get; set; }
        public Boolean Draff { get; set; }
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
            var obj = new SqlParameter[18];
            obj[1] = new SqlParameter("CONG_CQ_ID", item.CQ_ID);
            obj[2] = new SqlParameter("CONG_TangCuong", item.TangCuong);
            obj[3] = new SqlParameter("CONG_XE_ID", item.XE_ID);
            obj[4] = new SqlParameter("CONG_Ngay", item.Ngay);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("CONG_Ngay", item.Ngay);
            }
            else
            {
                obj[4] = new SqlParameter("CONG_Ngay", DBNull.Value);
            }
            obj[5] = new SqlParameter("CONG_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[6] = new SqlParameter("CONG_PHOI_ID", item.PHOI_ID);
            obj[7] = new SqlParameter("CONG_Loai", item.Loai);
            obj[8] = new SqlParameter("CONG_Duyet", item.Duyet);
            obj[9] = new SqlParameter("CONG_Username", item.Username);
            obj[10] = new SqlParameter("CONG_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("CONG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("CONG_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("CONG_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("CONG_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("CONG_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("CONG_RowId", item.RowId);
            obj[13] = new SqlParameter("CONG_Tien", item.Tien);
            obj[14] = new SqlParameter("CONG_TrangThaiNo", item.TrangThaiNo);
            obj[15] = new SqlParameter("CONG_GhiChu", item.GhiChu);
            obj[16] = new SqlParameter("CONG_NgayThanhToan", item.NgayThanhToan);
            if (item.NgayThanhToan > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("CONG_NgayThanhToan", item.NgayThanhToan);
            }
            else
            {
                obj[16] = new SqlParameter("CONG_NgayThanhToan", DBNull.Value);
            }
            obj[17] = new SqlParameter("CONG_Draff", item.Draff);

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
            var obj = new SqlParameter[18];
            obj[0] = new SqlParameter("CONG_ID", item.ID);
            obj[1] = new SqlParameter("CONG_CQ_ID", item.CQ_ID);
            obj[2] = new SqlParameter("CONG_TangCuong", item.TangCuong);
            obj[3] = new SqlParameter("CONG_XE_ID", item.XE_ID);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("CONG_Ngay", item.Ngay);
            }
            else
            {
                obj[4] = new SqlParameter("CONG_Ngay", DBNull.Value);
            }
            obj[5] = new SqlParameter("CONG_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[6] = new SqlParameter("CONG_PHOI_ID", item.PHOI_ID);
            obj[7] = new SqlParameter("CONG_Loai", item.Loai);
            obj[8] = new SqlParameter("CONG_Duyet", item.Duyet);
            obj[9] = new SqlParameter("CONG_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("CONG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("CONG_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("CONG_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("CONG_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("CONG_RowId", item.RowId);
            obj[13] = new SqlParameter("CONG_Tien", item.Tien);
            obj[14] = new SqlParameter("CONG_TrangThaiNo", item.TrangThaiNo);
            obj[15] = new SqlParameter("CONG_GhiChu", item.GhiChu);
            if (item.NgayThanhToan > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("CONG_NgayThanhToan", item.NgayThanhToan);
            }
            else
            {
                obj[16] = new SqlParameter("CONG_NgayThanhToan", DBNull.Value);
            }
            obj[17] = new SqlParameter("CONG_Draff", item.Draff);

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
            if (rd.FieldExists("CONG_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["CONG_CQ_ID"]);
            }
            if (rd.FieldExists("CONG_TangCuong"))
            {
                Item.TangCuong = (Boolean)(rd["CONG_TangCuong"]);
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
            if (rd.FieldExists("CONG_Tien"))
            {
                Item.Tien = (Double)(rd["CONG_Tien"]);
            }
            if (rd.FieldExists("CONG_TrangThaiNo"))
            {
                Item.TrangThaiNo = (Int16)(rd["CONG_TrangThaiNo"]);
            }
            if (rd.FieldExists("CONG_GhiChu"))
            {
                Item.GhiChu = (String)(rd["CONG_GhiChu"]);
            }
            if (rd.FieldExists("CONG_NgayThanhToan"))
            {
                Item.NgayThanhToan = (DateTime)(rd["CONG_NgayThanhToan"]);
            }
            if (rd.FieldExists("DaThuNo"))
            {
                Item.DaThuNo = (bool)(rd["DaThuNo"]);
            }
            if (rd.FieldExists("CONG_Draff"))
            {
                Item.Draff = (Boolean)(rd["CONG_Draff"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static ChamCongCollection NoByXeTuNgay(SqlConnection con, string TuNgay, long XE_ID)
        {
            return NoByXeTuNgay(con, TuNgay,null, XE_ID);
        }
        public static ChamCongCollection NoByXeTuNgay(SqlConnection con, string TuNgay, string THUNO_ID, long XE_ID)
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
            if (!string.IsNullOrEmpty(THUNO_ID))
            {
                obj[2] = new SqlParameter("THUNO_ID", THUNO_ID);
            }
            else
            {
                obj[2] = new SqlParameter("THUNO_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_NoByXeTuNgay_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static ChamCongCollection SelectByXeTuNgay(string PHOI_ID, string TuNgay, long XE_ID)
        {
            return SelectByXeTuNgay(DAL.con(), PHOI_ID, TuNgay, XE_ID);
        }
        public static ChamCongCollection SelectByXeTuNgay(SqlConnection con, string PHOI_ID, string TuNgay, long XE_ID)
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
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectByXeTuNgay_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static ChamCongCollection SelectByXeTuNgayCqId(SqlConnection con, int CqId, string TuNgay, string DenNgay, long XE_ID)
        {
            var List = new ChamCongCollection();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("XE_ID", XE_ID);
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[1] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (CqId>0)
            {
                obj[2] = new SqlParameter("CqId", CqId);
            }
            else
            {
                obj[2] = new SqlParameter("CqId", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[3] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[3] = new SqlParameter("DenNgay", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectByXeTuNgayCqId_linhnx", obj))
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
            return SelectByTruyThuId(DAL.con(),TRUYTHU_ID);
        }
        public static ChamCongCollection SelectByTruyThuId(SqlConnection con, long TRUYTHU_ID)
        {
            var List = new ChamCongCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TRUYTHU_ID", TRUYTHU_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectByTruyThuId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static ChamCongCollection SelectByPhoiId(long ID)
        {
            return SelectByPhoiId(DAL.con(), ID);
        }
        public static ChamCongCollection SelectByPhoiId(SqlConnection con, long ID)
        {
            var List = new ChamCongCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ChamCong_Select_SelectByPhoiId_linhnx", obj))
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

        public static void UpdateDuyetByTruyThuId(SqlConnection con, Int64 TruyThuId)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TruyThuId", TruyThuId);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure,
                                    "sp_tblBx_ChamCong_Update_UpdateDuyetByTruyThuId_linhnx", obj);
        }
        public static void UpdateTraNo(SqlConnection con, Int64 Id)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Id", Id);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure,
                                    "sp_tblBx_ChamCong_Update_UpdateTraNo_linhnx", obj);
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
        public string Hint
        {
            get { return string.Format("{0} {1} {2}", Ten, Mobile, DiaChi); }
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
                return (d < NgayHetHanBangLai && !Khoa && d < NgayHetHanGiayKhamSucKhoe);
            }
        }

        public bool HopLeAll { get; set; }
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
        public string Hint
        {
            get { return string.Format("{0}", Ten); }
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
            return SelectById(DAL.con(), LAIXE_ID);
        }
        public static LaiXe SelectById(SqlConnection con, Int64 LAIXE_ID)
        {
            var Item = new LaiXe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LAIXE_ID", LAIXE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_LaiXe_Select_SelectById_linhnx", obj))
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
        public string Hint{get { return string.Format("{0}", Ten); }}
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
            return SelectById(DAL.con(), LOAIXE_ID);
        }
        public static LoaiXe SelectById(SqlConnection con, Int32 LOAIXE_ID)
        {
            var Item = new LoaiXe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LOAIXE_ID", LOAIXE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_LoaiXe_Select_SelectById_linhnx", obj))
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
        public Int64 GIAOCA_ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public Int32 DONVI_ID { get; set; }
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
        public Double PhiMotChuyenTruyThu { get; set; }
        public Int16 KhachTruyThu { get; set; }
        public Boolean TruyThu { get; set; }
        public Boolean HopLe { get; set; }
        public Int16 TrangThai { get; set; }
        public Boolean XeThayThe { get; set; }
        public Int64 XeThayThe_ID { get; set; }
        public Boolean XeTangCuong { get; set; }
        public Guid RowId { get; set; }
        public Boolean ChoDuyet { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        public Double GiaVe { get; set; }
        public Boolean PHI_ChiThuBenBai { get; set; }
        public Boolean Draff { get; set; }
        #endregion
        #region Contructor
        public Phoi()
        { }
        #endregion
        #region Customs properties
        public string STTBXStr
        {
            get { return Lib.FormatMa(STTBX,"0000"); }
        }
        public string STTALLStr
        {
            get { return Lib.FormatMa(STTALL,"0000000"); }
        }
        public string Url
        {
            get { return string.Format("/lib/pages/Phoi/Add.aspx?ID={0}", ID); }
        }

        public Xe Xe { get; set; }
        public LaiXe LaiXe { get; set; }
        public string XE_BienSo { get; set; }
        public string DONVI_Ten { get; set; }
        

        public Int64 TruyThu_Id { get; set; }
        public Int64 TruyThu_STTBX { get; set; }
        public string TruyThu_STTBXStr { get { return Lib.FormatMa(TruyThu_STTBX); } 
        }
        public string CQ_Ten { get; set; }
        public string LAIXE_Ten { get; set; }
        public string XeThayThe_BienSo { get; set; }
        public List<ChamCong> ChamCongList { get; set; }
        public List<ChamCong> ChamCongListCurrent { get; set; }
        public TruyThu TruyThuItem { get; set; }
        public XeVaoBen XeVaoBen { get; set; }
        public string NgayXuatBenStr{get { return NgayXuatBen.NgayVn(); }}
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
                    var obj = new SqlParameter[42];
                    				obj[1] = new SqlParameter("PHOI_GIAOCA_ID", item.GIAOCA_ID);
				obj[2] = new SqlParameter("PHOI_XE_ID", item.XE_ID);
				obj[3] = new SqlParameter("PHOI_DONVI_ID", item.DONVI_ID);
				obj[4] = new SqlParameter("PHOI_CQ_ID", item.CQ_ID);
				obj[5] = new SqlParameter("PHOI_LAIXE_ID", item.LAIXE_ID);
				obj[6] = new SqlParameter("PHOI_STTBX", item.STTBX);
				obj[7] = new SqlParameter("PHOI_STTALL", item.STTALL);
				obj[8] = new SqlParameter("PHOI_NgayXuatBen", item.NgayXuatBen);
					if(item.NgayXuatBen > DateTime.MinValue)
					{
				obj[8] = new SqlParameter("PHOI_NgayXuatBen", item.NgayXuatBen);
					}
					else{
						obj[8] = new SqlParameter("PHOI_NgayXuatBen", DBNull.Value);
					}
				obj[9] = new SqlParameter("PHOI_NgayXuatThucTe", item.NgayXuatThucTe);
					if(item.NgayXuatThucTe > DateTime.MinValue)
					{
				obj[9] = new SqlParameter("PHOI_NgayXuatThucTe", item.NgayXuatThucTe);
					}
					else{
						obj[9] = new SqlParameter("PHOI_NgayXuatThucTe", DBNull.Value);
					}
				obj[10] = new SqlParameter("PHOI_PHI_BenBai", item.PHI_BenBai);
				obj[11] = new SqlParameter("PHOI_PHI_XeDauDem", item.PHI_XeDauDem);
				obj[12] = new SqlParameter("PHOI_PHI_VeSinhBenBai", item.PHI_VeSinhBenBai);
				obj[13] = new SqlParameter("PHOI_PHI_XeLuuBen", item.PHI_XeLuuBen);
				obj[14] = new SqlParameter("PHOI_PHI_HoaHongBanVe", item.PHI_HoaHongBanVe);
				obj[15] = new SqlParameter("PHOI_PHI_ChuyenTruyThu", item.PHI_ChuyenTruyThu);
				obj[16] = new SqlParameter("PHOI_PHI_KhachTruyThu", item.PHI_KhachTruyThu);
				obj[17] = new SqlParameter("PHOI_PHI_TruyThuGiam", item.PHI_TruyThuGiam);
				obj[18] = new SqlParameter("PHOI_PHI_Khac", item.PHI_Khac);
				obj[19] = new SqlParameter("PHOI_PHI_Tong", item.PHI_Tong);
				obj[20] = new SqlParameter("PHOI_PHI_Nop", item.PHI_Nop);
				obj[21] = new SqlParameter("PHOI_PHI_ConNo", item.PHI_ConNo);
				obj[22] = new SqlParameter("PHOI_HanhKhach", item.HanhKhach);
				obj[23] = new SqlParameter("PHOI_Ve", item.Ve);
				obj[24] = new SqlParameter("PHOI_GiaVe", item.GiaVe);
				obj[25] = new SqlParameter("PHOI_PHI_ChiThuBenBai", item.PHI_ChiThuBenBai);
				obj[26] = new SqlParameter("PHOI_ChuyenTruyThu", item.ChuyenTruyThu);
				obj[27] = new SqlParameter("PHOI_PhiMotChuyenTruyThu", item.PhiMotChuyenTruyThu);
				obj[28] = new SqlParameter("PHOI_KhachTruyThu", item.KhachTruyThu);
				obj[29] = new SqlParameter("PHOI_TruyThu", item.TruyThu);
				obj[30] = new SqlParameter("PHOI_TruyThu_Id", item.TruyThu_Id);
				obj[31] = new SqlParameter("PHOI_HopLe", item.HopLe);
				obj[32] = new SqlParameter("PHOI_ChoDuyet", item.ChoDuyet);
				obj[33] = new SqlParameter("PHOI_TrangThai", item.TrangThai);
				obj[34] = new SqlParameter("PHOI_XeThayThe", item.XeThayThe);
				obj[35] = new SqlParameter("PHOI_XeThayThe_ID", item.XeThayThe_ID);
				obj[36] = new SqlParameter("PHOI_XeTangCuong", item.XeTangCuong);
				obj[37] = new SqlParameter("PHOI_RowId", item.RowId);
				obj[38] = new SqlParameter("PHOI_NgayTao", item.NgayTao);
					if(item.NgayTao > DateTime.MinValue)
					{
				obj[38] = new SqlParameter("PHOI_NgayTao", item.NgayTao);
					}
					else{
						obj[38] = new SqlParameter("PHOI_NgayTao", DBNull.Value);
					}
				obj[39] = new SqlParameter("PHOI_NgayCapNhat", item.NgayCapNhat);
					if(item.NgayCapNhat > DateTime.MinValue)
					{
				obj[39] = new SqlParameter("PHOI_NgayCapNhat", item.NgayCapNhat);
					}
					else{
						obj[39] = new SqlParameter("PHOI_NgayCapNhat", DBNull.Value);
					}
				obj[40] = new SqlParameter("PHOI_Username", item.Username);
				obj[41] = new SqlParameter("PHOI_Draff", item.Draff);

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
            var obj = new SqlParameter[42];
                    		obj[0] = new SqlParameter("PHOI_ID", item.ID);
		obj[1] = new SqlParameter("PHOI_GIAOCA_ID", item.GIAOCA_ID);
		obj[2] = new SqlParameter("PHOI_XE_ID", item.XE_ID);
		obj[3] = new SqlParameter("PHOI_DONVI_ID", item.DONVI_ID);
		obj[4] = new SqlParameter("PHOI_CQ_ID", item.CQ_ID);
		obj[5] = new SqlParameter("PHOI_LAIXE_ID", item.LAIXE_ID);
		obj[6] = new SqlParameter("PHOI_STTBX", item.STTBX);
		obj[7] = new SqlParameter("PHOI_STTALL", item.STTALL);
			if(item.NgayXuatBen > DateTime.MinValue)
			{
		obj[8] = new SqlParameter("PHOI_NgayXuatBen", item.NgayXuatBen);
			}
			else{
				obj[8] = new SqlParameter("PHOI_NgayXuatBen", DBNull.Value);
			}
			if(item.NgayXuatThucTe > DateTime.MinValue)
			{
		obj[9] = new SqlParameter("PHOI_NgayXuatThucTe", item.NgayXuatThucTe);
			}
			else{
				obj[9] = new SqlParameter("PHOI_NgayXuatThucTe", DBNull.Value);
			}
		obj[10] = new SqlParameter("PHOI_PHI_BenBai", item.PHI_BenBai);
		obj[11] = new SqlParameter("PHOI_PHI_XeDauDem", item.PHI_XeDauDem);
		obj[12] = new SqlParameter("PHOI_PHI_VeSinhBenBai", item.PHI_VeSinhBenBai);
		obj[13] = new SqlParameter("PHOI_PHI_XeLuuBen", item.PHI_XeLuuBen);
		obj[14] = new SqlParameter("PHOI_PHI_HoaHongBanVe", item.PHI_HoaHongBanVe);
		obj[15] = new SqlParameter("PHOI_PHI_ChuyenTruyThu", item.PHI_ChuyenTruyThu);
		obj[16] = new SqlParameter("PHOI_PHI_KhachTruyThu", item.PHI_KhachTruyThu);
		obj[17] = new SqlParameter("PHOI_PHI_TruyThuGiam", item.PHI_TruyThuGiam);
		obj[18] = new SqlParameter("PHOI_PHI_Khac", item.PHI_Khac);
		obj[19] = new SqlParameter("PHOI_PHI_Tong", item.PHI_Tong);
		obj[20] = new SqlParameter("PHOI_PHI_Nop", item.PHI_Nop);
		obj[21] = new SqlParameter("PHOI_PHI_ConNo", item.PHI_ConNo);
		obj[22] = new SqlParameter("PHOI_HanhKhach", item.HanhKhach);
		obj[23] = new SqlParameter("PHOI_Ve", item.Ve);
		obj[24] = new SqlParameter("PHOI_GiaVe", item.GiaVe);
		obj[25] = new SqlParameter("PHOI_PHI_ChiThuBenBai", item.PHI_ChiThuBenBai);
		obj[26] = new SqlParameter("PHOI_ChuyenTruyThu", item.ChuyenTruyThu);
		obj[27] = new SqlParameter("PHOI_PhiMotChuyenTruyThu", item.PhiMotChuyenTruyThu);
		obj[28] = new SqlParameter("PHOI_KhachTruyThu", item.KhachTruyThu);
		obj[29] = new SqlParameter("PHOI_TruyThu", item.TruyThu);
		obj[30] = new SqlParameter("PHOI_TruyThu_Id", item.TruyThu_Id);
		obj[31] = new SqlParameter("PHOI_HopLe", item.HopLe);
		obj[32] = new SqlParameter("PHOI_ChoDuyet", item.ChoDuyet);
		obj[33] = new SqlParameter("PHOI_TrangThai", item.TrangThai);
		obj[34] = new SqlParameter("PHOI_XeThayThe", item.XeThayThe);
		obj[35] = new SqlParameter("PHOI_XeThayThe_ID", item.XeThayThe_ID);
		obj[36] = new SqlParameter("PHOI_XeTangCuong", item.XeTangCuong);
		obj[37] = new SqlParameter("PHOI_RowId", item.RowId);
			if(item.NgayTao > DateTime.MinValue)
			{
		obj[38] = new SqlParameter("PHOI_NgayTao", item.NgayTao);
			}
			else{
				obj[38] = new SqlParameter("PHOI_NgayTao", DBNull.Value);
			}
			if(item.NgayCapNhat > DateTime.MinValue)
			{
		obj[39] = new SqlParameter("PHOI_NgayCapNhat", item.NgayCapNhat);
			}
			else{
				obj[39] = new SqlParameter("PHOI_NgayCapNhat", DBNull.Value);
			}
		obj[40] = new SqlParameter("PHOI_Username", item.Username);
		obj[41] = new SqlParameter("PHOI_Draff", item.Draff);

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
            return SelectById(DAL.con(),PHOI_ID);
        }

        public static Phoi SelectById(SqlConnection con, Int64 PHOI_ID)
        {
            var Item = new Phoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PHOI_ID", PHOI_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Phoi_Select_SelectById_linhnx", obj))
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
            return SelectLastest(CQ_ID, false);
        }
        public static Phoi SelectLastest(string CQ_ID, bool DoNotInsert)
        {
            var Item = new Phoi();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            obj[1] = new SqlParameter("DoNotInsert", DoNotInsert);
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
            #region basic
            var Item = new Phoi();
            if (rd.FieldExists("PHOI_ID"))
            {
                Item.ID = (Int64)(rd["PHOI_ID"]);
            }
            if (rd.FieldExists("PHOI_GIAOCA_ID"))
            {
                Item.GIAOCA_ID = (Int64)(rd["PHOI_GIAOCA_ID"]);
            }
            if (rd.FieldExists("PHOI_XE_ID"))
            {
                Item.XE_ID = (Int64)(rd["PHOI_XE_ID"]);
            }
            if (rd.FieldExists("PHOI_DONVI_ID"))
            {
                Item.DONVI_ID = (Int32)(rd["PHOI_DONVI_ID"]);
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
            if(rd.FieldExists("PHOI_PhiMotChuyenTruyThu")){
			    Item.PhiMotChuyenTruyThu = (Double)(rd["PHOI_PhiMotChuyenTruyThu"]);
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
            if (rd.FieldExists("PHOI_PHI_ChiThuBenBai"))
            {
                Item.PHI_ChiThuBenBai = (Boolean)(rd["PHOI_PHI_ChiThuBenBai"]);
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
            if (rd.FieldExists("PHOI_ChuyenTruyThu"))
            {
                Item.ChuyenTruyThu = (Int16)(rd["PHOI_ChuyenTruyThu"]);
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
            if (rd.FieldExists("XVB_TrangThai"))
            {
                Item.TrangThai = (Int16)(rd["XVB_TrangThai"]);
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
            if (rd.FieldExists("PHOI_Draff"))
            {
                Item.Draff = (Boolean)(rd["PHOI_Draff"]);
            }
            if (rd.FieldExists("PHOI_GiaVe"))
            {
                Item.GiaVe = (Double)(rd["PHOI_GiaVe"]);
            }
            #endregion

            #region extend
            if (rd.FieldExists("XE_BienSo"))
            {
                Item.XE_BienSo = (String)(rd["XE_BienSo"]);
            }
            if (rd.FieldExists("XeThayThe_BienSo"))
            {
                Item.XeThayThe_BienSo = (String)(rd["XeThayThe_BienSo"]);
            }
            
            if (rd.FieldExists("DONVI_Ten"))
            {
                Item.DONVI_Ten = (String)(rd["DONVI_Ten"]);
            }
            if (rd.FieldExists("TruyThu_ID"))
            {
                Item.TruyThu_Id = (Int64)(rd["TruyThu_ID"]);
            }
            if (rd.FieldExists("TruyThu_STTBX"))
            {
                Item.TruyThu_STTBX = (Int64)(rd["TruyThu_STTBX"]);
            }
            #endregion
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<Phoi> PagerByUser(SqlConnection con,  string url, bool rewrite, string sort, string q, int size
            , string username, string giaoCa_Id, string donVi_id
            , string xe_id, string nguoiTao, string tuNgay
            , string denNgay)
        {
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(giaoCa_Id))
            {
                obj[3] = new SqlParameter("giaoCa_Id", giaoCa_Id);
            }
            else
            {
                obj[3] = new SqlParameter("giaoCa_Id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(donVi_id))
            {
                obj[4] = new SqlParameter("donVi_id", donVi_id);
            }
            else
            {
                obj[4] = new SqlParameter("donVi_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(xe_id))
            {
                obj[5] = new SqlParameter("xe_id", xe_id);
            }
            else
            {
                obj[5] = new SqlParameter("xe_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(nguoiTao))
            {
                obj[6] = new SqlParameter("nguoiTao", nguoiTao);
            }
            else
            {
                obj[6] = new SqlParameter("nguoiTao", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(tuNgay))
            {
                obj[7] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[7] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(denNgay))
            {
                obj[8] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[8] = new SqlParameter("denNgay", DBNull.Value);
            }
            var pg = new Pager<Phoi>(con, "sp_tblBx_Phoi_Pager_PagerByUser_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static List<Phoi> SelectByGiaoCa(SqlConnection con, Int32 giaoCa_Id, string ngay)
        {
            var obj = new SqlParameter[2];
            if (giaoCa_Id>0)
            {
                obj[1] = new SqlParameter("giaoCa_Id", giaoCa_Id);
            }
            else
            {
                obj[1] = new SqlParameter("giaoCa_Id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ngay))
            {
                obj[0] = new SqlParameter("ngay", ngay);
            }
            else
            {
                obj[0] = new SqlParameter("ngay", DBNull.Value);
            }

            var list = new PhoiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Phoi_Select_SelectByGiaoCa_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
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
        public Int32 CQ_ID { get; set; }
        /// <summary>
        /// 0: Truy thu thường. 1: Đề nghị truy thu chưa duyệt. 2: Đề nghị truy thu đã duyệt-chờ ý kiến chủ xe. 3: Chủ xe không đồng ý với truy thu. 4: Chủ xe đồng ý với ý kiến. 5: Truy thu đã hủy để tạm thời xử lý
        /// </summary>
        public Int16 TrangThai { get; set; }
        public Boolean Draff { get; set; }

        public  String YKienQuanLy{get;set;}
        public  String KienNghi{get;set;}
        #endregion
        #region Contructor
        public TruyThu()
        { }
        #endregion
        #region Customs properties

        public string DANHGIA_Ten { get; set; }
        public string NOIDUNG_Ten { get; set; }
        public Phoi Phoi { get; set; }
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
                    var obj = new SqlParameter[33];
                    				obj[1] = new SqlParameter("TRUYTHU_CQ_ID", item.CQ_ID);
				obj[2] = new SqlParameter("TRUYTHU_STTBX", item.STTBX);
				obj[3] = new SqlParameter("TRUYTHU_STTALL", item.STTALL);
				obj[4] = new SqlParameter("TRUYTHU_PHOI_ID", item.PHOI_ID);
				obj[5] = new SqlParameter("TRUYTHU_XE_ID", item.XE_ID);
				obj[6] = new SqlParameter("TRUYTHU_NguoiLap", item.NguoiLap);
				obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", item.ThoiGianNghi_TuNgay);
					if(item.ThoiGianNghi_TuNgay > DateTime.MinValue)
					{
				obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", item.ThoiGianNghi_TuNgay);
					}
					else{
						obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", DBNull.Value);
					}
				obj[8] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", item.ThoiGianNghi_DenNgay);
					if(item.ThoiGianNghi_DenNgay > DateTime.MinValue)
					{
				obj[8] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", item.ThoiGianNghi_DenNgay);
					}
					else{
						obj[8] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", DBNull.Value);
					}
				obj[9] = new SqlParameter("TRUYTHU_SoChuyenThucHien", item.SoChuyenThucHien);
				obj[10] = new SqlParameter("TRUYTHU_SoChuyenBieuDo", item.SoChuyenBieuDo);
				obj[11] = new SqlParameter("TRUYTHU_SoChuyenThieu", item.SoChuyenThieu);
				obj[12] = new SqlParameter("TRUYTHU_SoChuyenDeNghi", item.SoChuyenDeNghi);
				obj[13] = new SqlParameter("TRUYTHU_GiaTienDichVuTrongHopDong", item.GiaTienDichVuTrongHopDong);
				obj[14] = new SqlParameter("TRUYTHU_TongTruyThu", item.TongTruyThu);
				obj[15] = new SqlParameter("TRUYTHU_GiamTru", item.GiamTru);
				obj[16] = new SqlParameter("TRUYTHU_NOIDUNG_ID", item.NOIDUNG_ID);
				obj[17] = new SqlParameter("TRUYTHU_DANHGIA_ID", item.DANHGIA_ID);
				obj[18] = new SqlParameter("TRUYTHU_DeNghiCuaNhaXe", item.DeNghiCuaNhaXe);
				obj[19] = new SqlParameter("TRUYTHU_YKienQuanLy", item.YKienQuanLy);
				obj[20] = new SqlParameter("TRUYTHU_YKienChiDao", item.YKienChiDao);
				obj[21] = new SqlParameter("TRUYTHU_SoChuyenDuocDuyet", item.SoChuyenDuocDuyet);
				obj[22] = new SqlParameter("TRUYTHU_NgayDuyet", item.NgayDuyet);
					if(item.NgayDuyet > DateTime.MinValue)
					{
				obj[22] = new SqlParameter("TRUYTHU_NgayDuyet", item.NgayDuyet);
					}
					else{
						obj[22] = new SqlParameter("TRUYTHU_NgayDuyet", DBNull.Value);
					}
				obj[23] = new SqlParameter("TRUYTHU_LanhDaoDuyet", item.LanhDaoDuyet);
				obj[24] = new SqlParameter("TRUYTHU_Duyet", item.Duyet);
				obj[25] = new SqlParameter("TRUYTHU_DeNghi", item.DeNghi);
				obj[26] = new SqlParameter("TRUYTHU_NgayTao", item.NgayTao);
					if(item.NgayTao > DateTime.MinValue)
					{
				obj[26] = new SqlParameter("TRUYTHU_NgayTao", item.NgayTao);
					}
					else{
						obj[26] = new SqlParameter("TRUYTHU_NgayTao", DBNull.Value);
					}
				obj[27] = new SqlParameter("TRUYTHU_NgayCapNhat", item.NgayCapNhat);
					if(item.NgayCapNhat > DateTime.MinValue)
					{
				obj[27] = new SqlParameter("TRUYTHU_NgayCapNhat", item.NgayCapNhat);
					}
					else{
						obj[27] = new SqlParameter("TRUYTHU_NgayCapNhat", DBNull.Value);
					}
				obj[28] = new SqlParameter("TRUYTHU_RowId", item.RowId);
				obj[29] = new SqlParameter("TRUYTHU_Username", item.Username);
				obj[30] = new SqlParameter("TRUYTHU_TrangThai", item.TrangThai);
				obj[31] = new SqlParameter("TRUYTHU_KienNghi", item.KienNghi);
				obj[32] = new SqlParameter("TRUYTHU_Draff", item.Draff);

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
                    var obj = new SqlParameter[33];
                    				obj[0] = new SqlParameter("TRUYTHU_ID", item.ID);
				obj[1] = new SqlParameter("TRUYTHU_CQ_ID", item.CQ_ID);
				obj[2] = new SqlParameter("TRUYTHU_STTBX", item.STTBX);
				obj[3] = new SqlParameter("TRUYTHU_STTALL", item.STTALL);
				obj[4] = new SqlParameter("TRUYTHU_PHOI_ID", item.PHOI_ID);
				obj[5] = new SqlParameter("TRUYTHU_XE_ID", item.XE_ID);
				obj[6] = new SqlParameter("TRUYTHU_NguoiLap", item.NguoiLap);
					if(item.ThoiGianNghi_TuNgay > DateTime.MinValue)
					{
				obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", item.ThoiGianNghi_TuNgay);
					}
					else{
						obj[7] = new SqlParameter("TRUYTHU_ThoiGianNghi_TuNgay", DBNull.Value);
					}
					if(item.ThoiGianNghi_DenNgay > DateTime.MinValue)
					{
				obj[8] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", item.ThoiGianNghi_DenNgay);
					}
					else{
						obj[8] = new SqlParameter("TRUYTHU_ThoiGianNghi_DenNgay", DBNull.Value);
					}
				obj[9] = new SqlParameter("TRUYTHU_SoChuyenThucHien", item.SoChuyenThucHien);
				obj[10] = new SqlParameter("TRUYTHU_SoChuyenBieuDo", item.SoChuyenBieuDo);
				obj[11] = new SqlParameter("TRUYTHU_SoChuyenThieu", item.SoChuyenThieu);
				obj[12] = new SqlParameter("TRUYTHU_SoChuyenDeNghi", item.SoChuyenDeNghi);
				obj[13] = new SqlParameter("TRUYTHU_GiaTienDichVuTrongHopDong", item.GiaTienDichVuTrongHopDong);
				obj[14] = new SqlParameter("TRUYTHU_TongTruyThu", item.TongTruyThu);
				obj[15] = new SqlParameter("TRUYTHU_GiamTru", item.GiamTru);
				obj[16] = new SqlParameter("TRUYTHU_NOIDUNG_ID", item.NOIDUNG_ID);
				obj[17] = new SqlParameter("TRUYTHU_DANHGIA_ID", item.DANHGIA_ID);
				obj[18] = new SqlParameter("TRUYTHU_DeNghiCuaNhaXe", item.DeNghiCuaNhaXe);
				obj[19] = new SqlParameter("TRUYTHU_YKienQuanLy", item.YKienQuanLy);
				obj[20] = new SqlParameter("TRUYTHU_YKienChiDao", item.YKienChiDao);
				obj[21] = new SqlParameter("TRUYTHU_SoChuyenDuocDuyet", item.SoChuyenDuocDuyet);
					if(item.NgayDuyet > DateTime.MinValue)
					{
				obj[22] = new SqlParameter("TRUYTHU_NgayDuyet", item.NgayDuyet);
					}
					else{
						obj[22] = new SqlParameter("TRUYTHU_NgayDuyet", DBNull.Value);
					}
				obj[23] = new SqlParameter("TRUYTHU_LanhDaoDuyet", item.LanhDaoDuyet);
				obj[24] = new SqlParameter("TRUYTHU_Duyet", item.Duyet);
				obj[25] = new SqlParameter("TRUYTHU_DeNghi", item.DeNghi);
					if(item.NgayTao > DateTime.MinValue)
					{
				obj[26] = new SqlParameter("TRUYTHU_NgayTao", item.NgayTao);
					}
					else{
						obj[26] = new SqlParameter("TRUYTHU_NgayTao", DBNull.Value);
					}
					if(item.NgayCapNhat > DateTime.MinValue)
					{
				obj[27] = new SqlParameter("TRUYTHU_NgayCapNhat", item.NgayCapNhat);
					}
					else{
						obj[27] = new SqlParameter("TRUYTHU_NgayCapNhat", DBNull.Value);
					}
				obj[28] = new SqlParameter("TRUYTHU_RowId", item.RowId);
				obj[29] = new SqlParameter("TRUYTHU_Username", item.Username);
				obj[30] = new SqlParameter("TRUYTHU_TrangThai", item.TrangThai);
				obj[31] = new SqlParameter("TRUYTHU_KienNghi", item.KienNghi);
				obj[32] = new SqlParameter("TRUYTHU_Draff", item.Draff);

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
            return SelectById(DAL.con(),TRUYTHU_ID);
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
            if(rd.FieldExists("TRUYTHU_YKienQuanLy")){
					Item.YKienQuanLy = (String)(rd["TRUYTHU_YKienQuanLy"]);
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
            if (rd.FieldExists("TRUYTHU_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["TRUYTHU_CQ_ID"]);
            }
            if (rd.FieldExists("TRUYTHU_TrangThai"))
            {
                Item.TrangThai = (Int16)(rd["TRUYTHU_TrangThai"]);
            }
            if (rd.FieldExists("TRUYTHU_Draff"))
            {
                Item.Draff = (Boolean)(rd["TRUYTHU_Draff"]);
            }
            //Extended
            if (rd.FieldExists("NOIDUNG_Ten"))
            {
                Item.NOIDUNG_Ten = (String)(rd["NOIDUNG_Ten"]);
            }
            if (rd.FieldExists("DANHGIA_Ten"))
            {
                Item.DANHGIA_Ten = (String)(rd["DANHGIA_Ten"]);
            }
            if(rd.FieldExists("TRUYTHU_KienNghi")){
					Item.KienNghi = (String)(rd["TRUYTHU_KienNghi"]);
					}
            return Item;
        }
        #endregion

        #region Extend
        public static TruyThu SelectById(SqlConnection con, Int64 TRUYTHU_ID)
        {
            var Item = new TruyThu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TRUYTHU_ID", TRUYTHU_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_TruyThu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TruyThu SelectByPhoiId(Int64 PHOI_ID)
        {
            return SelectByPhoiId(DAL.con(), PHOI_ID);
        }
        public static TruyThu SelectByPhoiId(SqlConnection con, Int64 PHOI_ID)
        {
            var Item = new TruyThu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PHOI_ID", PHOI_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_TruyThu_Select_SelectByPhoiId_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TruyThu SelectLastest(Int32 CQ_ID)
        {
            var Item = new TruyThu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_TruyThu_Select_SelectLastest_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Pager<TruyThu> PagerByUserDuyet(SqlConnection con, string url, bool rewrite, string sort, string q, int size
            , string username, string duyet, string deNghi)
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
            if (!string.IsNullOrEmpty(username))
            {
                obj[2] = new SqlParameter("username", username);
            }
            else
            {
                obj[2] = new SqlParameter("username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(duyet))
            {
                obj[3] = new SqlParameter("duyet", duyet);
            }
            else
            {
                obj[3] = new SqlParameter("duyet", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(deNghi))
            {
                obj[4] = new SqlParameter("deNghi", deNghi);
            }
            else
            {
                obj[4] = new SqlParameter("deNghi", DBNull.Value);
            }
            var pg = new Pager<TruyThu>(con, "sp_tblBx_TruyThu_Pager_PagerByUserDuyet_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
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
        public string Hint
        {
            get { return string.Format("{0}", Ten); }
        }
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
            return SelectById(DAL.con(), TUYEN_ID);
        }
        public static Tuyen SelectById(SqlConnection con, Int32 TUYEN_ID)
        {
            var Item = new Tuyen();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TUYEN_ID", TUYEN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Tuyen_Select_SelectById_linhnx", obj))
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
        public static Tuyen SelectByDenIdDiId(SqlConnection con, string DenId, string DiId)
        {
            var Item = new Tuyen();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DenId", DenId);
            obj[1] = new SqlParameter("DiId", DiId);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Tuyen_Select_SelectByDenIdDiId_linhnx", obj))
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
        public Int16 NamSanXuat { get; set; }
        public Boolean XeTai { get; set; }
        public Boolean XeVangLai { get; set; }
        public Int32 HanhKhachHopDong { get; set; }
        public Double GiaVe { get; set; }
        public String Anh { get; set; }
        public Int32 CQ_ID { get; set; }
        public String GioXuatBen { get; set; }
        public Boolean ChuaDangKy { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        public Boolean Khoa { get; set; }
        public Int32 BIEUDO_ID { get; set; }
        public DateTime BaoHiem { get; set; }
        public Boolean KyGuiBanVe { get; set; }
        public DateTime NgayKyGuiBanVe { get; set; }
        public Int16 ChapThuanTuyen_SoChuyen { get; set; }
        #endregion
        #region Contructor
        public Xe()
        {
            LaiXe=new LaiXe();
        }
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
        public string BienSoStr
        {
            get { return string.Format("{0} {1}", BienSo_Chu, BienSo_So); }
        }
        public string BienSo { get; set; }
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

        public bool HopLeAll { get; set; }
        public Int16 TrangThai { get; set; }

        public List<LichItem> ListLichItem { get; set; }
        public List<ChamCong> ListChamCong { get; set; }
        public Int32 STT { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XeDal.getFromReader(rd);
        }
    }
    public class XeTiny: BaseEntity
    {
        public string Bien { get; set; }
        public Int64 ID { get; set; }
        public string Hint
        {
            get { return Bien; }
        }
        public string Ten
        {
            get { return Bien; }
        }
        public XeTiny(){}
        public XeTiny(Int64 id, string bien)
        {
            ID = id;
            Bien = bien;
        }
        public XeTiny(IDataReader rd)
        {
            if (rd.FieldExists("XE_ID"))
            {
                ID = (Int64)(rd["XE_ID"]);
            }
            if (rd.FieldExists("XE_BienSo"))
            {
                Bien = (String)(rd["XE_BienSo"]);
            }
        }
        public override BaseEntity getFromReader(IDataReader rd)
        {
            throw new NotImplementedException();
        }
    }
    public class XeTinyDal
    {
        public static List<XeTiny> SearchSQL(string q)
        {
            return SearchSQL(q,null);
        }
        public static List<XeTiny> SearchSQL(string q, string vangLai)
        {
            var List = new List<XeTiny>();
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(q))
            {
                obj[0] = new SqlParameter("q", q);
            }
            else
            {
                obj[0] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(vangLai))
            {
                obj[1] = new SqlParameter("vangLai", vangLai);
            }
            else
            {
                obj[1] = new SqlParameter("vangLai", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SearchSQLTiny_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(new XeTiny(rd));
                }
            }
            return List;
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
            var obj = new SqlParameter[30];
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
            obj[12] = new SqlParameter("XE_NamSanXuat", item.NamSanXuat);
            obj[13] = new SqlParameter("XE_XeTai", item.XeTai);
            obj[14] = new SqlParameter("XE_XeVangLai", item.XeVangLai);
            obj[15] = new SqlParameter("XE_BIEUDO_ID", item.BIEUDO_ID);
            obj[16] = new SqlParameter("XE_HanhKhachHopDong", item.HanhKhachHopDong);
            obj[17] = new SqlParameter("XE_GiaVe", item.GiaVe);
            obj[18] = new SqlParameter("XE_Anh", item.Anh);
            obj[19] = new SqlParameter("XE_CQ_ID", item.CQ_ID);
            obj[20] = new SqlParameter("XE_GioXuatBen", item.GioXuatBen);
            obj[21] = new SqlParameter("XE_ChuaDangKy", item.ChuaDangKy);
            obj[22] = new SqlParameter("XE_RowId", item.RowId);
            obj[23] = new SqlParameter("XE_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("XE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[23] = new SqlParameter("XE_NgayTao", DBNull.Value);
            }
            obj[24] = new SqlParameter("XE_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("XE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[24] = new SqlParameter("XE_NgayCapNhat", DBNull.Value);
            }
            obj[25] = new SqlParameter("XE_Username", item.Username);
            obj[26] = new SqlParameter("XE_Khoa", item.Khoa);
            obj[27] = new SqlParameter("XE_KyGuiBanVe", item.KyGuiBanVe);
            obj[28] = new SqlParameter("XE_NgayKyGuiBanVe", item.NgayKyGuiBanVe);
            if (item.NgayKyGuiBanVe > DateTime.MinValue)
            {
                obj[28] = new SqlParameter("XE_NgayKyGuiBanVe", item.NgayKyGuiBanVe);
            }
            else
            {
                obj[28] = new SqlParameter("XE_NgayKyGuiBanVe", DBNull.Value);
            }
            obj[29] = new SqlParameter("XE_ChapThuanTuyen_SoChuyen", item.ChapThuanTuyen_SoChuyen);

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
            var obj = new SqlParameter[30];
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
            obj[12] = new SqlParameter("XE_NamSanXuat", item.NamSanXuat);
            obj[13] = new SqlParameter("XE_XeTai", item.XeTai);
            obj[14] = new SqlParameter("XE_XeVangLai", item.XeVangLai);
            obj[15] = new SqlParameter("XE_BIEUDO_ID", item.BIEUDO_ID);
            obj[16] = new SqlParameter("XE_HanhKhachHopDong", item.HanhKhachHopDong);
            obj[17] = new SqlParameter("XE_GiaVe", item.GiaVe);
            obj[18] = new SqlParameter("XE_Anh", item.Anh);
            obj[19] = new SqlParameter("XE_CQ_ID", item.CQ_ID);
            obj[20] = new SqlParameter("XE_GioXuatBen", item.GioXuatBen);
            obj[21] = new SqlParameter("XE_ChuaDangKy", item.ChuaDangKy);
            obj[22] = new SqlParameter("XE_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("XE_NgayTao", item.NgayTao);
            }
            else
            {
                obj[23] = new SqlParameter("XE_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("XE_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[24] = new SqlParameter("XE_NgayCapNhat", DBNull.Value);
            }
            obj[25] = new SqlParameter("XE_Username", item.Username);
            obj[26] = new SqlParameter("XE_Khoa", item.Khoa);
            obj[27] = new SqlParameter("XE_KyGuiBanVe", item.KyGuiBanVe);
            if (item.NgayKyGuiBanVe > DateTime.MinValue)
            {
                obj[28] = new SqlParameter("XE_NgayKyGuiBanVe", item.NgayKyGuiBanVe);
            }
            else
            {
                obj[28] = new SqlParameter("XE_NgayKyGuiBanVe", DBNull.Value);
            }
            obj[29] = new SqlParameter("XE_ChapThuanTuyen_SoChuyen", item.ChapThuanTuyen_SoChuyen);

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
            return SelectById(DAL.con(), XE_ID);
        }
        public static Xe SelectById(SqlConnection con, Int64 XE_ID)
        {
            var Item = new Xe();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XE_ID", XE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SelectById_linhnx", obj))
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

        public static XeCollection SelectByTuyenId(Int32 tuyenId)
        {
            var List = new XeCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("tuyenId", tuyenId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SelectByTuyenId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static Pager<Xe> pagerNormal(string url, bool rewrite, string sort, string q, int size
            , string TUYEN_ID, string DONVI_ID, string LOAIXE_ID, string Ghe, string LuuHanh, string TuyenCoDinh, string XeVangLai, string ChuaDangKy)
        {
            var obj = new SqlParameter[10];
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
            if (!string.IsNullOrEmpty(XeVangLai))
            {
                obj[8] = new SqlParameter("XeVangLai", XeVangLai);
            }
            else
            {
                obj[8] = new SqlParameter("XeVangLai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ChuaDangKy))
            {
                obj[9] = new SqlParameter("ChuaDangKy", ChuaDangKy);
            }
            else
            {
                obj[9] = new SqlParameter("ChuaDangKy", DBNull.Value);
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
            if (rd.FieldExists("XE_BienSo"))
            {
                Item.BienSo = (String)(rd["XE_BienSo"]);
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
            if (rd.FieldExists("XE_NamSanXuat"))
            {
                Item.NamSanXuat = (Int16)(rd["XE_NamSanXuat"]);
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
            if(rd.FieldExists("XE_ChuaDangKy")){
			    Item.ChuaDangKy = (Boolean)(rd["XE_ChuaDangKy"]);
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
            if (rd.FieldExists("XE_ChapThuanTuyen_SoChuyen"))
            {
                Item.ChapThuanTuyen_SoChuyen = (Int16)(rd["XE_ChapThuanTuyen_SoChuyen"]);
            }
            if (rd.FieldExists("XE_KyGuiBanVe"))
            {
                Item.KyGuiBanVe = (Boolean)(rd["XE_KyGuiBanVe"]);
            }
            if (rd.FieldExists("XE_NgayKyGuiBanVe"))
            {
                Item.NgayKyGuiBanVe = (DateTime)(rd["XE_NgayKyGuiBanVe"]);
            }
            if (rd.FieldExists("XVB_TrangThai"))
            {
                Item.TrangThai = (Int16)(rd["XVB_TrangThai"]);
            }
            if (rd.FieldExists("XSTT"))
            {
                Item.STT = (Int32)(rd["XSTT"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Xe SelectByBienSo(SqlConnection con, string chu, string so)
        {
            var Item = new Xe();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("chu", chu);
            obj[1] = new SqlParameter("so", so);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SelectByBienSo_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        


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
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SearchSQL_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static List<string> SearchSQLString(string q)
        {
            var List = new List<string>();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(q))
            {
                obj[0] = new SqlParameter("q", q);
            }
            else
            {
                obj[0] = new SqlParameter("q", DBNull.Value);
            }
            var Item = new Xe();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SearchSQL_linhnx", obj))
            {
                while (rd.Read())
                {
                    if (rd.FieldExists("XE_BienSo_Chu"))
                    {
                        Item.BienSo_Chu = (String)(rd["XE_BienSo_Chu"]);
                    }
                    if (rd.FieldExists("XE_BienSo_So"))
                    {
                        Item.BienSo_So = (String)(rd["XE_BienSo_So"]);
                    }
                    List.Add(Item.BienSo);
                }
            }
            return List;
        }

        public static XeCollection WSRVGetAll(string q, int Top)
        {
            var List = new XeCollection();
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(q))
            {
                obj[0] = new SqlParameter("q", q);
            }
            else
            {
                obj[0] = new SqlParameter("q", DBNull.Value);
            }
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_Xe_Select_WSRVGetAll_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static XeCollection ListByTuyen(SqlConnection con,int TuyenId)
        {
            var list = new XeCollection();
            var obj = new SqlParameter[3];
            if (TuyenId>0)
            {
                obj[0] = new SqlParameter("TuyenId", TuyenId);
            }
            else
            {
                obj[0] = new SqlParameter("TuyenId", DBNull.Value);
            }
            

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Xe_Select_ListByTuyen_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static XeCollection SelectByTuyenId(SqlConnection con, int TuyenId)
        {
            var list = new XeCollection();
            var obj = new SqlParameter[3];
            if (TuyenId > 0)
            {
                obj[0] = new SqlParameter("TuyenId", TuyenId);
            }
            else
            {
                obj[0] = new SqlParameter("TuyenId", DBNull.Value);
            }


            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_Xe_Select_SelectByTuyenId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion
    }
    #endregion

    #endregion

    #region XeVaoBen
    #region BO
    public class XeVaoBen : BaseEntity
    {
        #region Properties
       
        /// <summary>
        /// 100: Vào bến; (Ngày vào)
        /// 110: Vào bến xe chưa đăng ký;
        /// 200: Yêu cầu lên phơi; (Ngày yêu cầu lên phơi)
        /// 300: Đang xử lý lên phơi; 
        /// 400: Đã lên phơi; (Ngày xử lý phơi)
        /// 500: Chờ duyệt truy thu
        /// 510: Đã duyệt truy thu (Ngày duyệt)
        /// 600: Yêu cầu thanh toán; (Ngày yêu cầu thanh toán)
        /// 700: Đang thanh toán; 
        /// 800: Thanh toán hoàn tất; (Ngày thanh toán xong)
        /// 810: Đang đăng tài; (Ngày đăng tài)
        /// 820: Xin ra ngoài trả khách
        /// 900: Đã ra cổng (Ngày ra cổng)
        /// </summary>
        public Int16 TrangThai { get; set; }

        public Int64 ID { get; set; }
        public Int64 GIAOCA_ID { get; set; }
        public Int64 STTBX { get; set; }
        public Int64 STTALL { get; set; }
        public Int32 CQ_ID { get; set; }
        public Int64 XE_ID { get; set; }
        public Double Tien { get; set; }
        public DateTime NgayVao { get; set; }
        public DateTime NgayYeuCauXuLy { get; set; }
        public DateTime NgayXuLyYeuCau { get; set; }
        public String NguoiXuLyYeuCau { get; set; }
        public DateTime NgayDuyetPhoi { get; set; }
        public String NguoiDuyetPhoi { get; set; }
        public DateTime NgayLanhDaoDuyetTruyThu { get; set; }
        public String NguoiDuyetTruyThu { get; set; }
        public DateTime NgayYeuCauThanhToan { get; set; }
        public DateTime NgayNhanYeuCauThanhToan { get; set; }
        public String NguoiNhanYeuCauThanhToan { get; set; }
        public DateTime NgayThanhToanXong { get; set; }
        public String NguoiXuLyThanhToan { get; set; }
        public DateTime NgayDangTai { get; set; }
        public DateTime NgayRa { get; set; }
        public Boolean DaRa { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public Int64 PHOI_ID { get; set; }
        public Int64 TC_ID { get; set; }
        public Int64 THUNO_ID { get; set; }
        public Int64 TRUYTHU_ID { get; set; }
        public String Username { get; set; }
       
        /// <summary>
        /// 0: Xe vãng lai. 100: Xe trả khách. 200: Xe cấp lệnh. 300: Xe ảo (Xe không vào nhưng chủ xe vào truy thu)
        /// </summary>
        public Int16 Loai { get; set; }
        public string LoaiStr{get
        {
            switch (Loai)
            {
                case 0:
                    return "Xe vãng lai"; 
                case 100:
                    return "Xe trả khách";
                case 200:
                    return "Xe cấp lệnh";
                case 300:
                    return "Xe ảo (Xe không vào bến, chủ xe vào truy thu)";
                default:
                    return string.Empty;
            }
        }}
        #endregion
        #region Contructor
        public XeVaoBen()
        { }
        #endregion
        #region Customs properties

        public Int64 PHOI_STTBX { get; set; }
        public string PHOI_STTBXStr
        {
            get { return Lib.FormatMa(PHOI_STTBX); }
        }        
        public string STTBXStr
        {
            get { return Lib.FormatMa(STTBX); }
        }
        public string STTALLStr
        {
            get { return Lib.FormatMa(STTALL); }
        }
        public string BienSo { get; set; }
        public int LOAIXE_ID { get; set; }
        public string NguoiDuyetPhoi_Ten { get; set;}
        public string NguoiXuLyThanhToan_Ten { get; set; }
        public string XE_GioXuatBen { get; set; }
        public int XE_GioXuatBenCountDown
        {
            get
            {
                if (string.IsNullOrEmpty(XE_GioXuatBen)) return 0;
                var d = DateTime.Now;
                var arrays = XE_GioXuatBen.Split(new char[] {':'});

                var gioXuatBen = new DateTime(d.Year, d.Month, d.Day, Convert.ToInt32(arrays[0]),
                                              Convert.ToInt32(arrays[1]), 0);
                //return Math.Floor(Convert.ToDecimal((d - gioXuatBen).TotalMinutes));
            }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XeVaoBenDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XeVaoBenCollection : BaseEntityCollection<XeVaoBen>
    { }
    #endregion
    #region Dal
    public class XeVaoBenDal
    {
        #region Methods

        public static void DeleteById(Int64 XVB_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XVB_ID", XVB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Delete_DeleteById_linhnx", obj);
        }

        public static XeVaoBen Insert(XeVaoBen item)
        {
            var Item = new XeVaoBen();
            var obj = new SqlParameter[33];
            obj[1] = new SqlParameter("XVB_GIAOCA_ID", item.GIAOCA_ID);
            obj[2] = new SqlParameter("XVB_STTBX", item.STTBX);
            obj[3] = new SqlParameter("XVB_STTALL", item.STTALL);
            obj[4] = new SqlParameter("XVB_CQ_ID", item.CQ_ID);
            obj[5] = new SqlParameter("XVB_XE_ID", item.XE_ID);
            obj[6] = new SqlParameter("XVB_Tien", item.Tien);
            obj[7] = new SqlParameter("XVB_TrangThai", item.TrangThai);
            obj[8] = new SqlParameter("XVB_NgayVao", item.NgayVao);
            if (item.NgayVao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("XVB_NgayVao", item.NgayVao);
            }
            else
            {
                obj[8] = new SqlParameter("XVB_NgayVao", DBNull.Value);
            }
            obj[9] = new SqlParameter("XVB_NgayYeuCauXuLy", item.NgayYeuCauXuLy);
            if (item.NgayYeuCauXuLy > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("XVB_NgayYeuCauXuLy", item.NgayYeuCauXuLy);
            }
            else
            {
                obj[9] = new SqlParameter("XVB_NgayYeuCauXuLy", DBNull.Value);
            }
            obj[10] = new SqlParameter("XVB_NgayXuLyYeuCau", item.NgayXuLyYeuCau);
            if (item.NgayXuLyYeuCau > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("XVB_NgayXuLyYeuCau", item.NgayXuLyYeuCau);
            }
            else
            {
                obj[10] = new SqlParameter("XVB_NgayXuLyYeuCau", DBNull.Value);
            }
            obj[11] = new SqlParameter("XVB_NguoiXuLyYeuCau", item.NguoiXuLyYeuCau);
            obj[12] = new SqlParameter("XVB_NgayDuyetPhoi", item.NgayDuyetPhoi);
            if (item.NgayDuyetPhoi > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("XVB_NgayDuyetPhoi", item.NgayDuyetPhoi);
            }
            else
            {
                obj[12] = new SqlParameter("XVB_NgayDuyetPhoi", DBNull.Value);
            }
            obj[13] = new SqlParameter("XVB_NguoiDuyetPhoi", item.NguoiDuyetPhoi);
            obj[14] = new SqlParameter("XVB_NgayLanhDaoDuyetTruyThu", item.NgayLanhDaoDuyetTruyThu);
            if (item.NgayLanhDaoDuyetTruyThu > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("XVB_NgayLanhDaoDuyetTruyThu", item.NgayLanhDaoDuyetTruyThu);
            }
            else
            {
                obj[14] = new SqlParameter("XVB_NgayLanhDaoDuyetTruyThu", DBNull.Value);
            }
            obj[15] = new SqlParameter("XVB_NguoiDuyetTruyThu", item.NguoiDuyetTruyThu);
            obj[16] = new SqlParameter("XVB_NgayYeuCauThanhToan", item.NgayYeuCauThanhToan);
            if (item.NgayYeuCauThanhToan > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("XVB_NgayYeuCauThanhToan", item.NgayYeuCauThanhToan);
            }
            else
            {
                obj[16] = new SqlParameter("XVB_NgayYeuCauThanhToan", DBNull.Value);
            }
            obj[17] = new SqlParameter("XVB_NgayNhanYeuCauThanhToan", item.NgayNhanYeuCauThanhToan);
            if (item.NgayNhanYeuCauThanhToan > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("XVB_NgayNhanYeuCauThanhToan", item.NgayNhanYeuCauThanhToan);
            }
            else
            {
                obj[17] = new SqlParameter("XVB_NgayNhanYeuCauThanhToan", DBNull.Value);
            }
            obj[18] = new SqlParameter("XVB_NguoiNhanYeuCauThanhToan", item.NguoiNhanYeuCauThanhToan);
            obj[19] = new SqlParameter("XVB_NgayThanhToanXong", item.NgayThanhToanXong);
            if (item.NgayThanhToanXong > DateTime.MinValue)
            {
                obj[19] = new SqlParameter("XVB_NgayThanhToanXong", item.NgayThanhToanXong);
            }
            else
            {
                obj[19] = new SqlParameter("XVB_NgayThanhToanXong", DBNull.Value);
            }
            obj[20] = new SqlParameter("XVB_NguoiXuLyThanhToan", item.NguoiXuLyThanhToan);
            obj[21] = new SqlParameter("XVB_NgayDangTai", item.NgayDangTai);
            if (item.NgayDangTai > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("XVB_NgayDangTai", item.NgayDangTai);
            }
            else
            {
                obj[21] = new SqlParameter("XVB_NgayDangTai", DBNull.Value);
            }
            obj[22] = new SqlParameter("XVB_NgayRa", item.NgayRa);
            if (item.NgayRa > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("XVB_NgayRa", item.NgayRa);
            }
            else
            {
                obj[22] = new SqlParameter("XVB_NgayRa", DBNull.Value);
            }
            obj[23] = new SqlParameter("XVB_DaRa", item.DaRa);
            obj[24] = new SqlParameter("XVB_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("XVB_NgayTao", item.NgayTao);
            }
            else
            {
                obj[24] = new SqlParameter("XVB_NgayTao", DBNull.Value);
            }
            obj[25] = new SqlParameter("XVB_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[25] = new SqlParameter("XVB_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[25] = new SqlParameter("XVB_NgayCapNhat", DBNull.Value);
            }
            obj[26] = new SqlParameter("XVB_RowId", item.RowId);
            obj[27] = new SqlParameter("XVB_PHOI_ID", item.PHOI_ID);
            obj[28] = new SqlParameter("XVB_TC_ID", item.TC_ID);
            obj[29] = new SqlParameter("XVB_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[30] = new SqlParameter("XVB_THUNO_ID", item.THUNO_ID);
            obj[31] = new SqlParameter("XVB_Username", item.Username);
            obj[32] = new SqlParameter("XVB_Loai", item.Loai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XeVaoBen Update(XeVaoBen item)
        {
            var Item = new XeVaoBen();
            var obj = new SqlParameter[33];
            obj[0] = new SqlParameter("XVB_ID", item.ID);
            obj[1] = new SqlParameter("XVB_GIAOCA_ID", item.GIAOCA_ID);
            obj[2] = new SqlParameter("XVB_STTBX", item.STTBX);
            obj[3] = new SqlParameter("XVB_STTALL", item.STTALL);
            obj[4] = new SqlParameter("XVB_CQ_ID", item.CQ_ID);
            obj[5] = new SqlParameter("XVB_XE_ID", item.XE_ID);
            obj[6] = new SqlParameter("XVB_Tien", item.Tien);
            obj[7] = new SqlParameter("XVB_TrangThai", item.TrangThai);
            if (item.NgayVao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("XVB_NgayVao", item.NgayVao);
            }
            else
            {
                obj[8] = new SqlParameter("XVB_NgayVao", DBNull.Value);
            }
            if (item.NgayYeuCauXuLy > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("XVB_NgayYeuCauXuLy", item.NgayYeuCauXuLy);
            }
            else
            {
                obj[9] = new SqlParameter("XVB_NgayYeuCauXuLy", DBNull.Value);
            }
            if (item.NgayXuLyYeuCau > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("XVB_NgayXuLyYeuCau", item.NgayXuLyYeuCau);
            }
            else
            {
                obj[10] = new SqlParameter("XVB_NgayXuLyYeuCau", DBNull.Value);
            }
            obj[11] = new SqlParameter("XVB_NguoiXuLyYeuCau", item.NguoiXuLyYeuCau);
            if (item.NgayDuyetPhoi > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("XVB_NgayDuyetPhoi", item.NgayDuyetPhoi);
            }
            else
            {
                obj[12] = new SqlParameter("XVB_NgayDuyetPhoi", DBNull.Value);
            }
            obj[13] = new SqlParameter("XVB_NguoiDuyetPhoi", item.NguoiDuyetPhoi);
            if (item.NgayLanhDaoDuyetTruyThu > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("XVB_NgayLanhDaoDuyetTruyThu", item.NgayLanhDaoDuyetTruyThu);
            }
            else
            {
                obj[14] = new SqlParameter("XVB_NgayLanhDaoDuyetTruyThu", DBNull.Value);
            }
            obj[15] = new SqlParameter("XVB_NguoiDuyetTruyThu", item.NguoiDuyetTruyThu);
            if (item.NgayYeuCauThanhToan > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("XVB_NgayYeuCauThanhToan", item.NgayYeuCauThanhToan);
            }
            else
            {
                obj[16] = new SqlParameter("XVB_NgayYeuCauThanhToan", DBNull.Value);
            }
            if (item.NgayNhanYeuCauThanhToan > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("XVB_NgayNhanYeuCauThanhToan", item.NgayNhanYeuCauThanhToan);
            }
            else
            {
                obj[17] = new SqlParameter("XVB_NgayNhanYeuCauThanhToan", DBNull.Value);
            }
            obj[18] = new SqlParameter("XVB_NguoiNhanYeuCauThanhToan", item.NguoiNhanYeuCauThanhToan);
            if (item.NgayThanhToanXong > DateTime.MinValue)
            {
                obj[19] = new SqlParameter("XVB_NgayThanhToanXong", item.NgayThanhToanXong);
            }
            else
            {
                obj[19] = new SqlParameter("XVB_NgayThanhToanXong", DBNull.Value);
            }
            obj[20] = new SqlParameter("XVB_NguoiXuLyThanhToan", item.NguoiXuLyThanhToan);
            if (item.NgayDangTai > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("XVB_NgayDangTai", item.NgayDangTai);
            }
            else
            {
                obj[21] = new SqlParameter("XVB_NgayDangTai", DBNull.Value);
            }
            if (item.NgayRa > DateTime.MinValue)
            {
                obj[22] = new SqlParameter("XVB_NgayRa", item.NgayRa);
            }
            else
            {
                obj[22] = new SqlParameter("XVB_NgayRa", DBNull.Value);
            }
            obj[23] = new SqlParameter("XVB_DaRa", item.DaRa);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("XVB_NgayTao", item.NgayTao);
            }
            else
            {
                obj[24] = new SqlParameter("XVB_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[25] = new SqlParameter("XVB_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[25] = new SqlParameter("XVB_NgayCapNhat", DBNull.Value);
            }
            obj[26] = new SqlParameter("XVB_RowId", item.RowId);
            obj[27] = new SqlParameter("XVB_PHOI_ID", item.PHOI_ID);
            obj[28] = new SqlParameter("XVB_TC_ID", item.TC_ID);
            obj[29] = new SqlParameter("XVB_TRUYTHU_ID", item.TRUYTHU_ID);
            obj[30] = new SqlParameter("XVB_THUNO_ID", item.THUNO_ID);
            obj[31] = new SqlParameter("XVB_Username", item.Username);
            obj[32] = new SqlParameter("XVB_Loai", item.Loai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XeVaoBen SelectById(Int64 XVB_ID)
        {
            var Item = new XeVaoBen();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XVB_ID", XVB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XeVaoBenCollection SelectAll()
        {
            var List = new XeVaoBenCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<XeVaoBen> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<XeVaoBen>("sp_tblBx_XeVaoBen_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static XeVaoBen getFromReader(IDataReader rd)
        {
            var Item = new XeVaoBen();
            if (rd.FieldExists("XVB_ID"))
            {
                Item.ID = (Int64)(rd["XVB_ID"]);
            }
            if (rd.FieldExists("XVB_GIAOCA_ID"))
            {
                Item.GIAOCA_ID = (Int64)(rd["XVB_GIAOCA_ID"]);
            }
            if (rd.FieldExists("XVB_STTBX"))
            {
                Item.STTBX = (Int64)(rd["XVB_STTBX"]);
            }
            if (rd.FieldExists("XVB_STTALL"))
            {
                Item.STTALL = (Int64)(rd["XVB_STTALL"]);
            }
            if (rd.FieldExists("XVB_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["XVB_CQ_ID"]);
            }
            if (rd.FieldExists("XVB_XE_ID"))
            {
                Item.XE_ID = (Int64)(rd["XVB_XE_ID"]);
            }
            if (rd.FieldExists("XVB_Tien"))
            {
                Item.Tien = (Double)(rd["XVB_Tien"]);
            }
            if (rd.FieldExists("XVB_TrangThai"))
            {
                Item.TrangThai = (Int16)(rd["XVB_TrangThai"]);
            }
            if (rd.FieldExists("XVB_NgayVao"))
            {
                Item.NgayVao = (DateTime)(rd["XVB_NgayVao"]);
            }
            if (rd.FieldExists("XVB_NgayYeuCauXuLy"))
            {
                Item.NgayYeuCauXuLy = (DateTime)(rd["XVB_NgayYeuCauXuLy"]);
            }
            if (rd.FieldExists("XVB_NguoiXuLyYeuCau"))
            {
                Item.NguoiXuLyYeuCau = (String)(rd["XVB_NguoiXuLyYeuCau"]);
            }
            if (rd.FieldExists("XVB_NgayXuLyYeuCau"))
            {
                Item.NgayXuLyYeuCau = (DateTime)(rd["XVB_NgayXuLyYeuCau"]);
            }

            if (rd.FieldExists("XVB_NgayDuyetPhoi"))
            {
                Item.NgayDuyetPhoi = (DateTime)(rd["XVB_NgayDuyetPhoi"]);
            }
          
            if (rd.FieldExists("XVB_NguoiDuyetPhoi"))
            {
                Item.NguoiDuyetPhoi = (String)(rd["XVB_NguoiDuyetPhoi"]);
            }
            if (rd.FieldExists("XVB_NgayLanhDaoDuyetTruyThu"))
            {
                Item.NgayLanhDaoDuyetTruyThu = (DateTime)(rd["XVB_NgayLanhDaoDuyetTruyThu"]);
            }
            if (rd.FieldExists("XVB_NguoiDuyetTruyThu"))
            {
                Item.NguoiDuyetTruyThu = (String)(rd["XVB_NguoiDuyetTruyThu"]);
            }
            if (rd.FieldExists("XVB_NgayYeuCauThanhToan"))
            {
                Item.NgayYeuCauThanhToan = (DateTime)(rd["XVB_NgayYeuCauThanhToan"]);
            }
            if (rd.FieldExists("XVB_NgayNhanYeuCauThanhToan"))
            {
                Item.NgayNhanYeuCauThanhToan = (DateTime)(rd["XVB_NgayNhanYeuCauThanhToan"]);
            }
            if (rd.FieldExists("XVB_NguoiNhanYeuCauThanhToan"))
            {
                Item.NguoiNhanYeuCauThanhToan = (String)(rd["XVB_NguoiNhanYeuCauThanhToan"]);
            }
            if (rd.FieldExists("XVB_NgayThanhToanXong"))
            {
                Item.NgayThanhToanXong = (DateTime)(rd["XVB_NgayThanhToanXong"]);
            }
            if (rd.FieldExists("XVB_NguoiXuLyThanhToan"))
            {
                Item.NguoiXuLyThanhToan = (String)(rd["XVB_NguoiXuLyThanhToan"]);
            }
            if (rd.FieldExists("XVB_NgayDangTai"))
            {
                Item.NgayDangTai = (DateTime)(rd["XVB_NgayDangTai"]);
            }
            if (rd.FieldExists("XVB_NgayRa"))
            {
                Item.NgayRa = (DateTime)(rd["XVB_NgayRa"]);
            }
            if (rd.FieldExists("XVB_DaRa"))
            {
                Item.DaRa = (Boolean)(rd["XVB_DaRa"]);
            }
           
            if (rd.FieldExists("XVB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["XVB_NgayTao"]);
            }
            if (rd.FieldExists("XVB_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["XVB_NgayCapNhat"]);
            }
            if (rd.FieldExists("XVB_RowId"))
            {
                Item.RowId = (Guid)(rd["XVB_RowId"]);
            }
            if (rd.FieldExists("XVB_PHOI_ID"))
            {
                Item.PHOI_ID = (Int64)(rd["XVB_PHOI_ID"]);
            }
            if (rd.FieldExists("XVB_TC_ID"))
            {
                Item.TC_ID = (Int64)(rd["XVB_TC_ID"]);
            }
            if (rd.FieldExists("XVB_TRUYTHU_ID"))
            {
                Item.TRUYTHU_ID = (Int64)(rd["XVB_TRUYTHU_ID"]);
            }
            if (rd.FieldExists("XVB_Username"))
            {
                Item.Username = (String)(rd["XVB_Username"]);
            }
           
            if (rd.FieldExists("XE_BienSo"))
            {
                Item.BienSo = (String)(rd["XE_BienSo"]);
            }
            if (rd.FieldExists("XVB_PHOI_ID"))
            {
                Item.PHOI_ID = (Int64)(rd["XVB_PHOI_ID"]);
            }
            if (rd.FieldExists("XVB_TC_ID"))
            {
                Item.TC_ID = (Int64)(rd["XVB_TC_ID"]);
            }
            if (rd.FieldExists("XVB_THUNO_ID"))
            {
                Item.THUNO_ID = (Int64)(rd["XVB_THUNO_ID"]);
            }
            if (rd.FieldExists("XVB_Loai"))
            {
                Item.Loai = (Int16)(rd["XVB_Loai"]);
            }
            if (rd.FieldExists("XE_LOAIXE_ID"))
            {
                Item.LOAIXE_ID = (Int32)(rd["XE_LOAIXE_ID"]);
            }

            if (rd.FieldExists("NguoiDuyetPhoi_Ten"))
            {
                Item.NguoiDuyetPhoi_Ten = (String)(rd["NguoiDuyetPhoi_Ten"]);
            }
            if (rd.FieldExists("NguoiXuLyThanhToan_Ten"))
            {
                Item.NguoiXuLyThanhToan_Ten = (String)(rd["NguoiXuLyThanhToan_Ten"]);
            }
            if (rd.FieldExists("XE_GioXuatBen"))
            {
                Item.XE_GioXuatBen = (String)(rd["XE_GioXuatBen"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static XeVaoBen SelectLastest(Int32 CQ_ID)
        {
            var Item = new XeVaoBen();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_SelectLastest_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static XeVaoBen SelectByPhoiId(SqlConnection con, Int64 PHOI_ID)
        {
            var Item = new XeVaoBen();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PHOI_ID", PHOI_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_SelectByPhoiId_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        /// <summary>
        /// Lấy về danh sách XeVaoBen theo CqId, trangThai
        /// </summary>
        /// <param name="con">SqlConnection</param>
        /// <param name="CqId">Mã cơ quan</param>
        /// <param name="trangThai">trạng thái</param>
        /// <param name="top">số lượng</param>
        /// <returns></returns>
        public static XeVaoBenCollection ListByTrangThaiCqId(SqlConnection con, int CqId, Int16 trangThai, long top)
        {
            return ListByTrangThaiCqId(con, CqId, trangThai, top, 0);
        }
        /// <summary>
        /// Lấy danh sách XeVaoBen theo CqId, trangThai, loai
        /// </summary>
        /// <param name="con">Sqlconnection</param>
        /// <param name="CqId">Mã cơ quan</param>
        /// <param name="trangThai">Trạng thái</param>
        /// <param name="top">Số lượng</param>
        /// <param name="loai">Loại xe vào bến</param>
        /// <returns></returns>
        public static XeVaoBenCollection ListByTrangThaiCqId(SqlConnection con, int CqId, Int16 trangThai, long top, int loai)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("CqId", CqId);
            if (trangThai > 0)
            {
                obj[1] = new SqlParameter("trangThai", trangThai);
            }
            else
            {
                obj[1] = new SqlParameter("trangThai", DBNull.Value);
            }
            if (top > 0)
            {
                obj[2] = new SqlParameter("top", top);
            }
            else
            {
                obj[2] = new SqlParameter("top", DBNull.Value);
            }
            if (loai > 0)
            {
                obj[3] = new SqlParameter("loai", loai);
            }
            else
            {
                obj[3] = new SqlParameter("loai", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListByTrangThaiUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static XeVaoBenCollection ListByCurrentCapPhoiByUser(SqlConnection con, int CqId, string username)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CqId", CqId);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListByCurrentCapPhoiByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static XeVaoBenCollection ListByCurrentThuCapPhoiByUser(SqlConnection con, int CqId, string username)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CqId", CqId);
            if (!string.IsNullOrEmpty(username))
            {
                obj[1] = new SqlParameter("username", username);
            }
            else
            {
                obj[1] = new SqlParameter("username", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListByCurrentThuCapPhoiByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static XeVaoBenCollection ListTsLenPhoi(SqlConnection con, int CqId
            , long top)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("CqId", CqId);
            if (top > 0)
            {
                obj[2] = new SqlParameter("top", top);
            }
            else
            {
                obj[2] = new SqlParameter("top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListTsLenPhoi_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static XeVaoBenCollection ListTruyThu(SqlConnection con, int CqId
           , long top)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("CqId", CqId);
            if (top > 0)
            {
                obj[2] = new SqlParameter("top", top);
            }
            else
            {
                obj[2] = new SqlParameter("top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListTruyThu_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static XeVaoBenCollection ListTsChoThanhToan(SqlConnection con, int CqId
            , long top)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("CqId", CqId);
            if (top > 0)
            {
                obj[2] = new SqlParameter("top", top);
            }
            else
            {
                obj[2] = new SqlParameter("top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListTsChoThanhToan_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static XeVaoBenCollection ListTsDaThanhToan(SqlConnection con, int CqId
            , long top)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("CqId", CqId);
            if (top > 0)
            {
                obj[2] = new SqlParameter("top", top);
            }
            else
            {
                obj[2] = new SqlParameter("top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListTsDaThanhToan_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }


        public static List<XeVaoBen> ListXeRaCongByCqId(SqlConnection con, int CqId)
        {
            var list = new XeVaoBenCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CqId", CqId);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Select_ListXeRaCongByCqId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static void UpdateTrangThai(Int16 TrangThai, Int64 XE_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Id", XE_ID);
            obj[1] = new SqlParameter("TrangThai", TrangThai);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Update_UpdateTrangThai_linhnx", obj);
        }

        /// <summary>
        /// Trang thai: 200 > 300
        /// </summary>
        /// <param name="XE_ID"></param>
        public static void UpdateNhanXuLy(Int64 XE_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Id", XE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Update_UpdateNhanXuLy_linhnx", obj);
        }

        /// <summary>
        /// Trang thai: 300 > 400
        /// </summary>
        /// <param name="XE_ID"></param>
        public static void UpdateXeDaXuLy(Int64 XE_ID, Int64 PHOI_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Id", XE_ID);
            obj[1] = new SqlParameter("PHOI_ID", PHOI_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Update_UpdateXeDaXuLy_linhnx", obj);
        }
        /// <summary>
        /// Trang thai: 110 > 100
        /// </summary>
        /// <param name="XE_ID"></param>
        public static void UpdateXeChuaDangKy(Int64 XE_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Id", XE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Update_XeChuaDangKy_linhnx", obj);
        }

        /// <summary>
        /// Trang thai: 400 > 600
        /// </summary>
        /// <param name="XE_ID"></param>
        public static void UpdateYeuCauThanhToan(Int64 XE_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Id", XE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_XeVaoBen_Update_UpdateYeuCauThanhToan_linhnx", obj);
        }
        #endregion
    }
    #endregion

    #endregion

    #region ThuNo
    #region BO
    public class ThuNo : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public Int64 GIAOCA_ID { get; set; }
        public Int64 XE_ID { get; set; }
        public Int64 STTBX { get; set; }
        public Int64 STTALL { get; set; }
        public Double Tien { get; set; }
        public DateTime Ngay { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public Boolean DaThu { get; set; }
        public DateTime NgayThu { get; set; }
        public String NguoiThu { get; set; }
        #endregion
        #region Contructor
        public ThuNo()
        { }
        #endregion
        #region Customs properties

        public string XE_BienSo { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuNoDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuNoCollection : BaseEntityCollection<ThuNo>
    { }
    #endregion
    #region Dal
    public class ThuNoDal
    {
        #region Methods

        public static void DeleteById(Int64 THUNO_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("THUNO_ID", THUNO_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNo_Delete_DeleteById_linhnx", obj);
        }

        public static ThuNo Insert(ThuNo item)
        {
            var Item = new ThuNo();
            var obj = new SqlParameter[16];
            obj[1] = new SqlParameter("THuNO_GIAOCA_ID", item.GIAOCA_ID);
            obj[2] = new SqlParameter("THUNO_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("THUNO_STTBX", item.STTBX);
            obj[4] = new SqlParameter("THUNO_STTALL", item.STTALL);
            obj[5] = new SqlParameter("THUNO_XE_ID", item.XE_ID);
            obj[6] = new SqlParameter("THUNO_Tien", item.Tien);
            obj[7] = new SqlParameter("THUNO_Ngay", item.Ngay);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("THUNO_Ngay", item.Ngay);
            }
            else
            {
                obj[7] = new SqlParameter("THUNO_Ngay", DBNull.Value);
            }
            obj[8] = new SqlParameter("THUNO_NguoiTao", item.NguoiTao);
            obj[9] = new SqlParameter("THUNO_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("THUNO_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("THUNO_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("THUNO_NguoiCapNhat", item.NguoiCapNhat);
            obj[11] = new SqlParameter("THUNO_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("THUNO_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("THUNO_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("THUNO_RowId", item.RowId);
            obj[13] = new SqlParameter("THUNO_DaThu", item.DaThu);
            obj[14] = new SqlParameter("THUNO_NgayThu", item.NgayThu);
            if (item.NgayThu > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("THUNO_NgayThu", item.NgayThu);
            }
            else
            {
                obj[14] = new SqlParameter("THUNO_NgayThu", DBNull.Value);
            }
            obj[15] = new SqlParameter("THUNO_NguoiThu", item.NguoiThu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNo_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuNo Update(ThuNo item)
        {
            var Item = new ThuNo();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("THUNO_ID", item.ID);
            obj[1] = new SqlParameter("THuNO_GIAOCA_ID", item.GIAOCA_ID);
            obj[2] = new SqlParameter("THUNO_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("THUNO_STTBX", item.STTBX);
            obj[4] = new SqlParameter("THUNO_STTALL", item.STTALL);
            obj[5] = new SqlParameter("THUNO_XE_ID", item.XE_ID);
            obj[6] = new SqlParameter("THUNO_Tien", item.Tien);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("THUNO_Ngay", item.Ngay);
            }
            else
            {
                obj[7] = new SqlParameter("THUNO_Ngay", DBNull.Value);
            }
            obj[8] = new SqlParameter("THUNO_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("THUNO_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("THUNO_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("THUNO_NguoiCapNhat", item.NguoiCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("THUNO_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("THUNO_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("THUNO_RowId", item.RowId);
            obj[13] = new SqlParameter("THUNO_DaThu", item.DaThu);
            if (item.NgayThu > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("THUNO_NgayThu", item.NgayThu);
            }
            else
            {
                obj[14] = new SqlParameter("THUNO_NgayThu", DBNull.Value);
            }
            obj[15] = new SqlParameter("THUNO_NguoiThu", item.NguoiThu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNo_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuNo SelectById(Int64 THUNO_ID)
        {
            return SelectById(DAL.con(),THUNO_ID);
        }
        public static ThuNo SelectLastest(Int32 CQ_ID)
        {
            var Item = new ThuNo();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNo_Select_SelectLastest_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuNo SelectById(SqlConnection con, Int64 THUNO_ID)
        {
            var Item = new ThuNo();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("THUNO_ID", THUNO_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ThuNo_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuNoCollection SelectAll()
        {
            var List = new ThuNoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNo_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuNo> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<ThuNo>("sp_tblBx_ThuNo_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ThuNo getFromReader(IDataReader rd)
        {
            var Item = new ThuNo();
            if (rd.FieldExists("THUNO_ID"))
            {
                Item.ID = (Int64)(rd["THUNO_ID"]);
            }
            if (rd.FieldExists("THuNO_GIAOCA_ID"))
            {
                Item.GIAOCA_ID = (Int64)(rd["THuNO_GIAOCA_ID"]);
            }
            if (rd.FieldExists("THUNO_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["THUNO_CQ_ID"]);
            }
            if (rd.FieldExists("THUNO_STTBX"))
            {
                Item.STTBX = (Int64)(rd["THUNO_STTBX"]);
            }
            if (rd.FieldExists("THUNO_STTALL"))
            {
                Item.STTALL = (Int64)(rd["THUNO_STTALL"]);
            }
            if (rd.FieldExists("THUNO_XE_ID"))
            {
                Item.XE_ID = (Int64)(rd["THUNO_XE_ID"]);
            }
            if (rd.FieldExists("THUNO_Tien"))
            {
                Item.Tien = (Double)(rd["THUNO_Tien"]);
            }
            if (rd.FieldExists("THUNO_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["THUNO_Ngay"]);
            }
            if (rd.FieldExists("THUNO_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["THUNO_NguoiTao"]);
            }
            if (rd.FieldExists("THUNO_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["THUNO_NgayTao"]);
            }
            if (rd.FieldExists("THUNO_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["THUNO_NguoiCapNhat"]);
            }
            if (rd.FieldExists("THUNO_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["THUNO_NgayCapNhat"]);
            }
            if (rd.FieldExists("THUNO_RowId"))
            {
                Item.RowId = (Guid)(rd["THUNO_RowId"]);
            }
            if (rd.FieldExists("THUNO_DaThu"))
            {
                Item.DaThu = (Boolean)(rd["THUNO_DaThu"]);
            }
            if (rd.FieldExists("THUNO_NgayThu"))
            {
                Item.NgayThu = (DateTime)(rd["THUNO_NgayThu"]);
            }
            if (rd.FieldExists("THUNO_NguoiThu"))
            {
                Item.NguoiThu = (String)(rd["THUNO_NguoiThu"]);
            }

            if (rd.FieldExists("XE_BienSo"))
            {
                Item.XE_BienSo = (String)(rd["XE_BienSo"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static ThuNo SelectByLastest(SqlConnection con, Int32 CQ_ID)
        {
            var Item = new ThuNo();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBx_ThuNo_Select_SelectByLastest_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Pager<ThuNo> PagerByCqId(string url, bool rewrite, string sort, string q, int size, int CqId, string daThu)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(daThu))
            {
                obj[1] = new SqlParameter("daThu", daThu);
            }
            else
            {
                obj[1] = new SqlParameter("daThu", DBNull.Value);
            }
            if (CqId>0)
            {
                obj[1] = new SqlParameter("CqId", CqId);
            }
            else
            {
                obj[1] = new SqlParameter("CqId", DBNull.Value);
            }

            var pg = new Pager<ThuNo>("sp_tblBx_ThuNo_Pager_pagerByCqId_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion

    #region ThuNoChiTiet
    #region BO
    public class ThuNoChiTiet : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 THUNO_ID { get; set; }
        public Int64 CONG_ID { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean DaThu { get; set; }
        public DateTime NgayThu { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiThu { get; set; }
        #endregion
        #region Contructor
        public ThuNoChiTiet()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuNoChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuNoChiTietCollection : BaseEntityCollection<ThuNoChiTiet>
    { }
    #endregion
    #region Dal
    public class ThuNoChiTietDal
    {
        #region Methods

        public static void DeleteById(Int64 TNCT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TNCT_ID", TNCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNoChiTiet_Delete_DeleteById_linhnx", obj);
        }

        public static ThuNoChiTiet Insert(ThuNoChiTiet item)
        {
            var Item = new ThuNoChiTiet();
            var obj = new SqlParameter[9];
            obj[1] = new SqlParameter("TNCT_THUNO_ID", item.THUNO_ID);
            obj[2] = new SqlParameter("TNCT_CONG_ID", item.CONG_ID);
            obj[3] = new SqlParameter("TNCT_NgayTao", item.NgayTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("TNCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("TNCT_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("TNCT_DaThu", item.DaThu);
            obj[5] = new SqlParameter("TNCT_NgayThu", item.NgayThu);
            if (item.NgayThu > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("TNCT_NgayThu", item.NgayThu);
            }
            else
            {
                obj[5] = new SqlParameter("TNCT_NgayThu", DBNull.Value);
            }
            obj[6] = new SqlParameter("TNCT_NguoiTao", item.NguoiTao);
            obj[7] = new SqlParameter("TNCT_NgayCapNhat", item.NgayCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TNCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("TNCT_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("TNCT_NguoiThu", item.NguoiThu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNoChiTiet_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuNoChiTiet Update(ThuNoChiTiet item)
        {
            var Item = new ThuNoChiTiet();
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("TNCT_ID", item.ID);
            obj[1] = new SqlParameter("TNCT_THUNO_ID", item.THUNO_ID);
            obj[2] = new SqlParameter("TNCT_CONG_ID", item.CONG_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("TNCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("TNCT_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("TNCT_DaThu", item.DaThu);
            if (item.NgayThu > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("TNCT_NgayThu", item.NgayThu);
            }
            else
            {
                obj[5] = new SqlParameter("TNCT_NgayThu", DBNull.Value);
            }
            obj[6] = new SqlParameter("TNCT_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TNCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("TNCT_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("TNCT_NguoiThu", item.NguoiThu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNoChiTiet_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuNoChiTiet SelectById(Int64 TNCT_ID)
        {
            var Item = new ThuNoChiTiet();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TNCT_ID", TNCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNoChiTiet_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuNoChiTietCollection SelectAll()
        {
            var List = new ThuNoChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNoChiTiet_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuNoChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<ThuNoChiTiet>("sp_tblBx_ThuNoChiTiet_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ThuNoChiTiet getFromReader(IDataReader rd)
        {
            var Item = new ThuNoChiTiet();
            if (rd.FieldExists("TNCT_ID"))
            {
                Item.ID = (Int64)(rd["TNCT_ID"]);
            }
            if (rd.FieldExists("TNCT_THUNO_ID"))
            {
                Item.THUNO_ID = (Int64)(rd["TNCT_THUNO_ID"]);
            }
            if (rd.FieldExists("TNCT_CONG_ID"))
            {
                Item.CONG_ID = (Int64)(rd["TNCT_CONG_ID"]);
            }
            if (rd.FieldExists("TNCT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TNCT_NgayTao"]);
            }
            if (rd.FieldExists("TNCT_DaThu"))
            {
                Item.DaThu = (Boolean)(rd["TNCT_DaThu"]);
            }
            if (rd.FieldExists("TNCT_NgayThu"))
            {
                Item.NgayThu = (DateTime)(rd["TNCT_NgayThu"]);
            }
            if (rd.FieldExists("TNCT_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TNCT_NguoiTao"]);
            }
            if (rd.FieldExists("TNCT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TNCT_NgayCapNhat"]);
            }
            if (rd.FieldExists("TNCT_NguoiThu"))
            {
                Item.NguoiThu = (String)(rd["TNCT_NguoiThu"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteByThuNoId(Int64 ThuNoId)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ThuNoId", ThuNoId);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNoChiTiet_Delete_DeleteByThuNoId_linhnx", obj);
        }
        public static ThuNoChiTietCollection SelectByThuNoId(Int64 ThuNoId)
        {
            var List = new ThuNoChiTietCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ThuNoId", ThuNoId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBx_ThuNoChiTiet_Select_SelectByThuNoId_linhnx", obj))
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
