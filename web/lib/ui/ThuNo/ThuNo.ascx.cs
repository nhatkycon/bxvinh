using System;
using System.Collections.Generic;
using System.Linq;
using docsoft.entities;

public partial class lib_ui_ThuNo_ThuNo : System.Web.UI.UserControl
{
    public ThuNo Item { get; set; }
    public List<ThuNoChiTiet> List { get; set; }
    public List<ChamCong> ChamCongs { get; set; }
    public string Id { get; set; }
    public string Ret { get; set; }
    public string XE_ID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["Id"];
        Ret = Request["Ret"];
        ThuNoList.List = ChamCongs;
        if(!ChamCongs.Any())
        {
            ThuNoList.Visible = false;
        }
        ThuNoList.XE_ID = XE_ID;
    }
}