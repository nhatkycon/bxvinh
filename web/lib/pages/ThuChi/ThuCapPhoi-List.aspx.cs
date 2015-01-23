using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThuChi_ThuCapPhoi_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var bienSo = Request["bienSo"];
        var xeId = string.Empty;
        if (string.IsNullOrEmpty(size)) size = "10";

        var url = string.Format("?q={0}&size={1}&bienSo={2}&", q, size, bienSo) + "?page={0}";
        
        
        using(var con=DAL.con())
        {
            if(!string.IsNullOrEmpty(bienSo))
            {
                if(bienSo.Length>4 && bienSo.IndexOf(" ") > 0)
                {
                    var spacePosition = bienSo.IndexOf(" ");
                    var bienSoChu = bienSo.Substring(0, spacePosition);
                    var bienSoSo = bienSo.Substring(spacePosition + 1);
                    var xe = XeDal.SelectByBienSo(con,bienSoChu, bienSoSo);
                    if (xe.ID > 0) xeId = xe.ID.ToString();
                }
            }

            var pg = ThuChiDal.PagerByUser(con, url, Security.Username, xeId, "TC_ID desc", q, Convert.ToInt32(20));
        ThuCapPhoiList.Pager = pg;    
        }
        
    }
}