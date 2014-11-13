<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KeToan_Item.ascx.cs" Inherits="lib_ui_ThuNo_templates_KeToan_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.DaThu? "success" : "warning" %>"">
    <td>
        <a href="/lib/pages/ThuNo/KeToan-Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td >
        <a href="/lib/pages/ThuNo/KeToan-Add.aspx?ID=<%=Item.ID %>">
            <strong>
                <%=Item.XE_BienSo %>
            </strong>
        </a>
    </td>
    <td class="hidden-xs">
            <%=Item.Ngay.NgayVn() %>
    </td>
    <td class="hidden-xs">
        <p class="form-control-static">
            <%=Item.Tien.TienVietNam() %>
        </p>
    </td>
    <td class="hidden-xs">
        <%if(Item.DaThu){ %>
            Đã thu
        <%}else{ %>
            Chưa thu
        <%} %>
        
    </td>
</tr>