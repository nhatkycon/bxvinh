<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_Tuyen_templates_Item" %>
<tr>
    <td class="">
        <a href="/lib/pages/Tuyen/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="">
        <a href="/lib/pages/Tuyen/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td class="">
        <%=Item.DI_Ten %>
    </td>
    <td class="hidden-xs">
        <%=Item.DEN_Ten %>
    </td>
    <td class="hidden-xs">
        <%=Item.NoiTinh ? "YES" : "NO" %>
    </td>
</tr>