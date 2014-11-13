<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="KeToan.aspx.cs" Inherits="lib_pages_ThuNo_KeToan" %>

<%@ Register Src="~/lib/ui/ThuNo/KeToan_List.ascx" TagPrefix="uc1" TagName="KeToan_List" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:ketoan_list runat="server" id="KeToan_List" />
</asp:Content>

