using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using linh.frm;
using linh.json;
using linh.common;
using System.IO;
using linh.controls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using linh.core.dal;
using System.Diagnostics;
using System.Drawing;
using System.Web.UI.HtmlControls;
using docsoft;
using docsoft.entities;

namespace linh.httpModule
{
    public class defaultHandle : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public bool IsReusable
        {
            get
            {
                return true;
            }

        }

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string act = context.Request["act"];
            string rqPlug = context.Request["rqPlug"];
            string imgSaveLoc = context.Server.MapPath("~/lib/up/i/");
            string imgTemp = context.Server.MapPath("~/lib/up/temp/");
            string docTemp = context.Server.MapPath("~/lib/up/d/");
            string imgSaveTintuc = context.Server.MapPath("~/lib/up/tintuc/");
            string imgSaveSanPham = context.Server.MapPath("~/lib/up/sanpham/");
            string imgSaveQuangCao = context.Server.MapPath("~/lib/up/quangcao/");
            string imgSaveKTNN = context.Server.MapPath("~/lib/up/KTNN/");

            string _height = context.Request["height"];
            string _width = context.Request["width"];
            string _PRowIdSP = context.Request["PRowIdSP"];
            switch (act)
        {
            case "loadPlug":
                #region loadPlug: nap plug
                if (rqPlug != null)
                {
                    sb.Append(PlugHelper.RenderHtml(rqPlug));
                }
                rendertext(sb);
                break;
                #endregion
            case "upload":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveLoc + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveLoc + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, imgten);
                    context.Request.Files[0].SaveAs(imgSaveLoc + imgten + "full" + img.Ext);

                    img.Crop(420, 560);
                    img.Save(imgSaveLoc + imgten + "420x560" + img.Ext);

                    img.Crop(240, 180);
                    img.Save(imgSaveLoc + imgten + "240x180" + img.Ext);

                    img.Crop(100, 100);
                    img.Save(imgSaveLoc + imgten + "100x100" + img.Ext);

                    img.Crop(50, 50);
                    img.Save(imgSaveLoc + imgten + img.Ext);

