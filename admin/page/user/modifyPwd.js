//modifyPwd

//var areaData = address;
var $form;
var form;
var $;
var myname;
var myPwd;
var newPwd;
layui.config({
    base: "../../js/"
}).use(['form', 'layer', 'upload', 'laydate'], function () {
    form = layui.form();
    var layer = parent.layer === undefined ? layui.layer : parent.layer;
    $ = layui.jquery;
    $form = $('form');
    laydate = layui.laydate;
    
    layui.upload({
        url: "../../json/userface.json",
        success: function (res) {
            var num = parseInt(4 * Math.random());  //生成0-4的随机数
            //随机显示一个头像信息
            userFace.src = res.data[num].src;
            window.sessionStorage.setItem('userFace', res.data[num].src);
        }
    });

    //添加验证规则
    form.verify({
        oldPwd: function (value, item) {
            //if (value != "123456") {
            //    return "密码错误，请重新输入！";
            //}
            myPwd = value;
        },
        newPwd: function (value, item) {
            newPwd = value;
            if (value.length < 6) {
                return "密码长度不能小于6位";
            }
        },
        confirmPwd: function (value, item) {
            if (!new RegExp($("#oldPwd").val()).test(value)) {
                return "两次输入密码不一致，请重新输入！";
            }
        }
    })

    //修改密码
    form.on("submit(changePwd)", function (data) {
        var index = layer.msg('提交中，请稍候', { icon: 16, time: false, shade: 0.8 });

        var name = $.cookie("Token-Name");

        



        setTimeout(function () {
            $.post("../../Handle.ashx", { "parameter": "modifyPwd", "myname": name, "myPwd": myPwd, "newPwd": newPwd }, function (data) {

                var data = JSON.parse(data);
                layer.msg(data.Info);

            });
            
            $(".pwd").val('');
        }, 2000);


        return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
    })

})

var Name = $.cookie("Token-Name");//获取 用户名
$("#myName").val(Name);
