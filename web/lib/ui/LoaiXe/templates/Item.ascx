<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_LoaiXe_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/LoaiXe/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="">
        <a href="/lib/pages/LoaiXe/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td class="">
        <%=Item.SoGhe %>
    </td>
    <td class="hidden-xs">
        <%=Lib.TienVietNam(Item.MucThu) %>
    </td>
    <td class="hidden-xs">
        <%=Item.BangLai %>
    </td>
</tr>