using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_ChamCong_TruyThu_KetQuaDuyet_List : System.Web.UI.UserControl
{
    public List<ChamCong> List { get; set; }
    public Phoi Phoi { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        rpt.DataSource = List;
        rpt.DataBind();
    }
}