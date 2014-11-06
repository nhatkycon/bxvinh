<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_TruyThu_Add" %>
<%@ Import Namespace="docsoft" %>
<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add TruyThu-Pnl-Add" 
    data-url="/lib/ajax/TruyThu/default.aspx"
    data-success="/lib/pages/TruyThu/Add.aspx?ID="
    data-list="/lib/pages/TruyThu/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/TruyThu/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-success duyetbtn">Duyệt</a>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-warning khongDuyetBtn">Không duyệt</a>
            <%if (Item.Username == Security.Username)
              { %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%} %>
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            
            

            
            <p class="alert alert-danger" style="display: none;"></p>
            <p class="alert alert-success" style="display: none;"></p>
        </div>
        
    
    </div>
    
    

    <div class="panel-footer">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/TruyThu/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-success duyetbtn">Duyệt</a>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-warning khongDuyetBtn">Không duyệt</a>
            <%if (Item.Username == Security.Username)
              { %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%} %>
    </div>
</div>
<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>

<%if(!string.IsNullOrEmpty(Id))
  {%>
  <script>
      $(function () {
      });
  </script>    
<%  } %>