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
	var editIndex = layedit.build('news_content', {
	    
	    uploadImage: { url: '../../ajax/AjaxUpImage.ashx?cmd=uploadImage', type: 'post' }
	});



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

 	            
 	            var Title = $(".Title").val();//标题 Abstract 1
 	            var Author = $(".Pseudonym").val();//作者  2 这个不能绑上去 后端绑个唯一识别码
 	            var IsClass = $(".newsLook option").eq($(".newsLook").val()).text();//分类 3
 	            var Abstract = $(".Abstract").val();//简介 后期加的 4
 	            var Tsize = $(".Tsize").val();//大小 后期加的 5 NStatistics
 	            var NStatistics = $(".NStatistics").val();//下载数 后期加的 6 
 	            var Download = $(".Download").val();//下载地址 后期加的 7 
 	            var lrNumber = $(".ViewCount").val();//浏览数 8
 	            var IsContents = layedit.getContent(editIndex);//内容 9
 	            var ReleaseTime = $(".CreatedTime").val();//时间 10
 	            var Thumbnail = $(".Thumbnail").val();//缩略图 11 这个要等后面来
 	            //var Star = $(".Star").val();//星级 12 
 	            var Star = $(".Stars option").eq($(".Stars").val()).text();//星级 12
 	            //alert(NewsClass);

 	            //parameter
 	            $.post("../../Handle.ashx", { "parameter": "addNEws", "Title": Title, "Author": Author, "IsClass": IsClass, "Abstract": Abstract, "Tsize": Tsize, "NStatistics": NStatistics, "Download": Download, "lrNumber": lrNumber, "IsContents": IsContents, "ReleaseTime": ReleaseTime, "Thumbnail": Thumbnail, "Star": Star }, function (data) {

 	                var data = JSON.parse(data);

 	                if (data.Success == true) {

 	                    layer.open({
 	                        title: '温馨提示', content: data.Info
 	                    });
 	                    window.location.href = "newsList.html?class=1";

 	                   
 	                } else {

 	                    layer.open({
 	                        title: '温馨提示', content: data.Info
 	                    });
 	                }
 	            });


 	        } 
 	    });


 	})


})
var Name = $.cookie("Token-Name");//获取 用户名
$(".Pseudonym").val(Name);




