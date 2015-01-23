using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThuNo_Add : System.Web.UI.Page
{
    public ThuNo Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var xeId = Request["XE_ID"];
        var idNull = string.IsNullOrEmpty(id);
        var chamCongs = new List<ChamCong>();
        
        using (var con = DAL.con())
        {
            if (!idNull)
            {
                var thuNo = ThuNoDal.SelectById(con, Convert.ToInt64(id));
                chamCongs = ChamCongDal.NoByXeTuNgay(con, null, id, thuNo.XE_ID);
                Item = ThuNoDal.SelectById(Convert.ToInt64(id));
                var xe = XeDal.SelectById(con, Convert.ToInt64(Item.XE_ID));
                Item.XE_BienSo = xe.BienSoStr;
                Item.XE_ID = xe.ID;
            }
            else
            {
                Item= ThuNoDal.SelectByLastest(con, Security.CqId);
                if(!string.IsNullOrEmpty(xeId))
                {
                    chamCongs = ChamCongDal.NoByXeTuNgay(con, null, null, Convert.ToInt64(xeId));
                    var xe = XeDal.SelectById(con, Convert.ToInt64(xeId));
                    Item.XE_BienSo = xe.BienSoStr;
                    Item.XE_ID = xe.ID;
                }
            }
            ThuNoItem.ChamCongs = chamCongs;
            ThuNoItem.Item = Item;
        }
    }
}