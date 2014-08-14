<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="BangChamCong.aspx.cs" Inherits="lib_Lab_BangChamCong" %>

<%@ Register Src="~/lib/ui/Phoi/ChamCongCalendar_View.ascx" TagPrefix="uc1" TagName="ChamCongCalendar_View" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:ChamCongCalendar_View runat="server" ID="ChamCongCalendar_View" />
</asp:Content>

