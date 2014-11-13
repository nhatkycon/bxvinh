<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="KetQuaDuyet.aspx.cs" Inherits="lib_pages_TruyThu_KetQuaDuyet" %>
<%@ Register Src="~/lib/ui/TruyThu/KetQuaDuyet.ascx" TagPrefix="uc1" TagName="KetQuaDuyet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:KetQuaDuyet runat="server" Id="Add" />
</asp:Content>

