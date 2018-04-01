layui.config({
	base : "js/"
}).use(['form','element','layer','jquery'],function(){
	var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		element = layui.element(),
		$ = layui.jquery;

	$(".panel a").on("click",function(){
		window.parent.addTab($(this));
	})

    //教程软件
	$.post("../Handle.ashx", { "parameter": "ListLength", "NEWSclass": "教程软件" }, function (data) {

	    $(".allNews span").text(data);
		}
	)

    //唯美头像
	$.post("../Handle.ashx", { "parameter": "ListLength", "NEWSclass": "唯美头像" }, function (data) {

	    $(".imgAll span").text(data);
	}
	)

    //线报活动
	$.post("../Handle.ashx", { "parameter": "ListLength", "NEWSclass": "线报活动" }, function (data) {

	    $(".newMessage span").text(data);
	}
	)


    //用户列表
	$.post("../Handle.ashx", { "parameter": "ListLength", "NEWSclass": "Users" }, function (data) {

	    $(".adminAll span").text(data);
	}
	)



    //管理员列表
	$.post("../Handle.ashx", { "parameter": "ListLength", "NEWSclass": "admin_table" }, function (data) {

	    $(".userAll span").text(data);
	}
	)


    //T_examine_J
    //待审核文章
	$.post("../Handle.ashx", { "parameter": "ListLength", "NEWSclass": "Rnews" }, function (data) {

	    $(".waitNews span").text(data);
	}
	)




	//数字格式化
	$(".panel span").each(function(){
		$(this).html($(this).text()>9999 ? ($(this).text()/10000).toFixed(2) + "<em>万</em>" : $(this).text());	
	})

	//系统基本参数
	if(window.sessionStorage.getItem("systemParameter")){
		var systemParameter = JSON.parse(window.sessionStorage.getItem("systemParameter"));
		fillParameter(systemParameter);
	}else{
		$.ajax({
			url : "../json/systemParameter.json",
			type : "get",
			dataType : "json",
			success : function(data){
				fillParameter(data);
			}
		})
	}

	//填充数据方法
 	function fillParameter(data){
 		//判断字段数据是否存在
 		function nullData(data){
 			if(data == '' || data == "undefined"){
 				return "未定义";
 			}else{
 				return data;
 			}
 		}
 		$(".version").text(nullData(data.version));      //当前版本
		$(".author").text(nullData(data.author));        //开发作者
		$(".homePage").text(nullData(data.homePage));    //网站首页
		$(".server").text(nullData(data.server));        //服务器环境
		$(".dataBase").text(nullData(data.dataBase));    //数据库版本
		$(".maxUpload").text(nullData(data.maxUpload));    //最大上传限制
		$(".userRights").text(nullData(data.userRights));//当前用户权限
 	}

})
