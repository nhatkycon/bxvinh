<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GiaoCaList.ascx.cs" Inherits="lib_ui_Phoi_GiaoCaList" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/Phoi/templates/GiaoCaList-Item.ascx" TagPrefix="uc1" TagName="GiaoCaListItem" %>

<div class="ModuleHeader">
    <div class="panel panel-default">
        <div class="panel-body" role="form">
            <div class="form-inline">
                <div class="form-group pull-left">
                    <a href="/lib/pages/Phoi/Add.aspx" class="btn btn-primary">Thêm</a>      
                    <a href="/lib/pages/Phoi/GiaoCaList.aspx" class="btn btn-success">
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
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Ngay %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control ngay" 
                                id="ngay" 
                                name="ngay" 
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
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:giaocalistitem runat="server" id="GiaoCaListItem" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater> 
        <tr>
            <td class="">
                
            </td>
            <td >
            </td>
            <td class="hidden-xs">
            </td>
            <td style="text-align: right;">
                <strong>
                    <%=List.Count %>
                </strong>
            </td>
            <td class="hidden-xs" style="text-align: right;">
                <strong>
                    <%=List.Sum(x=>x.PHI_Tong).TienVietNam() %>
                </strong>
            </td>
            <td class="hidden-xs">
            </td>
            <td class="hidden-xs">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </tbody>
      
</table>   
