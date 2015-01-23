<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuNo.ascx.cs" Inherits="lib_ui_ThuNo_ThuNo" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/ChamCong/ThuNo-List.ascx" TagPrefix="uc1" TagName="ThuNoList" %>

<div class="panel panel-default ThuNo-Pnl-Add" 
    data-url="/lib/ajax/ThuNo/default.aspx"
    data-success="/lib/pages/ThuNo/Add.aspx?ID="
    data-list="/lib/pages/ThuNo/"
    >
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="STTBX" class="col-sm-1 col-xs-2 control-label">Số:</label>
                <div class="col-sm-3 col-xs-4">
                    <div class="input-group">
                        <input type="text" name="STTBX" disabled id="STTBX" value="<%=Item.STTBX.SttbxStr() %>" class="form-control" />
                        <span class="input-group-addon">/</span>
                        <input type="text" name="STTALL" disabled id="STTALL" value="<%=Item.STTALL.SttAllStr() %>" class="form-control" />
                    </div>
                </div>
                <label for="Ngay" class="col-sm-1 control-label">Ngày:</label>
                <div class="col-sm-2">
                    <div id="NgayPicker" class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.Ngay == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.Ngay.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control Ngay" 
                            id="Ngay" 
                            name="Ngay" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                <label for="XE_BienSo" class="col-sm-1 control-label">Xe:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/Xe/Default.aspx" data-refId="XE_ID" class="form-control form-autocomplete-input-ThuNo-ChonXe XE_BienSo" name="XE_BienSo" id="XE_BienSo" value="<%=Item.XE_BienSo %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control XE_ID" name="XE_ID" id="XE_ID" value="<%=Item.XE_ID %>"/>
                    </div>
                </div>
            </div>
            <div class="ThuNo-ChamCong-Pnl" data-url="/lib/ajax/ChamCong/Default.aspx">
                <uc1:ThuNoList runat="server" ID="ThuNoList" />
            </div>
            <div class="form-group">
                <label for="Tien" class="col-sm-1 control-label">Phải thu:</label>
                <div class="col-sm-3">
                    <input type="text" style="text-align: right;" name="Tien" id="Tien" value="<%=Item.Tien %>" class="form-control input-lg TienPhaiThu money-input">
                </div>                      
            </div>
            <%if (!string.IsNullOrEmpty(Id)){ %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.NguoiTao %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>
            <%} %>
            <p class="alert alert-danger" style="display: none;"></p>
            <p class="alert alert-success" style="display: none;"></p>
        </div>
        
    
    </div>
    
    

    <div class="panel-footer">
        <a href="/lib/pages/ThuNo/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
            <a href="/lib/pages/ThuNo/Add.aspx" class="btn btn-success">Thêm</a>
            <%if(Item.NguoiTao == Security.Username){ %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%}
        else
        {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
        <%} %>
    </div>
</div>