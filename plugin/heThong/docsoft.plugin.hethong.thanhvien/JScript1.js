var thanhvien = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien',
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton('.mdl-head-btn');
        adm.loading('Đang lấy danh sách thành viên');
        $('.sub-mdl').tabs();
        var filterCQID = $('.mdl-head-filterThanhVienByCQID');
        var searchTxt = $('.mdl-head-search-thanhvien');
        $(searchTxt).unbind('keyup').keyup(function () {
            thanhvien.search();
        });

        adm.watermark(filterCQID, 'Gõ tên đơn vị để lọc', function () {
            $(searchTxt).val('');
            thanhvien.search();
            $(searchTxt).val('Tìm kiếm');
        });

        adm.watermark(searchTxt, 'Tìm kiếm', function () {
            $(searchTxt).val('');
            thanhvien.search();
            $(searchTxt).val('Tìm kiếm');
        });

        $('#thanhvienmdl-List').jqGrid({
            url: thanhvien.urlDefault + '&subAct=get',
            datatype: 'json',
            height: 'auto',
            pager: false,
            colNames: ['ID', 'Tên', 'Đơn vị', 'Tỉnh', 'Email', 'Mobile', 'Username', 'Nhóm Users', 'Kích hoạt', 'Người tạo'],
            colModel: [
            { name: 'ID', width: 20, key: true, hidden: true },
            { name: 'Ten', width: 100 },
            { name: 'CQ_ID', width: 80 },
            { name: 'Loai', width: 50 },
            { name: 'Email', width: 50 },
            { name: 'Mobile', width: 40 },
            { name: 'Username', width: 40, formatter: 'bold' },
            { name: 'Nhom', width: 100 },
            { name: 'Active', width: 20, formatter: 'checkbox' },
            { name: 'NguoiTao', width: 100 }
        ],
            caption: 'Danh sách',
            autowidth: true,
            multiselect: true,
            rowNum: 200,
            height: 200,
            ExpandColClick: true,
            sortname: 'ID',
            sortorder: 'desc',
            rowNum: 5,
            rowList: [5, 20, 50, 100, 200, 500, 1000],
            pager: $('#thanhvienmdl-Pager'),
            loadError: function () {
                adm.loading('Máy chủ đang quá tải');
            },
            onSelectRow: function (rowid) {
                var treedata = $('#thanhvienmdl-List').jqGrid('getRowData', rowid);
                thanhvien.showRoles(treedata.Username);
            },
            loadComplete: function () {
                adm.loading(null);
            },
            loadError: function (xhr, status, error) {
                adm.loading('Lỗi' + error);
            }
        });
        adm.regType(typeof (coquan), 'docsoft.plugin.hethong.coquan.Class1,docsoft.plugin.hethong.coquan', function () {
            coquan.setAutocomplete(filterCQID, function (event, ui) {
                $(filterCQID).val(ui.item.label);
                $(filterCQID).attr('_value', ui.item.id);
                if ($(searchTxt).val() == 'Tìm kiếm') {
                    $(searchTxt).val('');
                }
                thanhvien.search();
                $(searchTxt).val('Tìm kiếm');
            });
            $(filterCQID).unbind('click').click(function () {
                if ($(filterCQID).val() == 'Gõ tên đơn vị để lọc') $(filterCQID).val('');
                $(filterCQID).autocomplete('search', '');
            });
        });
    },
    add: function () {
        thanhvien.loadHtml(function () {
            adm.styleButton();
            var newDlg = $('#thanhvienmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 800,
                buttons: {
                    'Lưu': function () {
                        thanhvien.save();
                    },
                    'Lưu và đóng': function () {
                        thanhvien.save();
                        $(newDlg).dialog('close');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    thanhvien.popfn();
                    thanhvien.clearform();
                }
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery("#thanhvienmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#thanhvienmdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                thanhvien.loadHtml(function () {
                    adm.styleButton();
                    var newDlg = $('#thanhvienmdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 800,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                thanhvien.save();
                            },
                            'Lưu và đóng': function () {
                                thanhvien.save();
                                $(newDlg).dialog('close');
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            $.ajax({
                                url: thanhvien.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#thanhvienmdl-dlgNew');
                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);
                                    var txtUsername = $('.Username', newDlg);
                                    $(txtUsername).val(data.Username);
                                    var txtEmail = $('.Email', newDlg);
                                    $(txtEmail).val(data.Email);
                                    var txtPassword = $('.Password', newDlg);
                                    $(txtPassword).val('');
                                    var txtPasswordConfirm = $('.PasswordConfirm', newDlg);
                                    $(txtPasswordConfirm).val('');
                                    var ckbThuKy = $('.ThuKy', newDlg);
                                    if (data.ThuKy.toString() == 'true') {
                                        $(ckbThuKy).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbThuKy).removeAttr('checked');
                                    }
                                    var txtRefUsername = $('.refUsername', newDlg);
                                    $(txtRefUsername).val(data.refUsername);
                                    var sltLoai = $('.Loai', newDlg);
                                    $(sltLoai).val(data.Loai_Ten);
                                    $(sltLoai).attr('_value', data.Loai);

                                    var txtMobile = $('.Mobile', newDlg);
                                    $(txtMobile).val(data.Mobile);
                                    var ckbKhoa = $('.Khoa', newDlg);
                                    if (data.Khoa) {
                                        $(ckbKhoa).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbKhoa).removeAttr('checked');
                                    }
                                    var txtLuong = $('.Luong', newDlg);
                                    txtLuong.val(data.Luong);
                                    var txtNguoiTao = $('NguoiTao', newDlg);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/i/' + data.Anh + '?ref=' + Math.random());
                                    }
                                    var txtCQ_ID = $('.CQ_ID', newDlg);
                                    $(txtCQ_ID).val(data._CoQuan.Ten);
                                    $(txtCQ_ID).attr('_value', data.CQ_ID);
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    thanhvien.popfn();
                                    $(spbMsg).html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function () {
        var s = '';
        s = jQuery("#thanhvienmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var con = confirm('Bạn có muốn xóa thành viên');
            if (con) {
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=del',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#thanhvienmdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    sendmail: function () {
        var s = '';
        s = jQuery("#thanhvienmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        thanhvien.loadHtml(function () {
            var emailDlg = $('#thanhvienmdl-dlgEmail');
            $(emailDlg).dialog({
                title: 'Email cho thành viên',
                modal: true,
                width: 800,
                buttons: {
                    'Gửi': function () {
                        var EmailTo = $('.EmailToTxt', emailDlg);
                        var EmailToDiv = $(EmailTo).parent();
                        var l = '';
                        $.each($(EmailToDiv).find('span'), function (i, item) {
                            l += $(item).attr('_value') + ',';
                        });

                    },
                    'Đóng': function () {
                        $(emailDlg).dialog('close');
                    }
                },
                open: function () {
                    var EmailTo = $('.EmailToTxt', emailDlg);
                    $(EmailTo).focus();
                    var EmailToDiv = $(EmailTo).parent();
                    $(EmailToDiv).find('span').remove();
                    if (s != '') {
                        var ll = '';
                        var ss = s.split(',');
                        for (j = 0; j < ss.length; j++) {
                            var treedata = $("#thanhvienmdl-List").jqGrid('getRowData', ss[j]);
                            ll += '<span class=\"adm-token-item\" _value=\"' + treedata.Username + '\">' + treedata.Ten + '<a href=\"javascript:;\">x</a></span>';
                        }
                        $(EmailToDiv).prepend(ll);
                        $(EmailToDiv).find('a').click(function () {
                            $(this).parent().remove();
                        });
                    }
                    thanhvien.setAutocomplete(EmailTo, function (e, ui) {
                        var CurrentItem = $(EmailToDiv).find('span[_value=' + ui.item.value + ']');
                        setTimeout(function () {
                            $(EmailTo).val('');
                        }, 100);
                        if ($(CurrentItem).length < 1) {
                            var l = '';
                            l += '<span class=\"adm-token-item\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                            $(l).insertBefore(EmailTo);
                            CurrentItem = $(EmailToDiv).find('span[_value=' + ui.item.value + ']');
                            var removeBtn = $(CurrentItem).find('a');
                            $(removeBtn).click(function () {
                                $(CurrentItem).remove();
                            });
                        }
                        else {
                            $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                                $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                            });
                        }
                    });
                }
            });
        });
    },
    resendPwd: function () {
        var s = '';
        s = jQuery('#thanhvienmdl-List').jqGrid('getGridParam', 'selarrrow').toString();
        thanhvien.loadHtml(function () {
            var emailDlg = $('#thanhvienmdl-dlgResendEmail');
            alert($(emailDlg).length);
            alert($(emailDlg).html());
            $(emailDlg).dialog({
                title: 'Cấp mật khẩu',
                modal: true,
                width: 800,
                buttons: {
                    'Gửi': function () {
                        var EmailTo = $('.EmailToTxt', emailDlg);
                        var EmailToDiv = $(EmailTo).parent();
                        var l = '';
                        $.each($(EmailToDiv).find('span'), function (i, item) {
                            l += $(item).attr('_value') + ',';
                        });

                    },
                    'Đóng': function () {
                        $(emailDlg).dialog('close');
                    }
                },
                open: function () {
                    var EmailTo = $('.EmailToTxt', emailDlg);
                    $(EmailTo).focus();
                    var EmailToDiv = $(EmailTo).parent();
                    $(EmailToDiv).find('span').remove();
                    if (s != '') {
                        var ll = '';
                        var ss = s.split(',');
                        for (j = 0; j < ss.length; j++) {
                            var treedata = $("#thanhvienmdl-List").jqGrid('getRowData', ss[j]);
                            ll += '<span class=\"adm-token-item\" _value=\"' + treedata.Username + '\">' + treedata.Ten + '<a href=\"javascript:;\">x</a></span>';
                        }
                        $(EmailToDiv).prepend(ll);
                        $(EmailToDiv).find('a').click(function () {
                            $(this).parent().remove();
                        });
                    }
                    thanhvien.setAutocomplete(EmailTo, function (e, ui) {
                        var CurrentItem = $(EmailToDiv).find('span[_value=' + ui.item.value + ']');
                        setTimeout(function () {
                            $(EmailTo).val('');
                        }, 100);
                        if ($(CurrentItem).length < 1) {
                            var l = '';
                            l += '<span class=\"adm-token-item\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                            $(l).insertBefore(EmailTo);
                            CurrentItem = $(EmailToDiv).find('span[_value=' + ui.item.value + ']');
                            var removeBtn = $(CurrentItem).find('a');
                            $(removeBtn).click(function () {
                                $(CurrentItem).remove();
                            });
                        }
                        else {
                            $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                                $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                            });
                        }
                    });
                }
            });
        });
    },
    save: function () {
        var newDlg = $('#thanhvienmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();
        var txtUsername = $('.Username', newDlg);
        var username = $(txtUsername).val();
        var txtEmail = $('.Email', newDlg);
        var email = $(txtEmail).val();
        var txtPassword = $('.Password', newDlg);
        var password = $(txtPassword).val();
        var txtPasswordConfirm = $('.PasswordConfirm', newDlg);
        var passwordConfirm = $(txtPasswordConfirm).val();
        var txtCQ_ID = $('.CQ_ID', newDlg);
        var cq_id = $(txtCQ_ID).attr('_value');

        var txtLuong = $('.Luong', newDlg);

        var ckbThuKy = $('.ThuKy', newDlg);
        var thuky = $(ckbThuKy).is(':checked');
        var txtRefUsername = $('.refUsername', newDlg);
        var refUsername = $(txtRefUsername).val();

        var sltLoai = $('.Loai', newDlg);
        var loai = $(sltLoai).attr('_value');
        var loai_Ten = $(sltLoai).val();
        var txtMobile = $('.Mobile', newDlg);
        var mobile = $(txtMobile).val();
        var ckbKhoa = $('.Khoa', newDlg);
        var khoa = $(ckbKhoa).is(':checked');
        var txtNguoiTao = $('NguoiTao', newDlg);
        var luong = txtLuong.val();
        var lblAnh = $('.Anh', newDlg);
        var anh = $(lblAnh).attr('ref');

        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var err = '';
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (username == '') {
            err += 'Nhập mã<br/>';
        }
//        if (loai == '') {
//            err += 'Chọn chức vụ<br/>';
//        }
        if (id == '') {
            if (password == '') {
                err += 'Mật khẩu<br/>';
            }
            if (password != passwordConfirm) {
                err += 'Mật khẩu xác nhận trùng khớp<br/>';
            }
        }
        if (email == '') {
            err += 'Nhập email<br/>';
        }
        if (cq_id == '') {
            err += 'Chọn cơ quan<br/>';
        }
//        if (loai == '0') {
//            err += 'Chọn chức vụ<br/>';
//        }
//        if (loai_Ten == '') {
//            err += 'Chọn chức vụ<br/>';
//        }
        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: thanhvien.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': id,
                'Ten': ten,
                'Username': username,
                'Password': password,
                'Email': email,
                'ThuKy': thuky,
                'refUsername': refUsername,
                'Anh': anh,
                'Loai': loai,
                'Mobile': mobile,
                'Khoa': khoa,
                'CQ_ID': cq_id,
                'Loai_Ten': loai_Ten
                ,'Luong': luong
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    jQuery('#thanhvienmdl-List').trigger('reloadGrid');
                    if (id != '') {
                        setTimeout(function () {
                            jQuery('#thanhvienmdl-List').jqGrid('setSelection', id);
                        }, 1000);
                    }
                    thanhvien.clearform();
                }
                else if (dt == '0') {
                    spbMsg.html('Email và tên đăng nhập đã tồn tại');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })

    },
    setAutocompleteLanhDao: function (el, fn, CQ_ID) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=SelectLanhDaoByCQID',
                    dataType: 'script',
                    data: {
                        'q': request.term,
                        'CQ_ID': CQ_ID
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                chucvu: item.Loai_Ten
                            }
                        }));
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
                if (!ui.item) {
                    $(this).val('')
                    $(this).attr('_value', '');
                }
            },
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    setAutocompleteLanhDaoCQ: function (el, fn, Ma_CQ, fn2) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=SelectLanhDaoByMaCQ',
                    dataType: 'script',
                    data: {
                        'q': request.term,
                        'CQ_Ma': Ma_CQ
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                chucvu: item.Loai_Ten,
                                username: item.Username
                            }
                        }));
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
                if (!ui.item) {
                    $(this).val('')
                    $(this).attr('_value', '');
                    $(this).attr('_username', '');
                    if (typeof (fn2) == 'function')
                        fn2();
                }
            },
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    setAutocompleteLanhDaoVanBanDi: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var _term = 'setAutocompleteLanhDaoVanBanDi-' + request.term;
                if (_term in _cache) {
                    response($.map(_cache[_term], function (item) {
                        return {
                            label: item.Ten,
                            value: item.Ten,
                            id: item.ID,
                            chucvu: item.Loai_Ten
                        }
                    }))
                    return;
                }

                adm.loading('Nạp list');
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=SelectLanhDaoVanBanDi',
                    dataType: 'script',
                    data: {
                        'q': request.term
                    },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[_term] = data;
                        if (xhr === _lastXhr) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.Ten,
                                    value: item.Ten,
                                    id: item.ID,
                                    chucvu: item.Loai_Ten
                                }
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
                    $(this).val('')
                    $(this).attr('_value', '');
                }
            },
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    setAutocompleteLamDichVu: function (el, fn, fn1, TVDV_ID, fn2) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=GetLamDichVuList',
                    dataType: 'script',
                    data: {
                        'TVDV_ID': TVDV_ID
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            if (typeof (fn2) == "function") {
                                return fn2(item);
                            } else {
                                return {
                                    label: item.Ten,
                                    value: item.Username,
                                    level: item.Loai,
                                    id: item.ID,
                                    Email: item.Email
                                };
                            }
                        }));
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            if (typeof (fn1) == "function") {
                return fn1(ul, item);
            } else {
                return $("<li></li>")
                               .data("item.autocomplete", item)
                               .append("<a>" + item.label + "</a>")
                               .appendTo(ul);
            }
        };
    },
    setAutocomplete: function (el, fn, fn1) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=getpid',
                    dataType: 'script',
                    data: {
                        'q': request.term
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            return {
                                label: item.Ten,
                                value: item.Username,
                                level: item.Loai,
                                id: item.ID,                                
                                Email: item.Email
                            };
                        }));
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
                //if (!ui.item) {
                //    $(this).val('');
                //    $(this).attr('_value', '');
                //}
            },
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            if(typeof (fn1) == "function") {
                return fn1(ul, item);
            }else {
                return $("<li></li>")
                               .data("item.autocomplete", item)
                               .append("<a>" + item.label + "</a>")
                               .appendTo(ul);
            }            
        };
    },
    setAutocomplete2: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=getpuse',
                    dataType: 'script',
                    data: {
                        'q': request.term
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            return {
                                label: item.Ten,
                                value: item.Username,
                                level: item.Loai,
                                id: item.ID,
                                Email: item.Email
                            }
                        }));
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
//                alert('a');
//                                if (!ui.item) {
//                                    $(this).val('')
//                                    $(this).attr('_value', '');
//                                }

            },
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    setAutocompleteNodeWfId: function (el, nodeid, wfid, fn, donvi) {
        if (typeof (nodeid) == 'undefined') nodeid = '';
        if (typeof (wfid) == 'undefined') wfid = '';
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: thanhvien.urlDefault + '&subAct=SelectByNodeAndWfId',
                    dataType: 'script',
                    data: {
                        'q': request.term,
                        'NODE_ID': nodeid,
                        'WF_ID': wfid,
                        'CQ_ID': donvi
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.RowId
                            }
                        }));
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
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.value + "</a>")
				            .appendTo(ul);
        };
    },
    selectCungDonVi: function (fn) {
        var term = 'thanhvien-cungdonvi';
        if (term in _cache) {
            if (typeof (fn) == 'function') { fn(_cache[term]); }
            return;
        }
        adm.loading('Nạp danh sách Đơn vị');
        _lastXhr = $.ajax({
            url: thanhvien.urlDefault + '&subAct=cungDonVi',
            dataType: 'script',
            success: function (dt, status, xhr) {
                adm.loading(null);
                var data = eval(dt);
                _cache[term] = data;
                if (xhr === _lastXhr) {
                    if (typeof (fn) == 'function') { fn(data); }
                }
            }
        });
    }, 
    setAutocompleteCungDonVi: function (el, fn) {
        var term = 'thanhvien-cungdonvi';
        $(el).autocomplete({
            source: function (request, response) {
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                username: item.Username
                            }
                        }
                    }))
                    return;
                }
                adm.loading('Nạp danh sách Đơn vị');
                _lastXhr = $.ajax({
                    url: thanhvien.urlDefault + '&subAct=cungDonVi',
                    dataType: 'script',
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        username: item.Username
                                    }
                                }
                            }))
                        }
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            }, change: function (event, ui) {
                //                if (!ui.item) {
                //                    $(this).val('')
                //                    $(this).attr('_value', '');
                //                }
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
                				    .data("item.autocomplete", item)
                				    .append("<a><b>" + item.username + "</b>: " + item.label + "</a>")
                				    .appendTo(ul);
        };
        $(el).unbind('click').click(function () {
            $(el).autocomplete('search', '');
        });
    },
    autoCompleteGianHangByUsername: function (el, fn) {
        var term = 'thanhvien-Gianhang';
        $(el).autocomplete({
            source: function (request, response) {
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                username: item.Username
                            }
                        }
                    }))
                    return;
                }
                adm.loading('Nạp danh sách Đơn vị');
                _lastXhr = $.ajax({
                    url: thanhvien.urlDefault + '&subAct=cungDonVi',
                    dataType: 'script',
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        username: item.Username
                                    }
                                }
                            }))
                        }
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            }, change: function (event, ui) {
                //                if (!ui.item) {
                //                    $(this).val('')
                //                    $(this).attr('_value', '');
                //                }
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
                				    .data("item.autocomplete", item)
                				    .append("<a><b>" + item.username + "</b>: " + item.label + "</a>")
                				    .appendTo(ul);
        };
        $(el).unbind('click').click(function () {
            $(el).autocomplete('search', '');
        });
    },
    setSelectListbyNodeIdWf: function (el, nodeid, wfid, fn) {
        if (typeof (nodeid) == 'undefined') nodeid = '';
        if (typeof (wfid) == 'undefined') wfid = '';
        $(el).html('Nạp danh sách');
        adm.loading('Nạp danh sách cán bộ');
        $.ajax({
            url: thanhvien.urlDefault + '&subAct=SelectByNodeAndWfId',
            dataType: 'script',
            data: {
                'q': '',
                'NODE_ID': nodeid,
                'WF_ID': wfid
            },
            success: function (dt) {
                $(el).html('');
                adm.loading(null);
                var data = eval(dt);
                if ($(el).length > 0) {
                    $.each(data, function (i, item) {
                        $(el).append('<span class=\"adm-selectList-item\"><input _role=\"cid\" chinh=\"0\" _value=\"' + item.RowId + '\" type=\"checkbox\" /> ' + item.Ten + '</span>');
                    });
                    $(el).find('input').unbind('click').click(function () {
                        var item = this;
                        if (typeof (fn) == 'function') {
                            fn(item);
                        }
                    });
                }
            }
        });
    },
    search: function () {
        var timerSearch;
        var filterCQID = $('.mdl-head-filterThanhVienByCQID');
        var searchTxt = $('.mdl-head-search-thanhvien');
        var q = $(searchTxt).val();
        var cq = $(filterCQID).attr('_value');
        var _cq = $(filterCQID).val();
        if (_cq == '') cq = '';
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#thanhvienmdl-List').jqGrid('setGridParam', { url: thanhvien.urlDefault + "&subAct=get&q=" + q + "&CQ_ID=" + cq }).trigger("reloadGrid");
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#thanhvienmdl-dlgNew');
        var ThuKy = $('.ThuKy', newDlg);
        var Pnl = $(ThuKy).next();
        $(Pnl).hide();
        var PnlTxt = $(Pnl).find('input');
        $(ThuKy).unbind('click').click(function () {
            if ($(ThuKy).is(':checked')) {
                $(Pnl).show();
            }
            else {
                $(Pnl).hide();
            }
        });
        var ulpFn = function () {
            var uploadBtn = $('.adm-upload-btn', newDlg);
            var uploadView = $('.adm-upload-preview-img', newDlg);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            var Loai = $('.Loai', newDlg);
            danhmuc.autoCompleteByLoai($(Loai).attr('LDM'), Loai, function (event, ui) {
                $(Loai).attr('_value', ui.item.id);
            });
        });
        thanhvien.setAutocomplete(PnlTxt, function (event, ui) {
            $(PnlTxt).val(ui.item.label);
            $(PnlTxt).attr('_value', ui.item.value);
        });
        coquan.setAutocomplete($('.CQ_ID', newDlg), function (event, ui) {
            $('.CQ_ID', newDlg).val(ui.item.label);
            $('.CQ_ID', newDlg).attr('_value', ui.item.id);
        });
        $(PnlTxt).unbind('click').click(function () {
            $(PnlTxt).autocomplete('search', $(PnlTxt).val());
        });
        $('.CQ_ID', newDlg).unbind('click').click(function () {
            $('.CQ_ID', newDlg).autocomplete('search', $('.CQ_ID', newDlg).val());
        });
    },
    clearform: function () {
        var newDlg = $('#thanhvienmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtUsername = $('.Username', newDlg);
        var txtEmail = $('.Email', newDlg);
        var txtPassword = $('.Password', newDlg);
        var txtPasswordConfirm = $('.PasswordConfirm', newDlg);
        var txtCQ_ID = $('.CQ_ID', newDlg);
        var ckbThuKy = $('.ThuKy', newDlg);
        var txtRefUsername = $('.refUsername', newDlg);
        var sltLoai = $('.Loai', newDlg);
        var txtMobile = $('.Mobile', newDlg);
        var ckbKhoa = $('.Khoa', newDlg);
        var txtNguoiTao = $('NguoiTao', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        spbMsg.html('');
        $(txtID).val('');
        $(txtTen).val('');
        $(txtEmail).val('');
        $(txtUsername).val('');
        $(txtPassword).val('');
        $(txtPasswordConfirm).val('');
        $(txtMobile).val('');
        $(ckbThuKy).removeAttr('checked');
        $(ckbKhoa).removeAttr('checked');
        $(ckbThuKy).next().hide();
        $(txtRefUsername).val('');
        $(txtNguoiTao).val('');
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
    },
    showRoles: function (_username) {
        adm.loading('Nạp quyền');
        $.ajax({
            url: thanhvien.urlDefault + '&subAct=getRoles',
            data: {
                Username: _username
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '0') {
                    $('#thanhvienmdl-rolemdl-mdl').html('Đơn vị chưa có nhóm người dùng');
                    return false;
                }
                $('#thanhvienmdl-rolemdl-mdl').html(dt);
                $('input', '#thanhvienmdl-rolemdl-mdl').unbind('click').click(function () {
                    var l = '';
                    $.each($('input', '#thanhvienmdl-rolemdl-mdl'), function (i, item) {
                        if ($(item).is(':checked')) {
                            l += $(item).attr('_role') + ',';
                        }
                    });
                    adm.loading('Lưu quyền');
                    $.ajax({
                        url: thanhvien.urlDefault + '&subAct=saveRoles',
                        data: {
                            Username: _username,
                            roleList: l
                        }, success: function (_dt) {
                            adm.loading(null);
                        }
                    });
                });
            }
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#thanhvienmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("docsoft.plugin.hethong.thanhvien.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('body').append(dt);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    }
}
