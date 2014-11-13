<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChamCongCalendar_TuNgayDenNgay.ascx.cs" Inherits="lib_ui_Phoi_ChamCongCalendar_TuNgayDenNgay" %>
<%@ Import Namespace="linh.common" %>
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
        <tr>
            <td>
                <strong>
                    T<%=listThang.Thang %>                    
                </strong>
            </td>
            <%foreach (var d in listThang.Ngay)
              { %>
                <td class="<%=d.KieuChamCongClass %><%=d.Clickable ? " ChamCongTd-Item-Clickable" : "" %><%=d.Clickactive ? " ChamCongTd-Item-Clickable-Active" : "" %>" title="<%= d.KieuChamCongStr%>">
                    <%=d.SoChuyen.ChamCongHienThiStr() %>
                    <%=d.GhiChu %>
                    <input style="display: none;" name="<%=d.Clickactive ? "NgayChamCong" : "" %>" type="text" value="<%=d.Day.ToString("dd/MM/yyyy") %>"/>
                </td>
            <%} %>
            <td>
                <strong>
                    <%=listThang.Tong %>/ <%=listThang.TongBieuDo %>                    
                </strong>
            </td>
        </tr>
    </table>
<%   } %>