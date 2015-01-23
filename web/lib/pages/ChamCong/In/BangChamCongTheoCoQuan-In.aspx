<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="BangChamCongTheoCoQuan-In.aspx.cs" Inherits="lib_pages_ChamCong_In_BangChamCongTheoCoQuan_In" %>
<%@ Register Src="~/lib/ui/ChamCong/BangChamCongTheoCoQuan_List.ascx" TagPrefix="uc1" TagName="BangChamCongTheoCoQuan_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%=string.Format("{0} Tháng {1}",Item.Ten,TuNgay) %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:bangchamcongtheocoquan_list runat="server" id="BangChamCongTheoCoQuan_List" />
</asp:Content>

