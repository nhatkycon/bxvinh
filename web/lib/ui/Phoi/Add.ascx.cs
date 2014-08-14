using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_Phoi_Add : System.Web.UI.UserControl
{
    public Phoi Item { get; set; }
    public string Ret { get; set; }
    public string Id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ret = Request["ret"];
        Id = Request["ID"];
        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }
        var idNull = string.IsNullOrEmpty(Id);
        TruyThuDialog.Item = Item.TruyThuItem;

        if(idNull)
        {
            ChamCongCalendar_View.Visible = false;
            return;
        }
        else
        {
            ChamCongCalendar_View.ListChamCong = Item.ChamCongList;
            ChamCongCalendar_View.ListChamCongCurrent = Item.ChamCongListCurrent;
            ChamCongCalendar_View.LoaiBieuDo = Item.Xe.LoaiBieuDo;            
        }

       
    }
}