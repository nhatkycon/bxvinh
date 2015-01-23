using System;
using System.Collections.Generic;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ChamCong_BangChamCongTheoCoQuan : System.Web.UI.Page
{
    public Tuyen Item { get; set; }
    public string TuNgay { get; set; }
    public string TuyenId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var cqId = Security.CqId;
        TuyenId = Request["ID"];
        TuNgay = Request["Thang"];

        if (string.IsNullOrEmpty(TuyenId)) TuyenId = "2";
        if (string.IsNullOrEmpty(TuNgay)) TuNgay = string.Format("{0:MM}/{0:yyyy}", DateTime.Now);
        var thangStr = TuNgay.Split(new char[] { '/' });
        var thangInt = Convert.ToInt32(thangStr[0]);
        var namInt = Convert.ToInt32(thangStr[1]);

        var tuNgay = new DateTime(namInt, thangInt, 1).AddDays(-1);
        var denNgay = tuNgay.AddMonths(1);
        var newListXe = new List<Xe>();
        var item = new LichItem();
        var listNgay = new List<LichItem>();
        var listChamCong = new List<ChamCong>();
        var startRener = DateTime.Now;
        var endRender = DateTime.Now; // Kết thúc render
        using (var con = DAL.con())
        {
            Item = TuyenDal.SelectById(con, Convert.ToInt32(TuyenId));
            var listXe = XeDal.SelectByTuyenId(con, Item.ID);
            
            foreach (var xe in listXe)
            {
                listChamCong = ChamCongDal.SelectByXeTuNgayCqId(con, cqId, tuNgay.ToString("dd/MM/yyyy"), denNgay.ToString("dd/MM/yyyy"), xe.ID);
                listNgay = new List<LichItem>();
                for (var d = tuNgay.AddDays(1); d <= denNgay; d = d.AddDays(1))
                {
                    item = new LichItem() {Day = d};
                    var ngayChamCong = listChamCong.Where(x => x.Ngay == d);
                    if (ngayChamCong.Any())
                    {
                        var chamCongBinhThuong = ngayChamCong.FirstOrDefault();
                        if (chamCongBinhThuong != null)
                        {
                            // Xác định chấm công này đã được lãnh đạo duyệt hay chưa
                            var kieuChamCong = chamCongBinhThuong.Loai != 3 ? chamCongBinhThuong.Loai : (chamCongBinhThuong.Duyet ? 3 : 5);
                            if (chamCongBinhThuong.TrangThaiNo == 1)
                            {
                                kieuChamCong = 6;
                            }
                            item.Item = chamCongBinhThuong;
                            item.KieuChamCong = kieuChamCong;
                            item.SoChuyen = ngayChamCong.Count();
                            item.GhiChu = chamCongBinhThuong.GhiChu;
                            item.TangCuong = chamCongBinhThuong.TangCuong;
                            item.Clickable = false;
                        }
                    }
                    listNgay.Add(item);
                }
                xe.ListChamCong = listChamCong;
                xe.ListLichItem = listNgay;
                newListXe.Add(xe);
            }
           
        }
        endRender = DateTime.Now; // Kết thúc render
        BangChamCongTheoCoQuan_List.Ngay = listNgay;
        BangChamCongTheoCoQuan_List.List = newListXe;
        BangChamCongTheoCoQuan_List.Item = Item;
        BangChamCongTheoCoQuan_List.TuNgay = TuNgay;
    }
}