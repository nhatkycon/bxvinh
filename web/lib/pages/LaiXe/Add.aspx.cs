using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_pages_LaiXe_Add : System.Web.UI.Page
{
    public LaiXe Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        Item = string.IsNullOrEmpty(id) ? new LaiXe() : LaiXeDal.SelectById(Convert.ToInt32(id));
        Add.Item = Item;
    }
}