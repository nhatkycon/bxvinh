using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_pages_Tuyen_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pg = TuyenDal.pagerNormal("", false, null, "", 10);
        List.Pager = pg;
    }
}