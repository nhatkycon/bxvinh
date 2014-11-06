<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_LaiXe_Add" %>
<%@ Import Namespace="docsoft" %>
<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add" 
    data-url="/lib/ajax/LaiXe/default.aspx"
    data-success="/lib/pages/LaiXe/Add.aspx?ID="
    data-list="/lib/pages/LaiXe/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/LaiXe/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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
                <label for="Ten" class="col-sm-2 col-xs-2 control-label">Tên:</label>
                <div class="col-sm-4 col-xs-4">
                    <input type="text" name="Ten" id="Ten" value="<%=Item.Ten %>" class="form-control Ten">
                </div>
                <label for="BangLai" class="col-sm-1 col-xs-2 control-label">Bằng:</label>
                <div class="col-sm-2 col-xs-2">
                    <input type="text" name="BangLai" id="BangLai" value="<%=Item.BangLai %>" class="form-control BangLai">
                </div>
                <label for="LoaiBang" class="col-sm-1 col-xs-2 control-label">Hạng:</label>
                <div class="col-sm-2 col-xs-2">
                    <input type="text" name="LoaiBang" id="LoaiBang" value="<%=Item.LoaiBang %>" class="form-control LoaiBang">
                </div>
            </div>

           <div class="form-group">
               <label for="DONVI_Ten" class="col-sm-2 control-label">Nhà xe:</label>
                <div class="col-sm-4">
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
                <label for="XE_BienSo" class="col-sm-1 control-label">Xe:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/Xe/Default.aspx" data-refId="XE_ID" class="form-control form-autocomplete-input XE_BienSo" name="XE_BienSo" id="XE_BienSo" value="<%=Item.XE_BienSo %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control XE_ID" name="XE_ID" id="XE_ID" value="<%=Item.XE_ID %>"/>
                    </div>
                </div>
               <label for="NgaySinh" class="col-sm-1 control-label">Ngày sinh:</label>
                <div class="col-sm-2">
                    <div id="NgaySinhPicker" class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgaySinh == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgaySinh.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgaySinh" 
                            id="NgaySinh" 
                            name="NgaySinh" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>

            </div>
            
            <div class="form-group">
                
                <label for="NgayHetHanBangLai" class="col-sm-2 control-label">Hạn bằng lái:</label>
                <div class="col-sm-2">
                    <div id="NgayHetHanBangLaiPicker" class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayHetHanBangLai == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgayHetHanBangLai.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayHetHanBangLai" 
                            id="NgayHetHanBangLai" 
                            name="NgayHetHanBangLai" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                
                
                <label for="NgayHetHanGiayKhamSucKhoe" class="col-sm-2 control-label">Hạn giấy khám:</label>
                <div class="col-sm-2">
                    <div id="NgayHetHanGiayKhamSucKhoePicker" class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayHetHanGiayKhamSucKhoe == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgayHetHanGiayKhamSucKhoe.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayHetHanGiayKhamSucKhoe" 
                            id="NgayHetHanGiayKhamSucKhoe" 
                            name="NgayHetHanGiayKhamSucKhoe" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>

                <label for="Khoa" class="col-sm-2 control-label">Khóa:</label>
                <div class="col-sm-2">
                    <%if (Item.Khoa)
                    {%>
                        <input class="Khoa input-sm" id="Khoa" checked="checked" name="Khoa" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="Khoa input-sm" id="Checkbox1" name="Khoa" type="checkbox"/>
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
            <a href="/lib/pages/LaiXe/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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