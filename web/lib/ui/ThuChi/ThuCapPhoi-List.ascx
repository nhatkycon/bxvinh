<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuCapPhoi-List.ascx.cs" Inherits="lib_ui_ThuChi_ThuCapPhoi_List" %>
<%@ Import Namespace="linh.controls" %>
<%@ Register Src="~/lib/ui/ThuChi/templates/ThuCapPhoi-Item.ascx" TagPrefix="uc1" TagName="ThuCapPhoiItem" %>

<div class="ModuleHeader">
        <div class="panel panel-default">
            <div class="panel-body" role="form">
                <div class="form-inline">
                    <div class="form-group pull-left">
                        <a href="/lib/pages/ThuChi/ThuCapPhoi-Add.aspx" class="btn btn-primary">Thêm</a>      
                        <a href="/lib/pages/ThuChi/ThuCapPhoi-List.aspx" class="btn btn-success">
                            <i class="glyphicon glyphicon-refresh"></i>
                        </a>
                    </div>
                    <div class="form-group pull-right">
                        <a href="javascript:;" class="btn btn-default" data-toggle="collapse" data-target="#filtering">
                            <i class="glyphicon glyphicon-search"></i>
                        </a>
                    </div>
                </div>
            </div>               
        </div>
        <div id="filtering" class="panel panel-default collapse">
            <div class="panel-body">
                <div class="form-inline">
                    <div class="row">
                        <div class="col-sm-2">
                            <div class="pull-right">
                                <div class="input-group">
                                  <input name="q" type="text" value="<%=Request["q"] %>" class="form-control">
                                  <div class="input-group-btn">
                                    <a class="btn btn-default searchBtn">
                                        <i class="glyphicon glyphicon-search"></i>
                                    </a>                                
                                  </div>
                                </div>            
                            </div>                    
                        </div>
                    </div>   
                </div>            
            </div>
        </div>
    </div> 
    <table class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th class="">
                    #
                </th>
                <th >
                    STT
                </th>
                <th class="hidden-xs">
                    Xe
                </th>
                <th class="hidden-xs">
                    Tiền
                </th>
                <th class="hidden-xs">
                    Ngày thu
                </th>
                <th class="hidden-xs">
                    Người thu
                </th>                
            </tr>    
        </thead>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:thucapphoiitem runat="server" id="ThuCapPhoiItem"  Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>   
    </table>   
    <% if(Pager != null){ %> 
    <ul class="pagination">
        <%=Pager.Paging %>    
    </ul>
    <%} %> 