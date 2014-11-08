using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_TruyThu_Add : System.Web.UI.Page
{
    public TruyThu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        using(var con = DAL.con())
        {
            Item = TruyThuDal.SelectById(con, Convert.ToInt64(Id));
            var phoi = PhoiDal.SelectById(con, Item.PHOI_ID);
            var Xe = XeDal.SelectById(con, Item.XE_ID);
            var Tuyen = TuyenDal.SelectById(con, Xe.TUYEN_ID);
            var LaiXe = LaiXeDal.SelectById(con, phoi.LAIXE_ID);
            Xe.Tuyen = Tuyen;
            phoi.Xe = Xe;
            phoi.LaiXe = LaiXe;
            Item.Phoi = phoi;
            Add.Item = Item;
        }
    }
}