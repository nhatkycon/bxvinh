using System;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_ThuChi_ThuCapPhoi_List : System.Web.UI.UserControl
{
    public Pager<ThuChi> Pager { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Pager!=null)
        {
            rpt.DataSource = Pager.List;
            rpt.DataBind();
        }
    }
}