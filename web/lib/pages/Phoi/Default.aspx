<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Phoi_Default" %>

<%@ Register Src="~/lib/ui/Phoi/List.ascx" TagPrefix="uc1" TagName="List" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:List runat="server" id="List" />
</asp:Content>

