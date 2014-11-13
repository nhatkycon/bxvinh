<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KeToan_List.ascx.cs" Inherits="lib_ui_ThuNo_KeToan_List" %>
<%@ Register Src="~/lib/ui/ThuNo/templates/KeToan_Item.ascx" TagPrefix="uc1" TagName="KeToan_Item" %>

<div class="col-md-2">
    <div class="list-group">
        <a href="/lib/pages/ThuNo/KeToan.aspx?DaThu=0" class="list-group-item">
            Chưa thu
        </a>
        <a href="/lib/pages/ThuNo/KeToan.aspx?DaThu=1" class="list-group-item">
            Đã thu
        </a>
        <a href="/lib/pages/ThuNo/KeToan.aspx" class="list-group-item">
            Toàn bộ
        </a>
    </div>
</div>
<div class="col-md-10">
    <table class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th>
                    
                </th>
                <th >
                    Xe
                </th>
                <th class="hidden-xs">
                    Ngày
                </th>
                <th class="hidden-xs">
                    Tiền
                </th>
                <th class="hidden-xs">
                    Tình trạng
                </th>
            </tr>    
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <uc1:ketoan_item runat="server" id="KeToan_Item" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>  
    <% if(Pg!= null){ %> 
    <ul class="pagination">
        <%=Pg.Paging %>    
    </ul>
    <%} %>   
</div>