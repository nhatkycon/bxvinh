using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_XeVaoBen_TS_XeChoThanhToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            var list = XeVaoBenDal.ListTsChoThanhToan(con, Security.CqId, 100);
            TS_XeChoThanhToan.List = list;
        }
    }
}