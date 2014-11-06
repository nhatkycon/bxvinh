<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Blank.master" AutoEventWireup="true" CodeFile="TS_XeChoLenPhoi.aspx.cs" Inherits="lib_pages_XeVaoBen_TS_XeChoLenPhoi" %>
<%@ Register Src="~/lib/ui/XeVaoBen/TS_XeChoLenPhoi.ascx" TagPrefix="uc1" TagName="TS_XeChoLenPhoi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:TS_XeChoLenPhoi runat="server" ID="ListToday" />
</asp:Content>

