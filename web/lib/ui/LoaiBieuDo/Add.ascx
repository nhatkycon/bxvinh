<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_LoaiBieuDo_Add" %>
<%@ Import Namespace="docsoft" %>
<div class="panel panel-default Normal-Pnl-Add" 
    data-url="/lib/ajax/LoaiBieuDo/default.aspx"
    data-success="/lib/pages/LoaiBieuDo/Add.aspx?ID="
    data-list="/lib/pages/LoaiBieuDo/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/LoaiBieuDo/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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
                <label for="Ten" class="col-sm-2 control-label">Tên:</label>
                <div class="col-sm-10">
                    <input type="text" name="Ten" id="Ten" value="<%=Item.Ten %>" class="form-control Ten">
                </div>
            </div>
            <div class="form-group">
                <label for="SoTuyenKhoan" class="col-sm-2 control-label">Số chuyến/ tháng:</label>
                <div class="col-sm-4">
                    <input type="text" name="SoTuyenKhoan" id="SoTuyenKhoan" value="<%=Item.SoTuyenKhoan %>" class="form-control SoTuyenKhoan">
                </div>
                <label for="CachNgay" class="col-sm-2 control-label">Số ngày:</label>
                <div class="col-sm-4">
                    <input type="text" name="CachNgay" id="CachNgay" value="<%=Item.CachNgay %>" class="form-control CachNgay">
                </div>
            </div>
            <div class="form-group">
                <label for="KhoanTuyen" class="col-sm-2 control-label">Khoán tuyến/ tháng:</label>
                <div class="col-sm-2">
                    <%if (Item.KhoanTuyen)
                    {%>
                        <input class="KhoanTuyen input-sm" id="KhoanTuyen" checked="checked" name="KhoanTuyen" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="KhoanTuyen input-sm" id="KhoanTuyen" name="KhoanTuyen" type="checkbox"/>
                    <% } %>
                </div>
                <label for="HaiTuyenTrenNgay" class="col-sm-2 control-label">2 tuyến/ ngày:</label>
                <div class="col-sm-2">
                    <%if (Item.HaiTuyenTrenNgay)
                    {%>
                        <input class="HaiTuyenTrenNgay input-sm" id="HaiTuyenTrenNgay" checked="checked" name="HaiTuyenTrenNgay" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="HaiTuyenTrenNgay input-sm" id="HaiTuyenTrenNgay" name="HaiTuyenTrenNgay" type="checkbox"/>
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
            <a href="/lib/pages/LoaiBieuDo/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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