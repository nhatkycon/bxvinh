<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_Phoi_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="<%=Item.Url %>">
            <%=Item.ID %>
        </a>
    </td>
    <td>
        <a href="<%=Item.Url %>">
            <%=Item.STTBXStr %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/pages/Phoi/Default.aspx?xe_id=<%=Item.XE_ID %>">
            <%=Item.XE_BienSo %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/Phoi/Default.aspx?donVi_id=<%=Item.DONVI_ID %>">
            <%=Item.DONVI_Ten %>
        </a>
    </td>
    <td class="hidden-xs" style="text-align: right;">
        <%=Item.PHI_Tong.TienVietNam() %>
    </td>
    <td class="hidden-xs">
        <%=Item.NgayXuatBen.NgayVn() %>
    </td>
    <td class="hidden-xs">
        <a href="/lib/pages/Phoi/Default.aspx?nguoiTao=<%=Item.Username %>">
            <%=Item.Username %>
        </a>
    </td>
    <td>
        <%if(Item.TruyThu_Id!=0){ %>
            <a href="/lib/pages/TruyThu/Add.aspx?ID=<%=Item.TruyThu_Id %>">
                <%=Item.TruyThu_Id %>
            </a>
        <%} %>
    </td>
    <td>
        <%=Item.TrangThai.XvbTrangThaiStr() %>
    </td>
</tr>