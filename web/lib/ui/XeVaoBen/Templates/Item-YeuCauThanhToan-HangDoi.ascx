<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-YeuCauThanhToan-HangDoi.ascx.cs" Inherits="lib_ui_XeVaoBen_Templates_Item_YeuCauThanhToan_HangDoi" %>
<a href="javascript:;" 
    data-bx="<%=Item.BienSo %>" 
    data-id="<%=Item.XE_ID %>" 
    data-xvBI="<%=Item.ID %>"
    data-trangThai="<%=Item.TrangThai %>"
    class="list-group-item<%=Item.TrangThai==600 ? " list-group-item-warning" : "" %>">
    <%=Item.BienSo %>
</a>