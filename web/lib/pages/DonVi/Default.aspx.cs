using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_DonVi_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pg = DonViDal.pagerNormal("", false, null, "", 10);
        List.Pager = pg;
    }
}