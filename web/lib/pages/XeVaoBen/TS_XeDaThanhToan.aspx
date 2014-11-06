<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Blank.master" AutoEventWireup="true" CodeFile="TS_XeDaThanhToan.aspx.cs" Inherits="lib_pages_XeVaoBen_TS_XeDaThanhToan" %>

<%@ Register Src="~/lib/ui/XeVaoBen/TS_XeDaThanhToan.ascx" TagPrefix="uc1" TagName="TS_XeDaThanhToan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:TS_XeDaThanhToan runat="server" ID="TS_XeDaThanhToan" />
</asp:Content>

