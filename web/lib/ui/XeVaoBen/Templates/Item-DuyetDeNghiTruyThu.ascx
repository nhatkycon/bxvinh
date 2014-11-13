<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-DuyetDeNghiTruyThu.ascx.cs" Inherits="lib_ui_XeVaoBen_Templates_Item_DuyetDeNghiTruyThu" %>
<div class="col-md-1">
    <a href="/lib/pages/TruyThu/KetQuaDuyet.aspx?ID=<%=Item.TRUYTHU_ID %><%=Item.TrangThai==510 ? "&act=approvedTruyThu" : "" %>" 
        data-bx="<%=Item.BienSo %>" 
        data-id="<%=Item.XE_ID %>" 
        data-phoiId="<%=Item.PHOI_ID %>"
        data-truyThuId="<%=Item.TRUYTHU_ID %>"
        data-xvBI="<%=Item.ID %>"
        data-trangThai="<%=Item.TrangThai %>"
        class="btn btn-block<%=Item.TrangThai==500 ? " btn-default" : " btn-warning" %>">
        <%=Item.BienSo %>
    </a>
</div>
