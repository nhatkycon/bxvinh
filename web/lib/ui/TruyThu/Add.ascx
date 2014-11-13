<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_TruyThu_Add" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="panel panel-default TruyThu-Pnl-Add" 
    data-url="/lib/ajax/TruyThu/default.aspx"
    data-success="/lib/pages/TruyThu/Add.aspx?ID="
    data-list="/lib/pages/TruyThu/"
    >
    <div class="panel-heading">
        <a href="/lib/pages/TruyThu/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
                <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-success duyetbtn">Duyệt</a>
                <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-warning khongDuyetBtn">Không duyệt</a>
            <%if (Item.Username == Security.Username)
              { %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%} %>
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
                <input id="ID" style="display: none;" value="<%=Item.ID == 0 ? string.Empty  : Item.ID.ToString() %>" name="ID" type="text" />
                <div class="form-group">
                    <label for="SoChuyenDuocDuyet" class="col-sm-2 control-label">
                        Nhà xe:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.Phoi.Xe.DONVI_Ten %>
                        </p>
                    </div>              
                    <label for="YKienChiDao" class="col-sm-2 control-label">
                        Biển số:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.Phoi.Xe.BienSoStr %>
                        </p>
                    </div>    
                    <label class="col-sm-2 control-label">
                        Lái xe:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.Phoi.LaiXe.Ten %>
                        </p>
                    </div>              
                </div>
                <hr/>
                <div class="form-group">
                    <label for="SoChuyenDuocDuyet" class="col-sm-2 control-label">
                        Số chuyến truy thu:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.SoChuyenThieu %>
                        </p>
                    </div>              
                    <label for="YKienChiDao" class="col-sm-2 control-label">
                        Tổng:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.TongTruyThu.TienVietNam() %>
                        </p>
                    </div>    
                    <label class="col-sm-2 control-label">
                        Người tạo:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.NguoiLap %>: <%=Item.NgayTao.NgayVn() %>
                        </p>
                    </div>              
                </div>
                <hr/>
                <div class="form-group">
                    <label for="SoChuyenDeNghi" class="col-sm-2 control-label">
                        Số chuyến đề nghị:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.SoChuyenDeNghi %>
                        </p>
                    </div>              
                    <label for="NOIDUNG_Ten" class="col-sm-2 control-label">
                        Nội dung:
                    </label>
                    <div class="col-sm-2">                        
                        <p class="form-control-static">
                            <%=Item.NOIDUNG_Ten %>
                        </p>
                    </div>
                    <label for="DANHGIA_Ten" class="col-sm-2 control-label">                        
                        Đánh giá:
                    </label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.DANHGIA_Ten %>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label for="DeNghiCuaNhaXe" class="col-sm-2 control-label">
                        Đề nghị của nhà xe:
                    </label>
                    <div class="col-sm-10">
                        <textarea id="DeNghiCuaNhaXe" rows="3" class="form-control"><%=Item.DeNghiCuaNhaXe %></textarea>
                    </div>              
                </div>
                <hr/>
                <div class="form-group">
                    <label for="SoChuyenDuocDuyet" class="col-sm-2 control-label">
                        Số chuyến được duyệt:
                    </label>
                    <div class="col-sm-4">
                        <input type="number" min="0" max="<%=Item.SoChuyenThieu %>" name="SoChuyenDuocDuyet" id="SoChuyenDuocDuyet" 
                            value="<%=Item.SoChuyenDuocDuyet == 0 ? "" :Item.SoChuyenDuocDuyet.ToString() %>" class="form-control SoChuyenDuocDuyet">
                    </div>              
                </div>
                <div class="form-group">
                    <label for="YKienChiDao" class="col-sm-2 control-label">
                        Ý kiến lãnh đạo:
                    </label>
                    <div class="col-sm-4">
                        <textarea id="YKienChiDao" name="YKienChiDao" type="text" rows="3" class="form-control"><%=Item.YKienChiDao %></textarea>
                    </div>              
                </div>
            <%if(Item.Duyet){ %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.LanhDaoDuyet %></strong> duyệt ngày <%=Item.NgayDuyet.ToString("HH:mm dd/MM/yyyy") %>.                            
                    </div>
                </div>
            <%} %>
            <p class="alert alert-danger" style="display: none;"></p>
            <p class="alert alert-success" style="display: none;"></p>
        </div>
    </div>
    <div class="panel-footer">
        <a href="/lib/pages/TruyThu/" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
                <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-success duyetbtn">Duyệt</a>
                <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-warning khongDuyetBtn">Không duyệt</a>
            <%if (Item.Username == Security.Username)
              { %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%} %>
    </div>
</div>

<%if(!string.IsNullOrEmpty(Id))
  {%>
  <script>
      $(function () {
      });
  </script>    
<%  } %>