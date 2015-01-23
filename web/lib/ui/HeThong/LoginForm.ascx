<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginForm.ascx.cs" Inherits="lib_ui_HeThong_LoginForm" %>
<style type="text/css">
    body {
      padding-top: 40px;
      padding-bottom: 40px;
      background-color: #eee;
    }

    .form-signin {
      max-width: 330px;
      padding: 15px;
      margin: 0 auto;
    }
    .form-signin .form-signin-heading,
    .form-signin .checkbox {
      margin-bottom: 10px;
    }
    .form-signin .checkbox {
      font-weight: normal;
    }
    .form-signin .form-control {
      position: relative;
      height: auto;
      -webkit-box-sizing: border-box;
         -moz-box-sizing: border-box;
              box-sizing: border-box;
      padding: 10px;
      font-size: 16px;
    }
    .form-signin .form-control:focus {
      z-index: 2;
    }
    .form-signin input[type="email"] {
      margin-bottom: -1px;
      border-bottom-right-radius: 0;
      border-bottom-left-radius: 0;
    }
    .form-signin input[type="password"] {
      margin-bottom: 10px;
      border-top-left-radius: 0;
      border-top-right-radius: 0;
    }

    </style>

    <div class="form-signin">
    <h2 class="form-signin-heading">Đăng nhập</h2>
        <asp:TextBox ID="Username" runat="server" CssClass="input-block-level form-control"></asp:TextBox>
        <asp:TextBox ID="Pwd" TextMode="Password" CssClass="input-block-level form-control" runat="server"></asp:TextBox>
    <label class="checkbox">
        Ghi nhớ
        <asp:CheckBox runat="server" ID="ckb"/>
    </label>
        <div id="msg" runat="server" Visible="False" class="alert alert-warning">
        Username và mật khẩu không hợp lệ                    
    </div>
    <asp:Button ID="btnLogin" ClientIDMode="Static" CssClass="btn btn-lg btn-block btn-primary" runat="server" OnClick="btnLogin_Click" Text="Đăng nhập" />
    </div>
<script src="/lib/js/jQueryLib/jquery-1.10.2.min.js"></script>
<script src="/lib/js/jQueryLib/jquery.hotkeys.js"></script>
<script>
    $(document).ready(function () {
        var btn = $('#btnLogin');
        
        $(document).keypress(function (e) {
            if (e.which == 13) {
                btn.click();
            }
        });
    });
</script>