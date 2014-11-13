<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TruyThu-KetQuaDuyet-Item.ascx.cs" Inherits="lib_ui_ChamCong_templates_TruyThu_KetQuaDuyet_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td >
        <input name="CHAMCONG_ID" value="<%=Item.ID %>" class="hidden"/>
        <p class="form-control-static">
            <strong>
                <%=Item.Ngay.NgayVn() %>
            </strong>
        </p>
    </td>
    <td class="hidden-xs">
        <input type="text" tabindex="<%=Item.ID %>" value="<%=Item.GhiChu %>" name="CHAMCONG_GhiChu" class="form-control TruyThu-KetQuaView-AjaxInput"/>
    </td>
    <td class="hidden-xs">
        <input type="text" tabindex="-1" value="<%=Item.Tien.TienVietNam() %>" name="CHAMCONG_Tien" style="text-align: right;" class="form-control GhiChu TruyThu-KetQuaView-AjaxInput"/>
    </td>
    <td class="hidden-xs">
        <%if (Item.TrangThaiNo==1)
        {%>
            <input class="TrangThaiNo input-sm" checked="checked" name="CHAMCONG_TrangThaiNo" type="checkbox"/>
        <%}
        else
        {%>
            <input class="TrangThaiNo input-sm"  name="CHAMCONG_TrangThaiNo" type="checkbox"/>
        <% } %>
    </td>
    <td class="hidden-xs">
        <button class="btn btn-default removeBtn" tabindex="-1" title="Xóa bỏ ngày này khỏi truy thu" data-id="<%=Item.ID %>">
            <i class="glyphicon glyphicon-remove"></i>
        </button>
    </td>
</tr>