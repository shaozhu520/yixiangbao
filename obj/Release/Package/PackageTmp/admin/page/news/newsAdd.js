/// <reference path="jquery-1.11.0.js" />
layui.config({
	base : "js/"
}).use(['form','layer','jquery','layedit','laydate'],function(){
	var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage,
		layedit = layui.layedit,
		laydate = layui.laydate,
		$ = layui.jquery;

	//创建一个编辑器
 	var editIndex = layedit.build('news_content');
 	//var addNewsArray = [],addNews;


 	//form.on("submit(addNews)", function (data) {
 	//	//是否添加过信息
	// 	if(window.sessionStorage.getItem("addNews")){
	// 		addNewsArray = JSON.parse(window.sessionStorage.getItem("addNews"));
	// 	}
	// 	//显示、审核状态
 	//	var isShow = data.field.show=="on" ? "checked" : "",
 	//		newsStatus = data.field.shenhe=="on" ? "审核通过" : "待审核";

 	//	addNews = '{"newsName":"'+$(".newsName").val()+'",';  //文章名称
 	//	addNews += '"newsId":"'+new Date().getTime()+'",';	 //文章id
 	//	addNews += '"newsLook":"'+$(".newsLook option").eq($(".newsLook").val()).text()+'",'; //开放浏览
 	//	addNews += '"newsTime":"'+$(".newsTime").val()+'",'; //发布时间
 	//	addNews += '"newsAuthor":"'+$(".newsAuthor").val()+'",'; //文章作者
 	//	addNews += '"isShow":"'+ isShow +'",';  //是否展示
 	//	addNews += '"newsStatus":"'+ newsStatus +'"}'; //审核状态
 	//	addNewsArray.unshift(JSON.parse(addNews));
 	//	window.sessionStorage.setItem("addNews",JSON.stringify(addNewsArray));
 	//	//弹出loading
 	//	var index = top.layer.msg('数据提交中，请稍候',{icon: 16,time:false,shade:0.8});
    //    setTimeout(function(){
    //        top.layer.close(index);
	//		top.layer.msg("文章添加成功！");
 	//		layer.closeAll("iframe");
	// 		//刷新父页面
	// 		parent.location.reload();
    //    },2000);
 	//	return false;
 	//})
	

 	//$("#add").click(function () {
 	//    if ($("#Title").val() != "") {
 	//        alert($("#Title").val());
 	//    }
 	//});

 	$(function () {

 	    $("#add").click(function () {
 	        if ((($(".Title").val() != "" && $(".ViewCount").val() != "") && ($(".Pseudonym").val() != "" && $(".CreatedTime").val() != "")) || layedit.getContent(editIndex) != "") {
 	            //alert($(".Title").val());

                //获取编辑器页面的内容
 	            //alert(layedit.getContent(editIndex));

 	            var Text = layedit.getContent(editIndex);//内容
 	            var Title = $(".Title").val();//标题
 	            var ViewCount = $(".ViewCount").val();//浏览数
 	            var Pseudonym = $(".Pseudonym").val();//作者
 	            var CreatedTime = $(".CreatedTime").val();//时间
 	            var NewsClass = $(".newsLook option").eq($(".newsLook").val()).text();//分类
 	            //alert(NewsClass);

 	            //parameter
 	            $.post("../../Handle.ashx", { "parameter": "add", "Title": Title, "Text": Text, "CreatedTime": CreatedTime, "NewsClass": NewsClass, "ViewCount": ViewCount, "Pseudonym": Pseudonym }, function (data) {
 	                if (data == "True") {

 	                    layer.open({
 	                        title: '温馨提示', content: '添加成功'
 	                    });
 	                    window.location.href = "newsList.html"

 	                    //alert("登陆成功");
 	                } else {

 	                    layer.open({
 	                        title: '温馨提示', content: '添加失败'
 	                    });
 	                   // alert("用户名或密码错误");
 	                }
 	            });



 	        } else {

 	            layer.open({
 	                title: '温馨提示', content: '必填项必须要填哦，亲！'
 	            });


 	            //alert("必填项必须要填哦，亲！");

 	        }
 	    });


 	})


})




