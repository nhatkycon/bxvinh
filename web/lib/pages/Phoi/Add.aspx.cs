using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_pages_Phoi_Add : System.Web.UI.Page
{
    public Phoi Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        var loggedIn = Security.IsAuthenticated();
        if(idNull)
        {
            var member = loggedIn ? new Member() : MemberDal.SelectByUser(Security.Username);
            Item = PhoiDal.SelectLastest(member.CQ_ID.ToString());
            Item.CQ_ID = member.CQ_ID;
            Item.Xe = new Xe() {Tuyen = new Tuyen(), LoaiBieuDo = new LoaiBieuDo()};
            Item.LaiXe=new LaiXe();
            Item.ChamCongList=new List<ChamCong>();
            Item.ChamCongListCurrent = new List<ChamCong>();
            Item.TruyThuItem = new TruyThu();
            
        }
        else
        {
            Item = PhoiDal.SelectById(Convert.ToInt32(id));
            var Xe = XeDal.SelectById(Item.XE_ID);
            var LaiXe = LaiXeDal.SelectById(Item.LAIXE_ID);
            var LoaiBieuDo = LoaiBieuDoDal.SelectById(Xe.BIEUDO_ID);
            var Tuyen = TuyenDal.SelectById(Xe.TUYEN_ID);
            var TruyThuItem = TruyThuDal.SelectByPhoiId(Convert.ToInt64(Item.ID));
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
            var chamCongList = ChamCongDal.SelectByXeTuNgay(id, tuNgay.ToString("dd/MM/yyyy"), Xe.ID);
            var chamCongListCurrent = ChamCongDal.SelectByTruyThuId(TruyThuItem.ID);
            Item.ChamCongList = chamCongList;
            Item.ChamCongListCurrent = chamCongListCurrent;
        }
        Add.Item = Item;
    }
}