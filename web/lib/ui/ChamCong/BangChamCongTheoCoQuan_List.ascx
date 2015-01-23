<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BangChamCongTheoCoQuan_List.ascx.cs" Inherits="lib_ui_ChamCong_BangChamCongTheoCoQuan_List" %>
<%@ Register Src="~/lib/ui/ChamCong/templates/BangChamCongTheoCoQuan_Item.ascx" TagPrefix="uc1" TagName="BangChamCongTheoCoQuan_Item" %>

<table width="100%">
    <tr>
        <td style="text-align: center; width: 260px;">
            CÔNG TY CỔ PHẦN BẾN XE NGHỆ AN<br/>
            BẾN XE VINH
        </td>
        <td style="text-align: center;">
            BÁO CÁO TÌNH HÌNH PHƯƠNG TIỆN HOẠT ĐỘNG VTK<br/>
            Tháng <%=TuNgay %>
        </td>
    </tr>
</table> 
<p>
    <%=Item.NoiTinh ? "TUYẾN NỘI TỈNH" : "TUYẾN NGOẠI TỈNH" %>
</p>
<table class="table table-hover table-bordered print-border">
    <thead>
        <th>
        TT    
        </th>
        <th >
           Biển số 
        </th>
        <th>
            TT
        </th>
        <th>
            Giờ XB
        </th>
        <%foreach (var d in Ngay)
        { %>
            <th  style="width: 20px;">
                <%=d.Day.ToString("dd") %>
            </th>
        <%} %>
        <th>
            Σ
        </th>
    </thead>
    <tbody>
        
        <tr>
            <td colspan="<%=Ngay.Count + 5 %>">
                <strong><%=Item.Ten %></strong>
            </td>
        </tr>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:bangchamcongtheocoquan_item runat="server" id="BangChamCongTheoCoQuan_Item" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>        
    </tbody>
</table>
