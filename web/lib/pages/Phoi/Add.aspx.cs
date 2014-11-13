using System;
using System.Collections.Generic;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Phoi_Add : System.Web.UI.Page
{
    public Phoi Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var act = Request["act"];
        var idNull = string.IsNullOrEmpty(id);
        using (var con = DAL.con())
        {
            if (idNull)
            {
                Item = PhoiDal.SelectLastest(Security.CqId.ToString());
                Item.CQ_ID = Security.CqId;
                Item.Xe = new Xe() { Tuyen = new Tuyen(), LoaiBieuDo = new LoaiBieuDo() };
                Item.LaiXe = new LaiXe();
                Item.ChamCongList = new List<ChamCong>();
                Item.ChamCongListCurrent = new List<ChamCong>();
                Item.TruyThuItem = new TruyThu();
                Item.XeVaoBen=new XeVaoBen();

            }
            else
            {

                Item = PhoiDal.SelectById(con, Convert.ToInt32(id));
                var Xe = XeDal.SelectById(con, Item.XE_ID);
                var LaiXe = LaiXeDal.SelectById(con, Item.LAIXE_ID);
                var LoaiBieuDo = LoaiBieuDoDal.SelectById(con, Xe.BIEUDO_ID);
                var Tuyen = TuyenDal.SelectById(con, Xe.TUYEN_ID);
                var TruyThuItem = TruyThuDal.SelectByPhoiId(con, Item.ID);
                var XeVaoBen = XeVaoBenDal.SelectByPhoiId(con, Item.ID);
                
                Item.XeVaoBen = XeVaoBen;
                Item.TruyThuItem = TruyThuItem;
                Xe.LaiXe = LaiXe;
                Item.LaiXe = LaiXe;
                Xe.LoaiBieuDo = LoaiBieuDo;
                Xe.Tuyen = Tuyen;
                Item.Xe = Xe;
                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;
                var prevMonth = month == 1 ? 12 : month - 1;
                var tuNgay = new DateTime(year, prevMonth, 1).AddDays(-1);
                var chamCongList = ChamCongDal.SelectByXeTuNgay(id, tuNgay.ToString("dd/MM/yyyy"), Xe.ID).Where(x => x.Ngay < Item.NgayTao).ToList();
                var chamCongListCurrent = ChamCongDal.SelectByTruyThuId(TruyThuItem.ID);
                Item.ChamCongList = chamCongList;
                Item.ChamCongListCurrent = chamCongListCurrent;

                // Duyệt truy thu nên đẩy XeVaoBen sang thu ngân
                if(act=="approvedTruyThu")
                {
                    //var xvb = XeVaoBenDal.SelectByPhoiId(con, Item.ID);
                    //xvb.TrangThai = 400;
                    //xvb.NgayCapNhat = DateTime.Now;
                    //xvb = XeVaoBenDal.Update(xvb);
                }
            }
        }
        
        Add.Item = Item;
    }
}