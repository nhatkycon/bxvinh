<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Phoi-NgoaiTinh.ascx.cs" Inherits="lib_ui_Phoi_In_Phoi_NgoaiTinh" %>
<%@ Import Namespace="linh.common" %>

<div class="print-frame">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 300px;">
                <h2>
                    CÔNG TY CP BẾN XE NA
                </h2>
                <h3>
                    BẾN XE VINH
                </h3>
            </td>
            <td>
                <center>
                    <h1>
                        BẢNG KÊ GIÁ DỊCH VỤ BẾN XE
                    </h1>
                    <p>
                        <i>
                            (Liên 2 - giao khách hàng)
                        </i>
                    </p>
                </center>
            </td>
            <td style="width: 100px; text-align: right;">
                <p>
                    Số: <%=Item.STTBXStr %>
                </p>
                <p>
                    Ngày: <%=Item.NgayXuatBen.NgayVn() %>
                </p>
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 100px; text-align: right;">
                Doanh nghiệp:
            </td>
            <td>
                <%=Item.Xe.DONVI_Ten %>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                Biển số:
            </td>
            <td>
                <%=Item.Xe.BienSoStr %>
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 100px; text-align: right;">
                Bến đi:
            </td>
            <td>
                <%=Item.Xe.Tuyen.DI_Ten %>
            </td>
            <td style="width: 100px; text-align: right;">
                Bến đến:
            </td>
            <td>
                <%=Item.Xe.Tuyen.DEN_Ten %>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                Xuất bến:
            </td>
            <td>
                <%=Item.Xe.GioXuatBen %>
            </td>
            <td style="width: 100px; text-align: right;">
                Ngày:
            </td>
            <td>
                <%=Item.NgayXuatBen.NgayVn() %>
            </td>
        </tr>
    </table>
    
    <table width="100%" border="1" cellpadding="5" cellspacing="0">
        <thead>
            <tr>
                <th>TT</th>
                <th>Kiểm tra</th>
                <th>Khách truy thu</th>
                <th>Giá vé</th>
                <th>Tổng chuyến</th>
                <th>Các khoản giá dịch vụ</th>
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Phí dịch vụ bến bãi
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_BenBai.TienVietNam() %>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Xe đậu đêm
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_XeDauDem.TienVietNam() %>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Vệ sinh bến bãi
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_VeSinhBenBai.TienVietNam() %>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Xe lưu bến
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_XeLuuBen.TienVietNam() %>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Hoa hồng bán vé
                </td>
                <td>
                    <%=Item.Ve %>
                </td>
                <td>
                    <%=Item.Xe.Tuyen.HoaHongBanVe %>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_HoaHongBanVe.TienVietNam() %>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Chuyến truy thu
                </td>
                <td>
                    <%=Item.ChuyenTruyThu %>
                </td>
                <td>
                    Chuyến
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_ChuyenTruyThu.TienVietNam() %>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Khách truy thu
                </td>
                <td>
                    <%=Item.KhachTruyThu %>
                </td>
                <td>
                    Khách
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_KhachTruyThu.TienVietNam() %>
                </td>
            </tr>
            
             <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Giảm trừ
                </td>
                <td>
                </td>
                <td>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_TruyThuGiam.TienVietNam() %>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    Thu khác
                </td>
                <td>
                </td>
                <td>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <%=Item.PHI_Khac.TienVietNam() %>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <strong>
                        Tổng
                    </strong>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td style="text-align: right;">
                    <strong>
                        <%=Item.PHI_Tong.TienVietNam() %>
                    </strong>
                </td>
            </tr>

        </tbody>
    </table>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="text-align: right; font-style: italic; width: 100px;">
                <u>
                    Bằng chữ:
                </u>
            </td>
            <td>
                <u>
                    <strong>
                        <i>
                            <%=Lib.So_chu(Item.PHI_Tong) %>
                        </i>
                    </strong>
                </u>
            </td>
        </tr>
    </table>
    
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 33%;" valign="top">
                <center>
                    <p>
                        Ban quản lý
                    </p>
                </center>
            </td>
            <td style="width: 33%;" valign="top">
                <center>
                    <p>
                        Lái xe
                    </p>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        <strong>
                            <i><%=Item.Xe.LaiXe.Ten %></i>
                        </strong>
                    </p>
                </center>
            </td>
            <td style="width: 33%;" valign="top">
                <center>
                    <p>
                        Bán vé
                    </p>
                </center>
            </td>
        </tr>
    </table>
</div>