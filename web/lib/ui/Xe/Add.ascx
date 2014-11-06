<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_Xe_Add" %>
<%@ Import Namespace="docsoft" %>

<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add" 
    data-url="/lib/ajax/Xe/default.aspx"
    data-success="/lib/pages/Xe/Add.aspx?ID="
    data-list="/lib/pages/Xe/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/Xe/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <% }else{ %>
            <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
            <%if (Item.Username == Security.Username)
              { %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%}
        else
        {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
        <%} %>                    
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            
            

            <div class="form-group">
                <label for="BienSo_Chu" class="col-sm-2 col-xs-4 control-label">Biển số:</label>
                <div class="col-sm-5 col-xs-4">
                    <input type="text" name="BienSo_Chu" id="BienSo_Chu" value="<%=Item.BienSo_Chu %>" class="form-control BienSo_Chu">
                </div>
                <div class="col-sm-5 col-xs-4">
                    <input type="text" name="BienSo_So" id="BienSo_So" value="<%=Item.BienSo_So %>" class="form-control BienSo_So">
                </div>
            </div>

           <div class="form-group">
                <label for="LOAIXE_Ten" class="col-sm-2 control-label">Loại xe:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/LoaiXe/Default.aspx" data-refId="LOAIXE_ID" class="form-control form-autocomplete-input LOAIXE_Ten" name="LOAIXE_Ten" id="LOAIXE_Ten" value="<%=Item.LOAIXE_Ten %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control LOAIXE_ID" name="LOAIXE_ID" id="LOAIXE_ID" value="<%=Item.LOAIXE_ID %>"/>
                    </div>
                </div>
                <label for="TUYEN_Ten" class="col-sm-2 control-label">Tuyến xe:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/Tuyen/Default.aspx" data-refId="TUYEN_ID" class="form-control form-autocomplete-input TUYEN_Ten" name="TUYEN_Ten" id="TUYEN_Ten" value="<%=Item.TUYEN_Ten %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control TUYEN_ID" name="TUYEN_ID" id="TUYEN_ID" value="<%=Item.TUYEN_ID %>"/>
                    </div>
                </div>
               <label for="DONVI_Ten" class="col-sm-2 control-label">Nhà xe:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/DonVi/Default.aspx" data-refId="DONVI_ID" class="form-control form-autocomplete-input DONVI_Ten" name="DONVI_Ten" id="DONVI_Ten" value="<%=Item.DONVI_Ten %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control DONVI_ID" name="DONVI_ID" id="DONVI_ID" value="<%=Item.DONVI_ID %>"/>
                    </div>
                </div>
            </div>
            
            <div class="form-group">
                <label for="TuyenCoDinh" class="col-sm-2 control-label">Tuyến cố định:</label>
                <div class="col-sm-2">
                    <div id="TuyenCoDinhPicker" class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.TuyenCoDinh == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.TuyenCoDinh.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control TuyenCoDinh" 
                            id="TuyenCoDinh" 
                            name="TuyenCoDinh" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                
                <label for="LuuHanh" class="col-sm-2 control-label">Lưu hành:</label>
                <div class="col-sm-2">
                    <div id="LuuHanhPicker" class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.LuuHanh == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.LuuHanh.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control LuuHanh" 
                            id="LuuHanh" 
                            name="LuuHanh" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                
                <label for="BaoHiem" class="col-sm-2 control-label">Bảo hiểm:</label>
                <div class="col-sm-2">
                    <div id="BaoHiemPicker" class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.BaoHiem == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.BaoHiem.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control BaoHiem" 
                            id="BaoHiem" 
                            name="BaoHiem" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>

            </div>
            
            
            <div class="form-group">
                <label for="Ghe" class="col-sm-2 control-label">Số ghế:</label>
                <div class="col-sm-2">
                    <input type="text" name="Ghe" id="Ghe" value="<%=Item.Ghe %>" class="form-control Ghe">
                </div>
                <label for="SoKhach" class="col-sm-2 control-label">Số khách:</label>
                <div class="col-sm-2">
                    <input type="text" name="SoKhach" id="SoKhach" value="<%=Item.SoKhach %>" class="form-control SoKhach">
                </div>
                <label for="MucPhi" class="col-sm-2 control-label">Mức phí:</label>
                <div class="col-sm-2">
                    <input type="text" name="MucPhi" id="MucPhi" value="<%=Item.MucPhi %>" class="form-control MucPhi money-input">
                </div>
            </div>
            
            
            <div class="form-group">
                <label for="GiaVe" class="col-sm-2 control-label">Giá vé:</label>
                <div class="col-sm-2">
                    <input type="text" name="GiaVe" id="GiaVe" value="<%=Item.GiaVe %>" class="form-control GiaVe money-input">
                </div>
                <label for="GioXuatBen" class="col-sm-2 control-label">Giờ xuất bến:</label>
                <div class="col-sm-2">
                    <div class="input-group bootstrap-timepicker">
                        <input type="text" name="GioXuatBen" id="GioXuatBen" value="<%=Item.GioXuatBen %>" class="form-control GioXuatBen timePicker-input">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                    </div>
                </div>
                <label for="BIEUDO_Ten" class="col-sm-2 control-label">Loại biểu đồ:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/LoaiBieuDo/Default.aspx" data-refId="BIEUDO_ID" class="form-control form-autocomplete-input BIEUDO_Ten" name="BIEUDO_Ten" id="Text1" value="<%=Item.BIEUDO_Ten %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control BIEUDO_ID" name="BIEUDO_ID" id="BIEUDO_ID" value="<%=Item.BIEUDO_ID %>"/>
                    </div>
                </div>
            </div>
            
            <div class="form-group">
                <label for="Ghe" class="col-sm-2 control-label">Năm S/X:</label>
                <div class="col-sm-2">
                    <input type="text" name="NamSanXuat" id="NamSanXuat" value="<%=Item.NamSanXuat %>" class="form-control NamSanXuat">
                </div>
                <label for="XeTai" class="col-sm-2 control-label">Xe tải:</label>
                <div class="col-sm-2">
                    <%if (Item.XeTai)
                    {%>
                        <input class="XeTai input-sm" id="XeTai" checked="checked" name="XeTai" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="XeTai input-sm" id="XeTai" name="XeTai" type="checkbox"/>
                    <% } %>
                </div>
                <label for="Khoa" class="col-sm-2 control-label">Khóa:</label>
                <div class="col-sm-2">
                    <%if (Item.Khoa)
                    {%>
                        <input class="Khoa input-sm" id="Khoa" checked="checked" name="Khoa" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="Khoa input-sm" id="Khoa" name="Khoa" type="checkbox"/>
                    <% } %>
                </div>
            </div>
            
            
            <div class="form-group">
                <label for="XeVangLai" class="col-sm-2 control-label">Vãng lai:</label>
                <div class="col-sm-2">
                    <%if (Item.XeVangLai)
                    {%>
                        <input class="XeVangLai input-sm" id="XeVangLai" checked="checked" name="XeVangLai" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="XeVangLai input-sm" id="Checkbox1" name="XeVangLai" type="checkbox"/>
                    <% } %>
                </div>
                <label for="ChuaDangKy" class="col-sm-2 control-label">Đã đăng ký:</label>
                <div class="col-sm-2">
                    <%if (!Item.ChuaDangKy)
                    {%>
                        <input class="ChuaDangKy input-sm" id="ChuaDangKy" checked="checked" name="ChuaDangKy" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="ChuaDangKy input-sm" id="ChuaDangKy" name="ChuaDangKy" type="checkbox"/>
                    <% } %>
                </div>
            </div>
            <%if (!string.IsNullOrEmpty(Id)){ %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.Username %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>
            <%} %>
            <p class="alert alert-danger" style="display: none;"></p>
            <p class="alert alert-success" style="display: none;"></p>
        </div>
        
    
    </div>
    
    

    <div class="panel-footer">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/Xe/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <% }else{ %>
            <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
           
            <%if(Item.Username == Security.Username){ %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%}
        else
        {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
        <%} %>
    </div>
</div>
<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>

<%if(!string.IsNullOrEmpty(Id))
  {%>
  <script>
      $(function () {
      });
  </script>    
<%  } %>