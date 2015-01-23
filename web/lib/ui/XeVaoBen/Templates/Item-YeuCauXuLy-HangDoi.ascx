<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-YeuCauXuLy-HangDoi.ascx.cs" Inherits="lib_ui_XeVaoBen_Templates_Item_YeuCauXuLy_HangDoi" %>
<div href="javascript:;" data-bx="<%=Item.BienSo %>" 
    data-id="<%=Item.XE_ID %>" 
    data-xvbId="<%=Item.ID %>" 
    data-trangThai="<%=Item.TrangThai %>"
    class="list-group-item<%=Item.TrangThai==200 ? " list-group-item-warning" : "" %>">
    <span class="pull-right">
        <button data-xvbId="<%=Item.ID %>" class="btn btn-link">
            <i class="glyphicon glyphicon-share-alt"></i>
        </button>
    </span>
    <%=Item.BienSo %>
</div>