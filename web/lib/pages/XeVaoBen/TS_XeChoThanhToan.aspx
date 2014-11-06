<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Blank.master" AutoEventWireup="true" CodeFile="TS_XeChoThanhToan.aspx.cs" Inherits="lib_pages_XeVaoBen_TS_XeChoThanhToan" %>

<%@ Register Src="~/lib/ui/XeVaoBen/TS_XeChoThanhToan.ascx" TagPrefix="uc1" TagName="TS_XeChoThanhToan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:TS_XeChoThanhToan runat="server" ID="TS_XeChoThanhToan" />
</asp:Content>

