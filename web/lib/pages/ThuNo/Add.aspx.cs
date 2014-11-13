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
            if (!string.IsNullOrEmpty(id))
            {
                var thuNo = ThuNoDal.SelectById(con, Convert.ToInt64(id));
                chamCongs = ChamCongDal.NoByXeTuNgay(con, null, id, thuNo.XE_ID);
                ThuNoItem.XE_ID = thuNo.XE_ID.ToString();
            }
            else
            {
                chamCongs = ChamCongDal.NoByXeTuNgay(con, null, null, Convert.ToInt64(xeId));
                ThuNoItem.XE_ID = xeId;
            }
            ThuNoItem.ChamCongs = chamCongs;
            Item = idNull ? ThuNoDal.SelectByLastest(con, Security.CqId) : ThuNoDal.SelectById(Convert.ToInt64(id));
            ThuNoItem.Item = Item;
        }
    }
}