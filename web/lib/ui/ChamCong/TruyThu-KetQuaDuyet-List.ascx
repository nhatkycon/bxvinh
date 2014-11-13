<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TruyThu-KetQuaDuyet-List.ascx.cs" Inherits="lib_ui_ChamCong_TruyThu_KetQuaDuyet_List" %>
<%@ Register Src="~/lib/ui/ChamCong/templates/TruyThu-KetQuaDuyet-Item.ascx" TagPrefix="uc1" TagName="TruyThuKetQuaDuyetItem" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th >
                Ngày
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
            <th class="hidden-xs">
            </th>
        </tr>    
    </thead>
    <tbody class="TruyThu-KetQuaView-List" data-url="/lib/ajax/ChamCong/Default.aspx">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:TruyThuKetQuaDuyetItem runat="server" ID="TruyThuKetQuaDuyetItem" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>   