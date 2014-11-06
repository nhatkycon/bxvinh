<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TS_XeDaThanhToan-Ajax.ascx.cs" Inherits="lib_ui_XeVaoBen_TS_XeDaThanhToan_Ajax" %>
<%@ Register Src="~/lib/ui/XeVaoBen/Templates/TS_XeDaThanhToan-Item.ascx" TagPrefix="uc1" TagName="TS_XeDaThanhToanItem" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:TS_XeDaThanhToanItem runat="server" ID="TS_XeDaThanhToanItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>