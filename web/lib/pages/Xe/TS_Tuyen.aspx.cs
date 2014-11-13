using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Xe_TS_Tuyen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var di = Request["DI_ID"];
        var den = Request["DEN_ID"];
        using (var con = DAL.con())
        {
            var list = new List<Xe>();
            var tuyen = TuyenDal.SelectByDenIdDiId(con, den, di);
            list = XeDal.ListByTuyen(con, Security.CqId, tuyen.ID, 50);
            TS_Tuyen.Item = tuyen;
            TS_Tuyen.List = list;
        }
    }
}