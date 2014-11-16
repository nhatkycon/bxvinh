<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_ChamCong_Default" %>
<%@ Register Src="~/lib/ui/ChamCong/ThuNo-List.ascx" TagPrefix="uc1" TagName="ThuNoList" %>
<%@ Register Src="~/lib/ui/Phoi/ChamCongCalendar_TuNgayDenNgay.ascx" TagPrefix="uc1" TagName="ChamCongCalendar_TuNgayDenNgay" %>
<uc1:ChamCongCalendar_TuNgayDenNgay runat="server" ID="ChamCongCalendar_View" Visible="False" />
<uc1:ThuNoList runat="server" ID="ThuNoList" Visible="False" />
