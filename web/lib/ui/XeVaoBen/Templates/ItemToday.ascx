<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemToday.ascx.cs" Inherits="lib_ui_XeVaoBen_Templates_ItemToday" %>
<div class="col-md-2 col-sm-2 XeVaoBen-HangDoi-Box">
    <button data-id="<%=Item.ID %>" class="btn btn-lg btn-block XeVaoBen-HangDoi-Item<%=Item.TrangThai==200 ? " btn-default" : " btn-warning" %>">
        <%=Item.BienSo %>
    </button>
</div>