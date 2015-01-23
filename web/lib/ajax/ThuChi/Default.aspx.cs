using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_ThuChi_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loggedIn = Security.IsAuthenticated();

        var Id = Request["Id"];
        var PHOI_ID = Request["PHOI_ID"];
        var STTBX = Request["STTBX"];
        var STTALL = Request["STTALL"];
        var XE_ID = Request["XE_ID"];
        var Ngay = Request["Ngay"];
        var Tien = Request["Tien"];
        var XVB_ID = Request["XVB_ID"];

        var Inserted = string.IsNullOrEmpty(Id);

        switch (subAct)
        {
            case "save":

                #region save

                if (loggedIn)
                {
                    var Item = Inserted ? ThuChiDal.SelectByLastest(DAL.con(), Security.CqId) : ThuChiDal.SelectById(Convert.ToInt32(Id));

                    if(!string.IsNullOrEmpty(Tien))
                    {
                        Item.Tien = Convert.ToDouble(Tien);                        
                    }
                    Item.CQ_ID = Security.CqId;
                    if (!string.IsNullOrEmpty(PHOI_ID))
                    {
                        Item.PHOI_ID = Convert.ToInt64(PHOI_ID);
                        var phoi = PhoiDal.SelectById(Item.PHOI_ID);
                        Item.XE_ID = Convert.ToInt32(phoi.XE_ID);
                        
                    }
                    if (!string.IsNullOrEmpty(Ngay))
                    {
                        Item.Ngay = Convert.ToDateTime(Ngay, new CultureInfo("vi-vn"));
                    }
                    if (Inserted)
                    {
                        Item.NguoiTao = Security.Username;
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        
                    }
                    if(Inserted)
                    {
                        var giaoCa = GiaoCaDal.Current(Security.CqId, Security.Username);
                        Item.GIAOCA_ID = giaoCa.ID;
                        giaoCa.DoanhThu += Item.Tien;
                        giaoCa.NgayCapNhat = DateTime.Now;
                        GiaoCaDal.Update(giaoCa);
                    }
                    Item.NgayCapNhat = DateTime.Now;
                    Item.XVB_ID = Convert.ToInt64(XVB_ID);
                    Item = Inserted ? ThuChiDal.Insert(Item) : ThuChiDal.Update(Item);

                    if(Inserted)
                    {
                        if (!string.IsNullOrEmpty(XVB_ID))
                        {
                            var xvb = XeVaoBenDal.SelectById(Convert.ToInt64(XVB_ID));
                            xvb.TC_ID = Item.ID;
                            xvb.TrangThai = 800;
                            xvb.NguoiXuLyThanhToan = Security.Username;
                            xvb.NgayThanhToanXong = xvb.NgayCapNhat = DateTime.Now;
                            XeVaoBenDal.Update(xvb);
                        }
                        var chamCongByPhoiId = ChamCongDal.SelectByPhoiId(Item.PHOI_ID);
                        foreach (var item in chamCongByPhoiId)
                        {
                            item.NgayCapNhat = DateTime.Now;
                            item.Draff = false;
                            ChamCongDal.Update(item);
                        }
                    }

                    rendertext(Item.ID.ToString());
                }
                rendertext("0");
                break;

                #endregion

            case "remove":
                #region remove

                if (loggedIn)
                {
                    var Item = XeVaoBenDal.SelectById(Convert.ToInt64(Id));
                    if (Item.Username == Security.Username)
                    {
                        LaiXeDal.DeleteById(Item.ID);
                        rendertext("0");
                    }
                }
                rendertext("-1");
                break;

                #endregion
            case "getLatest":
                #region getLatest
                if (loggedIn)
                {
                    var item = ThuChiDal.SelectByLastest(DAL.con(), Security.CqId);
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(item)));
                }
                rendertext("-1");
                break;
                #endregion
            case "search":

                #region search

                #endregion

            default:
                break;
        }
    }
}