                    rendertext(imgten + img.Ext);
                }

                break;
                #endregion
            case "uploadQuangCao":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveQuangCao + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveQuangCao + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                    img.Save(imgSaveQuangCao + imgten + "source" + img.Ext);
                    img.Crop(int.Parse(_width), int.Parse(_height));
                    img.Save(imgSaveQuangCao + imgten + img.Ext);
                    rendertext(imgten + img.Ext);
                }

                break;
                #endregion
            case "uploadSanPham":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveSanPham + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveSanPham + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                    img.Crop(400, 400);
                    img.Save(imgSaveSanPham + imgten + "400x400" + img.Ext);
                    img.Crop(400, 300);
                    img.Save(imgSaveSanPham + imgten + "400x300" + img.Ext);
                    img.Crop(200, 200);
                    img.Save(imgSaveSanPham + imgten + "200x200" + img.Ext);
                    img.Crop(90, 90);
                    img.Save(imgSaveSanPham + imgten + img.Ext);
                    rendertext(imgten + img.Ext);
                }

                break;
                #endregion
            case "uploadTintuc":
                #region upload ?nh
                if (Security.IsAuthenticated())
                {
                    if (context.Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                                if (File.Exists(imgSaveTintuc + context.Request["oldFile"]))
                                {
                                    File.Delete(imgSaveTintuc + context.Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        context.Request.Files[0].SaveAs(imgSaveTintuc + imgten + "full" + img.Ext);
                        img.Crop(180, 120);
                        img.Save(imgSaveTintuc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadKTNN":
                #region upload ?nh
                if (Security.IsAuthenticated())
                {
                    if (context.Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                                if (File.Exists(imgSaveKTNN + context.Request["oldFile"]))
                                {
                                    File.Delete(imgSaveKTNN + context.Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(730, 600);
                        img.Save(imgSaveKTNN + imgten + "730x600" + img.Ext);
                        img.Crop(420, 280);
                        img.Save(imgSaveKTNN + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveKTNN + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadFlash":
                #region upload flash
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveLoc + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveLoc + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    if (Path.GetExtension(context.Request.Files[0].FileName).ToLower() == ".swf")
                    {
                        string flash = Guid.NewGuid().ToString();

                        context.Request.Files[0].SaveAs(context.Server.MapPath("~/lib/up/v/") + flash + Path.GetExtension(context.Request.Files[0].FileName));
                        rendertext(flash + Path.GetExtension(context.Request.Files[0].FileName));
                    }
                    else
                    {
                        ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(420, 280);
                        img.Save(imgSaveLoc + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveLoc + imgten + img.Ext);
                        img.Crop(370, 90);
                        img.Save(imgSaveLoc + imgten + "370x90" + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }

                break;
                #endregion
            case "uploadFull":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveLoc + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveLoc + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                    img.Save(imgSaveLoc + imgten + img.Ext);
                    rendertext(imgten + img.Ext);
                }
                break;
                #endregion
            case "uploadfileDkLuong":
                #region upload tài li?u
                //if (!loggedIn) rendertext("403");
                if (context.Request.Files[0] != null)
                {
                    string foldername = Guid.NewGuid().ToString().Replace("-", "");
                    string filename = Path.GetFileNameWithoutExtension(context.Request.Files[0].FileName);
                    string fileType = Path.GetExtension(context.Request.Files[0].FileName);
                    Directory.CreateDirectory(docTemp + foldername);
                    context.Request.Files[0].SaveAs(docTemp + foldername + "/" + filename + fileType);
                    //context.Request.Files[0].SaveAs(docTemp +  filename + fileType);
                    Files item = new Files();
                    item.Download = 0;
                    item.MimeType = fileType;
                    item.NgayTao = DateTime.Now;
                    item.NguoiTao = Security.Username;
                    item.Path = filename;
                    item.PID = Guid.NewGuid();
                    item.RowId = Guid.NewGuid();
                    item.Size = context.Request.Files[0].ContentLength;
                    item.Ten = filename;
                    item.ThuMuc = foldername;
                    item.VB_ID = 0;
                    item = FilesDal.Insert(item);
                    rendertext(item.ID.ToString());
                    
                }
                break;
                #endregion
            case "download":
                string _F_ID = context.Request["ID"];
                if (!string.IsNullOrEmpty(_F_ID))
                {
                    Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                    context.Response.Buffer = true;
                    context.Response.Clear();
                    context.Response.AddHeader("content-disposition", "attachment; filename=\"" + item.Ten + item.MimeType + "\"");
                    context.Response.ContentType = "octet/stream";
                    //Response.ContentType = "application/ms-word";
                    context.Response.WriteFile(context.Server.MapPath("~/lib/up/d/") + item.ThuMuc + "/" + item.Path + item.MimeType);
                }
                break;
           

            case "MultiuploadImg":
                #region UploadAnh
                if (context.Request.Files[0] != null)
                {
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                    string foldername = Guid.NewGuid().ToString().Replace("-", "");
                    string imgten = Guid.NewGuid().ToString();
                    Directory.CreateDirectory(imgSaveSanPham + foldername);

                    context.Request.Files[0].SaveAs(imgSaveSanPham + foldername + "/" + imgten + "full" + img.Ext);
                    img.Crop(400, 400);

                    img.Save(imgSaveSanPham + foldername + "/" + imgten + "400x400" + img.Ext);
                    img.Crop(75, 75);
                    
                    img.Save(imgSaveSanPham + foldername + "/" + imgten + img.Ext);
                    Files item = new Files();
                    item.Download = 0;
                    item.MimeType = img.Ext;
                    item.NgayTao = DateTime.Now;
                    item.NguoiTao = Security.Username;
                    item.Path = imgten + img.Ext;
                    item.PID = new Guid(_PRowIdSP);
                    item.RowId = Guid.NewGuid();
                    item.Size = context.Request.Files[0].ContentLength;
                    item.Ten = imgten;
                    item.ThuMuc = foldername;
                    item.VB_ID = 0;
                    item = FilesDal.Insert(item);
                    rendertext(sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item)));
                }
                break;
                #endregion
            case "loadPlugDirect":
                if (!string.IsNullOrEmpty(rqPlug))
                {
                    string _IPlugType = rqPlug;
                    Type type = Type.GetType(_IPlugType);
                    IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
                    _IPlug.ImportPlugin();                    
                    UserControl uc = (UserControl)(_IPlug);
                    Page page = new Page();
                    page.EnableViewState = false;
                    HtmlForm form = new HtmlForm();
                    form.ID = "__t";
                    page.Controls.Add(form);
                    form.Controls.Add(uc);
                    StringWriter tw = new StringWriter();
                    HttpContext.Current.Server.Execute(page, tw, true);
                }
                break;
            case "capcha":
                #region capcha
                string _capchaCode = CaptchaImage.GenerateRandomCode(CaptchaType.AlphaNumeric, 3);
                context.Session["capcha"] = _capchaCode;
                CaptchaImage c = new CaptchaImage(_capchaCode, 200, 50, "Tahoma", Color.White, Color.Orange);
                context.Response.ClearContent();
                context.Response.ContentType = "image/jpeg";
                MemoryStream ms = new MemoryStream();
                c.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                context.Response.OutputStream.Write(ms.ToArray(), 0, Convert.ToInt32(ms.Length));
                ms.Close();
                context.Response.End();
                break;
                #endregion
                default:
                #region macdinh
                context.Response.Write(DateTime.Now.ToString("hh:mm"));
                break;
                #endregion
        }
        }
        public void rendertext(StringBuilder sb)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(sb.ToString());
            c.Response.End();
        }
        public void rendertext(string txt)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(txt);
            c.Response.End();
        }

    }
    public class adminHtmlHandle : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public bool IsReusable
        {
            get
            {
                return true;
            }

        }

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string act = context.Request["act"];
            string rqPlug = context.Request["rqPlug"];
            string domain = string.Format("http://{0}{1}", context.Request.Url.Host, context.Request.IsLocal ? string.Format(":{0}{1}", context.Request.Url.Port, context.Request.ApplicationPath) : "");

         sb.AppendFormat(@"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""en"" lang=""en"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
<title>potbai.com - beta 01</title>
<link href=""{0}/lib/css/admin/redmond/admin.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""{0}/lib/js/jquery-1.4.2.min.js"" type=""text/javascript""></script>
<script src=""{0}/lib/js/jquery-ui-1.8.4.custom.min.js"" type=""text/javascript""></script>
<script src=""{0}/lib/js/jquery.layout.js"" type=""text/javascript""></script>
<script src=""{0}/lib/js/grid.locale-en.js"" type=""text/javascript""></script>
<script type=""text/javascript"">$.jgrid.no_legacy_api = true;$.jgrid.useJSON = true;$.jgrid.scrollOffset = 0;</script>
<script src=""{0}/lib/js/ui.multiselect.js"" type=""text/javascript""></script><script src=""{0}/lib/js/jquery.jqGrid.min.js"" type=""text/javascript""></script>
<!-- tree --><script src=""{0}/lib/js/jquery.hotkeys.js"" type=""text/javascript""></script><script src=""{0}/lib/js/jquery.cookie.js"" type=""text/javascript""></script><script src=""{0}/lib/js/jquery.jstree.js"" type=""text/javascript""></script><!--end tree-->
<script src=""{0}/lib/js/ckeditor/ckeditor.js"" type=""text/javascript""></script>
<script src=""{0}/lib/js/ckeditor/adapters/jquery.js"" type=""text/javascript""></script>
<script src=""{0}/lib/js/ckfinder/ckfinder.js"" type=""text/javascript""></script>
<script src=""{0}/lib/js/admin.js"" type=""text/javascript""></script>", domain);
            sb.Append("<script>$(function () { adm.preload(); });</script>");
            sb.Append(@"</head><body></body></html>");
            rendertext(sb);
        }
        public void rendertext(StringBuilder sb)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(sb.ToString());
            c.Response.End();
        }
        public void rendertext(string txt)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(txt);
            c.Response.End();
        }
        //hiennb
        

    }
}
