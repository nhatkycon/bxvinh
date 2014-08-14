<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="lib_pages_Login" %>
<%@ Register Src="~/lib/ui/HeThong/LoginForm.ascx" TagPrefix="uc1" TagName="LoginForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Đăng nhập</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="/lib/css/web/1.css" rel="stylesheet" type="text/css" />
    <link href="/lib/css/web/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <link href="/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/lib/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:LoginForm runat="server" id="LoginForm" />
    </form>
</body>
</html>
