using System;
using System.Globalization;
using System.Linq;
using docsoft;
using docsoft.entities;

public partial class lib_ajax_ThuNo_KeToan : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Id = Request["Id"];
        var loggedIn = Security.IsAuthenticated();
        var chamCongIds = Request["ChamCongIds"];
        var ngay = Request["Ngay"];
        var tien = Request["Tien"];
        var xeID = Request["XE_ID"];
        var Inserted = string.IsNullOrEmpty(Id);
        switch (subAct)
        {
            case "save":

                #region save

                /////////////////////////////////////////
                ////////////////////////////////////////
                if (!loggedIn || !string.IsNullOrEmpty(Id))
                {
                    var item = ThuNoDal.SelectById(Convert.ToInt64(Id));
                    item.NgayThu = DateTime.Now;
                    item.NguoiThu = Security.Username;
                    item.DaThu = true;
                    ThuNoDal.Update(item);

                    var chiTiets = ThuNoChiTietDal.SelectByThuNoId(item.ID);
                    foreach (var chiTiet in chiTiets)
                    {
                        chiTiet.DaThu = true;
                        chiTiet.NgayThu = item.NgayCapNhat = DateTime.Now;
                        chiTiet.NguoiThu = Security.Username;
                        ThuNoChiTietDal.Update(chiTiet);

                        var chamCong = ChamCongDal.SelectById(chiTiet.CONG_ID);
                        chamCong.NgayCapNhat = chamCong.NgayThanhToan = DateTime.Now;
                        chamCong.TrangThaiNo = 2;
                        chamCong.Loai = 3;
                        ChamCongDal.Update(chamCong);
                    }

                    rendertext(item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion

            case "remove":
                #region remove

                if (loggedIn)
                {
                    var item = ThuNoDal.SelectById(Convert.ToInt32(Id));
                    if (item.NguoiTao == Security.Username)
                    {
                        ThuNoChiTietDal.DeleteByThuNoId(item.ID);
                        ThuNoDal.DeleteById(item.ID);
                        rendertext("0");
                    }
                }
                rendertext("-1");
                break;

                #endregion
            default:
                break;
        }
    }
}