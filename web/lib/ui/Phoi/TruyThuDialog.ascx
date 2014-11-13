<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TruyThuDialog.ascx.cs" Inherits="lib_ui_Phoi_TruyThuDialog" %>
<!-- Modal -->
<div class="modal fade" id="TruyThuModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel">
            Đề nghị truy thu
        </h4>
      </div>
      <div class="modal-body">
          <div class="form-horizontal TruyThuModal-Pnl" role="form">
                   <input id="TRUYTHU_ID" style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="TRUYTHU_ID" type="text" />
                   <div class="form-group">
                        <label for="SoChuyenDeNghi" class="col-sm-4 control-label">
                            Số chuyến đề nghị:
                        </label>
                        <div class="col-sm-8">
                            <input type="text" name="SoChuyenDeNghi" id="SoChuyenDeNghi" value="<%=Item.SoChuyenDeNghi %>" class="form-control SoChuyenDeNghi">
                        </div>              
                   </div>
                   <div class="form-group">
                        <label for="NOIDUNG_Ten" class="col-sm-4 control-label">
                            Nội dung:
                        </label>
                        <div class="col-sm-8">
                            <div class="input-group">
                                <input type="text" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=NOIDUNGTRUYTHU" data-refId="NOIDUNG_ID" class="form-control form-autocomplete-input NOIDUNG_Ten" name="NOIDUNG_Ten" id="NOIDUNG_Ten" value="<%=Item.NOIDUNG_Ten %>"/>
                                <span class="input-group-btn">
                                <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                    <i class="glyphicon glyphicon-search"></i>
                                </button>
                                </span>
                                <input type="text" style="display: none;" class="form-control NOIDUNG_ID" name="NOIDUNG_ID" id="NOIDUNG_ID" value="<%=Item.NOIDUNG_ID == Guid.Empty ? "" : Item.NOIDUNG_ID.ToString() %>"/>
                            </div>
                        </div>
                   </div>
                    <div class="form-group">
                        <label for="DANHGIA_Ten" class="col-sm-4 control-label">
                            Đánh giá:
                        </label>
                        <div class="col-sm-8">
                            <div class="input-group">
                                <input type="text" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=DANHGIANHAXE" data-refId="DANHGIA_ID" class="form-control form-autocomplete-input DANHGIA_Ten" name="DANHGIA_Ten" id="DANHGIA_Ten" value="<%=Item.DANHGIA_Ten %>"/>
                                <span class="input-group-btn">
                                <button class="btn btn-default autocomplete-btn" tabindex="-1" type="button">
                                    <i class="glyphicon glyphicon-search"></i>
                                </button>
                                </span>
                                <input type="text" style="display: none;" class="form-control DANHGIA_ID" name="DANHGIA_ID" id="DANHGIA_ID" value="<%=Item.DANHGIA_ID == Guid.Empty ? "" : Item.DANHGIA_ID.ToString() %>"/>
                            </div>
                        </div>
                   </div>
                    <div class="form-group">
                        <label for="DeNghiCuaNhaXe" class="col-sm-4 control-label">
                            Đề nghị của nhà xe:
                        </label>
                        <div class="col-sm-8">
                            <textarea id="DeNghiCuaNhaXe" name="DeNghiCuaNhaXe" type="text" rows="3" class="form-control"><%=Item.DeNghiCuaNhaXe %></textarea>
                        </div>              
                   </div>
          </div>                      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
      </div>
    </div>
  </div>
</div>
<script>
    
</script>