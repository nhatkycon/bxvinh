using System;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_Phoi_List : System.Web.UI.UserControl
{
    public Pager<Phoi> Pager { get; set; }
    public string TuNgay { get; set; }
    public string DenNgay { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        TuNgay = Request["tuNgay"];
        DenNgay = Request["denNgay"];
        if(Pager==null) return;
        rpt.DataSource = Pager.List;
        rpt.DataBind();
    }
}