<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_Xe_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="<%=Item.Url %>">
            <%=Item.ID %>
        </a>
    </td>
    <td>
        <a href="<%=Item.Url %>">
            <%=Item.BienSo_Chu %> <%=Item.BienSo_So %>
        </a>
    </td>
    <td  class="hidden-xs">
        <a href="?TUYEN_ID=<%=Item.TUYEN_ID %>">
            <%=Item.TUYEN_Ten %>
        </a>
    </td>
    <td  class="hidden-xs">
        <a href="?DONVI_ID=<%=Item.DONVI_ID %>">
            <%=Item.DONVI_Ten %>
        </a>
    </td>
    <td  class="hidden-xs">
        <a href="?LOAIXE_ID=<%=Item.LOAIXE_ID %>">
            <%=Item.LOAIXE_Ten %>
        </a>
    </td>
    <td  class="hidden-xs">
        <%=Item.Ghe %>
    </td>
    <td class="<% = Item.TuyenCoDinh < DateTime.Now.AddDays(-1) ? "danger" : "" %>">
        <%=Item.TuyenCoDinh.NgayVn() %>
    </td>
    <td class="<% = Item.BaoHiem < DateTime.Now.AddDays(-1) ? "danger" : "" %>">
        <%=Item.BaoHiem.NgayVn() %>
    </td>
    <td class="<% = Item.LuuHanh < DateTime.Now.AddDays(-1) ? "danger" : "" %>">
        <%=Item.LuuHanh.NgayVn() %>
    </td>
    <td class="<% = Item.Khoa ? "danger" : "" %>">
        <%=Item.Khoa ? "KHÓA" : "OK" %>
    </td>
</tr>   