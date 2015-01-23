using System;
using System.Globalization;
using System.Linq;
using docsoft;
using docsoft.entities;

public partial class lib_ajax_ThuNo_Default : basePage
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
                if (!loggedIn || !string.IsNullOrEmpty(chamCongIds))
                {
                    if (chamCongIds.Length < 2)
                    {
                        rendertext("0");
                    }
                    var ids = chamCongIds.Split(new char[] {','}).Where(x => x.Length > 0);


                    var item = Inserted
                                   ? ThuNoDal.SelectLastest(Security.CqId)
                                   : ThuNoDal.SelectById(Convert.ToInt64(Id));
                    if (!string.IsNullOrEmpty(ngay))
                    {
                        item.Ngay = Convert.ToDateTime(ngay, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(tien))
                    {
                        tien = tien.Replace(",", "");
                        item.Tien = Convert.ToDouble(tien);
                    }

                    if(!string.IsNullOrEmpty(xeID))
                    {
                        item.XE_ID = Convert.ToInt64(xeID);
                    }
                    item.CQ_ID = Security.CqId;
                    item.NgayCapNhat = DateTime.Now;
                    item.NguoiCapNhat = Security.Username;




                    if (Inserted)
                    {
                        item.NguoiTao = Security.Username;
                        item.NgayTao = DateTime.Now;
                        item.RowId = Guid.NewGuid();
                        item = ThuNoDal.Insert(item);
                        //Update Ca làm việc
                        var giaoCa = GiaoCaDal.Current(Security.CqId, Security.Username);
                        item.GIAOCA_ID = giaoCa.ID;
                        giaoCa.TongSoPhoi += 1;
                        giaoCa.DoanhThu += item.Tien;
                        giaoCa.NgayCapNhat = DateTime.Now;
                        GiaoCaDal.Update(giaoCa);
                    }
                    else
                    {
                        ThuNoChiTietDal.DeleteByThuNoId(item.ID);
                        item = ThuNoDal.Update(item);
                    }
                    // Xóa bỏ các thu nợ chi tiết cũ

                    // Thêm thu nợ chi tiết
                    foreach (var thuNoChiTiet in ids.Select(id => new ThuNoChiTiet
                    {
                        CONG_ID = Convert.ToInt64(id),
                        DaThu = false,
                        NgayTao = DateTime.Now,
                        THUNO_ID = item.ID,
                        NguoiTao = Security.Username
                    }))
                    {
                        ThuNoChiTietDal.Insert(thuNoChiTiet);
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