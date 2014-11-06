<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TS_XeChoLenPhoi-Ajax.ascx.cs" Inherits="lib_ui_XeVaoBen_TS_XeChoLenPhoi_Ajax" %>
<%@ Register TagPrefix="uc1" TagName="TS_XeChoLenPhoiItem" Src="~/lib/ui/XeVaoBen/Templates/TS_XeChoLenPhoi-Item.ascx" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:TS_XeChoLenPhoiItem runat="server" ID="TS_XeChoLenPhoiItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>