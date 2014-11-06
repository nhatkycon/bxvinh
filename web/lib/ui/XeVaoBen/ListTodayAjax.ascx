<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListTodayAjax.ascx.cs" Inherits="lib_ui_XeVaoBen_ListTodayAjax" %>
<%@ Register Src="~/lib/ui/XeVaoBen/Templates/ItemToday.ascx" TagPrefix="uc1" TagName="ItemToday" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemToday runat="server" ID="ItemToday" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>       
