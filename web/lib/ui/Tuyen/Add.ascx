<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_Tuyen_Add" %>
<%@ Import Namespace="docsoft" %>
<%@ Register Src="~/lib/ui/HeThong/ListDmByLdmMa.ascx" TagPrefix="uc1" TagName="ListDmByLdmMa" %>

<div class="panel panel-default Normal-Pnl-Add" 
    data-url="/lib/ajax/Tuyen/default.aspx"
    data-success="/lib/pages/Tuyen/Add.aspx?ID="
    data-list="/lib/pages/Tuyen/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/Tuyen/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <% }else{ %>
            <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
            <a href="/lib/pages/Tuyen/Add.aspx" class="btn btn-success">Thêm</a>
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
                <label for="DI_ID" class="col-sm-2 control-label">Đi:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=BenXe" data-refId="DI_ID" class="form-control form-autocomplete-input DI_Ten" name="DI_Ten" id="DI_Ten" value="<%=Item.DI_Ten %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control DI_ID" name="DI_ID" id="DI_ID" value="<%=Item.DI_ID == Guid.Empty ? "" : Item.DI_ID.ToString() %>"/>
                    </div>
                </div>
                <label for="DEN_ID" class="col-sm-2 control-label">Đến:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=BenXe" data-refId="DEN_ID" class="form-control form-autocomplete-input DEN_Ten" name="DEN_Ten" id="DEN_Ten" value="<%=Item.DEN_Ten %>"/>
                        <span class="input-group-btn">
                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                            <i class="glyphicon glyphicon-search"></i>
                        </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control DEN_ID" name="DEN_ID" id="DEN_ID" value="<%=Item.DEN_ID == Guid.Empty ? "" : Item.DEN_ID.ToString() %>"/>
                    </div>
                </div>
            </div>
            
            <div class="form-group">
                <label for="VeSinhLuuBen" class="col-sm-2 control-label">Vệ sinh lưu bến:</label>
                <div class="col-sm-4">
                    <input type="text" name="VeSinhLuuBen" id="VeSinhLuuBen" value="<%=Item.VeSinhLuuBen %>" class="form-control VeSinhLuuBen money-input">
                </div>            
                <label for="HoaHongBanVe" class="col-sm-2 control-label">Hoa hồng bán vé:</label>
                <div class="col-sm-4">
                    <input type="text" name="HoaHongBanVe" id="HoaHongBanVe" value="<%=Item.HoaHongBanVe %>" class="form-control HoaHongBanVe">
                </div>
            </div>

            <div class="form-group">
                <label for="Khoa" class="col-sm-2 control-label">Nội tỉnh</label>
                <div class="col-sm-10">
                    <%if (Item.NoiTinh)
                    {%>
                        <input class="NoiTinh input-sm" id="NoiTinh" checked="checked" name="NoiTinh" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="NoiTinh input-sm" id="Checkbox1" name="NoiTinh" type="checkbox"/>
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
            <a href="/lib/pages/Tuyen/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <% }else{ %>
            <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
           <a href="/lib/pages/Tuyen/Add.aspx" class="btn btn-success">Thêm</a>
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
