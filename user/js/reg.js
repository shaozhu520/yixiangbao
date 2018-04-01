$(function () {

    $("#send").click(function () {//发送邮箱验证码

        var Email = $.trim($(".Email").val());//邮箱;
        
        if (isEmail(Email) != false) {//邮箱没有问题

            $.post("../ajax/regAjax.ashx", { "parameter": "toMail", "Email": Email }, function (data) {

                var data = JSON.parse(data);//将json 转换成 对象

                //{"Success":true,"TypeID":0,"Info":"","Redirect":"","Data":null}
                console.log(data);

                if (data.Success) {
                    layer.msg(data.Info, {
                        time: 1000,
                        icon: 6
                    });
                    //console.log("发送成功");
                } else {
                    //console.log("发送失败");
                    layer.msg(data.Info, {
                        time: 1000,
                        icon: 5
                    });
                }



            })

        } else {


        }

    });


    $("#reg").click(function (e) {//注册

        e.preventDefault(); //阻止默认的行为

        var Email = $.trim($(".Email").val());//邮箱;
        var pwd = $.trim($(".pwd").val());//邮箱;
        var yzm = $.trim($(".Verification").val());//邮箱验证码

        if ((Email != "" || pwd != "") || yzm != "") {
            $.post("../ajax/regAjax.ashx", { "parameter": "Register", "Email": Email, "Pwd": pwd, "proving": yzm }, function (data) {

                var data = JSON.parse(data);//转json

                //console.log(data);
                if (data.Success) {
                    layer.msg(data.Info, {
                        time: 1000,
                        icon: 6
                    });
                    //console.log("注册成功");
                } else {
                    //console.log("注册失败");
                    layer.msg(data.Info, {
                        time: 1000,
                        icon: 5
                    });
                }

            });
        }

    })

});

//验证邮箱的函数 返回bool
function isEmail(str) {
    var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
    return reg.test(str);
}