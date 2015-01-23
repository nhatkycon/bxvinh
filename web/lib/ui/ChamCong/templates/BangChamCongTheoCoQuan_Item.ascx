<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BangChamCongTheoCoQuan_Item.ascx.cs" Inherits="lib_ui_ChamCong_templates_BangChamCongTheoCoQuan_Item" %>
<tr>
    <td style="width: 10px;">
        <%=Item.STT %>
    </td>
    <td>
        <%=Item.BienSo_Chu %>-<%=Item.BienSo_So %>
    </td>
    <td style="width: 10px;">
        <%=Item.SoKhach %>
    </td>
    <td style="width: 20px;">
        <%=Item.GioXuatBen %>
    </td>
    <%foreach (var d in Item.ListLichItem)
        { %>
        <td style="width: 20px;" data-id="<%=d.Item.ID==0 ? "" : d.Item.ID.ToString() %>" data-ngay="<%=d.Day.ToString("dd/MM/yyyy") %>" data-tangCuong="false" class="ChamCongTd-Item-UnClickable <%=d.KieuChamCongClass %><%=d.Clickable ? " ChamCongTd-Item-Clickable" : "" %><%=d.Clickactive ? " ChamCongTd-Item-Clickable-Active" : "" %>" title="<%= d.KieuChamCongStr%>">
            <%=d.Txt %>
        </td>
    <%} %>
    <td style="width: 10px;">
        <strong>
            <%=Item.ListChamCong.Count %>
        </strong>
    </td>
</tr>