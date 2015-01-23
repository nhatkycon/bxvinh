<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddPhoiList-Item.ascx.cs" Inherits="lib_ui_ChamCong_templates_AddPhoiList_Item" %>
<%@ Import Namespace="linh.common" %>
<div class="col-md-2 addPhoiTruyThuChamCong-Item" data-id="<%=Item.ID %>">
    <div class="panel panel-default">
        <div class="panel-heading">
            <span class="pull-right">
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btnXoaNgayChamCong btn btn-link btn-sm">
                    <i class="glyphicon glyphicon-remove"></i>
                </a>    
            </span>
            <%=Item.Ngay.NgayVn() %>
        </div>
        <div class="panel-body">
            <div class="input-group">
              <span class="input-group-addon">
                <label title="Truy thu">
                    <%if(Item.Loai==3){ %>
                        <input checked="checked" data-id="<%=Item.ID %>" class="ChamCongTruyChuCkb" type="checkbox" name="ChamCongIsTruyThu">
                    <%}else{ %>
                        <input data-id="<%=Item.ID %>" class="ChamCongTruyChuCkb" type="checkbox" name="ChamCongIsTruyThu">
                    <%} %>
                </label>
              </span>
                <input data-id="<%=Item.ID %>" name="GhiChu" placeholder="Ghi lý do" class="form-control addPhoiTruyThuChamCong-Item-InputAjax" />
            </div>
        </div>
    </div>    
</div>
