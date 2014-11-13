<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TS_Tuyen.ascx.cs" Inherits="lib_ui_Xe_TS_Tuyen" %>
<%@ Register Src="~/lib/ui/Xe/templates/TS_Tuyen-Item.ascx" TagPrefix="uc1" TagName="TS_TuyenItem" %>
<div class="ModuleHeader">
        <div class="panel panel-default">
            <div class="panel-body" role="form">
                <div class="form-inline">
                    <div class="form-group pull-left">
                        <a href="/lib/pages/Xe/TS_Tuyen.aspx" class="btn btn-success">
                            <i class="glyphicon glyphicon-refresh"></i>
                        </a>
                        <div class="input-group">
                            <input type="text" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=BenXe" placeholder="Chọn bến đi" data-refId="DI_ID" class="form-control form-autocomplete-input DI_Ten" name="DI_Ten" id="DI_Ten"  value="<%=Item.ID>0 ? Item.DI_Ten : "" %>"/>
                            <span class="input-group-btn">
                            <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                <i class="glyphicon glyphicon-list"></i>
                            </button>
                            </span>
                            <input type="text" style="display: none;" class="form-control DI_ID" name="DI_ID" id="DI_ID"  value="<%=Item.ID>0 ? Item.DI_ID.ToString() : "" %>"/>
                        </div>
                        <div class="input-group">
                            <input type="text" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=BenXe" placeholder="Chọn bến đến" data-refId="DEN_ID" class="form-control form-autocomplete-input DEN_Ten" name="DEN_Ten" id="DEN_Ten" value="<%=Item.ID>0 ? Item.DEN_Ten : "" %>"/>
                            <span class="input-group-btn">
                            <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                <i class="glyphicon glyphicon-list"></i>
                            </button>
                            </span>
                            <input type="text" style="display: none;" class="form-control DEN_ID" value="<%=Item.ID>0 ? Item.DEN_ID.ToString() : "" %>" name="DEN_ID" id="DEN_ID"/>
                        </div>
                        <a href="javascript:;" class="btn btn-default searchBtn">
                            <i class="glyphicon glyphicon-search"></i>
                        </a>
                    </div>
                    <div class="form-group pull-right">
                        
                    </div>
                </div>
            </div>               
        </div>
    </div> 
<%if(Item.ID>0){ %>
<h3>
    <%=Item.Ten %>
</h3>
<%} %>
<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th >
                Xe
            </th>
            <th class="hidden-xs">
                Đơn vị
            </th>
            <th class="hidden-xs">
                Số ghế
            </th>
            <th class="hidden-xs">
                Giá vé
            </th>
            <th class="hidden-xs">
                Giờ xuất bến
            </th>
            <th>
                Trạng thái
            </th>            
        </tr>    
    </thead>
    <tbody class="XeByTuyenList">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:TS_TuyenItem runat="server" ID="TS_TuyenItem1" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>   