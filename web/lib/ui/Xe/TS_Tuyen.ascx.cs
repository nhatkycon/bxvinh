using System;
using System.Collections.Generic;
using docsoft.entities;


public partial class lib_ui_Xe_TS_Tuyen : System.Web.UI.UserControl
{
    public List<Xe> List { get; set; }
    public Tuyen Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        rpt.DataSource = List;
        rpt.DataBind();
    }
}