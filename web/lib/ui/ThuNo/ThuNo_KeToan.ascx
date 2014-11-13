<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuNo_KeToan.ascx.cs" Inherits="lib_ui_ThuNo_ThuNo_KeToan" %>
<%@ Register TagPrefix="uc1" TagName="ThuNoList" Src="~/lib/ui/ChamCong/ThuNo-List.ascx" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="panel panel-default ThuNo-Pnl-Add" 
    data-url="/lib/ajax/ThuNo/default.aspx"
    data-success="/lib/pages/ThuNo/Add.aspx?ID="
    data-list="/lib/pages/ThuNo/"
    >
    <div class="panel-heading">
        <a href="/lib/pages/ThuNo/KeToan.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%if (!Item.DaThu)
        {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Thanh toán</a>
        <%} %>
        <a href="/lib/pages/ThuNo/In/PhieuThuNo.aspx?ID=<%=Item.ID %>" 
            target="_blank" class="btn printBtn btn-lg btn-primary">In</a>             
    </div>
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
                    <p class="form-control-static">
                        <%=Item.Ngay.NgayVn() %>
                    </p>
                </div>
                <label for="XE_BienSo" class="col-sm-1 control-label">Xe:</label>
                <div class="col-sm-2">
                    <p class="form-control-static">
                        <%=Item.XE_BienSo %>
                    </p>
                </div>
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
        <a href="/lib/pages/ThuNo/KeToan.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%if (!Item.DaThu)
        {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Thanh toán</a>
        <%} %>
        <a href="/lib/pages/ThuNo/In/PhieuThuNo.aspx?ID=<%=Item.ID %>" 
            target="_blank" class="btn printBtn btn-lg btn-primary">In</a>
    </div>
</div>