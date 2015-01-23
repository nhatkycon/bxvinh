using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using docsoft.entities;
using linh.common;

public partial class lib_ui_Phoi_ChamCongCalendar_TuNgayDenNgay : System.Web.UI.UserControl
{
    /// <summary>
    /// Phơi
    /// </summary>
    public Phoi Item { get; set; }
    /// <summary>
    /// Loại biểu đồ của xe
    /// </summary>
    public LoaiBieuDo LoaiBieuDo { get; set; }
    /// <summary>
    /// Danh sách chấm công trước khi tạo phơi này
    /// </summary>
    public List<ChamCong> ListChamCong { get; set; }
    /// <summary>
    /// Danh sách chấm công đã tạo bởi phơi này, trong trường hợp chỉnh sửa phơi
    /// </summary>
    public List<ChamCong> ListChamCongCurrent { get; set; }
    /// <summary>
    /// Tháng trước
    /// </summary>
    public List<LichItem> PrevMonth { get; set; }
    /// <summary>
    /// Tháng này
    /// </summary>
    public List<LichItem> CurrentMonth { get; set; }
    /// <summary>
    /// Danh sách tháng
    /// </summary>
    public List<ListThang> Thangs { get; set; }
    /// <summary>
    /// Số chuyến chấm công còn nợ
    /// </summary>
    public int SoChuyenNo { get; set; }
    public int PrevMonthLabel { get; set; }
    public int CurrentMonthLabel { get; set; }

    /// <summary>
    /// Ngày xuất bến dạng string
    /// </summary>
    public string NgayXuatBen { get; set; }
    /// <summary>
    /// Ngày xuất bến dạng Datetime
    /// </summary>
    public DateTime Today { get; set; }

    public DateTime TuNgay { get; set; }
    public DateTime DenNgay { get; set; }
    /// <summary>
    /// Hiển thị đầy đủ lịch
    /// </summary>
    public bool ShowFullMonth { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ListChamCong == null || ListChamCongCurrent == null) return;
        ListChamCong = ListChamCong;
        Today = string.IsNullOrEmpty(NgayXuatBen)
                    ? DateTime.Now
                    : Convert.ToDateTime(NgayXuatBen, new CultureInfo("Vi-vn"));

        SoChuyenNo = ListChamCong.Count(x => x.TrangThaiNo == 1);
        if (ListChamCong.Any() && !ShowFullMonth)
        {
            TuNgay = ListChamCong.Last().Ngay;
        }

        var tuNgayDauThang = new DateTime(TuNgay.Year, TuNgay.Month, 1);
        var denNgayCuoiThang = new DateTime(DenNgay.Year, DenNgay.Month, 1).AddMonths(1).AddDays(-1);
       
        
        
