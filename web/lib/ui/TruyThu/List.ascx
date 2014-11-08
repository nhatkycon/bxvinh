<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_TruyThu_List" %>
<%@ Register Src="~/lib/ui/TruyThu/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

<div class="col-md-2">
    <div class="list-group">
        <a href="/lib/pages/TruyThu/Default.aspx" class="list-group-item">
            Tất cả
        </a>
        <a href="/lib/pages/TruyThu/Default.aspx?Duyet=0&DeNghi=1" class="list-group-item">
            Chưa duyệt
        </a>
        <a href="/lib/pages/TruyThu/Default.aspx?Duyet=1&DeNghi=1" class="list-group-item">
            Đã duyệt
        </a>
        <a href="/lib/pages/TruyThu/Default.aspx?&DeNghi=0" class="list-group-item">
            Thường
        </a>
    </div>
</div>
<div class="col-md-10">
    <div class="ModuleHeader">
        <div class="panel panel-default">
            <div class="panel-body" role="form">
                <div class="form-inline">
                    <div class="form-group pull-left">
                        <a href="/lib/pages/TruyThu/Add.aspx" class="btn btn-primary">Thêm</a>      
                        <a href="/lib/pages/TruyThu/" class="btn btn-success">
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
                            <div class="form-group">
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
                <th class="hidden-xs">
                    Phơi
                </th>
                <th class="hidden-xs">
                    Tổng
                </th>
                <th class="hidden-xs">
                    Số chuyến thiếu
                </th>
                <th class="hidden-xs">
                    Số chuyến đề nghị
                </th>
                <th>
                    Người lập
                </th>
                <th>
                    Ngày lập
                </th>
                <th>
                    Trạng thái
                </th>            
            </tr>    
        </thead>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:Item runat="server" ID="Item" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>   
    </table>   
    <% if(Pager!= null){ %> 
    <ul class="pagination">
        <%=Pager.Paging %>    
    </ul>
    <%} %>    
</div>