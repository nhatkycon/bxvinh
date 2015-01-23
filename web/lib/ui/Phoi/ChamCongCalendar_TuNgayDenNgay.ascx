<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChamCongCalendar_TuNgayDenNgay.ascx.cs" Inherits="lib_ui_Phoi_ChamCongCalendar_TuNgayDenNgay" %>
<%@ Import Namespace="linh.common" %>
<p>
    <span class="pull-right">
        <a class="btn btn-link" href="/lib/pages/ChamCong/Xe_ChamCongTuNgayDenNgay.aspx?XE_ID=<%=Item.XE_ID %>">
            <i class="glyphicon glyphicon-calendar"></i>
        </a>
    </span>
    <strong class="BIEUDO_Ten">
        <%=LoaiBieuDo.Ten %> (<span data-toggle="tooltip" class="Xe_SoChuyenChapThuan" title="Xe này được chấp thuận <%=Item.Xe.ChapThuanTuyen_SoChuyen %> chuyến/ tháng" ><%=Item.Xe.ChapThuanTuyen_SoChuyen %></span>)
        <%=SoChuyenNo==0 ? "" : string.Format(": Còn nợ <a href=\"/lib/pages/ThuNo/Add.aspx?XE_ID={1}\">{0}</a> chuyến",SoChuyenNo, Item.XE_ID) %>
    </strong>
</p>
<hr/>
<% foreach (var listThang in Thangs)
   {%>
    <table class="table table-striped table-bordered table-hover">
        <thead>
            <th>
            
            </th>
            <%foreach (var d in listThang.Ngay)
              { %>
                <th class="<%= (d.Day.Day == Today.Day && d.Day.Month == Today.Month) ? " danger" : " " %>">
                    <%=d.Day.Day %>
                </th>
            <%} %>
            <th>
                Σ
            </th>
        </thead>
        <tr data-id="<%= listThang.Ngay.Count() %>">
            <td rowspan="2" height="60" style="vertical-align: middle;">
                <strong>
                    T<%=listThang.Thang %>                    
                </strong>
            </td>
            <%foreach (var d in listThang.Ngay)
              { %>
                <td  data-id="<%=d.Item.ID==0 ? "" : d.Item.ID.ToString() %>" data-ngay="<%=d.Day.ToString("dd/MM/yyyy") %>" data-tangCuong="false" class="ChamCongTd-Item-UnClickable <%=d.KieuChamCongClass %><%=d.Clickable ? " ChamCongTd-Item-Clickable" : "" %><%=d.Clickactive ? " ChamCongTd-Item-Clickable-Active" : "" %>" title="<%= d.KieuChamCongStr%>">
                    <%=d.Txt %>
                </td>
            <%} %>
            <td rowspan="2"   style="vertical-align: middle;">
                <strong>
                    <%=listThang.Tong %>/ <%=listThang.TongBieuDo %>                    
                </strong>
            </td>
        </tr>
        <tr data-id="<%= listThang.NgayTangCuong.Count() %>">
            <%foreach (var d in listThang.NgayTangCuong)
              { %>
                <td data-id="<%=d.Item.ID==0 ? "" : d.Item.ID.ToString() %>" data-ngay="<%=d.Day.ToString("dd/MM/yyyy") %>" data-tangCuong="true" class="ChamCongTd-Item-UnClickable <%=d.KieuChamCongClass %><%=d.Clickable ? " ChamCongTd-Item-Clickable" : "" %><%=d.Clickactive ? " ChamCongTd-Item-Clickable-Active" : "" %>" title="<%= d.KieuChamCongStr%>">
                    <%=d.Txt %>
                </td>
            <%} %>
        </tr>
    </table>
<%   } %>