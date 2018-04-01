//验证登录



$.post("/ajax/loginAjax.ashx", { "parameter": "toyztoken" }, function (data) {
    var data = JSON.parse(data);
    if (data.Success) {//已经登录
        /*
        <li class="yzbtn1"><a href="/user/login.aspx">登录</a></li>
        <li class="yzbtn2"><a href="/user/reg.aspx">注册</a></li>
        <li class="yzbtn1"><a href="/user/index.aspx">个人中心</a></li>
        <li class="yzbtn2"><a href="javascript:;">退出</a></li>
        */

        $(".yzbtn1").attr("href", "/user/index.aspx");
        $(".yzbtn1").text("个人中心");
        $(".yzbtn2").attr("href", "javascript:;");
        $(".yzbtn2").text("退出");

    } else {//没有登录
        
        $(".yzbtn1").attr("href", "/user/login.aspx");
        $(".yzbtn1").text("登录");
        $(".yzbtn2").attr("href", "/user/reg.aspx");
        $(".yzbtn2").text("注册");
        $(".personalbtn").hide();//隐藏
    }


});

$(".secedeBtn").click(function (e) {//退出登录请求
    e.preventDefault();

    var texs = $(".secedeBtn").text();

    if (texs == "退出") {

        $.post("/ajax/loginAjax.ashx", { "parameter": "secede" }, function (data) {

            var timestamp = Date.parse(new Date());//获取一个时间戳

            var data = JSON.parse(data);
            if (data.Success) {
                window.location.href = "/index.aspx" + "?xiaoyi=" + timestamp;
            } else {
                window.location.href = window.location.href + "?xiaoyi=" + timestamp;
            }
        })

    } else {
        window.location.href = "/user/reg.aspx";
    }
    
});