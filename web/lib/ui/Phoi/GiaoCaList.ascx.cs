using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_Phoi_GiaoCaList : System.Web.UI.UserControl
{
    public List<Phoi> List { get; set; }
    public string Ngay { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ngay = Request["ngay"];
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}