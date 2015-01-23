<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="GiaoCaList.aspx.cs" Inherits="lib_pages_Phoi_GiaoCaList" %>

<%@ Register Src="~/lib/ui/Phoi/GiaoCaList.ascx" TagPrefix="uc1" TagName="GiaoCaList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:giaocalist runat="server" id="List" />
</asp:Content>

