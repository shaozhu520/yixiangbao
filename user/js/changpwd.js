
    //修改密码
$(".changePwdBTN").click(function (e) {
        //var index = layui.msg('提交中，请稍候', { icon: 16, time: false, shade: 0.8 });

    e.preventDefault();//阻止表单跳转。如果需要表单跳转，去掉这段即可。


    var myPwd = $.trim($(".jpwd").val());//旧密码
    var newPwd = $.trim($("#oldPwd").val());//新密码

    if (myPwd != "" && newPwd!=""){

        $.post("/ajax/loginAjax.ashx", { "parameter": "changpwd", "Pwd": myPwd, "xpwd": newPwd }, function (data) {
            var data = JSON.parse(data);

            //layui.msg(data.Info);
            layer.msg(data.Info);
            $(".pwd").val('');
            $("#oldPwd").val('');
        });
    
    }


    })
