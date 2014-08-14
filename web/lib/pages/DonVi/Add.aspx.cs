using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_DonVi_Add : System.Web.UI.Page
{
    public DonVi Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        Item = string.IsNullOrEmpty(id) ? new DonVi() : DonViDal.SelectById(Convert.ToInt32(id));
        Add1.Item = Item;
    }
}