using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_Tuyen_Add : System.Web.UI.UserControl
{
    public Tuyen Item { get; set; }
    public string Ret { get; set; }
    public string Id { get; set; }
    public List<DanhMuc> DiaDiem { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ret = Request["ret"];
        Id = Request["ID"];
        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }
        DI_ID.List = DiaDiem;
        DEN_ID.List = DiaDiem;
    }
}