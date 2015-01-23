<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="BangChamCongTheoCoQuan.aspx.cs" Inherits="lib_pages_ChamCong_BangChamCongTheoCoQuan" %>

<%@ Register Src="~/lib/ui/ChamCong/BangChamCongTheoCoQuan_List.ascx" TagPrefix="uc1" TagName="BangChamCongTheoCoQuan_List" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <div class="ModuleHeader">
    <div class="panel panel-default">
        <div class="panel-body" role="form">
            <div class="form-inline">
                <div class="form-group pull-left">
                    <a href="/lib/pages/ChamCong/BangChamCongTheoCoQuan.aspx" class="btn btn-success">
                        <i class="glyphicon glyphicon-refresh"></i>
                    </a>
                    <div class="input-group">
                        <input type="text" data-src="/lib/ajax/Tuyen/Default.aspx" data-refId="TUYEN_ID" value="<%=Item.Ten %>" class="form-control form-autocomplete-input TUYEN_Ten"/>
                        <span class="input-group-btn">
                            <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                <i class="glyphicon glyphicon-list"></i>
                            </button>
                        </span>
                        <input type="text" style="display: none;" class="form-control TUYEN_ID" name="ID"  value="<%=Item.ID==0 ? "" : Item.ID.ToString() %>"/>
                    </div>
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=TuNgay %>"
                            data-format="MM/yyyy" 
                            class="form-control Thang" 
                            id="Thang" 
                            name="Thang" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                    <a href="javascript:;" class="btn btn-default searchBtn">
                        <i class="glyphicon glyphicon-search"></i>
                    </a>
                </div>
                <div class="form-group pull-right">
                       <a target="_blank" href="/lib/pages/ChamCong/In/BangChamCongTheoCoQuan-In.aspx?ID=<%=TuyenId %>&Thang=<%=TuNgay %>" class="btn btn-default">
                        <i class="glyphicon glyphicon-print"></i>
                    </a>                     
                </div>
            </div>
        </div>               
    </div>
</div>
    <uc1:bangchamcongtheocoquan_list runat="server" id="BangChamCongTheoCoQuan_List" />
</asp:Content>

