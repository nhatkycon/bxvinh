using System;
using System.Collections.Generic;
using System.Linq;
using docsoft.entities;
public partial class lib_ui_ThuNo_ThuNo_KeToan : System.Web.UI.UserControl
{
    public ThuNo Item { get; set; }
    public string Id { get; set; }
    public string Ret { get; set; }
    public string XE_ID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["Id"];
        Ret = Request["Ret"];
    }
}