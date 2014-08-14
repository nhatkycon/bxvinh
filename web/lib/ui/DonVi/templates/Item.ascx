<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_DonVi_templates_Item" %>
<tr class="<%=Item.Khoa ? "warning" : "" %>">
    <td class="">
        <a href="/lib/pages/DonVi/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="">
        <a href="/lib/pages/DonVi/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td class="">
        <%=Item.Mobile %>
    </td>
    <td class="hidden-xs">
        <%=Item.GPS_Website %>
    </td>
    <td class="hidden-xs">
        <%=Item.GPS_Username %>
    </td>
    <td  class="">
        <%=Item.GPS_Password %>
    </td>
    <td class="hidden-xs">
        <%if(Item.Khoa){ %>
        X
        <%}else{ %>
        OK
        <%} %>
    </td>
</tr>