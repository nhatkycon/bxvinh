using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThuChi_In_ThuCapPhoi : System.Web.UI.Page
{
    public Phoi Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);
        using (var con = DAL.con())
        {
            var thuChi = ThuChiDal.SelectById(con, Convert.ToInt64(id));
            Item = PhoiDal.SelectById(con, thuChi.PHOI_ID);
            var Xe = XeDal.SelectById(con, Item.XE_ID);
            var LaiXe = LaiXeDal.SelectById(con, Item.LAIXE_ID);
            var LoaiBieuDo = LoaiBieuDoDal.SelectById(con, Xe.BIEUDO_ID);
            var Tuyen = TuyenDal.SelectById(con, Xe.TUYEN_ID);
            var TruyThuItem = TruyThuDal.SelectByPhoiId(con, Convert.ToInt64(Item.ID));
            var XeVaoBen = XeVaoBenDal.SelectByPhoiId(con, Item.ID);

            Item.TruyThuItem = TruyThuItem;
            Item.XeVaoBen = XeVaoBen;
            Xe.LaiXe = LaiXe;
            Item.LaiXe = LaiXe;
            Xe.LoaiBieuDo = LoaiBieuDo;
            Xe.Tuyen = Tuyen;
            Item.Xe = Xe;
            PhoiNgoaiTinh.Item = Item;
        }
    }
}