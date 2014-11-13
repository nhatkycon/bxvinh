<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_pages_ThuNo_Add" %>

<%@ Register Src="~/lib/ui/ThuNo/ThuNo.ascx" TagPrefix="uc1" TagName="ThuNo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:ThuNo runat="server" id="ThuNoItem" />
</asp:Content>

