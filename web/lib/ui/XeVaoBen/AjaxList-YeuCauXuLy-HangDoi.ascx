<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AjaxList-YeuCauXuLy-HangDoi.ascx.cs" Inherits="lib_ui_XeVaoBen_AjaxList_YeuCauXuLy_HangDoi" %>
<%@ Register Src="~/lib/ui/XeVaoBen/Templates/Item-YeuCauXuLy-HangDoi.ascx" TagPrefix="uc1" TagName="ItemYeuCauXuLyHangDoi" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemYeuCauXuLyHangDoi runat="server" ID="ItemYeuCauXuLyHangDoi" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>  