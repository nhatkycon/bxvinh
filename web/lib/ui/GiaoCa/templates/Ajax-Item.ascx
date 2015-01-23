<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ajax-Item.ascx.cs" Inherits="lib_ui_GiaoCa_templates_Ajax_Item" %>
<%@ Import namespace="linh.common" %>
<a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
    <strong><%=Item.DoanhThu.TienVietNam() %></strong><b class="caret"></b>
</a>
<ul class="dropdown-menu">
    <li>
        <a href="/lib/pages/Phoi/GiaoCaList.aspx">
            <i class="glyphicon glyphicon-info-sign"></i>Phơi theo ca
        </a>
    </li>
</ul> 