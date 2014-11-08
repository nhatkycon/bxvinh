<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AjaxList-DuyetDeNghiTruyThu.ascx.cs" Inherits="lib_ui_XeVaoBen_AjaxList_DuyetDeNghiTruyThu" %>
<%@ Register Src="~/lib/ui/XeVaoBen/Templates/Item-DuyetDeNghiTruyThu.ascx" TagPrefix="uc1" TagName="ItemDuyetDeNghiTruyThu" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemDuyetDeNghiTruyThu runat="server" ID="ItemDuyetDeNghiTruyThu"  Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>  