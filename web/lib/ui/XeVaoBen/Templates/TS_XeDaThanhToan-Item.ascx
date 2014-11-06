<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TS_XeDaThanhToan-Item.ascx.cs" Inherits="lib_ui_XeVaoBen_Templates_TS_XeDaThanhToan_Item" %>
<div class="col-md-2 col-sm-2 XeVaoBen-HangDoi-Box">
    <button data-id="<%=Item.ID %>" class="btn btn-lg btn-block XeVaoBen-ChoThanhToan-Item<%=Item.TrangThai==900 ? " btn-default" : " btn-warning" %>">
        <%=Item.BienSo %>
    </button>
</div>