<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_LoaiBieuDo_templates_Item" %>
<tr>
    <td class="">
        <a href="<%=Item.Url %>">
            <%=Item.ID %>
        </a>
    </td>
    <td >
        <a href="<%=Item.Url %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td class="">
        <%=Item.SoTuyenKhoan %>
    </td>
    <td class="hidden-xs">
        <%=Item.CachNgay %>
    </td>
    <td class="hidden-xs">
        <%if(Item.KhoanTuyen){ %>
            <input type="checkbox" checked="checked"/>
        <%}else{ %>
            <input type="checkbox"/>
        <%} %>
    </td>
    <td class="hidden-xs">
        <%if(Item.HaiTuyenTrenNgay){ %>
            <input type="checkbox" checked="checked"/>
        <%}else{ %>
            <input type="checkbox"/>
        <%} %>
    </td>
</tr> 