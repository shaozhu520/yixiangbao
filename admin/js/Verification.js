//验证权限的JS


var Name = $.cookie("Token-Name");//获取
//var token = $.cookie("Token");//获取



if (Name != null) {

    $.post("Handle.ashx", { "parameter": "adminyz", "newsName": Name }, function (data) {

        var data = JSON.parse(data);//将json 转换成 对象
        if (data.Info) {
            //验证没有问题

        } else {
            window.location.href = "admin_login.html";

        }
    });



} else {
    window.location.href = "admin_login.html";
}



