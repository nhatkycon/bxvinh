<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Blank.master" AutoEventWireup="true" CodeFile="Xe_ChamCongTuNgayDenNgay.aspx.cs" Inherits="lib_pages_ChamCong_Xe_ChamCongTuNgayDenNgay" %>

<%@ Register Src="~/lib/ui/Phoi/ChamCongCalendar_TuNgayDenNgay.ascx" TagPrefix="uc1" TagName="ChamCongCalendar_TuNgayDenNgay" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:chamcongcalendar_tungaydenngay runat="server" id="ChamCongCalendar_View" />
</asp:Content>

