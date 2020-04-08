$.extend({

    //對Url進行簡單處理，識別虛擬目錄
    UrlEx: function (url) {
        debugger;
        return url;
    },
    isNullOrEmpty: function (obj) {
        return obj === null || obj === undefined || obj === "";
    },
    parseParam: function (param) {
        return $.param(param);
    },
    post: function (url, data, callback, type) {
        if ($.isFunction(data)) {
            type = type || callback;
            callback = data;
            data = undefined;
        }
        //對post方法重寫，增加timeout和異常提示
        return $.ajax({
            type: "POST",
            //timeout: 20000,
            url: url,
            dataType: type,
            data: data,
            success: callback,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("請求錯誤:" + XMLHttpRequest.status + "\n" + "錯誤描述:" + XMLHttpRequest.statusText);
            }
        });
    },
    get: function (url, data, callback, type) {
        if ($.isFunction(data)) {
            type = type || callback;
            callback = data;
            data = undefined;
        }
        //對get方法重寫，增加timeout和異常提示
        return $.ajax({
            type: "GET",
            //timeout: 20000,
            url: url,
            dataType: type,
            data: data,
            success: callback,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("請求錯誤:" + XMLHttpRequest.status + "\n" + "錯誤描述:" + XMLHttpRequest.statusText);
            }
        });
    },
    getExplorer: function () {
        var explorer = window.navigator.userAgent;
        //ie
        if (explorer.indexOf("MSIE") >= 0) {
            return 'IE';
        }
            //firefox
        else if (explorer.indexOf("Firefox") >= 0) {
            return 'Firefox';
        }
            //Chrome
        else if (explorer.indexOf("Chrome") >= 0) {
            return 'Chrome';
        }
            //Opera
        else if (explorer.indexOf("Opera") >= 0) {
            return 'Opera';
        }
            //Safari
        else if (explorer.indexOf("Safari") >= 0) {
            return 'Safari';
        }
    }
});
//重寫load方法，添加timeout和異常提示
$.fn.load = function (url, params, callback) {
    debugger;

    var _load = $.fn.load;
    if (typeof url !== "string" && _load) {
        return _load.apply(this, arguments);
    }

    var selector, response, type,
        self = this,
        off = url.indexOf(" ");

    if (off >= 0) {
        selector = $.trim(url.slice(off, url.length));
        url = url.slice(0, off);
    }

    // If it's a function
    if ($.isFunction(params)) {

        // We assume that it's the callback
        callback = params;
        params = undefined;

        // Otherwise, build a param string
    } else if (params && typeof params === "object") {
        type = "POST";
    }

    // If we have elements to modify, make the request
    if (self.length > 0) {
        $.ajax({
            url: url,
            //timeout: 20000,
            // if "type" variable is undefined, then "GET" method will be used
            type: type,
            dataType: "html",
            data: params,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("請求錯誤:" + XMLHttpRequest.status + "\n" + "錯誤描述:" + XMLHttpRequest.statusText);
            }
        }).done(function (responseText) {

            // Save response for use in complete callback
            response = arguments;

            self.html(selector ?

                // If a selector was specified, locate the right elements in a dummy div
                // Exclude scripts to avoid IE 'Permission Denied' errors
                $("<div>").append($.parseHTML(responseText)).find(selector) :

                // Otherwise use the full result
                responseText);

        }).complete(callback && function (jqXHR, status) {
            self.each(callback, response || [jqXHR.responseText, status, jqXHR]);
        });
    }

    return this;
}

//BootStrapTable ie8隔行換色
function BStableStriped() {
    var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串 
    var isOpera = userAgent.indexOf("Opera") > -1; //判断是否Opera浏览器 
    var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串 
    var isIE = userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera; //判断是否IE浏览器 
    var isEdge = userAgent.indexOf("Windows NT 6.1; Trident/7.0;") > -1 && !isIE; //判断是否IE的Edge浏览器 
    if (isIE) {
        var reIE = new RegExp("MSIE (\\d+\\.\\d+);");
        reIE.test(userAgent);
        var fIEVersion = parseFloat(RegExp["$1"]);
        //alert(fIEVersion)
        if (fIEVersion <= 8) {
            var tables = $(".bootstrap-table table").find("tbody");
            for (var j = 0; j < tables.length; j++) {
                var table = tables[j];
                var trs = table.getElementsByTagName("tr");
                for (var i = 0; i < trs.length; i++) {
                    if (i % 2 == 0) {
                        trs[i].style.backgroundColor = "#f5f9fe";
                    }
                }
            }
        }
    }
}
//BootStrapTable 返回結果格式化
function BStableFormate(result) {
    if (result.success) {
        return {
            total: (result.data == null || result.data.length == 0) ? 0 : (result.data[0].COUNTSUM == undefined ? result.data.length : result.data[0].COUNTSUM),
            rows: result.data
        };
    }
    else {
        alert(result.errormessage);
        return;
    }
}