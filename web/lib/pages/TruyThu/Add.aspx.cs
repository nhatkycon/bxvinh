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
            Add.Item = Item;
        }
    }
}