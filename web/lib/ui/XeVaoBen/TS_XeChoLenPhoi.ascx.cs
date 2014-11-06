using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_XeVaoBen_TS_XeChoLenPhoi : System.Web.UI.UserControl
{
    public List<XeVaoBen> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        rpt.DataSource = List;
        rpt.DataBind();
    }
}