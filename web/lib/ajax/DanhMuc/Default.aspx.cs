using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_DanhMuc_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var LDM = Request["LDM"];
        

        var q = Request["q"];

      


        switch (subAct)
        {
            case "search":
                #region search
                var pgResult = DanhMucDal.SelectByLDMMa(LDM);
                rendertext(JavaScriptConvert.SerializeObject(pgResult), "text/javascript");
                break;
                #endregion
            default:
                break;
        }
    }
}