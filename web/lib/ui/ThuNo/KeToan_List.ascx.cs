using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_ThuNo_KeToan_List : System.Web.UI.UserControl
{
    public Pager<ThuNo> Pg { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Pg==null) return;
        rpt.DataSource = Pg.List;
        rpt.DataBind();
    }
}