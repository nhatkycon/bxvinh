using System;
using docsoft;
using docsoft.entities;

public partial class lib_ajax_GiaoCa_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();
        var uname = Security.Username;
        switch (subAct)
        {
            case "Detail":
                #region Detail
                if (loggedIn)
                {
                    var giaoCa = GiaoCaDal.Current(Security.CqId, uname);
                    AjaxItem.Item = giaoCa;
                    AjaxItem.Visible = true;
                }
                break;
                #endregion
            default:
                break;
        }
    }
}