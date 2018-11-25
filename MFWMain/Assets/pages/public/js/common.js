layui.use(['layer', 'jquery'], function () {
    var $ = layui.$;
    
    $(".bottom").delegate('#huiyi', 'click', function () {
        location.href = "meeting.html";
    });
    $(".bottom").delegate('#lianxiren', 'click', function () {
        location.href = "callman.html";
    });
    $(".bottom").delegate('#hujiao', 'click', function () {
        location.href = "call.html";
    });
    $(".bottom").delegate('#shezhi', 'click', function () {
        location.href = "option1.html";
    });
    $(".bottom").delegate('#tuichu', 'click', function () {
        layer.confirm('确定需要退出系统吗？', {
            btn: ['确定', '取消'] //按钮
        }, function () {
            if (window.OnLogout) {
                window.OnLogout();
            }
            location.href = "login.html";
        }, function () {
        });
    });
});