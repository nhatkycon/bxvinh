using System;
using System.Collections.Generic;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThuChi_ThuCapPhoi_Add : System.Web.UI.Page
{
    public ThuChi Item;
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var idNull = string.IsNullOrEmpty(id);

        using(var con = DAL.con())
        {
            if(idNull)
            {
                Item = ThuChiDal.SelectByLastest(con, Security.CqId);
            }
            else
            {
                Item = ThuChiDal.SelectById(con, Convert.ToInt64(id));
                var phoi = PhoiDal.SelectById(Item.PHOI_ID);
                var xe = XeDal.SelectById(phoi.XE_ID);
                phoi.Xe = xe;
                Item.Phoi = phoi;
            }
        }
        ThuCapPhoiAdd.Item = Item;
    }
}