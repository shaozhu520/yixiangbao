var $;
layui.config({
	base : "js/"
}).use(['form','layer','jquery'],function(){
	var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage;
		$ = layui.jquery;

 	var addUserArray = [],addUser;
 	form.on("submit(addUser)",function(data){


 	    var userGrade, userStatus, user_Pwd, userName, Contact, Sex;//声明变量

 	    userGrade = $(".Status").val();//职务1

 		//会员状态2
 		if(data.field.userStatus == '0'){
 			userStatus = "true";
 		}else if(data.field.userStatus == '1'){
 			userStatus = "false";
 		}

 		user_Pwd = $(".userPwd").val();//密码3
 		userName = $(".userName").val();//用户名4
 		Contact = $(".Contact").val();//联系方式5
 		Sex = $(".userSex .layui-form-radioed span").text();//性别6


        
 		var Name = $.cookie("Token-Name");//获取

 		if (Name != "admin") {
 		    layer.msg("权限不足");
 		}
 		else {

 		    //弹出loading

 		    var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
 		    setTimeout(function () {

 		        $.post("../../Handle.ashx", { "parameter": "add_admin", "admin_Name": userName, "admin_Pwd": user_Pwd, "state": userStatus, "Sex": Sex, "Status": userGrade, "Contact": Contact }, function (data) {

 		            var data = JSON.parse(data);
 		            

 		            layer.msg(data.Info);


 		            layer.closeAll("iframe");

 		            //刷新父页面
 		            //parent.location.reload();
 		        });
 		    }, 2000);
 		}



 		return false;
 	})
	
})

////格式化时间
//function formatTime(_time){
//    var year = _time.getFullYear();
//    var month = _time.getMonth()+1<10 ? "0"+(_time.getMonth()+1) : _time.getMonth()+1;
//    var day = _time.getDate()<10 ? "0"+_time.getDate() : _time.getDate();
//    var hour = _time.getHours()<10 ? "0"+_time.getHours() : _time.getHours();
//    var minute = _time.getMinutes()<10 ? "0"+_time.getMinutes() : _time.getMinutes();
//    return year+"-"+month+"-"+day+" "+hour+":"+minute;
//}
