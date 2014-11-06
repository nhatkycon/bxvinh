<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListToday.ascx.cs" Inherits="lib_ui_XeVaoBen_ListToday" %>
<%@ Register Src="~/lib/ui/XeVaoBen/Templates/ItemToday.ascx" TagPrefix="uc1" TagName="ItemToday" %>
<div class="row XeRaVaoToDayList" >
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemToday runat="server" ID="ItemToday" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>       
</div>
