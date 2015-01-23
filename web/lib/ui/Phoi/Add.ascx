<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_Phoi_Add" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/Phoi/TruyThuDialog.ascx" TagPrefix="uc1" TagName="TruyThuDialog" %>
<%@ Register Src="~/lib/ui/Phoi/ChamCongCalendar_View.ascx" TagPrefix="uc1" TagName="ChamCongCalendar_View" %>

<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="row">
    <div class="col-md-2 Phoi-HangDoi-XeYeuCauXuLy-Pnl">
        <div class="panel panel-default">
            <div data-toggle="collapse" data-target="#Phoi-HangDoi-XeYeuCauXuLy-Body" class="panel-heading">
                <span class="pull-right">
                    <a href="javascript:;" class="btn-link">
                        <i class="glyphicon glyphicon-remove"></i>
                    </a>    
                </span>
                Xe chờ
            </div>    
            <div id="Phoi-HangDoi-XeYeuCauXuLy-Body" class="list-group Phoi-HangDoi-XeYeuCauXuLy-Body collapse in"></div>    
        </div>
    </div>
    <div class="col-md-10" >
        <div data-id="<%=Item.ID==0 ? "" : Item.ID.ToString() %>" 
            data-draff="<%=Item.Draff.ToString().ToLower() %>"
            class="panel panel-default Normal-Pnl-Add Phoi-ThongTinXe-Pnl" 
            data-url="/lib/ajax/Phoi/default.aspx"
            data-success="/lib/pages/Phoi/Add.aspx?ID="
            data-list="/lib/pages/Phoi/"
            >    
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <input id="Id" class="ID" form-control-hasDefalltValue style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
                    <input id="Draff" form-control-hasDefalltValue class="draff" style="display: none;" value="<%=Item.Draff.ToString().ToLower() %>" name="Draff" type="text" />
                    <input id="CQ_ID" style="display: none;" value="<%=Item.CQ_ID == 0 ? string.Empty  : Item.CQ_ID.ToString() %>" name="CQ_ID" type="text" />
                    <input id="XVB_ID" class="XVB_ID" style="display: none;" value="<%=Item.XeVaoBen.ID==0 ? "" : Item.XeVaoBen.ID.ToString() %>" name="XVB_ID" type="text" />
                    <div class="Phoi-Xe-Pnl">
                        <div class="form-group">
                            <label for="STTBX" class="col-sm-1 col-xs-2 control-label">Số:</label>
                            <div class="col-sm-3 col-xs-4">
                                <div class="input-group">
                                    <input type="text" name="STTBX" disabled id="STTBX" value="<%=Item.STTBXStr %>" class="form-control STTBX" form-control-hasDefalltValue/>
                                    <span class="input-group-addon">/</span>
                                    <input type="text" name="STTALL" disabled id="STTALL" data-sttAll="<%=Item.STTALLStr %>" value="<%=Item.STTALLStr %>" class="form-control STTALL" form-control-hasDefalltValue/>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">Bến đi:</span>
                                    <input type="text" name="DI_Ten" id="DI_Ten" disabled value="<%=Item.Xe.Tuyen.DI_Ten %>" class="form-control DI_Ten">
                                    <span class="input-group-addon">Bến đến:</span>
                                    <input type="text" name="DEN_Ten" id="DEN_Ten" disabled value="<%=Item.Xe.Tuyen.DEN_Ten %>" class="form-control DEN_Ten">
                                </div>
                            </div>                                
                            <label for="NgayXuatBen" class="col-sm-1 col-xs-12 control-label">Ngày:</label>
                            <div class="col-sm-3 col-xs-12">
                                <div id="NgayXuatBenPicker" class="input-append datepicker-input date input-group">
                                    <input form-control-hasDefalltValue
                                        value="<%=Item.NgayXuatBen == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgayXuatBen.ToString("dd/MM/yyyy") %>"
                                        data-format="dd/MM/yyyy" 
                                        class="form-control NgayXuatBen" 
                                        autofocus
                                        id="NgayXuatBen" 
                                        name="NgayXuatBen" 
                                        type="text"/>
                                    <span class="add-on input-group-addon">
                                        <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                        </i>
                                    </span>
                                </div>
                            </div>  
                        </div>
                        <div class="form-group">
                            <label for="XE_BienSo" class="col-sm-1 control-label">Biển:</label>
                            <div class="col-sm-3">
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                            <i class="glyphicon glyphicon-search"></i>
                                        </button>
                                    </span>
                                    <input  data-toggle="tooltip" title="Gõ biển số xe" type="text" placeholder="Nhập biển số xe" 
                                        data-src="/lib/ajax/Xe/Default.aspx" data-refId="XE_ID" 
                                        class="form-control form-autocomplete-input-Phoi-ChonXe XE_BienSo" name="XE_BienSo" id="XE_BienSo" value="<%=Item.Xe.BienSo_Chu %> <%=Item.Xe.BienSo_So %>"/>
                                    
                                    <input type="text" style="display: none;" class="form-control XE_ID" name="XE_ID" id="XE_ID" value="<%=Item.XE_ID %>"/>
                                </div>
                            </div>
                
                            <label for="XE_BienSo" class="col-sm-1 control-label">Lái:</label>
                            <div class="col-sm-3">
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                            <i class="glyphicon glyphicon-search"></i>
                                        </button>
                                    </span>
                                    <input type="text" data-src="/lib/ajax/LaiXe/Default.aspx" data-refId="LAIXE_ID" class="form-control form-autocomplete-input-Phoi-ChonLaiXe LAIXE_Ten" name="LAIXE_Ten" id="LAIXE_Ten" value="<%=Item.LaiXe.Ten %>"/>
                                    <input type="text" style="display: none;" class="form-control LAIXE_ID" name="LAIXE_ID" id="LAIXE_ID" value="<%=Item.LAIXE_ID %>"/>
                                </div>
                            </div>
                
                             <label for="GioXuatBen" class="col-sm-1 control-label">Giờ xuất bến:</label>
                             <div class="col-sm-3">                    
                                <div class="input-group bootstrap-timepicker">
                                    <input type="text" name="GioXuatBen" id="GioXuatBen" value="<%=Item.Xe.GioXuatBen %>" class="form-control GioXuatBen timePicker-input">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                                </div>
                            </div>  

                        </div>
            
                        <div class="form-group">
                            <label for="XeThayThe" class="col-sm-1 control-label">Xe thay thế:</label>
                            <div class="col-sm-3">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        
                                <%if (Item.XeThayThe)
                                    {%>
                                        <input class="XeThayThe" id="XeThayThe" form-control-hasDefalltValue checked="checked" name="XeThayThe" type="checkbox"/>
                                    <%}
                                    else
                                    {%>
                                        <input class="XeThayThe" id="XeThayThe" form-control-hasDefalltValue name="XeThayThe" type="checkbox"/>
                                    <% } %>
                                    </span>
                                    <input type="text" data-src="/lib/ajax/Xe/Default.aspx" data-refId="XeThayThe_ID" class="form-control form-autocomplete-input XeThayThe_BienSo" name="XeThayThe_BienSo" id="XeThayThe_BienSo" value="<%=Item.XeThayThe_BienSo %>"/>
                                    <span class="input-group-btn">
                                        <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                            <i class="glyphicon glyphicon-search"></i>
                                        </button>
                                    </span>
                                    <input type="text" style="display: none;" class="form-control XeThayThe_ID" name="XeThayThe_ID" id="XeThayThe_ID" value="<%=Item.XeThayThe_ID %>"/>
                                </div>
                            </div>
                            <label for="DONVI_Ten" class="col-sm-1 control-label">Chủ xe:</label>
                            <div class="col-sm-3">
                                <input type="text" name="DONVI_Ten" disabled id="DONVI_Ten" value="<%=Item.Xe.DONVI_Ten %>" class="form-control DONVI_Ten">
                            </div>      
                            <label for="XeTangCuong" class="col-sm-1 control-label">Tăng cường:</label>
                            <div class="col-sm-3">
                                <%if (Item.XeTangCuong)
                                {%>
                                    <input class="XeTangCuong input-sm" id="XeTangCuong" form-control-hasDefalltValue  checked="checked" name="XeTangCuong" type="checkbox"/>
                                <%}
                                else
                                {%>
                                    <input class="XeTangCuong input-sm" id="XeTangCuong" form-control-hasDefalltValue  name="XeTangCuong" type="checkbox"/>
                                <% } %>
                            </div>   
                        </div>
                    </div>
            
            
                    <div class="Phoi-NghiepVu-Pnl <%=Item.ID == 0 ? "" : " Phoi-NghiepVuActive-Pnl" %>">                
                        <div class="well well-sm Phoi-NghiepVu-HanPnl">
                            <div class="form-group">
                                <label for="TuyenCoDinhStr" class="col-sm-1 control-label">Tuyến CĐ:</label>
                                <div class="col-sm-1">
                                    <p name="TuyenCoDinhStr" id="TuyenCoDinhStr" class="form-control-static DateValidator TuyenCoDinhStr"><%=Item.Xe.TuyenCoDinhStr %></p>
                                </div>
                                <label for="LuuHanhStr" class="col-sm-1 control-label">Lưu hành:</label>
                                <div class="col-sm-1">
                                    <p name="LuuHanhStr" id="LuuHanhStr" class="form-control-static DateValidator LuuHanhStr"><%=Item.Xe.LuuHanhStr %></p>
                                </div>    
                                <label for="BaoHiemStr" class="col-sm-1 control-label">Bảo hiểm:</label>
                                <div class="col-sm-1">                    
                                    <p name="BaoHiemStr" id="BaoHiemStr" class="form-control-static DateValidator BaoHiemStr"><%=Item.Xe.BaoHiemStr %></p>
                                </div>           
                                <label for="NgayHetHanBangLaiStr" class="col-sm-1 control-label">Hạn BL:</label>
                                <div class="col-sm-1">
                                    <p name="NgayHetHanBangLaiStr" id="NgayHetHanBangLaiStr" class="form-control-static DateValidator NgayHetHanBangLaiStr"><%=Item.LaiXe.NgayHetHanBangLaiStr %></p>
                                </div>
                                <label for="NgayHetHanGiayKhamSucKhoeStr" class="col-sm-1 control-label">Giấy KSK:</label>
                                <div class="col-sm-1">
                                    <p name="NgayHetHanGiayKhamSucKhoeStr" id="NgayHetHanGiayKhamSucKhoeStr" class="form-control-static DateValidator NgayHetHanGiayKhamSucKhoeStr"><%=Item.LaiXe.NgayHetHanGiayKhamSucKhoeStr %></p>
                                </div>    
                                <label for="BaoHiemStr" class="col-sm-1 control-label">Khóa:</label>
                                <div class="col-sm-1">                    
                                    <%if (Item.Xe.Khoa)
                                    {%>
                                        <input tabindex="-1" class="XE_Khoa input-sm" id="Khoa" disabled checked="checked" type="checkbox"/>
                                    <%}
                                    else
                                    {%>
                                        <input tabindex="-1" class="XE_Khoa input-sm" id="Khoa" disabled type="checkbox"/>
                                    <% } %>
                                </div>           
                            </div>
                        </div>
                    <div class="Phoi-TruyThuPnl">
                        <div class="Phoi-TruyThuPnl-ChamCongPnl">
                            <uc1:ChamCongCalendar_View runat="server" ID="ChamCongCalendar_View" />                    
                        </div>
                    </div>
                   <hr/> 
                        <div class="Phoi-TruyThuNgayChamCongPnl">
                        <p>
                            <span class="pull-right" data-toggle="tooltip"  title="Click để đề nghị truy thu" >
                                <button data-toggle="modal" data-target="#TruyThuModal" class="btn btn-default btn-sm" type="button">
                                    <i class="glyphicon glyphicon-paperclip"></i>
                                </button>
                            </span>
                            <strong>Truy thu chi tiết</strong>
                            <button class="btn btn-link btn-sm" data-toggle="collapse" data-target="#Phoi-TruyThuNgayChamCongPnl-Body">
                                    <i class="glyphicon glyphicon-plus"></i>
                            </button>
                        </p>
                            <hr/>
                        <div class="collapse" id="Phoi-TruyThuNgayChamCongPnl-Body">
                            <div class="Phoi-TruyThuNgayChamCongPnl-Body row">
                            </div>
                            <hr/>
                        </div>
                    </div>
                    <div class="">
                        <div class="Phoi-ThuPhi-Pnl">
                            <p>                                
                                <strong>Thu phí</strong>
                                <button class="btn btn-link btn-sm" data-toggle="collapse" data-target="#Phoi-ThuPhiForm-Pnl">
                                    <i class="glyphicon glyphicon-plus"></i>
                                </button>
                            </p>
                                <hr/>
                            <div class="Phoi-ThuPhiForm-Pnl collapse" id="Phoi-ThuPhiForm-Pnl">
                                <div class="form-group">
                                    <label for="PHI_BenBai" class="col-sm-1 control-label">Bến bãi:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_BenBai" id="PHI_BenBai" value="<%=Item.PHI_BenBai %>" class="form-control PHI_BenBai ThuPhiMotChuyen-Input-Item ThuPhi-Input-Item money-input">
                                    </div>                                  
                                    <label for="PHI_XeDauDem" class="col-sm-1 control-label">Đậu đêm:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_XeDauDem" id="PHI_XeDauDem" value="<%=Item.PHI_XeDauDem %>" class="form-control PHI_XeDauDem ThuPhi-Input-Item money-input">
                                    </div>                                  
                                    <label for="PHI_VeSinhBenBai" class="col-sm-1 control-label">Vệ sinh:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_VeSinhBenBai" id="Text1" value="<%=Item.PHI_VeSinhBenBai %>" class="form-control ThuPhiMotChuyen-Input-Item PHI_VeSinhBenBai ThuPhi-Input-Item money-input">
                                    </div>              
                                    <label for="PHI_XeLuuBen" class="col-sm-1 control-label">Lưu bến:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_XeLuuBen" id="PHI_XeLuuBen" value="<%=Item.PHI_XeLuuBen %>" class="form-control PHI_XeLuuBen ThuPhiMotChuyen-Input-Item ThuPhi-Input-Item money-input">
                                    </div>
                                </div>                    
                                <div class="form-group">
                                    <label for="Ve" class="col-sm-1 col-xs-12 control-label">Bán vé</label>
                                    <div class="col-sm-6 col-xs-2">
                                        <div class="input-group">
                                            <input type="text" name="GiaVe" id="GiaVe" value="<%=Item.GiaVe %>" class="form-control GiaVe money-input">
                                            <span class="input-group-addon">X</span>
                                            <input type="text" name="HoaHongBanVe" id="HoaHongBanVe" value="<%=Item.Xe.Tuyen.HoaHongBanVe %>" class="form-control HoaHongBanVe money-input">
                                            <%--<span class="input-group-addon">=</span>
                                            <input type="text" name="PhiTrenMotVe" disabled id="PhiTrenMotVe" value="<%=Item.GiaVe * Item.Xe.Tuyen.HoaHongBanVe / 100 %>" class="form-control PhiTrenMotVe money-input">--%>
                                            <span class="input-group-addon">X</span>
                                            <input type="text" name="Ve" id="Ve" value="<%=Item.Ve %>" class="form-control Ve money-input">
                                            <span class="input-group-addon">=</span>
                                            <input type="text" name="PHI_HoaHongBanVe" disabled id="PHI_HoaHongBanVe" value="<%=Item.PHI_HoaHongBanVe %>" class="form-control ThuPhiMotChuyen-Input-Item PHI_HoaHongBanVe ThuPhi-Input-Item money-input">
                                        </div>
                                    </div>
                                    <label for="KhachTruyThu" class="col-sm-1 col-xs-12 control-label">
                                        Khách thêm:
                                    </label>
                                    <div class="col-sm-3 col-xs-2">
                                        <div class="input-group">
                                            <input type="text" name="KhachTruyThu" id="KhachTruyThu" value="<%=Item.KhachTruyThu %>" class="form-control KhachTruyThu money-input">
                                            <span class="input-group-addon">=</span>
                                            <input type="text" name="PHI_KhachTruyThu" disabled id="PHI_KhachTruyThu" value="<%=Item.PHI_KhachTruyThu %>" class="form-control ThuPhi-Input-Item PHI_KhachTruyThu money-input">
                                        </div>    
                                    </div>    
                               
                                </div>
                                <div class="form-group">
                                    <label for="ChuyenTruyThu"  class="col-sm-1 control-label">Truy thu:</label>
                                    <div class="col-sm-3">
                                        <div class="input-group">                                            
                                            <input type="text" name="ChuyenTruyThu" placeholder="Số chuyến truy thu" disabled id="ChuyenTruyThu" value="<%=Item.ChuyenTruyThu %>" class="form-control ChuyenTruyThu money-input">
                                            <span data-toggle="tooltip" title="Tick chọn nếu chỉ truy thu bến bãi. Bỏ tick nếu truy thu bến bãi + khách." class="input-group-addon" title="Tick nếu chỉ truy thu phí bến bãi">
                                                <%if (Item.PHI_ChiThuBenBai)
                                                {%>
                                                    <input class="PHI_ChiThuBenBai" form-control-hasDefalltValue id="PHI_ChiThuBenBai" checked="checked" name="PHI_ChiThuBenBai" type="checkbox"/>
                                                <%}
                                                else
                                                {%>
                                                    <input class="PHI_ChiThuBenBai" form-control-hasDefalltValue id="PHI_ChiThuBenBai" name="PHI_ChiThuBenBai" type="checkbox"/>
                                                <% } %>
                                            </span>
                                            <input type="text" name="PHI_ChuyenTruyThu" id="PHI_ChuyenTruyThu" value="<%=Item.PHI_ChuyenTruyThu %>" class="form-control PHI_ChuyenTruyThu ThuPhi-Input-Item money-input">
                                        
                                        </div>
                                    </div>                                  
                                    <%--<label for="PHI_ChuyenTruyThu" class="col-sm-2 control-label">Phí truy thu:</label>
                                    <div class="col-sm-2">
                                        <div class="input-group">
                                        
                                        </div>
                                    </div>--%>
                                    <label for="PHI_TruyThuGiam" class="col-sm-1 control-label">Giảm trừ:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_TruyThuGiam" id="PHI_TruyThuGiam" value="<%=Item.PHI_TruyThuGiam %>" class="form-control PHI_TruyThuGiam money-input">
                                    </div>  
                                    <label for="PHI_Khac" class="col-sm-1 control-label">Khác:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_Khac" id="PHI_Khac" value="<%=Item.PHI_Khac %>" class="form-control PHI_Khac ThuPhi-Input-Item money-input">
                                    </div>             
                                </div>    
                                <hr/>
                            </div>
                            <div class="form-group">
                                <label for="PHI_Tong" class="col-sm-1 control-label">Tổng:</label>
                                <div class="col-sm-3">
                                    <input type="text" name="PHI_Tong" id="PHI_Tong" disabled value="<%=Item.PHI_Tong %>" class="form-control PHI_Tong ThuPhi-Input-Sum money-input input-lg">
                                </div>        
                                <div class="hidden">
                                    <label for="PHI_Nop" class="col-sm-2 control-label">Thu:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_Nop" id="PHI_Nop" value="<%=Item.PHI_Nop %>" class="form-control PHI_Nop money-input">
                                    </div>              
                                    <label for="PHI_ConNo" class="col-sm-2 control-label">Còn nợ:</label>
                                    <div class="col-sm-2">
                                        <input type="text" name="PHI_ConNo" id="PHI_ConNo" disabled value="<%=Item.PHI_ConNo %>" class="form-control PHI_ConNo money-input">
                                    </div>                  
                                </div>      
                            </div>
                        </div> 
                    </div>
            
                    </div>            
            
                    <%if (!string.IsNullOrEmpty(Id)){ %>
                        <div class="help-block">
                            <div class="well well-sm">
                                <p>
                                    <i class="glyphicon glyphicon-info-sign"></i>
                                    <strong><%=Item.Username %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.    
                                    sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                                </p>
                                <%if(Item.TruyThuItem.ID!= 0 && Item.TruyThuItem.Duyet){ %>
                                    <p>
                                        <strong><%=Item.TruyThuItem.LanhDaoDuyet %></strong> duyệt <strong><%=Item.TruyThuItem.SoChuyenDuocDuyet %></strong> chuyến, ngày <%=Item.TruyThuItem.NgayDuyet.NgayVn() %>
                                    </p>                                
                                <%} %>
                            </div>
                        </div>
                    <%} %>
                    <br clear="all"/>                        
                    <p class="alert alert-danger" style="display: none;"></p>
                    <p class="alert alert-success" style="display: none;"></p>
                    <uc1:TruyThuDialog runat="server" id="TruyThuDialog" />
                    
                </div>
            </div>
            <div class="panel-footer" style="display: none;">
        
                <%if (!string.IsNullOrEmpty(Id))
                    {%>
                    <div class="panel-footer-insert" style="display: none;">
                            <button class="btn saveBtn btn-lg btn-primary" data-toggle="tooltip" title="Cấp phơi ngày hôm nay + truy thu">Phơi-F8</button>
                            <button class="btn truyThuBtn btn-lg btn-default" data-toggle="tooltip" title="Truy thu (không cấp phơi ngày hôm nay)">Truy thu-F9</button>
                            <button class="btn restoreBtn btn-lg btn-default" data-toggle="tooltip" title="Đóng lại">Đóng-F10</button>    
                    </div>
                    <div class="panel-footer-saved">
                        <a href="/lib/pages/Phoi/In/Phoi-NgoaiTinh.aspx?ID=<%=Item.ID %>" data-id="" data-url="/lib/pages/Phoi/In/Phoi-NgoaiTinh.aspx" target="_blank" class="btn printBtn btn-lg btn-primary">In</a>                        
                        <button  class="btn newBtn btn-lg btn-success">Thêm-F6</button>
                        <a href="/lib/pages/Phoi/Add.aspx?ID=<%=Item.ID %>" data-url="/lib/pages/Phoi/Add.aspx" data-id="" class="btn editBtn btn-lg btn-default">Sửa</a>
                        <%if (Item.Username == Security.Username)
                        { %>
                            <a href="javascript:;" data-id="" class="btn btn-warning btn-lg xoaBtn">Xóa</a>
                        <%}%>
                    </div>
                <%}
                else
                {%>
                    <div class="panel-footer-insert">
                        <button class="btn saveBtn btn-lg btn-primary" data-toggle="tooltip" title="Cấp phơi ngày hôm nay + truy thu">Phơi-F8</button>
                        <button class="btn truyThuBtn btn-lg btn-default" data-toggle="tooltip" title="Truy thu (không cấp phơi ngày hôm nay)">Truy thu-F9</button>
                        <button class="btn restoreBtn btn-lg btn-default" data-toggle="tooltip" title="Đóng lại">Đóng-F10</button>    
                    </div>
                    <div class="panel-footer-saved">
                        
                        <a  data-id="" data-url="/lib/pages/Phoi/In/Phoi-NgoaiTinh.aspx" target="_blank" class="btn printBtn btn-lg btn-primary">In</a>
                        <button  class="btn newBtn btn-lg btn-success" data-toggle="tooltip" title="Thêm mới">Thêm-F6</button>
                        <a data-url="/lib/pages/Phoi/Add.aspx" data-id="" class="btn editBtn btn-lg btn-default">Sửa</a>
                        <a href="javascript:;" data-id="" class="btn btn-warning btn-lg xoaBtn">Xóa</a>
                    </div>
                    
                <%} %> 
        
            </div>
        </div>       
    </div>
</div>
<div class="Phoi-DeNghiTruyThu-Pnl">
    <div class="row Phoi-DeNghiTruyThu-Body">
    </div>
</div>
<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>
<script>
<%if(!string.IsNullOrEmpty(Id))
  {%>
    
    <%  } else{ %>
    
<%} %>
</script>

