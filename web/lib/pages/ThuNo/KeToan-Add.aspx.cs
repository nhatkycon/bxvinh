using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThuNo_KeToan_Add : System.Web.UI.Page
{
    public ThuNo Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using (var con = DAL.con())
        {
            if (!string.IsNullOrEmpty(id))
            {
                Item = ThuNoDal.SelectById(con, Convert.ToInt64(id));
            }
            else
            {
                Item =new ThuNo();
            }
           
            ThuNo_KeToan.Item = Item;
        }

    }
}