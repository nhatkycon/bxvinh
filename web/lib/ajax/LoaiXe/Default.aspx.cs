using System;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_LoaiXe_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var SoGhe = Request["SoGhe"];
        var MucThu = Request["MucThu"];
        var BangLai = Request["BangLai"];
        var q = Request["q"];

        var Ten = Request["Ten"];
        var Inserted = string.IsNullOrEmpty(Id);

        switch (subAct)
        {
            case "save":

                #region save

                if (!loggedIn || !string.IsNullOrEmpty(Ten))
                {
                    var Item = Inserted ? new LoaiXe() : LoaiXeDal.SelectById(Convert.ToInt32(Id));
                    Item.Ten = Ten;
                    Item.MucThu = Convert.ToDouble(MucThu);
                    Item.BangLai = BangLai;
                    Item.SoGhe = Convert.ToInt32(SoGhe);
                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                    }

                    Item.NgayCapNhat = DateTime.Now;
                    Item = Inserted ? LoaiXeDal.Insert(Item) : LoaiXeDal.Update(Item);
                    rendertext(Item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion

            case "remove":

                #region remove

                if (loggedIn)
                {
                    var Item = LoaiXeDal.SelectById(Convert.ToInt32(Id));
                    if (Item.Username == Security.Username)
                    {
                        LoaiXeDal.DeleteById(Item.ID);
                        rendertext("0");
                    }
                }
                rendertext("-1");
                break;
                #endregion
            case "search":
                #region search
                var pgResult = LoaiXeDal.SelectAll();
                rendertext(JavaScriptConvert.SerializeObject(pgResult), "text/javascript");
                break;
                #endregion
            default:
                break;
        }
    }
}