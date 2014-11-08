<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_TruyThu_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.Duyet ? "success" : "warning"%>">
    <td class="">
        <a href="/lib/pages/TruyThu/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td >
        <a href="/lib/pages/TruyThu/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.STTBX %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/pages/TruyThu/?XE_D=<%=Item.XE_ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="hidden-xs">
        <%=Item.PHOI_ID %>
    </td>
    <td class="hidden-xs">
        <%=Item.TongTruyThu.TienVietNam() %>
    </td>
    <td class="hidden-xs">
        <%=Item.SoChuyenThieu %>
    </td>
    <td class="hidden-xs">
        <%=Item.SoChuyenDeNghi %>
    </td>
    <td>
        <%=Item.NguoiLap %>
    </td>
    <td>
        <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>
    </td>
    <td>
        <%=Item.Duyet ? "Đã duyệt" : "Chưa duyệt" %>
    </td>            
</tr>