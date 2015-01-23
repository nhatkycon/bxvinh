using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var act = Request["act"];
        switch (act)
        {
           
            case "Logout":
                #region logout this system
                Security.LogOut();
                Session["GiaoCa-Current"] = null;
                break;
                #endregion
            default:break;
        }
        
    }
}