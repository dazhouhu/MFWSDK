G = {
    baseUri:'https://api.dev.qunlivideo.com'
};

layui.use(['layer', 'jquery'], function () {
    var $ = layui.$;
    $.support.cors = true

    var refreshTokenTimer = null;
    var refreshToken = function () {
        if (refreshTokenTimer) {
            clearTimeout(refreshTokenTimer)
        }
        $.svc.remotePost({
            url: '/api/refresh',
            success: function (result) {
                if (result.code === 1) {
                    refreshTokenTimer = setTimeout(refreshToken, result.data.expires_in * 1000);
                    setToken(result.data.access_token);
                } else {
                   location.href = "login.html"
                }
            },
            error: function (errMsg) {
               location.href = "login.html"
            }
        });
    }
    $.extend({
        getQueryString: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        },
        isNumber: function (obj) {
            return typeof obj === 'number' && isFinite(obj)
        },
        getValue: function (key) {
            if (!window.localStorage) {
                if (document.cookie.length > 0) {
                    c_start = document.cookie.indexOf(key + "=")
                    if (c_start != -1) {
                        c_start = c_start + key.length + 1
                        c_end = document.cookie.indexOf(";", c_start)
                        if (c_end == -1) c_end = document.cookie.length
                        return unescape(document.cookie.substring(c_start, c_end))
                    }
                }
            } else {
                var storage = window.localStorage;
                return storage[key];
            }
        },
        setValue: function (key, value) {
            if (!window.localStorage) {
                var exdate = new Date()
                if (!expiredays) {
                    expiredays = 1;
                    exdate.setDate(exdate.getDate() + expiredays)
                }
                document.cookie = key + "=" + escape(value) +
                    ((expiredays == null) ? "" : "; expires=" + exdate.toGMTString())
            } else {
                var storage = window.localStorage;
                storage[key] = value;
            }
        },

        getToken: function (username, password, success, fail) {
            if (refreshTokenTimer) {
                clearTimeout(refreshTokenTimer)
            }
            $.svc.remotePost({
                url: '/api/login',
                data: {
                    username: username,
                    password: password
                },
                success: function (result) {
                    if (success) {
                        if (result.code === 1) {
                            setToken(result.data.access_token);
                            refreshTokenTimer = setTimeout(refreshToken, result.data.expires_in * 1000);
                            success(result);
                        } else if (fail) {
                            fail(result.message);
                        }
                    }
                },
                error: function (errMsg) {
                    if (fail) {
                        fail(errMsg);
                    }
                }
            });
        },
        svc: {
            config: {
                url: "",
                data: null,
                success: null,
                error: null,
            },
            remoteGet: function (option) {
                var cfg = $.extend({
                    type: 'GET'
                }, this.config, option);
                cfg.url = G.baseUri + cfg.url;
                var token = G.token;
                cfg.data = $.extend({}, cfg.data)
                if (token) {
                    cfg.data = $.extend(cfg.data, {
                        token: token
                    })
                }
                ajax(cfg);
            },
            remotePost: function (option) {
                var cfg = $.extend({
                    type: 'POST'
                }, this.config, option);
                cfg.url = G.baseUri + cfg.url;
                var token = G.token;
                cfg.data = $.extend({}, cfg.data)
                if (token) {
                    cfg.data = $.extend(cfg.data, {
                        token: token
                    })
                }
                ajax(cfg);
            }            
        },
    });
    var setToken = function (token) {
        G.token = token;
        $.setValue('token', token);
    };
    var ajax = function (cfg) {
        $.ajax({
            url: cfg.url,
            type: cfg.type,
            data: cfg.data,
            dataType: 'json',
            beforeSend: function (xhr) {
                if (G.token) {
                    xhr.setRequestHeader("Authorization", "Bearer " + G.token);
                }
            },
            success: function (respData) {
                if (cfg.success) {
                    cfg.success(respData);
                }
            },
            error: function (error, status, ex) {
                if (cfg.error) {
                    if (error.responseJSON) {
                        cfg.error(error.responseJSON.Msg);
                    } else {
                        cfg.error(ex);
                    }
                    return;
                }
                if (error.responseJSON) {
                    $.Msg(error.responseJSON.Msg, '错误消息', 'error');
                } else {
                    $.Msg(ex, '错误消息', 'error');
                }
            }
        });
    }
    Date.prototype.Format = function (fmt) { //author: meizz   
        var o = {
            "M+": this.getMonth() + 1, //月份   
            "d+": this.getDate(), //日   
            "h+": this.getHours(), //小时   
            "m+": this.getMinutes(), //分   
            "s+": this.getSeconds(), //秒   
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
            "S": this.getMilliseconds() //毫秒   
        };
        if (/(y+)/.test(fmt))
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt))
                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    }

    function ChangeDateFormat(val, format) {
        if (val != null && val.indexOf("/Date(") != -1) {
            var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
            if (format)
                return date.Format(format);
            return date.Format("yyyy-MM-dd hh:mm:ss");
        }

        return "";
    }
    $.DateFormat = function (date, mask) {
        var d = date;
        var zeroize = function (value, length) {
            if (!length) length = 2;
            value = String(value);
            for (var i = 0, zeros = ''; i < (length - value.length); i++) {
                zeros += '0';
            }
            return zeros + value;
        };

        return mask.replace(/"[^"]*"|'[^']*'|\b(?:d{1,4}|m{1,4}|yy(?:yy)?|([hHMstT])\1?|[lLZ])\b/g, function ($0) {
            switch ($0) {
                case 'd':
                    return d.getDate();
                case 'dd':
                    return zeroize(d.getDate());
                case 'ddd':
                    return ['Sun', 'Mon', 'Tue', 'Wed', 'Thr', 'Fri', 'Sat'][d.getDay()];
                case 'dddd':
                    return ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][d.getDay()];
                case 'M':
                    return d.getMonth() + 1;
                case 'MM':
                    return zeroize(d.getMonth() + 1);
                case 'MMM':
                    return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()];
                case 'MMMM':
                    return ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'][d.getMonth()];
                case 'yy':
                    return String(d.getFullYear()).substr(2);
                case 'yyyy':
                    return d.getFullYear();
                case 'h':
                    return d.getHours() % 12 || 12;
                case 'hh':
                    return zeroize(d.getHours() % 12 || 12);
                case 'H':
                    return d.getHours();
                case 'HH':
                    return zeroize(d.getHours());
                case 'm':
                    return d.getMinutes();
                case 'mm':
                    return zeroize(d.getMinutes());
                case 's':
                    return d.getSeconds();
                case 'ss':
                    return zeroize(d.getSeconds());
                case 'l':
                    return zeroize(d.getMilliseconds(), 3);
                case 'L':
                    var m = d.getMilliseconds();
                    if (m > 99) m = Math.round(m / 10);
                    return zeroize(m);
                case 'tt':
                    return d.getHours() < 12 ? 'am' : 'pm';
                case 'TT':
                    return d.getHours() < 12 ? 'AM' : 'PM';
                case 'Z':
                    return d.toUTCString().match(/[A-Z]+$/);
                    // Return quoted strings with the surrounding quotes removed
                default:
                    return $0.substr(1, $0.length - 2);
            }
        });
    };
    $.Msg = function (text, type, cb) {
        var icon = 6;
        switch (type) {
            case 'info':
                {
                    icon = 6;
                }
                break;
            case 'fail':
            case 'error':
                {
                    icon = 2
                }
                break;
            case 'warning':
                {
                    icon = 0;
                }
            case 'success':
                {
                    icon = 1;
                }
                break;
        }
        layer.alert(text, {
            icon: icon,
            closeBtn: 1,
            anim: 1,
            btn: ['确定'],
            yes: function (index) {
                if (cb) {
                    cb();
                }
                layer.close(index);
            }
        })
    }


    G.token = $.getValue('token');
});