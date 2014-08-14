using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_Lab_BangChamCong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var chamCongList = new List<ChamCong>();
        var month = DateTime.Now.Month;
        var year = DateTime.Now.Year;
        var prevMonth = month == 1 ? 12 : month - 1;
        var rnd = new Random();

        for (var i = 0; i < 20; i++ )
        {
            var cday = new DateTime(year, month, rnd.Next(1, 30));
            if(cday < DateTime.Now)
            {
                chamCongList.Add(new ChamCong()
            {
                Duyet = true
                ,
                Loai = Convert.ToInt16(rnd.Next(1, 4))
                ,
                Ngay = cday
            });
            }
            
        }

        for (var i = 0; i < 12; i++)
        {
            chamCongList.Add(new ChamCong()
            {
                Duyet = true
                ,
                Loai = Convert.ToInt16(rnd.Next(1, 4))
                ,
                Ngay = new DateTime(year, prevMonth, rnd.Next(1, 30))
            });
        }

        ChamCongCalendar_View.ListChamCong = chamCongList;
        ChamCongCalendar_View.LoaiBieuDo=new LoaiBieuDo()
                                             {
                                                 KhoanTuyen = false
                                                 , SoTuyenKhoan = 2
                                             };
    }
}