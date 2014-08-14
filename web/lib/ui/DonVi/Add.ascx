<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_DonVi_Add" %>
<%@ Import Namespace="docsoft" %>
<div class="panel panel-default Normal-Pnl-Add" 
    data-url="/lib/ajax/DonVi/default.aspx"
    data-success="/lib/pages/DonVi/Add.aspx?ID="
    data-list="/lib/pages/DonVi/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/DonVi/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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
                <label for="Mobile" class="col-sm-2 control-label">Mobile:</label>
                <div class="col-sm-10">
                    <input type="text" name="Mobile" id="Mobile" value="<%=Item.Mobile %>" class="form-control Mobile">
                </div>
            </div>
            
            <div class="form-group">
                <label for="Phone" class="col-sm-2 control-label">Phone:</label>
                <div class="col-sm-10">
                    <input type="text" name="Phone" id="Phone" value="<%=Item.Phone %>" class="form-control Phone">
                </div>
            </div>

            
            <div class="form-group">
                <label for="DiaChi" class="col-sm-2 control-label">Địa chỉ:</label>
                <div class="col-sm-10">
                    <textarea id="DiaChi" name="DiaChi" type="text" rows="3" class="form-control"><%=Item.DiaChi%></textarea>
                </div>
            </div>
            
            
            <div class="form-group">
                <label for="GPS_Website" class="col-sm-2 control-label">GPS Website:</label>
                <div class="col-sm-10">
                    <input type="text" name="GPS_Website" id="GPS_Website" value="<%=Item.GPS_Website %>" class="form-control GPS_Website">
                </div>
            </div>
            
            <div class="form-group">
                <label for="GPS_Username" class="col-sm-2 control-label">GPS Username:</label>
                <div class="col-sm-10">
                    <input type="text" name="GPS_Username" id="GPS_Username" value="<%=Item.GPS_Username %>" class="form-control GPS_Username">
                </div>
            </div>
            
            <div class="form-group">
                <label for="GPS_Password" class="col-sm-2 control-label">GPS Password:</label>
                <div class="col-sm-10">
                    <input type="text" name="GPS_Password" id="GPS_Password" value="<%=Item.GPS_Password %>" class="form-control GPS_Password">
                </div>
            </div>

            <div class="form-group">
                <label for="Khoa" class="col-sm-2 control-label">Khóa</label>
                <div class="col-sm-10">
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
            <a href="/lib/pages/DonVi/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
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