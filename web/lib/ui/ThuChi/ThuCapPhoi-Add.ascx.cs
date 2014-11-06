using System;
using docsoft.entities;
public partial class lib_ui_ThuChi_ThuCapPhoi_Add : System.Web.UI.UserControl
{
    public ThuChi Item { get; set; }
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
    }
}