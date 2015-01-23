<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="ThuCapPhoi-List.aspx.cs" Inherits="lib_pages_ThuChi_ThuCapPhoi_List" %>

<%@ Register Src="~/lib/ui/ThuChi/ThuCapPhoi-List.ascx" TagPrefix="uc1" TagName="ThuCapPhoiList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:thucapphoilist runat="server" id="ThuCapPhoiList" />
</asp:Content>

