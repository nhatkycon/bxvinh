using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Phoi_GiaoCaList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            var q = Request["q"];
            var uname = Security.Username;
            var ngay = Request["ngay"];
            List.List = PhoiDal.SelectByGiaoCa(con, GiaoCaDal.Current(Security.CqId, uname).ID, ngay);
        }
    }
}