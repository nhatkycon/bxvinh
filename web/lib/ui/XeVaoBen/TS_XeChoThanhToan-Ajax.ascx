<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TS_XeChoThanhToan-Ajax.ascx.cs" Inherits="lib_ui_XeVaoBen_TS_XeChoThanhToan_Ajax" %>
<%@ Register TagPrefix="uc1" TagName="TS_XeChoThanhToanItem" Src="~/lib/ui/XeVaoBen/Templates/TS_XeChoThanhToan-Item.ascx" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:TS_XeChoThanhToanItem runat="server" ID="TS_XeChoThanhToanItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>