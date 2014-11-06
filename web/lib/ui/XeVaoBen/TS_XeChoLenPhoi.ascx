<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TS_XeChoLenPhoi.ascx.cs" Inherits="lib_ui_XeVaoBen_TS_XeChoLenPhoi" %>
<%@ Register Src="~/lib/ui/XeVaoBen/Templates/TS_XeChoLenPhoi-Item.ascx" TagPrefix="uc1" TagName="TS_XeChoLenPhoiItem" %>
<div class="row XeRaVaoToDayList" >
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:TS_XeChoLenPhoiItem runat="server" ID="TS_XeChoLenPhoiItem" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>       
</div>
