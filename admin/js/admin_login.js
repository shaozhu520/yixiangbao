/// <reference path="../../js/jquery-1.11.0.js" />
$(function () {
    $("#submit").click(function () {
        var nrwsneme = $.trim($("#UserName").val());
        var pwd = $.trim($("#pwd").val());
        if (nrwsneme != "" && pwd!="") {
            //加载中图标
            var index = layer.load(0, { time: 10 * 1000 }); //最长等待10秒 
            $.post("Handle.ashx", { "parameter": "adminLogin", "newsName": nrwsneme, "Pwd": pwd }, function (data) {
                //关闭
                layer.close(index);
                var data = JSON.parse(data);//将json 转换成 对象
                //{"Success":true,"TypeID":0,"Info":"登录成功","Redirect":"shaozhu","Data":null}
                if (data.Success == true) {
                    $.cookie("Token-Name", data.Redirect);//保存cookie
                    layer.alert(data.Info);
                    window.location.href = "base.html";
                } else {
                    layer.alert(data.Info);
                }
            });
        }
    })
});
