using System;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_DonVi_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var Mobile = Request["Mobile"];
        var Phone = Request["Phone"];
        var DiaChi = Request["DiaChi"];
        var GPS_Website = Request["GPS_Website"];
        var GPS_Username = Request["GPS_Username"];
        var GPS_Password = Request["GPS_Password"];
        var Khoa = Request["Khoa"];
        var Ten = Request["Ten"];
        var Inserted = string.IsNullOrEmpty(Id);
        Khoa = !string.IsNullOrEmpty(Khoa) ? "true" : "false";

        switch (subAct)
        {
            case "save":

                #region save

                if (!loggedIn || !string.IsNullOrEmpty(Ten))
                {
                    var Item = Inserted ? new DonVi() : DonViDal.SelectById(Convert.ToInt32(Id));
                    Item.Ten = Ten;
                    Item.Mobile = Mobile;
                    Item.Phone = Phone;
                    Item.GPS_Website = GPS_Website;
                    Item.GPS_Username = GPS_Username;
                    Item.GPS_Password = GPS_Password;
                    Item.Khoa = Convert.ToBoolean(Khoa);
                    Item.DiaChi = DiaChi;
                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                    }

                    Item.NgayCapNhat = DateTime.Now;
                    Item = Inserted ? DonViDal.Insert(Item) : DonViDal.Update(Item);
                    rendertext(Item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion

            case "remove":

                #region remove

                if (loggedIn)
                {
                    var Item = DonViDal.SelectById(Convert.ToInt32(Id));
                    if(Item.Username == Security.Username)
                    {
                        DonViDal.DeleteById(Item.ID);
                        rendertext("0");
                    }
                }
                rendertext("-1");
                break;
            #endregion
            case "search":
                #region search
                var pgResult = DonViDal.SelectAll();
                rendertext(JavaScriptConvert.SerializeObject(pgResult), "text/javascript");
                break;
                #endregion
            default:
                break;
        }
    }
}