$(function () {
    $("#tologin").click(function (e) {//注册

        e.preventDefault(); //阻止默认的行为
        var Email = $.trim($(".Email").val());
        var pwd = $.trim($(".pwd").val());
        if (Email != "" || pwd != "")  {
            $.post("../ajax/loginAjax.ashx", { "parameter": "login", "Email": Email, "Pwd": pwd}, function (data) {

                var data = JSON.parse(data);//转json
                if (data.Success) {
                    layer.msg(data.Info, {
                        time: 1000,
                        icon: 6
                    });
                    window.location.href = "index.aspx";
                } else {
                    layer.msg(data.Info, {
                        time: 1000,
                        icon: 5
                    });
                }

            });
        }

    })

});