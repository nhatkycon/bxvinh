<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_LaiXe_templates_Item" %>
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
    <td class="hidden-xs">
        <a href="?DONVI_ID=<%=Item.DONVI_ID %>">
            <%=Item.DONVI_Ten %>            
        </a>
    </td>
    <td>
        <a href="?DONVI_ID=<%=Item.LoaiBang.Trim() %>">
            <%=Item.LoaiBang %>
        </a>
    </td>
    <td class="hidden-xs">
        <%=Item.NgaySinh.ToString("dd/MM/yyyy") %>
    </td>
    <td class="hidden-xs <% = Item.NgayHetHanBangLai < DateTime.Now.AddDays(-1) ? "danger" : "" %>">
        <%=Item.NgayHetHanBangLai.ToString("dd/MM/yyyy") %>
    </td>
    <td class="hidden-xs <% = Item.NgayHetHanGiayKhamSucKhoe < DateTime.Now.AddDays(-1) ? "danger" : "" %>">
        <%=Item.NgayHetHanGiayKhamSucKhoe.ToString("dd/MM/yyyy") %>
    </td>
    <td class="<% = Item.Khoa ? "danger" : "" %>">
        <%=Item.Khoa ? "KHÓA" : "OK" %>
    </td>
</tr>