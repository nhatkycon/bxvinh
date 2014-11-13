using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using docsoft.entities;

public partial class lib_ui_Phoi_ChamCongCalendar_View : System.Web.UI.UserControl
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ListChamCong == null || ListChamCongCurrent == null) return;
        Today = string.IsNullOrEmpty(NgayXuatBen)
                    ? DateTime.Now
                    : Convert.ToDateTime(NgayXuatBen, new CultureInfo("Vi-vn"));

        SoChuyenNo = ListChamCong.Count(x => x.TrangThaiNo == 1);

        ListChamCong = ListChamCong.Where(x => x.TrangThaiNo != 1).ToList();

        var month = Today.Month;
        var year = Today.Year;
        var prevMonth = month == 1 ? 12 : month - 1;
        PrevMonth = new List<LichItem>();
        CurrentMonth = new List<LichItem>();

        var mongMotThangTruoc = new DateTime(month == 1 ? year + -1 : year, prevMonth, 1);
        var mongMotThangNay = new DateTime(year, month, 1);
        var mongMotThangSau = new DateTime(month == 12 ? year + 1 : year, month == 12 ? 1 : month + 1, 1);


        PrevMonthLabel = prevMonth;
        CurrentMonthLabel = month;
        Thangs=new List<ListThang>();

        var listCanTruyThu = ListCanTruyThu(ListChamCong, LoaiBieuDo);

        for (var d = mongMotThangTruoc; d < mongMotThangNay; d = d.AddDays(1))
        {
            var chamCongList = ListChamCong.Where(x => x.Ngay == d);
            var item = new LichItem {Day = d};
            var chamCongs = chamCongList as List<ChamCong> ?? chamCongList.ToList();
            var itemCanTruyThu = listCanTruyThu.FirstOrDefault(x => x.Day == d);

            if (itemCanTruyThu!=null)
            {
                item.KieuChamCong = 4;
            }

            if(chamCongs.Any())
            {
                var chamCongsItem = chamCongs[0];
                // Xác định chấm công này đã được lãnh đạo duyệt hay chưa
                var kieuChamCong = chamCongsItem.Loai != 3 ? chamCongsItem.Loai : (chamCongsItem.Duyet ? 3 : 5);
                item.List.AddRange(chamCongs);
                item.KieuChamCong = kieuChamCong;
                item.SoChuyen = chamCongs.Count;
            }

            var chamCongsCurrent = ListChamCongCurrent.Where(x => x.Ngay == d).ToList();
            if (chamCongsCurrent.Any())
            {
                item.List.AddRange(chamCongsCurrent);
                item.KieuChamCong = chamCongsCurrent[0].Loai;
                item.SoChuyen += chamCongsCurrent.Count;
                item.TRUYTHU_ID = chamCongsCurrent[0].TRUYTHU_ID;
                item.PHOI_ID = chamCongsCurrent[0].PHOI_ID;
                item.Clickactive = true;
            }


            PrevMonth.Add(item);
        }

        Thangs.Add(new ListThang()
                       {
                           Ngay = PrevMonth
                           , Thang = prevMonth
                           ,
                           Tong = PrevMonth.Sum(x => x.SoChuyen)
                           ,
                           TongBieuDo = TongSoChuyeBieuDo(LoaiBieuDo,year,prevMonth)
                       });

        for (var d = mongMotThangNay; d < mongMotThangSau; d = d.AddDays(1))
        {
            var chamCongList = ListChamCong.Where(x => x.Ngay == d);
            var item = new LichItem { Day = d };
            var chamCongs = chamCongList as List<ChamCong> ?? chamCongList.ToList();

            var itemCanTruyThu = listCanTruyThu.FirstOrDefault(x => x.Day == d);

            if (itemCanTruyThu != null)
            {
                item.KieuChamCong = 4;
            }

            if (chamCongs.Any())
            {
                var chamCongsItem = chamCongs[0];
                // Xác định chấm công này đã được lãnh đạo duyệt hay chưa
                var kieuChamCong = chamCongsItem.Loai != 3 ? chamCongsItem.Loai : (chamCongsItem.Duyet ? 3 : 5);
                item.List.AddRange(chamCongs);
                item.KieuChamCong = kieuChamCong;
                item.SoChuyen = chamCongs.Count;
            }

            var chamCongsCurrent = ListChamCongCurrent.Where(x => x.Ngay == d).ToList();
            if (chamCongsCurrent.Any())
            {
                item.List.AddRange(chamCongsCurrent);
                item.KieuChamCong = chamCongsCurrent[0].Loai;
                item.SoChuyen += chamCongsCurrent.Count;
                item.Clickactive = true;
                item.TRUYTHU_ID = chamCongsCurrent[0].TRUYTHU_ID;
                item.PHOI_ID = chamCongsCurrent[0].PHOI_ID;
            }
            CurrentMonth.Add(item);
        }

        Thangs.Add(new ListThang()
        {
            Ngay = CurrentMonth
            ,
            Thang = month
            , Tong = CurrentMonth.Sum( x => x.SoChuyen)
            ,
            TongBieuDo = TongSoChuyeBieuDo(LoaiBieuDo, year, month)
        });
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
        if(loaiBieuDo.KhoanTuyen)
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
    /// <param name="ngayChamCongCuoiCung">Ngày chấm công (truy thu) cuối cùng</param>
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

        if(!loaiBieuDo.KhoanTuyen) // Nếu biểu đồ là biểu đồ cách ngày
        {
            // lấy tất cả các ngày cách còn lại trong biểu đồ (không kể ngày chấm công cuối cùng)
            for (var d = currentDate; d > ngayChamCongCuoiCung; d = d.AddDays(-loaiBieuDo.CachNgay))
            {
                if(d==ngayChamCongCuoiCung || d==currentDate) continue;
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
            if(soNgayConLaiTrongThang == 0)
            {
                var i = 0;
                for(var d = currentDate; d > ngayDauThang.AddMonths(-1); d=d.AddDays(-1))
                {
                    if (i == soChuyenConLai) break;
                    if (d == ngayChamCongCuoiCung || d == currentDate) continue;
                    if(ListChamCong.Any(x => x.Ngay==d)) continue;
                    list.Add(new LichItem() { Day = d, Clickactive = true, KieuChamCong = 4, SoChuyen = 1 });
                    i++;
                }
            }
            else // Số chuyến phải truy thu = Số chuyến còn lại - Số chuyến có thể chạy trong những ngày còn lại (chính là số ngày còn lại trong tháng)
            {
                if(soChuyenConLai > soNgayConLaiTrongThang)
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

