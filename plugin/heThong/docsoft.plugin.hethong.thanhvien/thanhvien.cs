using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
using System.Data.SqlClient;
using linh.core.dal;
[assembly: WebResource("docsoft.plugin.hethong.thanhvien.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.thanhvien.htm.htm", "text/html", PerformSubstitution = true)]
namespace docsoft.plugin.hethong.thanhvien
{
    public class Class1:docPlugUI
    {
        delegate void sendEmailDelegate(string[] _email,string _title,string _body);
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _CQ_ID = Request["CQ_ID"];
            string _Username = Request["Username"];
            string _Password = Request["Password"];
            string _Pwd = Request["Pwd"];
            string _Ten = Request["Ten"];
            string _Khoa = Request["Khoa"];
            string _Luong = Request["Luong"];
            string _q = Request["q"];
            string _Anh = Request["Anh"];
            string _Loai = Request["Loai"];
            string _ThuKy = Request["ThuKy"];
            string _refUsername = Request["refUsername"];
            string _Email = Request["Email"];
            string _Captcha = Request["Captcha"];
            string _Mobile = Request["Mobile"];
            string _DiaChi = Request["DiaChi"];
            string _MoTa = Request["MoTa"];
            string _Loai_Ten = Request["Loai_Ten"];
            string _CQ_Ma = Request["CQ_Ma"];
            string TVDV_ID = Request["TVDV_ID"];
            string _Lang= Request["Lang"];
            #endregion
            //if (!Security.IsAuthenticated())
            //{
            //    Response.End();
            //}
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    Pager<Member> PagerGet = MemberDal.pagerAllChildByUsername("", false, "MEM_" + jgrsidx + " " + jgrsord, Security.Username, _CQ_ID, _q, Request["rows"]);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (Member item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,item.Ten
                            , item._CoQuan.Ten
                            , item.Loai_Ten
                            ,item.Email
                            ,item.Mobile
                            , item.Username
                            ,item.Password.Length > 2 ? item.Password.Substring(0,item.Password.Length-2) : ""
                            , item.Active.ToString()
                            , item.NguoiTao
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getpid":
                    #region lấy danh sách cho autocomplete
                    Pager<Member> PagerGetPid = MemberDal.pagerAllChildByUsername("", true, null, string.IsNullOrEmpty(Security.Username) ? "sspa" : Security.Username, null, _q, "20");
                    sb.Append(JavaScriptConvert.SerializeObject(PagerGetPid.List));
                    break;
                    #endregion
                case "GetLamDichVuList":
                    #region lấy danh sách cho autocomplete
                    var listLamDichVu = MemberDal.SelectLamDichVu(TVDV_ID, "sspa");
                    sb.Append(JavaScriptConvert.SerializeObject(listLamDichVu));
                    break;
                    #endregion
                case "getpuse":
                    #region lấy danh sách cho autocomplete
                    Pager<Member> PagerGetPues = MemberDal.pagerAllByUsername("", true, null, Security.Username, null, _q, "20");
                    sb.Append(JavaScriptConvert.SerializeObject(PagerGetPues.List));
                    break;
                    #endregion
                case "SelectByNodeAndWfId":
                    #region lấy danh sách cho autocomplete
                    string Username = Security.Username;
                    //if (Request["WF_ID"] == "4" && string.IsNullOrEmpty(Request["NODE_ID"]))
                    //{
                    //    sb.Append(JavaScriptConvert.SerializeObject(MemberDal.SelectLanhDaoByCQMa("1")));
                    //}
                    //else
                    //{
                    //    if (!string.IsNullOrEmpty(_CQ_ID))
                    //    {
                    //        MemberCollection mem = MemberDal.SelectLanhDaoByCQMa(_CQ_ID);
                    //        foreach (Member m in mem)
                    //        {
                    //            Username = m.Username;
                    //            break;
                    //        }
                    //    }
                        sb.Append(JavaScriptConvert.SerializeObject(MemberDal.SelectByNodeAndWfId(Request["NODE_ID"], Request["WF_ID"], _q, "20", Username)));
                    //}
                    break;
                    #endregion
                case "del":
                    #region xóa
                    MemberDal.DeleteByIdList(Request["ID"]);
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(MemberDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "editX":
                    #region editX
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append(MemberDal.SelectById(Convert.ToInt32(_ID)).Loai.ToString());
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    Member ItemSave = new Member();
                    if (string.IsNullOrEmpty(_Username))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = MemberDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        if (MemberDal.ValidEmailUsername(_Email, _Username) != "-1" 
                            || MemberDal.ValidEmailUsername(_Email, _Username) != (string.IsNullOrEmpty(_ID) ? "-1" : _ID))
                        {
                            sb.Append("0");
                            break;
                        }
                    }
                    ItemSave.Luong = Convert.ToDouble(_Luong);
                    ItemSave.Anh = _Anh;
                    ItemSave.CQ_ID = Convert.ToInt32(_CQ_ID);
                    ItemSave.DiaChi = string.Empty;
                    ItemSave.Email = _Email;
                    ItemSave.Ho = string.Empty;
                    ItemSave.Khoa = Convert.ToBoolean(_Khoa);
                    ItemSave.Loai = Convert.ToInt32("0");
                    ItemSave.Mobile = _Mobile;
                    ItemSave.Mota = string.Empty;
                    ItemSave.NgayCapNhat = DateTime.Now;
                    ItemSave.NguoiTao = Security.Username;
                    ItemSave.RefUsername = _refUsername;
                    ItemSave.Ten = _Ten;
                    ItemSave.Loai_Ten = _Loai_Ten;
                    ItemSave.ThuKy = Convert.ToBoolean(_ThuKy);
                    ItemSave.XacNhan = false;                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        if (!string.IsNullOrEmpty(_Password))
                        {
                            //ItemSave.Password = maHoa.EncryptString(_Password, _Username);
                            ItemSave.Password = maHoa.MD5Encrypt(_Password);
                        }
                        ItemSave = MemberDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NgayTao = DateTime.Now;
                        //ItemSave.Password = maHoa.EncryptString(_Password, _Username);
                        ItemSave.Password = maHoa.MD5Encrypt(_Password);
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave.Username = _Username;
                        ItemSave = MemberDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "sendmail":
                    #region gửi email
                    if (!string.IsNullOrEmpty(_Email))
                    {
                        string[] _email = _Email.Split(new char[] { ',' });
                        sendEmailDelegate _send = new sendEmailDelegate(sendMail);
                        //_send.BeginInvoke(_email, _Ten, _MoTa, null, null);
                        sb.Append("1");
                    }
                    else
                    {
                        sb.Append("0");
                    }
                    break;
                    #endregion
                case "getRoles":
                #region lấy quyền của thành viên
                    if (!string.IsNullOrEmpty(_Username))
                    {
                        sb.AppendFormat(getRoleByUsername(_Username));
                    }
                    break;
                #endregion
                case "saveRoles":
                #region lưu quyền
                    if (!string.IsNullOrEmpty(_Username))
                    {
                        string roleList = Request["roleList"];
                        if (!string.IsNullOrEmpty(roleList))
                        {
                            MemberRoleDal.UpdateRoleListUsername(roleList, _Username);
                        }
                    }
                    break;
                #endregion
                case "SelectLanhDaoByCQID":
                #region lấy lãnh đạo theo cơ quan
                    if (!string.IsNullOrEmpty(_CQ_ID))
                    {
                        MemberCollection PG = MemberDal.SelectLanhDaoByCQID(_CQ_ID);
                        sb.Append(JavaScriptConvert.SerializeObject(PG));
                    }
                    break;
                #endregion  
                case "SelectLanhDaoVanBanDi":
                    #region lấy lãnh đạo theo cơ quan
                    MemberCollection _SelectLanhDaoVanBanDi = MemberDal.SelectLanhDaoVanBanDi();
                    sb.Append(JavaScriptConvert.SerializeObject(_SelectLanhDaoVanBanDi));
                    break;
                    #endregion  
                case "SelectLanhDaoByMaCQ":
                    #region tim lanh dao theo ma co quan
                    MemberCollection _SelectLanhDaoByMaCoQuan = MemberDal.SelectLanhDaoByCQMa(_CQ_Ma);
                    sb.Append(JavaScriptConvert.SerializeObject(_SelectLanhDaoByMaCoQuan));
                    break;
                    #endregion
                case "ValidateEmail":
                    #region tim lanh dao theo ma co quan
                    if (!string.IsNullOrEmpty(_Email))
                    {
                        if (MemberDal.ValidEmail(_Email))
                        {
                            sb.Append("1");
                        }
                        else
                        {
                            sb.Append("0");
                        }
                    }
                    break;
                    #endregion
                case "ValidateCaptcha":
                    #region tim lanh dao theo ma co quan
                    if (!string.IsNullOrEmpty(_Captcha))
                    {
                        if (Session["capcha"] != null)
                        {
                            if (Session["capcha"].ToString() == _Captcha)
                            {
                                sb.Append("1");
                            }
                            else
                            {
                                sb.Append("0");
                            }
                        }
                        else
                        {
                            sb.Append("0");
                        }
                    }
                    else
                    {
                        sb.Append("0");
                    }
                    break;
                    #endregion
                case "cungDonVi":
                    #region cungDonVi : Lấy thành viên cùng đơn vị
                    sb.Append(JavaScriptConvert.SerializeObject(MemberDal.SelectCungDonVi(Security.Username)));
                    break;
                    #endregion
                
                case "dangKyCaNhan":
                    #region dangKyCaNhan
                    using (SqlConnection con = DAL.con())
                    {
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        try
                        {
                            CoQuan ItemCq = CoQuanDal.SelectByMa(tran, "RAOVAT");
                            //Member ItemMe = MemberDal.Insert(tran, ItemCq.ID, _Ten, _Email, _Mobile, _DiaChi, maHoa.EncryptString(_Pwd, _Email));
                            Member ItemMe = MemberDal.Insert(tran, ItemCq.ID, _Ten, _Email, _Mobile, _DiaChi, maHoa.MD5Encrypt(_Password));
                            MemberRole ItemMR = MemberRoleDal.InsertDangKyCaNhan(tran, ItemCq.ID, _Email);                           
                            Security.Login(_Email, "true");
                            sb.Append("1");
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            Security.LogOut();
                            sb.Append(ex.ToString());
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                    
                    break;
                    #endregion
                case "dangKyGh":
                    #region dangKyGh
                    using (SqlConnection con = DAL.con())
                    {
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        try
                        {
                            CoQuan ItemCqP = CoQuanDal.SelectByMa(tran, "GIANHANG");
                            CoQuan ItemCq = CoQuanDal.Insert(tran, ItemCqP.ID, _Ten, _Email);
                            //Member ItemMe = MemberDal.Insert(tran, ItemCq.ID, _Ten, _Email, _Mobile, _DiaChi, maHoa.EncryptString(_Pwd, _Email));
                            Member ItemMe = MemberDal.Insert(tran, ItemCq.ID, _Ten, _Email, _Mobile, _DiaChi, maHoa.MD5Encrypt(_Pwd));
                            MemberRoleDal.InsertDangKyGianHang(tran, ItemCq.ID, _Email, _Ten,_Lang);
                            //LienHe itemLH = LienHeDal.InsertLH(tran, ItemMe.RowId.ToString());
                            Security.Login(_Email, "true");
                            sb.Append("1");
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            Security.LogOut();                             
                            sb.Append(ex.ToString());
                        }
                        finally
                        {
                            con.Close();
                        }
                    }

                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.thanhvien.JScript1.js"));
                    break;
                    #endregion
                default://Session["capcha"]
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-thanhvien"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""thanhvienmdl-addBtn"" href=""javascript:thanhvien.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""thanhvienmdl-editBtn"" href=""javascript:thanhvien.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""thanhvienmdl-delBtn"" href=""javascript:thanhvien.del();"">Xóa</a>
<a class=""mdl-head-btn mdl-head-sendmail"" id=""thanhvienmdl-emailBtn"" href=""javascript:thanhvien.sendmail();"">Email</a>
<a class=""mdl-head-btn mdl-head-resetPwd"" id=""thanhvienmdl-reSendPwdBtn"" href=""javascript:thanhvien.resendPwd();"">Cấp mật khẩu</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterThanhVienByCQID""/>
</span>
</div>
<table id=""thanhvienmdl-List"" class=""mdl-list"">
</table>
<div id=""thanhvienmdl-Pager""></div><div class=""sub-mdl""><ul><li><a id=""thanhvienmdl-rolemdl-subMdlBtn"" href=""#mdl-1"">Quyền</a></li></ul><div id=""mdl-1"">
<div class=""sub-mdl-list"" id=""thanhvienmdl-rolemdl-mdl""></div>
</div></div>");                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.thanhvien.JScript1.js")
                        , "{thanhvien.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));                    
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        void sendMail(string[] _email, string _title, string _body)
        {
            omail.Send(_email, _title, _body, "gigawebhome@gmail.com", "Văn phòng điện tử", "25111987");
        }
        string getRoleByUsername(string _Username)
        {
            StringBuilder sb = new StringBuilder();
            RoleCollection list = RoleDal.SelectAllByUsernameCQ(_Username);
            if (list.Count > 0)
            {
                foreach (Role item in list)
                {
                    sb.AppendFormat(@"<input type=""checkbox"" _role=""{0}"" _username=""{1}"" {2} > {3}<br/>"
                        ,item.ID,_Username,item.Active ? "checked=\"checked\"" : "",item.Ten);
                }
            }
            else
            {
                sb.Append("0");
            }
            return sb.ToString();
        }
        public string ChucVu(int Loai)
        {
            switch (Loai)
            {
                case 1:
                    return "Lãnh đạo Bộ";
                case 2:
                    return "Lãnh đạo Cục/Vụ/Tổng cục";
                case 3:
                    return "Trưởng phó phòng";
                case 4:
                    return "Chuyên viên";
                default:
                    return "Văn thư";
            }
        }
    }
}
