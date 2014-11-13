<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="KeToan-Add.aspx.cs" Inherits="lib_pages_ThuNo_KeToan_Add" %>

<%@ Register Src="~/lib/ui/ThuNo/ThuNo_KeToan.ascx" TagPrefix="uc1" TagName="ThuNo_KeToan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:thuno_ketoan runat="server" id="ThuNo_KeToan" />
</asp:Content>

