using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_Phoi_ChamCongCalendar_View : System.Web.UI.UserControl
{
    public Phoi Item { get; set; }
    public LoaiBieuDo LoaiBieuDo { get; set; }
    public List<ChamCong> ListChamCong { get; set; }
    public List<ChamCong> ListChamCongCurrent { get; set; }

    public List<LichItem> PrevMonth { get; set; }
    public List<LichItem> CurrentMonth { get; set; }
    public List<ListThang> Thangs { get; set; }
    public int PrevMonthLabel { get; set; }
    public int CurrentMonthLabel { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ListChamCong == null || ListChamCongCurrent == null) return;
        var month = DateTime.Now.Month;
        var year = DateTime.Now.Year;
        var prevMonth = month == 1 ? 12 : month - 1;
        PrevMonth = new List<LichItem>();
        CurrentMonth = new List<LichItem>();

        var mongMotThangTruoc = new DateTime(month == 1 ? year + -1 : year, prevMonth, 1);
        var mongMotThangNay = new DateTime(year, month, 1);
        var cuoiThangTruoc = mongMotThangNay.AddDays(-1);
        var mongMotThangSau = new DateTime(month == 12 ? year + 1 : year, month == 12 ? 1 : month + 1, 1);
        var cuoiThangNay = mongMotThangSau.AddDays(-1);

        var rnd = new Random();

        PrevMonthLabel = prevMonth;
        CurrentMonthLabel = month;
        Thangs=new List<ListThang>();


        for (var d = mongMotThangTruoc; d < mongMotThangNay; d = d.AddDays(1))
        {
            var chamCongList = ListChamCong.Where(x => x.Ngay == d);
            var item = new LichItem {Day = d};
            var chamCongs = chamCongList as List<ChamCong> ?? chamCongList.ToList();

            if(chamCongs.Any())
            {
                item.List.AddRange(chamCongs);
                item.KieuChamCong = chamCongs[0].Loai;
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

            if (chamCongs.Any())
            {
                item.List.AddRange(chamCongs);
                item.KieuChamCong = chamCongs[0].Loai;
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
            TongBieuDo = TongSoChuyeBieuDo(LoaiBieuDo, year, prevMonth)
        });

    }
    public int TongSoChuyeBieuDo(LoaiBieuDo loaiBieuDo, int year, int month)
    {
        if(loaiBieuDo.KhoanTuyen)
        {
            return loaiBieuDo.SoTuyenKhoan;
        }
        var days = DateTime.DaysInMonth(year, month);
        if(days % loaiBieuDo.CachNgay ==0)
        {
            return days / loaiBieuDo.CachNgay;
        }
        return Convert.ToInt32(Math.Round(Convert.ToDecimal(days / loaiBieuDo.CachNgay)));
    }




}

