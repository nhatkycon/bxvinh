using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_TruyThu_KetQuaDuyet : System.Web.UI.UserControl
{
    public TruyThu Item { get; set; }
    public List<ChamCong> List { get; set; }
    public string Id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        TruyThuKetQuaDuyetList.List = List;
    }
}