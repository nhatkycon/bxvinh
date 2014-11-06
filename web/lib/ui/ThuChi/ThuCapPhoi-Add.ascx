<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThuCapPhoi-Add.ascx.cs" Inherits="lib_ui_ThuChi_ThuCapPhoi_Add" %>
<%@ Import Namespace="docsoft" %>
<div class="row">
    <div class="col-md-1 ThuChi-HangDoi-XeYeuCauThanhToan-Pnl">
        <div class="panel panel-default">
            <div data-toggle="collapse" data-target="#ThuChi-HangDoi-XeYeuCauThanhToan-Body" class="panel-heading">
                <span class="pull-right">
                    <a href="javascript:;" class="btn-link">
                        <i class="glyphicon glyphicon-remove"></i>
                    </a>    
                </span>
                Xe chờ
            </div>    
            <div id="ThuChi-HangDoi-XeYeuCauThanhToan-Body" class="list-group ThuChi-HangDoi-XeYeuCauThanhToan-Body collapse in">
                        
            </div>    
        </div>
    </div>
    <div class="col-md-11">
        <div class="panel panel-default Normal-Pnl-Add ThuCapPhoi-Pnl-Add" 
            data-url="/lib/ajax/ThuChi/default.aspx"
            data-success="/lib/pages/ThuChi/ThuCapPhoi-Add.aspx?ID="
            data-list="/lib/pages/ThuChi/"
            >
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <input id="Id" style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
                    <input id="PHOI_ID" class="PHOI_ID" style="display: none;" value="<%=Item.PHOI_ID == 0 ? string.Empty  : Item.PHOI_ID.ToString() %>" name="PHOI_ID" type="text" />
                    <input id="XVB_ID" class="XVB_ID" style="display: none;" value="<%=Item.XVB_ID == 0 ? string.Empty : Item.XVB_ID.ToString() %>" name="XVB_ID" type="text" />
                    <div class="form-group">
                        <label for="STTBX" class="col-sm-2 col-xs-2 control-label">Số bến:</label>
                        <div class="col-sm-2 col-xs-4">
                            <input type="text" name="STTBX" disabled id="STTBX" value="<%=Item.STTBXStr %>" class="form-control STTBX" />
                        </div>
                        <label for="STTALL" class="col-sm-2 col-xs-2 control-label">Số công ty:</label>
                        <div class="col-sm-2 col-xs-4">
                            <input type="text" name="STTALL" disabled id="STTALL" data-sttAll="<%=Item.STTALLStr %>" value="<%=Item.STTALLStr %>" class="form-control STTALL" />
                        </div>
                    </div>
                   <div class="form-group">
                       <label for="XE_BienSo" class="col-sm-2 control-label">Xe:</label>
                        <div class="col-sm-2">
                            <div class="input-group">
                                <input type="text" placeholder="Nhập biển số xe" data-src="/lib/ajax/Xe/Default.aspx" 
                                    data-refId="XE_ID" class="form-control form-autocomplete-input-ThuChi-ChonXe XE_BienSo" name="XE_BienSo" id="XE_BienSo" value="<%=Item.XE_BienSo %>"/>
                                <span class="input-group-btn">
                                    <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                        <i class="glyphicon glyphicon-search"></i>
                                    </button>
                                </span>
                                <input type="text" style="display: none;" class="form-control XE_ID" name="XE_ID" 
                                    id="XE_ID" value="<%=Item.XE_ID %>"/>
                            </div>
                        </div>
                       <label for="Ngay" class="col-sm-2 control-label">Ngày:</label>
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
                        
                      
                    </div>
                    <div class="form-group">
                        <label for="Tien" class="col-sm-2 control-label">Phải thu:</label>
                        <div class="col-sm-2">
                            <input type="text" name="Tien" id="Tien" value="<%=Item.Tien %>" class="form-control input-lg Tien money-input">
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
                <%if (string.IsNullOrEmpty(Ret))
                  { %>
                    <a href="/lib/pages/ThuChi/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
                <% }else{ %>
                    <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
                <%} %>
                <%if (!string.IsNullOrEmpty(Id))
                    {%>
                    <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
           
                    <%if (Item.NguoiTao == Security.Username)
                      { %>
                        <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
                    <%} %>
                <%}
                else
                {%>
                    <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
                    <button class="btn restoreBtn btn-default">Đóng</button>
                <%} %>
            </div>
        </div>
        
    </div>
</div>
<%if(!string.IsNullOrEmpty(Id))
    {%>
    <script>
        $(function () {
        });
    </script>    
<%  } %>