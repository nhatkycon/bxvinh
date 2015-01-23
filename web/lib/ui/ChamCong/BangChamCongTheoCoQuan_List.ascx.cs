using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_ChamCong_BangChamCongTheoCoQuan_List : System.Web.UI.UserControl
{
    public Tuyen Item { get; set; }
    public List<Xe> List { get; set; }
    public List<LichItem> Ngay { get; set; }
    public string TuNgay { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(List!=null)
        {
            rpt.DataSource = List;
            rpt.DataBind();
        }
    }
}