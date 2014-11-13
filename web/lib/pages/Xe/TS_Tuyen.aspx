<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Blank.master" AutoEventWireup="true" CodeFile="TS_Tuyen.aspx.cs" Inherits="lib_pages_Xe_TS_Tuyen" %>

<%@ Register Src="~/lib/ui/Xe/TS_Tuyen.ascx" TagPrefix="uc1" TagName="TS_Tuyen" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:TS_Tuyen runat="server" ID="TS_Tuyen" />
</asp:Content>

