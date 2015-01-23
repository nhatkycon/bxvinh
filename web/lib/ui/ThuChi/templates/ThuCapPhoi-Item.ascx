<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuCapPhoi-Item.ascx.cs" Inherits="lib_ui_ThuChi_templates_ThuCapPhoi_Item" %>
<%@ Import namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/ThuChi/ThuCapPhoi-Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td >
        <a href="/lib/pages/ThuChi/ThuCapPhoi-Add.aspx?ID=<%=Item.ID %>">
            <%=Item.STTBX.SttbxStr() %>/<%=Item.STTALL.SttAllStr() %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/pages/ThuChi/ThuCapPhoi-List.aspx?bienSo=<%=Item.XE_BienSo %>">
            <%=Item.XE_BienSo %>
        </a>
    </td>
    <td class="hidden-xs">
        <%=Item.Tien.TienVietNam() %>
    </td>
    <td class="hidden-xs">
        <%=Item.Ngay.NgayVn() %>
    </td>
    <td class="hidden-xs">
        <%=Item.NguoiTao_Ten %> - <%=Item.NgayTao.NgayVnFull() %>
    </td>                
</tr>    