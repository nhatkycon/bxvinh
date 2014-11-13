<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuNo-Item.ascx.cs" Inherits="lib_ui_ChamCong_templates_ThuNo_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td >
        <p class="form-control-static">
            <strong>
                <%=Item.Ngay.NgayVn() %>
            </strong>
        </p>
    </td>
    <td class="hidden-xs">
        <p class="form-control-static">
            <%=Item.GhiChu %>
        </p>
    </td>
    <td class="hidden-xs">
        <p class="form-control-static">
            <%=Item.Tien.TienVietNam() %>
        </p>
    </td>
    <td class="hidden-xs">
        <%if(Item.DaThuNo){ %>
            <input class="TrangThaiNo input-sm" checked="checked" tabindex="<%=Item.ID %>" data-value="<%=Item.Tien %>" type="checkbox"/>
            <input name="ChamCongIds" class="ChamCongIds hidden" value="<%=Item.ID %>"/>
        <%}else{ %>
            <input class="TrangThaiNo input-sm" tabindex="<%=Item.ID %>" data-value="<%=Item.Tien %>" type="checkbox"/>
            <input name="ChamCongIds" disabled class="ChamCongIds hidden" value="<%=Item.ID %>"/>
        <%} %>
        
    </td>
</tr>