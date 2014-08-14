<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_LoaiXe_Add" %>
<%@ Import Namespace="docsoft" %>
<div class="panel panel-default Normal-Pnl-Add" 
    data-url="/lib/ajax/LoaiXe/default.aspx"
    data-success="/lib/pages/LoaiXe/Add.aspx?ID="
    data-list="/lib/pages/LoaiXe/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/LoaiXe/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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
                <label for="SoGhe" class="col-sm-2 control-label">Số ghế:</label>
                <div class="col-sm-10">
                    <input type="text" name="SoGhe" id="SoGhe" value="<%=Item.SoGhe %>" class="form-control SoGhe">
                </div>
            </div>
            
            <div class="form-group">
                <label for="MucThu" class="col-sm-2 control-label">Mức thu:</label>
                <div class="col-sm-10">
                    <input type="text" name="MucThu" id="MucThu" value="<%=Item.MucThu %>" class="form-control MucThu">
                </div>
            </div>
            <div class="form-group">
                <label for="BangLai" class="col-sm-2 control-label">Bằng lái:</label>
                <div class="col-sm-10">
                    <input type="text" name="BangLai" id="BangLai" value="<%=Item.BangLai %>" class="form-control BangLai">
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
            <a href="/lib/pages/LoaiXe/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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