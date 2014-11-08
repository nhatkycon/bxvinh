<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="Phoi-NgoaiTinh.aspx.cs" Inherits="lib_pages_Phoi_In_Phoi_NgoaiTinh" %>

<%@ Register Src="~/lib/ui/Phoi/In/Phoi-NgoaiTinh.ascx" TagPrefix="uc1" TagName="PhoiNgoaiTinh" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Phơi: <%=Item.STTBXStr %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:PhoiNgoaiTinh runat="server" ID="PhoiNgoaiTinh" />
</asp:Content>