        var listCanTruyThu = ListCanTruyThu(ListChamCong, LoaiBieuDo);
        Thangs = new List<ListThang>();
        var listNgay = new List<LichItem>();
        var listNgayTangCuong = new List<LichItem>();
        var item = new LichItem();
        for (var xDay = tuNgayDauThang; xDay <= denNgayCuoiThang; xDay = xDay.AddMonths(1))
        {
            var xNgayCuoiThang = new DateTime(xDay.Year, xDay.Month, 1).AddMonths(1);
            listNgay=new List<LichItem>();
            listNgayTangCuong=new List<LichItem>();
            for (var d = xDay; d < xNgayCuoiThang; d = d.AddDays(1))
            {
                var chamCongBinhThuong = ListChamCong.FirstOrDefault(x => x.Ngay == d && !x.TangCuong);
                var chamCongTangCuong = ListChamCong.FirstOrDefault(x => x.Ngay == d && x.TangCuong);
                var itemCanTruyThu = listCanTruyThu.FirstOrDefault(x => x.Day == d);
                var chamCongsCurrentBinhThuong = ListChamCongCurrent.FirstOrDefault(x => x.Ngay == d && !x.TangCuong);
                var chamCongsCurrentTangCuong = ListChamCongCurrent.FirstOrDefault(x => x.Ngay == d && x.TangCuong);

                item = new LichItem { Day = d };
                item.Clickable = true;

                // Chỉ tính chấm công đã trả nợ 
                if (itemCanTruyThu != null)
                {
                    item.KieuChamCong = 7;
                }

                if (chamCongBinhThuong !=null)
                {
                    // Xác định chấm công này đã được lãnh đạo duyệt hay chưa
                    var kieuChamCong = chamCongBinhThuong.Loai != 3 ? chamCongBinhThuong.Loai : (chamCongBinhThuong.Duyet ? 3 : 5);
                    if(chamCongBinhThuong.TrangThaiNo==1)
                    {
                        kieuChamCong = 6;
                    }
                    item.Item = chamCongBinhThuong;
                    item.KieuChamCong = kieuChamCong;
                    item.SoChuyen = 1;
                    item.GhiChu = chamCongBinhThuong.GhiChu;
                    item.TangCuong = chamCongBinhThuong.TangCuong;
                    item.Clickable = false;
                }
                if (chamCongsCurrentBinhThuong != null)
                {
                    item.Item = chamCongsCurrentBinhThuong;
                    item.KieuChamCong = chamCongsCurrentBinhThuong.Loai;
                    item.SoChuyen += 1;
                    item.TRUYTHU_ID = chamCongsCurrentBinhThuong.TRUYTHU_ID;
                    item.PHOI_ID = chamCongsCurrentBinhThuong.PHOI_ID;
                    item.TangCuong = chamCongsCurrentBinhThuong.TangCuong;
                    item.Clickactive = true;
                }
                listNgay.Add(item);

                item = new LichItem() { Day = d };
                item.Clickable = true;
                if (chamCongTangCuong != null)
                {
                    // Xác định chấm công này đã được lãnh đạo duyệt hay chưa
                    var kieuChamCong = chamCongTangCuong.Loai != 3 ? chamCongTangCuong.Loai : (chamCongTangCuong.Duyet ? 3 : 5);
                    if (chamCongTangCuong.TrangThaiNo == 1)
                    {
                        kieuChamCong = 6;
                    }
                    item.Item = chamCongTangCuong;
                    item.KieuChamCong = kieuChamCong;
                    item.SoChuyen = 1;
                    item.GhiChu = chamCongTangCuong.GhiChu;
                    item.TangCuong = chamCongTangCuong.TangCuong;
                    item.Clickable = false;
                }
                //Ngày chấm công hiện tại
                if (chamCongsCurrentTangCuong != null)
                {
                    item.Item = chamCongsCurrentTangCuong;
                    item.KieuChamCong = chamCongsCurrentTangCuong.Loai;
                    item.SoChuyen += 1;
                    item.TRUYTHU_ID = chamCongsCurrentTangCuong.TRUYTHU_ID;
                    item.PHOI_ID = chamCongsCurrentTangCuong.PHOI_ID;
                    item.TangCuong = chamCongsCurrentTangCuong.TangCuong;
                    item.Clickactive = true;
                }
                listNgayTangCuong.Add(item);
            }

            Thangs.Add(new ListThang()
            {
                Ngay = listNgay,
                NgayTangCuong = listNgayTangCuong,
                Thang = xDay.Month,
                Tong = listNgay.Sum(x => x.SoChuyen),
                TongBieuDo = TongSoChuyeBieuDo(LoaiBieuDo, xDay.Year, xDay.Month)
            });
        }
        
    }
    /// <summary>
    /// Hàm tính tổng số ngày theo biểu đồ
    /// </summary>
    /// <param name="loaiBieuDo"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    public int TongSoChuyeBieuDo(LoaiBieuDo loaiBieuDo, int year, int month)
    {
        if (loaiBieuDo.KhoanTuyen)
        {
            return loaiBieuDo.SoTuyenKhoan;
        }
        var days = DateTime.DaysInMonth(year, month);
        var cachNgay = loaiBieuDo.CachNgay == 0 ? 1 : loaiBieuDo.CachNgay;
        if (days % cachNgay == 0)
        {
            return days / cachNgay;
        }
        return Convert.ToInt32(Math.Round(Convert.ToDecimal(days / cachNgay)) + 1);
    }

    /// <summary>
    /// Tính số ngày cần truy thu tính từ ngày chấm công (truy thu) cuối cùng đến ngày hôm nay
    /// </summary>
    /// <param name="chamCongList"> Danh sách chấm công </param>
    /// <param name="loaiBieuDo">Loại biểu đồ</param>
    /// <returns>Danh sách ngày cần truy thu dựa vào loại biểu đồ</returns>
    public List<LichItem> ListCanTruyThu(List<ChamCong> chamCongList, LoaiBieuDo loaiBieuDo)
    {
        var date = Today;
        var currentDate = new DateTime(date.Year, date.Month, date.Day);
        var ngayDauThang = new DateTime(currentDate.Year, currentDate.Month, 1);
        var ngayCuoiThang = ngayDauThang.AddMonths(1);
        var ngayChamCongCuoiCung = chamCongList.Any() ? chamCongList.Last().Ngay : ngayDauThang.AddDays(-1).AddMonths(-1);
        var tongNgay = (currentDate - ngayChamCongCuoiCung).Days;


        var list = new List<LichItem>();
        if (loaiBieuDo.ID == 0) return list;

        if (!loaiBieuDo.KhoanTuyen) // Nếu biểu đồ là biểu đồ cách ngày
        {
            // lấy tất cả các ngày cách còn lại trong biểu đồ (không kể ngày chấm công cuối cùng)
            for (var d = currentDate; d > ngayChamCongCuoiCung; d = d.AddDays(-loaiBieuDo.CachNgay))
            {
                if (d == ngayChamCongCuoiCung || d == currentDate) continue;
                list.Add(new LichItem() { Day = d, Clickactive = true, KieuChamCong = 4, SoChuyen = 1 });
            }
        }
        else // Nếu biểu đồ là biểu đồ khoán số chuyển theo tháng. Cần tính số tuyến đã chạy trong tháng + số tuyến còn lại.
        {
            var totalChuyen = Convert.ToInt32(loaiBieuDo.SoTuyenKhoan);
            var soChuyenDaChayTrongThang = chamCongList.Count(x => x.Ngay >= ngayDauThang.AddDays(-1));
            var soChuyenConLai = totalChuyen - soChuyenDaChayTrongThang;
            var soNgayConLaiTrongThang = (ngayCuoiThang - currentDate).Days;


            // Nếu là ngày cuối cùng của tháng sẽ truy thu các chuyến còn thiếu của tháng.
            if (soNgayConLaiTrongThang == 0)
            {
                var i = 0;
                for (var d = currentDate; d > ngayDauThang.AddMonths(-1); d = d.AddDays(-1))
                {
                    if (i == soChuyenConLai) break;
                    if (d == ngayChamCongCuoiCung || d == currentDate) continue;
                    if (ListChamCong.Any(x => x.Ngay == d)) continue;
                    list.Add(new LichItem() { Day = d, Clickactive = true, KieuChamCong = 4, SoChuyen = 1 });
                    i++;
                }
            }
            else // Số chuyến phải truy thu = Số chuyến còn lại - Số chuyến có thể chạy trong những ngày còn lại (chính là số ngày còn lại trong tháng)
            {
                if (soChuyenConLai > soNgayConLaiTrongThang)
                {
                    var soChuyenCanTruyThu = soChuyenConLai - soNgayConLaiTrongThang;
                    for (var d = currentDate; d > currentDate.AddDays(-soChuyenCanTruyThu); d = d.AddDays(-1))
                    {
                        if (d == ngayChamCongCuoiCung || d == currentDate) continue;
                        list.Add(new LichItem() { Day = d, Clickactive = true, KieuChamCong = 4, SoChuyen = 1 });
                    }
                }
            }
        }
        return list;
    }

}