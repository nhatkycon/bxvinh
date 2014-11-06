<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AjaxList-YeuCauThanhToan-HangDoi.ascx.cs" Inherits="lib_ui_XeVaoBen_AjaxList_YeuCauThanhToan_HangDoi" %>
<%@ Register Src="~/lib/ui/XeVaoBen/Templates/Item-YeuCauThanhToan-HangDoi.ascx" TagPrefix="uc1" TagName="ItemYeuCauThanhToanHangDoi" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemYeuCauThanhToanHangDoi runat="server" ID="ItemYeuCauThanhToanHangDoi" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>  