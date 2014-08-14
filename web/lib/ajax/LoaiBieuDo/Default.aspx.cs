using System;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_LoaiBieuDo_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var SoTuyenKhoan = Request["SoTuyenKhoan"];
        var CachNgay = Request["CachNgay"];
        var KhoanTuyen = Request["KhoanTuyen"];
        var HaiTuyenTrenNgay = Request["HaiTuyenTrenNgay"];
        KhoanTuyen = !string.IsNullOrEmpty(KhoanTuyen)
                      ? "true"
                      : "false";
        HaiTuyenTrenNgay = !string.IsNullOrEmpty(HaiTuyenTrenNgay)
                      ? "true"
                      : "false";

        var q = Request["q"];
        var Ten = Request["Ten"];
        var Inserted = string.IsNullOrEmpty(Id);

        switch (subAct)
        {
            case "save":

                #region save

                if (!loggedIn || !string.IsNullOrEmpty(Ten))
                {
                    var Item = Inserted ? new LoaiBieuDo() : LoaiBieuDoDal.SelectById(Convert.ToInt32(Id));
                    Item.Ten = Ten;
                    Item.KhoanTuyen = Convert.ToBoolean(KhoanTuyen);
                    Item.HaiTuyenTrenNgay = Convert.ToBoolean(HaiTuyenTrenNgay);
                    Item.SoTuyenKhoan = Convert.ToInt16(SoTuyenKhoan);
                    Item.CachNgay = Convert.ToInt16(CachNgay);
                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                    }

                    Item.NgayCapNhat = DateTime.Now;
                    Item = Inserted ? LoaiBieuDoDal.Insert(Item) : LoaiBieuDoDal.Update(Item);
                    rendertext(Item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion

            case "remove":

                #region remove

                if (loggedIn)
                {
                    var Item = LoaiBieuDoDal.SelectById(Convert.ToInt32(Id));
                    if (Item.Username == Security.Username)
                    {
                        LoaiBieuDoDal.DeleteById(Item.ID);
                        rendertext("0");
                    }
                }
                rendertext("-1");
                break;
                #endregion
            case "search":
                #region search
                var pgResult = LoaiBieuDoDal.SelectAll();
                rendertext(JavaScriptConvert.SerializeObject(pgResult), "text/javascript");
                break;
                #endregion
            default:
                break;
        }
    }
}