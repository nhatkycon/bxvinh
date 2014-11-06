<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_XeVaoBen_Default" %>
<%@ Register Src="~/lib/ui/XeVaoBen/AjaxList-YeuCauXuLy-HangDoi.ascx" TagPrefix="uc1" TagName="AjaxListYeuCauXuLyHangDoi" %>
<%@ Register Src="~/lib/ui/XeVaoBen/TS_XeChoLenPhoi-Ajax.ascx" TagPrefix="uc1" TagName="TS_XeChoLenPhoiAjax" %>
<%@ Register Src="~/lib/ui/XeVaoBen/TS_XeChoThanhToan-Ajax.ascx" TagPrefix="uc1" TagName="TS_XeChoThanhToanAjax" %>
<%@ Register Src="~/lib/ui/XeVaoBen/AjaxList-YeuCauThanhToan-HangDoi.ascx" TagPrefix="uc1" TagName="AjaxListYeuCauThanhToanHangDoi" %>
<%@ Register Src="~/lib/ui/XeVaoBen/TS_XeDaThanhToan-Ajax.ascx" TagPrefix="uc1" TagName="TS_XeDaThanhToanAjax" %>
<uc1:TS_XeChoLenPhoiAjax runat="server" ID="ListTodayAjax" Visible="False"/>
<uc1:AjaxListYeuCauXuLyHangDoi runat="server" ID="AjaxListYeuCauXuLyHangDoi" Visible="False" />
<uc1:TS_XeChoThanhToanAjax runat="server" ID="TS_XeChoThanhToanAjax" Visible="False"/>
<uc1:AjaxListYeuCauThanhToanHangDoi runat="server" ID="AjaxListYeuCauThanhToanHangDoi" Visible="False"/>
<uc1:TS_XeDaThanhToanAjax runat="server" ID="TS_XeDaThanhToanAjax"  Visible="False"/>
