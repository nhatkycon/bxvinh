<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="BangChamCongTungayDenNgay.aspx.cs" Inherits="lib_Lab_BangChamCongTungayDenNgay" %>

<%@ Register Src="~/lib/ui/Phoi/ChamCongCalendar_TuNgayDenNgay.ascx" TagPrefix="uc1" TagName="ChamCongCalendar_TuNgayDenNgay" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:ChamCongCalendar_TuNgayDenNgay runat="server" ID="ChamCongCalendar_View" />
</asp:Content>

