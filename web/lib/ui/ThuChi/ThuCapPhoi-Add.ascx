<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuCapPhoi-Add.ascx.cs" Inherits="lib_ui_ThuChi_ThuCapPhoi_Add" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="row">
    <div class="col-md-2 ThuChi-HangDoi-XeYeuCauThanhToan-Pnl">
        <div class="panel panel-default">
            <div data-toggle="collapse" data-target="#ThuChi-HangDoi-XeYeuCauThanhToan-Body" class="panel-heading">
                <span class="pull-right">
                    <a href="javascript:;" class="btn-link">
                        <i class="glyphicon glyphicon-remove"></i>
                    </a>    
                </span>
                Xe chờ thanh toán
            </div>    
            <div id="ThuChi-HangDoi-XeYeuCauThanhToan-Body" class="list-group ThuChi-HangDoi-XeYeuCauThanhToan-Body collapse in">
            </div>
        </div>
    </div>
    <div class="col-md-10">
        <div class="panel panel-default ThuCapPhoi-Pnl-Add" 
            data-url="/lib/ajax/ThuChi/default.aspx"
            data-success="/lib/pages/ThuChi/ThuCapPhoi-Add.aspx?ID="
            data-list="/lib/pages/ThuChi/"
            data-id="<%=Item.ID==0 ? "" : Item.ID.ToString() %>"
            >
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <input class="ID" id="Id" style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
                    <input id="PHOI_ID" class="PHOI_ID" style="display: none;" value="<%=Item.PHOI_ID == 0 ? string.Empty  : Item.PHOI_ID.ToString() %>" name="PHOI_ID" type="text" />
                    <input id="XVB_ID" class="XVB_ID" style="display: none;" value="<%=Item.XVB_ID == 0 ? string.Empty : Item.XVB_ID.ToString() %>" name="XVB_ID" type="text" />
                    <div class="form-group">
                        <label for="STTBX" class="col-sm-1 col-xs-2 control-label">Số:</label>
                        <div class="col-sm-3 col-xs-4">
                            <div class="input-group">
                                <input type="text" name="STTBX" disabled id="STTBX" value="<%=Item.STTBXStr %>" class="form-control STTBX" />
                                <span class="input-group-addon">/</span>
                                <input type="text" name="STTALL" disabled id="STTALL" data-sttAll="<%=Item.STTALLStr %>" value="<%=Item.STTALLStr %>" class="form-control STTALL" />
                            </div>
                        </div>
                        <label for="Ngay" class="col-sm-1 control-label">Ngày:</label>
                        <div class="col-sm-2">
                            <div id="NgayPicker" class="input-append datepicker-input date input-group">
                                <input 
                                    value="<%=Item.Ngay == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.Ngay.ToString("dd/MM/yyyy") %>"
                                    data-format="dd/MM/yyyy" 
                                    class="form-control Ngay" 
                                    id="Ngay" 
                                    name="Ngay" 
                                    type="text"/>
                                <span class="add-on input-group-addon">
                                    <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                    </i>
                                </span>
                            </div>
                        </div>
                        <label for="XE_BienSo" class="col-sm-1 control-label">Xe:</label>
                        <div class="col-sm-2">
                            <input type="text" placeholder="Nhập biển số xe" class="form-control XE_BienSo" name="XE_BienSo" id="XE_BienSo" value="<%=Item.XE_BienSo %>"/>
                        </div>
                    </div>
                   <div class="form-group">
                       
                        <label for="Tien" class="col-sm-1 control-label">Phải thu:</label>
                        <div class="col-sm-3">
                            <input type="text" name="Tien" id="Tien" value="<%=Item.Tien %>" class="form-control input-lg Tien money-input"/>
                        </div>                      
                    </div>
                    <%if (!string.IsNullOrEmpty(Id)){ %>
                        <div class="help-block">
                            <div class="well well-sm">
                                <i class="glyphicon glyphicon-info-sign"></i>
                                <strong><%=Item.NguoiTao %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                                sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                            </div>
                        </div>
                    <%} %>
                    <p class="alert alert-danger" style="display: none;"></p>
                    <p class="alert alert-success" style="display: none;"></p>
                </div>
            </div>
            <div class="panel-footer">

                <%if (!string.IsNullOrEmpty(Id))
                    {%>
                    <div class="panel-footer-insert">
                        <button class="btn saveBtn btn-lg btn-primary">Thu tiền-F8</button>
                        <button class="btn restoreBtn btn-lg btn-default">Đóng-F10</button>    
                    </div>
                    <div class="panel-footer-saved">
                        <a href="/lib/pages/ThuChi/In/ThuCapPhoi.aspx?ID=<%=Item.ID %>" data-id="" data-url="/lib/pages/ThuChi/In/ThuCapPhoi.aspx" target="_blank" class="btn printBtn btn-lg btn-primary">In</a>
                        <button  class="btn newBtn btn-lg btn-success">Thêm-F6</button>
                        <a href="/lib/pages/ThuChi/ThuCapPhoi-Add.aspx?ID=<%=Item.ID %>" data-id="" data-url="/lib/pages/ThuChi/In/ThuCapPhoi.aspx" class="btn editBtn btn-lg btn-default">Sửa</a>
                        <%if (Item.NguoiTao == Security.Username)
                        { %>
                            <a href="javascript:;" data-id="" class="btn btn-warning btn-lg xoaBtn">Xóa</a>
                        <%} %>
                    </div>
           
                    
                <%}
                else
                {%>
                    <div class="panel-footer-insert">
                        <button class="btn saveBtn btn-lg btn-primary">Thu tiền-F8</button>
                        <button class="btn restoreBtn btn-lg btn-default">Đóng-F10</button>    
                    </div>
                    <div class="panel-footer-saved">
                        <a  data-id="" data-url="/lib/pages/ThuChi/In/ThuCapPhoi.aspx" target="_blank" class="btn printBtn btn-lg btn-primary">In</a>
                        <button  class="btn newBtn btn-lg btn-success">Thêm-F6</button>
                        <a href="javascript:;" data-id="" data-url="/lib/pages/ThuChi/ThuCapPhoi-Add.aspx" class="btn editBtn btn-lg btn-default">Sửa</a>
                        <a href="javascript:;" data-id="" class="btn btn-warning btn-lg xoaBtn">Xóa</a>
                    </div>
                <%} %>
            </div>
        </div>
        
    </div>
</div>