using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_LaiXe_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];

        var Ten = Request["Ten"];
        var BangLai = Request["BangLai"];
        var LoaiBang = Request["LoaiBang"];
        var DONVI_ID = Request["DONVI_ID"];
        var XE_ID = Request["XE_ID"];
        var NgaySinh = Request["NgaySinh"];
        var NgayHetHanBangLai = Request["NgayHetHanBangLai"];
        var NgayHetHanGiayKhamSucKhoe = Request["NgayHetHanGiayKhamSucKhoe"];
        var q = Request["q"];
        var Khoa = Request["Khoa"];

        Khoa = !string.IsNullOrEmpty(Khoa)
                      ? "true"
                      : "false";

        var Inserted = string.IsNullOrEmpty(Id);

        switch (subAct)
        {
            case "save":

                #region save

                if (!loggedIn || !string.IsNullOrEmpty(Ten) || !string.IsNullOrEmpty(BangLai))
                {
                    var Item = Inserted ? new LaiXe() : LaiXeDal.SelectById(Convert.ToInt32(Id));

                    Item.Ten = Ten;
                    Item.BangLai = BangLai;
                    Item.LoaiBang = LoaiBang;
                    Item.XE_ID = Convert.ToInt32(XE_ID);
                    Item.DONVI_ID = Convert.ToInt32(DONVI_ID);
                    Item.NgaySinh = Convert.ToDateTime(NgaySinh, new CultureInfo("vi-vn"));
                    if (!string.IsNullOrEmpty(NgayHetHanBangLai))
                    {
                        Item.NgayHetHanBangLai = Convert.ToDateTime(NgayHetHanBangLai, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayHetHanGiayKhamSucKhoe))
                    {
                        Item.NgayHetHanGiayKhamSucKhoe = Convert.ToDateTime(NgayHetHanGiayKhamSucKhoe, new CultureInfo("vi-vn"));
                    }
                    Item.Khoa = Convert.ToBoolean(Khoa);

                    if (Inserted)
                    {
                        Item.Username = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                    }

                    Item.NgayCapNhat = DateTime.Now;
                    Item = Inserted ? LaiXeDal.Insert(Item) : LaiXeDal.Update(Item);
                    rendertext(Item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion

            case "remove":

                #region remove

                if (loggedIn)
                {
                    var Item = LaiXeDal.SelectById(Convert.ToInt32(Id));
                    if (Item.Username == Security.Username)
                    {
                        LaiXeDal.DeleteById(Item.ID);
                        rendertext("0");
                    }
                }
                rendertext("-1");
                break;

                #endregion

            case "search":

                #region search

                var pgResult = LaiXeDal.pagerNormal(null, false, null, q, 20, null, null, null);
                rendertext(JavaScriptConvert.SerializeObject(pgResult.List), "text/javascript");
                break;

                #endregion

            default:
                break;
        }
    }
}