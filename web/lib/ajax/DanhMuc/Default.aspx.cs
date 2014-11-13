using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                var list =  !string.IsNullOrEmpty(q) ? DanhMucDal.SelectByLDMMa(LDM).Where(x => x.Ten.ToLower().Contains(q) || x.Ma.ToLower().Contains(q)).ToList() : DanhMucDal.SelectByLDMMa(LDM);
                rendertext(JavaScriptConvert.SerializeObject(list), "text/javascript");
                break;
                #endregion
            default:
                break;
        }
    }
}