<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuNo-List.ascx.cs" Inherits="lib_ui_ChamCong_ThuNo_List" %>
<%@ Register Src="~/lib/ui/ChamCong/templates/ThuNo-Item.ascx" TagPrefix="uc1" TagName="ThuNoItem" %>

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
                Thu
            </th>
        </tr>    
    </thead>
    <tbody class="ThuNo-ChamCong-List">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ThuNoItem runat="server" ID="ThuNoItem" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>  