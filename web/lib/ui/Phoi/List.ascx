<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_Phoi_List" %>
<%@ Register Src="~/lib/ui/Phoi/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

<div class="ModuleHeader">
    <div class="panel panel-default">
        <div class="panel-body" role="form">
            <div class="form-inline">
                <div class="form-group pull-left">
                    <a href="/lib/pages/Phoi/Add.aspx" class="btn btn-primary">Thêm</a>      
                    <a href="/lib/pages/Phoi/" class="btn btn-success">
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
                        <div class="form-group">
                            <select name="Duyet">
                                <option value="">Trạng thái</option>
                                <option value="false">Chưa khóa</option>
                                <option value="true">Khóa</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=TuNgay %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control TuNgay" 
                                id="TuNgay" 
                                name="TuNgay" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=DenNgay %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control DenNgay" 
                                id="DenNgay" 
                                name="DenNgay" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
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
                Mã
            </th>
            <th class="hidden-xs">
                Xe
            </th>
            <th>
                Nhà xe
            </th>
            <th class="hidden-xs">
                Thu
            </th>
            <th class="hidden-xs">
                Ngày
            </th>
            <th class="hidden-xs">
                Nhân viên
            </th>
            <th>
                Truy thu
            </th>
            <th>
                T/Thái
            </th>
        </tr>
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item runat="server" ID="Item1" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>   
</table>   
<% if(Pager!= null){ %> 
<ul class="pagination">
    <%=Pager.Paging %>    
</ul>
<%} %>