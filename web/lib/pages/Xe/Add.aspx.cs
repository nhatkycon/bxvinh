using System;
using docsoft.entities;

public partial class lib_pages_Xe_Add : System.Web.UI.Page
{
    public Xe Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        Item = string.IsNullOrEmpty(id) ? new Xe() : XeDal.SelectById(Convert.ToInt32(id));
        Add.Item = Item;
    }
}