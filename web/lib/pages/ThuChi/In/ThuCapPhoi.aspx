<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="ThuCapPhoi.aspx.cs" Inherits="lib_pages_ThuChi_In_ThuCapPhoi" %>

<%@ Register Src="~/lib/ui/Phoi/In/Phoi-NgoaiTinh.ascx" TagPrefix="uc1" TagName="PhoiNgoaiTinh" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:phoingoaitinh runat="server" id="PhoiNgoaiTinh" />
</asp:Content>

