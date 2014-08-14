var pmLatestLoadedTimer;
var pmLatestLoadedTimeOut = 10000;
var _lastXhr;
jQuery(function () {
    $('#__VIEWSTATE').remove();
    bxVinhFn.init();
    
});

var bxVinhFn = {
    init:function () {
        bxVinhFn.normalFormFn.init();
    }
    , utils: {
        msg: function (tit, txt, fn, time) {
            var body = $('#AlertModal').find('.modal-body');
            var title = $('#AlertModal').find('.modal-title');
            body.html('');
            title.html('');
            if (tit == '') tit = 'Thông báo';
            title.html(tit);
            body.html(txt);
            $('#AlertModal').modal('show');
            if (time == null) time = 2000;
            setTimeout(function () {
                $('#AlertModal').modal('hide');
            }, time);
        }
        , loader:function (title, show) {
            if (show) {
                bxVinhFn.utils.msg(title, 'Đang lưu');
            } else {
                $('#AlertModal').modal('hide');
            }
        }
        , normalizeStr: function (term) {
            var ret = "";
            for (var i = 0; i < term.length; i++) {
                ret += adm.inorgeCaseMap[term.charAt(i)] || term.charAt(i);
            }
            return ret;
        }
        , convertNumberToMoney:function(_num) {
            if (_num == '') {
                return 0;
            }
            var num = parseInt(_num);
            var p = num.toFixed(2).split(".");
            return p[0].split("").reverse().reduce(function (acc, num, i, orig) {
                return num + (i && !(i % 3) ? "," : "") + acc;
            }, "");
        }
        , getNumberFormMoney: function (tien) {
            function escapeRegExp(string) {
                return string.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
            }
            function replaceAll(string, find, replace) {
                return string.replace(new RegExp(escapeRegExp(find), 'g'), replace);
            }

            return replaceAll(tien, ',', '');
        }
        , formatTien: function (obj) {
            // Format while typing & warn on decimals entered, no cents
            obj.formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 0, symbol: '' });
            obj.blur(function () {
                obj.html(null);
                $(this).formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 0, symbol: '' });
            })
            .keyup(function (e) {
                var e = window.event || e;
                var keyUnicode = e.charCode || e.keyCode;
                if (e !== undefined) {
                    switch (keyUnicode) {
                        case 16: break; // Shift
                        case 27: this.value = ''; break; // Esc: clear entry
                        case 35: break; // End
                        case 36: break; // Home
                        case 37: break; // cursor left
                        case 38: break; // cursor up
                        case 39: break; // cursor right
                        case 40: break; // cursor down
                        case 78: break; // N (Opera 9.63+ maps the "." from the number key section to the "N" key too!) (See: http://unixpapa.com/js/key.html search for ". Del")
                        case 110: break; // . number block (Opera 9.63+ maps the "." from the number block to the "N" key (78) !!!)
                        case 190: break; // .
                        default: $(this).formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: -1, eventOnDecimalsEntered: true, symbol: '' });
                    }
                }
            })
            .bind('decimalsEntered', function (e, cents) {
                //var errorMsg = 'Please do not enter any cents (0.' + cents + ')';
                //$('#formatWhileTypingAndWarnOnDecimalsEnteredNotification').html(errorMsg);
                //log('Event on decimals entered: ' + errorMsg);
            });

        }
        , autoCompleteSearch: function (el, url, cache, fn, fn2, fn1) {
            if (typeof (fn1) != "function") {
                fn1 = function (ul, item) {
                    return $("<li></li>")
                        .data("item.autocomplete", item)
                        .append("<a href=\"javascript:;\">" + item.label + "</a>")
                        .appendTo(ul);
                };
            }

            $(el).autocomplete({
                source: function (request, response) {
                    var term = cache + request.term;
                    _lastXhr = $.ajax({
                        url: url,
                        dataType: 'script',
                        data: { 'subAct': 'search', 'q': request.term },
                        success: function (dt, status, xhr) {
                            var data = eval(dt);
                            _cache[term] = data;
                            if (xhr === _lastXhr) {
                                var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                                response($.map(data, function (item) {
                                    return fn2(matcher, item);
                                }));
                            }
                        }
                    });
                },
                minLength: 0,
                select: function (event, ui) {
                    fn(event, ui);
                },
                change: function (event, ui) {
                    if (!ui.item) {
                        if ($(this).val() == '') {
                            $(this).attr('_value', '');
                        }
                    }
                },
                delay: 0,
                selectFirst: true
            }).data("autocomplete")._renderItem = fn1;
            $(el).autocomplete("option", "appendTo", el.parent());

        }
    }
    ,url : {
        login: '/lib/ajax/login/default.aspx'
        , donVi: '/lib/ajax/DonVi/default.aspx'
    }
    , normalFormFn: {
        init:function () {
            bxVinhFn.normalFormFn.add();
            bxVinhFn.normalFormFn.addPhoi();
        }
        ,add:function () {
            var pnl = $('.Normal-Pnl-Add');
            if ($(pnl).length < 1) return;
            var url = pnl.attr('data-url');
            var urlSuccess = pnl.attr('data-success');
            var urlList = pnl.attr('data-list');
            
            var btn = pnl.find('.savebtn');
            var xoaBtn = pnl.find('.xoaBtn');
            var txt = pnl.find('.Ten');

            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');

            btn.click(function () {


                alertErr.hide();
                alertOk.hide();
                var val = txt.val();
                if (val == '') {
                    alertErr.show();
                    alertErr.html('Nhập nội dung');
                    return;
                }
                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'save' });
                bxVinhFn.utils.loader('Đang lưu', true);
                $.ajax({
                    url: url
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       bxVinhFn.utils.loader('Lưu', false);
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Đăng nhập và nhập dữ liệu cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           setTimeout(function () {
                               document.location.href = urlSuccess + rs;
                           }, 1000);
                       }
                   }
                });
            });
            
            xoaBtn.click(function () {
                var con = confirm('Bạn có thực sự muốn xóa?');
                if (!con) return;

                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'remove' });
                $.ajax({
                    url: url
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') {
                           window.history.back();
                           document.location.href = urlList;
                       }
                       else {
                           alertErr.fadeIn();
                           alertErr.html('Đăng nhập chỉ người tạo ra mới có quyền xóa bỏ');
                       }
                   }
                });
            });


            var autoCompleteElements = pnl.find('.form-autocomplete-input');
            $.each(autoCompleteElements, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var refId = itemEl.attr('data-refId');
                var refEl = parentEl.find('.' + refId);
                var src = itemEl.attr('data-src');
                btnAutocomplete.unbind('click').click(function() {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, refId
                    , function (event, ui) {
                        refEl.val(ui.item.id);
                    }
                    , function (matcher, item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase())) || matcher.test(item.Ma.toLowerCase()) || matcher.test(item.Mobile.toLowerCase())) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID
                            };
                        }
                    }
                );
            });


            var datePickerElements = pnl.find('.datepicker-input');
            $.each(datePickerElements, function(i, j) {
                var itemEl = $(j);
                itemEl.datetimepicker({
                    language: 'vi-Vn'
                });
            });
            
            var timePickerElements = pnl.find('.timePicker-input');
            $.each(timePickerElements, function (i, j) {
                var itemEl = $(j);
                itemEl.timepicker({
                    minuteStep: 15,
                    showMeridian: false,
                    defaultTime: false
                });
            });
            

            
            
            
            
            var moneyInputs = pnl.find('.money-input');
            $.each(moneyInputs, function (i, j) {
                var itemEl = $(j);
                bxVinhFn.utils.formatTien(itemEl);
            });

        }
        , phepTinh:function (pnl) {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // FORM THU
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Giá vé
            var PhoiThuPhiPnl = pnl.find('.Phoi-ThuPhi-Pnl');
            var GiaVe = PhoiThuPhiPnl.find('.GiaVe');
            var HoaHongBanVe = PhoiThuPhiPnl.find('.HoaHongBanVe');
            var PhiTrenMotVe = PhoiThuPhiPnl.find('.PhiTrenMotVe');
            var PHI_BenBai = PhoiThuPhiPnl.find('.PHI_BenBai');
            var Ve = PhoiThuPhiPnl.find('.Ve');
            var PHI_HoaHongBanVe = PhoiThuPhiPnl.find('.PHI_HoaHongBanVe');
            // Truy thu khách
            var KhachTruyThu = PhoiThuPhiPnl.find('.KhachTruyThu');
            var ChuyenTruyThu = PhoiThuPhiPnl.find('.ChuyenTruyThu');
            var PHI_KhachTruyThu = PhoiThuPhiPnl.find('.PHI_KhachTruyThu');
            var PHI_TruyThuGiam = PhoiThuPhiPnl.find('.PHI_TruyThuGiam');
            var PHI_ChuyenTruyThu = PhoiThuPhiPnl.find('.PHI_ChuyenTruyThu');
            // Tổng
            var PHI_Tong = PhoiThuPhiPnl.find('.PHI_Tong');
            var PHI_Nop = PhoiThuPhiPnl.find('.PHI_Nop');
            var PHI_ConNo = PhoiThuPhiPnl.find('.PHI_ConNo');
            
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // HÀM TÍNH TOÁN FORM THU
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            // HÀM TÍNH TOÁN TRÊN CLIENT
            var thuPhiInputs = PhoiThuPhiPnl.find('.ThuPhi-Input-Item');
            var tong = 0;
            var thuPhiAllInputs = PhoiThuPhiPnl.find('.money-input');
            thuPhiAllInputs.unbind('keyup').keyup(function () {
                var giaVe = bxVinhFn.utils.getNumberFormMoney(GiaVe.val());
                var hoaHongBanVe = bxVinhFn.utils.getNumberFormMoney(HoaHongBanVe.val());

                var phiTrenMotVe = parseInt(giaVe) * parseInt(hoaHongBanVe) / 100;
                PhiTrenMotVe.val(bxVinhFn.utils.convertNumberToMoney(phiTrenMotVe));


                var ve = bxVinhFn.utils.getNumberFormMoney(Ve.val());
                var pHI_HoaHongBanVe = parseInt(ve) * parseInt(phiTrenMotVe);
                PHI_HoaHongBanVe.val(bxVinhFn.utils.convertNumberToMoney(pHI_HoaHongBanVe));
            
                var chuyenTruyThu1 = bxVinhFn.utils.getNumberFormMoney(ChuyenTruyThu.val());
                var pHI_BenBai1 = bxVinhFn.utils.getNumberFormMoney(PHI_BenBai.val());
                var pHI_ChuyenTruyThu1 = parseInt(chuyenTruyThu1) * parseInt(pHI_BenBai1);
                PHI_ChuyenTruyThu.val(bxVinhFn.utils.convertNumberToMoney(pHI_ChuyenTruyThu1));


                var khachTruyThu = bxVinhFn.utils.getNumberFormMoney(KhachTruyThu.val());
                var pHI_KhachTruyThu = parseInt(khachTruyThu) * parseInt(phiTrenMotVe);
                PHI_KhachTruyThu.val(bxVinhFn.utils.convertNumberToMoney(pHI_KhachTruyThu));



                var tong1 = 0;
                $.each(thuPhiInputs, function (i3, i4) {
                    var thuPhiItem1 = $(i4);
                    var phi1 = bxVinhFn.utils.getNumberFormMoney(thuPhiItem1.val());
                    tong1 += parseInt(phi1);
                });
                var pHI_TruyThuGiam1 = bxVinhFn.utils.getNumberFormMoney(PHI_TruyThuGiam.val());
                var tongSauTru1 = parseInt(tong1) - parseInt(pHI_TruyThuGiam1);

                PHI_Tong.val(bxVinhFn.utils.convertNumberToMoney(tongSauTru1));

                var pHI_Nop = bxVinhFn.utils.getNumberFormMoney(PHI_Nop.val());
                var pHI_ConNo = parseInt(tongSauTru1) - parseInt(pHI_Nop);
                PHI_ConNo.val(bxVinhFn.utils.convertNumberToMoney(pHI_ConNo));

            });


            $.each(thuPhiInputs, function (i1, i2) {
                var thuPhiItem = $(i2);
                var phi = bxVinhFn.utils.getNumberFormMoney(thuPhiItem.val());
                tong += parseInt(phi);
            });
            
            var chuyenTruyThu = bxVinhFn.utils.getNumberFormMoney(ChuyenTruyThu.val());
            var pHI_BenBai = bxVinhFn.utils.getNumberFormMoney(PHI_BenBai.val());
            var pHI_ChuyenTruyThu = parseInt(chuyenTruyThu) * parseInt(pHI_BenBai);
            PHI_ChuyenTruyThu.val(bxVinhFn.utils.convertNumberToMoney(pHI_ChuyenTruyThu));

            var pHI_TruyThuGiam = bxVinhFn.utils.getNumberFormMoney(PHI_TruyThuGiam.val());
            var tongSauTru = parseInt(tong) - parseInt(pHI_TruyThuGiam);
            PHI_Tong.val(bxVinhFn.utils.convertNumberToMoney(tongSauTru));
            var pHI_NopAll = bxVinhFn.utils.getNumberFormMoney(PHI_Nop.val());
            var pHI_ConNoAll = parseInt(tongSauTru) - parseInt(pHI_NopAll);
            PHI_ConNo.val(bxVinhFn.utils.convertNumberToMoney(pHI_ConNoAll));
            
            bxVinhFn.utils.formatTien(pnl.find('.money-input'));
        }
        , addPhoi:function () {
            var pnl = $('.Phoi-ThongTinXe-Pnl');
            if ($(pnl).length < 1) return;
            var url = pnl.attr('data-url');
            var urlSuccess = pnl.attr('data-success');
            var urlList = pnl.attr('data-list');
            
            var btn = pnl.find('.saveBtn');
            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');
            var TruyThuModal = $('#TruyThuModal');
            var TruyThuChamCongPnl = pnl.find('.Phoi-TruyThuPnl-ChamCongPnl');
            var PhoiNghiepVuHanPnl = pnl.find('.Phoi-NghiepVu-HanPnl');
            var PhoiThuPhiPnl = pnl.find('.Phoi-ThuPhi-Pnl');
            
            btn.click(function () {
                
                var LAIXE_Ten = pnl.find('.LAIXE_Ten');
                var XE_BienSo = pnl.find('.XE_BienSo');
                
                if (LAIXE_Ten.val() == '' || XE_BienSo.val() == '') {
                    alertErr.show();
                    alertErr.html('Nhập xe và lái xe');
                    setTimeout(function() {
                        alertErr.hide();
                    }, 2000);
                    return;
                }

                alertErr.hide();
                alertOk.hide();
                


                var disabled = pnl.find(':input:disabled').removeAttr('disabled');

                // serialize the form
                var data = pnl.find(':input').serializeArray();


                // re-disabled the set of inputs that you previously enabled
                disabled.attr('disabled', 'disabled');
                
                data.push({ name: 'subAct', value: 'save' });
                bxVinhFn.utils.loader('Đang lưu', true);
                $.ajax({
                    url: url
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       bxVinhFn.utils.loader('Lưu', false);
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Đăng nhập và nhập dữ liệu cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           //setTimeout(function () {
                           //    document.location.href = urlSuccess + rs;
                           //}, 1000);
                       }
                   }
                });
            });

            var autoCompletePhoiChonLaiXe = pnl.find('.form-autocomplete-input-Phoi-ChonLaiXe');
            $.each(autoCompletePhoiChonLaiXe, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var refId = itemEl.attr('data-refId');
                var refEl = parentEl.find('.' + refId);
                var src = itemEl.attr('data-src');
                btnAutocomplete.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, refId
                    , function (event, ui) {
                        refEl.val(ui.item.id);
                        var NgayHetHanBangLaiStr = PhoiNghiepVuHanPnl.find('.NgayHetHanBangLaiStr');
                        var NgayHetHanGiayKhamSucKhoeStr = PhoiNghiepVuHanPnl.find('.NgayHetHanGiayKhamSucKhoeStr');
                        NgayHetHanBangLaiStr.html(ui.item.NgayHetHanBangLaiStr);
                        NgayHetHanGiayKhamSucKhoeStr.html(ui.item.NgayHetHanGiayKhamSucKhoeStr);

                    }
                    , function (matcher, item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                loaiBang: item.LoaiBang,
                                khoa: item.Khoa,
                                hopLe: item.HopLe,
                                hopLeThongBao: item.HopLeThongBao
                                , NgayHetHanBangLaiStr: item.NgayHetHanBangLaiStr
                                , NgayHetHanGiayKhamSucKhoeStr: item.NgayHetHanGiayKhamSucKhoeStr
                            };
                        }
                    }
                );

                itemEl.data('ui-autocomplete')._renderItem = function (ul, item) {
                    return $("<li></li>")
                        .data("item.autocomplete", item)
                        .append("<a href=\"javascript:;\"><strong class=\"" + (item.hopLe ? "" : "ui-state-error-text") + "\">" + item.label + " (" + item.loaiBang + ")</strong> " + (item.hopLe ? "" : item.hopLeThongBao) + "</a>")
                        .appendTo(ul);
                };
            });

            // Autocomplete in Phoi/Xe
            
            var autoCompletePhoiChonXe = pnl.find('.form-autocomplete-input-Phoi-ChonXe');
            $.each(autoCompletePhoiChonXe, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var refId = itemEl.attr('data-refId');
                var refEl = parentEl.find('.' + refId);
                var src = itemEl.attr('data-src');
                btnAutocomplete.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, refId
                    , function (event, ui) {
                        refEl.val(ui.item.id);
                        var data = [];
                        data.push({ name: 'subAct', value: 'GetById' });
                        data.push({ name: 'Id', value: ui.item.id });
                        $.ajax({
                            url: '/lib/ajax/Xe/Default.aspx'
                            , type: 'POST'
                            , data: data
                           , success: function (rs) {
                               $('.Phoi-NghiepVu-Pnl').addClass('Phoi-NghiepVuActive-Pnl');

                               var dt = eval(rs);
                               var thongTinXePnl = $('.Phoi-ThongTinXe-Pnl');

                               var LAIXE_Ten = thongTinXePnl.find('.LAIXE_Ten');
                               var LAIXE_ID = thongTinXePnl.find('.LAIXE_ID');
                               var DONVI_Ten = thongTinXePnl.find('.DONVI_Ten');
                               var DI_Ten = thongTinXePnl.find('.DI_Ten');
                               var DEN_Ten = thongTinXePnl.find('.DEN_Ten');
                               var GioXuatBen = thongTinXePnl.find('.GioXuatBen');
                               var BIEUDO_Ten = thongTinXePnl.find('.BIEUDO_Ten');
                               
                               // Hạn
                               var TuyenCoDinhStr = PhoiNghiepVuHanPnl.find('.TuyenCoDinhStr');
                               var LuuHanhStr = PhoiNghiepVuHanPnl.find('.LuuHanhStr');
                               var BaoHiemStr = PhoiNghiepVuHanPnl.find('.BaoHiemStr');
                               var NgayHetHanBangLaiStr = PhoiNghiepVuHanPnl.find('.NgayHetHanBangLaiStr');
                               var NgayHetHanGiayKhamSucKhoeStr = PhoiNghiepVuHanPnl.find('.NgayHetHanGiayKhamSucKhoeStr');
                               var XE_Khoa = PhoiNghiepVuHanPnl.find('.XE_Khoa');
                               
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               // FORM THU
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               
                               // Giá vé
                               var PhoiThuPhiPnl = pnl.find('.Phoi-ThuPhi-Pnl');
                               var GiaVe = PhoiThuPhiPnl.find('.GiaVe');
                               var HoaHongBanVe = PhoiThuPhiPnl.find('.HoaHongBanVe');
                               var PhiTrenMotVe = PhoiThuPhiPnl.find('.PhiTrenMotVe');
                               var PHI_BenBai = PhoiThuPhiPnl.find('.PHI_BenBai');
                               var Ve = PhoiThuPhiPnl.find('.Ve');
                               var PHI_HoaHongBanVe = PhoiThuPhiPnl.find('.PHI_HoaHongBanVe');
                               // Truy thu khách
                               var KhachTruyThu = PhoiThuPhiPnl.find('.KhachTruyThu');
                               var PHI_KhachTruyThu = PhoiThuPhiPnl.find('.PHI_KhachTruyThu');
                               var PHI_TruyThuGiam = PhoiThuPhiPnl.find('.PHI_TruyThuGiam');
                               // Tổng
                               var PHI_Tong = PhoiThuPhiPnl.find('.PHI_Tong');
                               var PHI_Nop = PhoiThuPhiPnl.find('.PHI_Nop');
                               var PHI_ConNo = PhoiThuPhiPnl.find('.PHI_ConNo');
                               
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               // FORM MODAL
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               
                               var TruyThuModal = pnl.find('#TruyThuModal');
                               var GiaTienDichVuTrongHopDong = TruyThuModal.find('.GiaTienDichVuTrongHopDong');
                               var SoChuyenBieuDo = TruyThuModal.find('#SoChuyenBieuDo');
                               var TongTruyThu = TruyThuModal.find('#TongTruyThu');
                               var GiamTru = TruyThuModal.find('#GiamTru');
                               var ConLai = TruyThuModal.find('#ConLai');


                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               // BIND DỮ LIỆU TỪ AJAX
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               
                               LAIXE_Ten.val(dt.LaiXe.Ten);
                               LAIXE_ID.val(dt.LaiXe.ID);
                               TuyenCoDinhStr.html(dt.TuyenCoDinhStr);
                               LuuHanhStr.html(dt.LuuHanhStr);
                               BaoHiemStr.html(dt.BaoHiemStr);
                               NgayHetHanBangLaiStr.html(dt.LaiXe.NgayHetHanBangLaiStr);
                               NgayHetHanGiayKhamSucKhoeStr.html(dt.LaiXe.NgayHetHanGiayKhamSucKhoeStr);

                               if(dt.Khoa) {
                                   XE_Khoa.attr('checked', 'checked');
                               } else {
                                   XE_Khoa.removeAttr('checked');
                               }
                               HoaHongBanVe.val(dt.Tuyen.HoaHongBanVe);
                               GiaTienDichVuTrongHopDong.val(dt.MucPhi);
                               PHI_BenBai.val(dt.MucPhi);
                               Ve.val(dt.SoKhach);
                               GiaVe.val(dt.GiaVe);
                               PhiTrenMotVe.val(dt.GiaVe * dt.Tuyen.HoaHongBanVe / 100);

                               PHI_HoaHongBanVe.val(dt.GiaVe * dt.Tuyen.HoaHongBanVe / 100 * dt.SoKhach);


                               PHI_BenBai.val();
                               DONVI_Ten.val(dt.DONVI_Ten);
                               DONVI_Ten.val(dt.DONVI_Ten);
                               DI_Ten.val(dt.Tuyen.DI_Ten);
                               DEN_Ten.val(dt.Tuyen.DEN_Ten);
                               GioXuatBen.val(dt.GioXuatBen);
                               BIEUDO_Ten.html(dt.LoaiBieuDo.Ten);
                               
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               // HÀM TÍNH TOÁN TRÊN MODAL FORM
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               $(TongTruyThu).unbind('keyup').keyup(function () {
                                   var tongModal = parseInt(bxVinhFn.utils.getNumberFormMoney(TongTruyThu.val()));
                                   var giamModal = parseInt(bxVinhFn.utils.getNumberFormMoney(GiamTru.val()));
                                   var conModal = tongModal - giamModal;
                                   ConLai.val(bxVinhFn.utils.convertNumberToMoney(conModal));
                               });
                               $(GiamTru).unbind('keyup').keyup(function () {
                                   var tongModal = parseInt(bxVinhFn.utils.getNumberFormMoney(TongTruyThu.val()));
                                   var giamModal = parseInt(bxVinhFn.utils.getNumberFormMoney(GiamTru.val()));
                                   var conModal = tongModal - giamModal;
                                   ConLai.val(bxVinhFn.utils.convertNumberToMoney(conModal));
                               });

                               $(GiaTienDichVuTrongHopDong).unbind('keyup').keyup(function () {
                                   var soChuyen = parseInt(bxVinhFn.utils.getNumberFormMoney(SoChuyenBieuDo.val()));
                                   var giaChuyen = parseInt(bxVinhFn.utils.getNumberFormMoney(GiaTienDichVuTrongHopDong.val()));
                                   var tongModal = (soChuyen * giaChuyen);
                                   TongTruyThu.val(bxVinhFn.utils.convertNumberToMoney(tongModal));
                                   var giamModal = parseInt(GiamTru.val());
                                   var conModal = tongModal - giamModal;
                                   ConLai.val(bxVinhFn.utils.convertNumberToMoney(conModal));
                               });


                               
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               // HÀM TÍNH TOÁN FORM THU
                               ////////////////////////////////////////////////////////////////////////////////////////////////////////
                               bxVinhFn.utils.formatTien(pnl.find('.money-input'));

                               // HÀM TÍNH TOÁN TRÊN CLIENT
                               bxVinhFn.normalFormFn.phepTinh(pnl);
                               
                           }
                        });

                        data = [];
                        data.push({ name: 'subAct', value: 'BangChamCongTheoXe' });
                        data.push({ name: 'XE_ID', value: ui.item.id });
                        $.ajax({
                            url: '/lib/ajax/ChamCong/Default.aspx'
                           , type: 'POST'
                           , data: data
                          , success: function (rs) {
                              TruyThuChamCongPnl.html(rs);
                          }
                        });

                        //Phoi-TruyThuPnl-ChamCongPnl
                    }
                    , function (matcher, item) {
                        if (matcher.test(item.BienSo_So.toLowerCase()) || matcher.test(adm.normalizeStr(item.BienSo_So.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                bh: item.BaoHiem,
                                luuHanh: item.LuuHanh,
                                tcd: item.TuyenCoDinh,
                                khoa: item.Khoa,
                                mucPhi: item.MucPhi,
                                hopLe: item.HopLe,
                                donVi_Ten: item.DONVI_Ten,
                                hopLeThongBao: item.HopLeThongBao,
                                gioXuatBen: item.GioXuatBen
                            };
                        }
                    }
                );

                itemEl.data('ui-autocomplete')._renderItem = function (ul, item) {
                    return $("<li></li>")
                        .data("item.autocomplete", item)
                        .append("<a href=\"javascript:;\"><strong class=\"" + (item.hopLe ? "" : "ui-state-error-text") + "\">" + item.label + "</strong> " + (item.hopLe ? "" : item.hopLeThongBao) + "</a>")
                        .appendTo(ul);
                };

            });
            

            bxVinhFn.normalFormFn.phepTinh(pnl);

            var ChuyenTruyThu = PhoiThuPhiPnl.find('.ChuyenTruyThu');
            $('.Phoi-TruyThuPnl-ChamCongPnl').on('click', '.ChamCongTd-Item-Clickable', function () {
                var item = $(this);
                var txt = item.find('input');
                if (item.hasClass('ChamCongTd-Item-Clickable-Active')) {
                    item.removeClass('ChamCongTd-Item-Clickable-Active');
                    txt.removeAttr('name');
                }
                else {
                    item.addClass('ChamCongTd-Item-Clickable-Active');
                    txt.attr('name', 'NgayChamCong');
                }
                var totalChuyenTruyThu = TruyThuChamCongPnl.find('.ChamCongTd-Item-Clickable-Active').length;
                ChuyenTruyThu.val(totalChuyenTruyThu);
                bxVinhFn.normalFormFn.phepTinh(pnl);
            });
        }
        , chonXeHandler:function () {
            
        }
    }
}