<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TS_Tuyen-Item.ascx.cs" Inherits="lib_ui_Xe_templates_TS_Tuyen_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td >
        <%=Item.BienSo %>
    </td>
    <td class="hidden-xs">
        <%=Item.DONVI_Ten %>
    </td>
    <td class="hidden-xs">
        <%=Item.Ghe %>
    </td>
    <td class="hidden-xs">
        <%=Item.GiaVe.TienVietNam() %>
    </td>
    <td class="hidden-xs">
        <%=Item.GioXuatBen %>
    </td>
    <td>
        <%=Item.TrangThai.XvbTrangThaiStr() %>
    </td>            
</tr>