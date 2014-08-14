using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_HeThong_ListDmByLdmMa : System.Web.UI.UserControl
{
    public List<DanhMuc> List { get; set; }
    public string CssName { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}