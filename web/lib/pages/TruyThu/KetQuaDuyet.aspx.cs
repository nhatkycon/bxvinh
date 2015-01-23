using System;
using docsoft.entities;
using linh.core.dal;
using System.Linq.Expressions;
using System.Linq;
public partial class lib_pages_TruyThu_KetQuaDuyet : System.Web.UI.Page
{
    public TruyThu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["ID"];
        using (var con = DAL.con())
        {
            Item = TruyThuDal.SelectById(con, Convert.ToInt64(Id));
            var phoi = PhoiDal.SelectById(con, Item.PHOI_ID);
            var Xe = XeDal.SelectById(con, Item.XE_ID);
            var Tuyen = TuyenDal.SelectById(con, Xe.TUYEN_ID);
            var LaiXe = LaiXeDal.SelectById(con, phoi.LAIXE_ID);
            var chamCong = ChamCongDal.SelectByTruyThuId(con, Item.ID).Where(x => x.Loai!= 1 && x.Loai!= 2) 
                .OrderBy(x => x.Ngay).ToList();
            Xe.Tuyen = Tuyen;
            phoi.Xe = Xe;
            phoi.LaiXe = LaiXe;
            Item.Phoi = phoi;
            Add.Item = Item;
            Add.List = chamCong;
            Add.Phoi = phoi;
        }
    }
}