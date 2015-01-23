<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TruyThu-KetQuaDuyet-List.ascx.cs" Inherits="lib_ui_ChamCong_TruyThu_KetQuaDuyet_List" %>
<%@ Register Src="~/lib/ui/ChamCong/templates/TruyThu-KetQuaDuyet-Item.ascx" TagPrefix="uc1" TagName="TruyThuKetQuaDuyetItem" %>
<%@ Import namespace="linh.common" %>
<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th >
                Ngày
            </th>
            <th>
                Truy thu
            </th>
            <th class="hidden-xs">
                Lý do
            </th>
            <th class="hidden-xs">
                Tiền
            </th>
            <th class="hidden-xs">
                Nợ
            </th>
            <%--<th class="hidden-xs">
            </th>--%>
        </tr>    
    </thead>
    <tbody class="TruyThu-KetQuaView-List" data-url="/lib/ajax/ChamCong/Default.aspx">
        <tr>
           
            <td>
               
            </td>
            <td>
                
            </td>
            <td style="text-align: right;">
                 <strong>
                    Phí trước truy thu 
                </strong>
            </td>
            <td >
                <input disabled style="text-align: right;" class="form-control PhiTruocTruyThu money-input" value="<%=(Phoi.PHI_Tong-(Phoi.ChuyenTruyThu * Phoi.PhiMotChuyenTruyThu)) %>"/>
            </td>
            <td>
                
            </td>
        </tr>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:TruyThuKetQuaDuyetItem runat="server" ID="TruyThuKetQuaDuyetItem" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
        <tr>
           
            <td>
                
            </td>
            <td>
                
            </td>
            <td style="text-align: right;">
                <strong>
                    Tổng truy thu
                </strong>
            </td>
            <td >
                <input disabled style="text-align: right;" class="TongTruyThu money-input form-control input-lg" value="<%=(Phoi.PHI_Tong - Phoi.PHI_TruyThuGiam) %>"/>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
           
            <td>
                
            </td>
            <td>
                
            </td>
            <td style="text-align: right;">
                <strong>
                    Nợ
                </strong>
            </td>
            <td >
                <input  name="PHI_ConNo" disabled style="text-align: right;" class="No money-input form-control input-lg" value=""/>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
           
            <td>
                
            </td>
            <td>
                
            </td>
            <td style="text-align: right;">
                <strong>
                    Phải nộp
                </strong>
            </td>
            <td >
                <input disabled name="PHI_Nop" style="text-align: right;" class="Tong money-input form-control input-lg" value="<%=Phoi.PHI_Tong %>"/>
            </td>
            <td>
                
            </td>
        </tr>
    </tbody>
</table>   