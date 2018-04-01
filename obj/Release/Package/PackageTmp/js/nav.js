$(function(){
	/*导航动态生成*/
    $(".nav_k .list").append('<li><a   href="index.aspx">首页</a></li>');
	$(".nav_k .list").append('<li><a target="_blank" href="Article.aspx">文章中心</a></li>');
	$(".nav_k .list").append('<li><a target="_blank" href="http://www.baidu.com/">戒色学院</a></li>'); 
	$(".nav_k .list").append('<li><a target="_blank" href="http://www.baidu.com/">女戒学院</a></li>'); 
	$(".nav_k .list").append('<li><a target="_blank" href="http://www.baidu.com/">戒邪淫部落</a></li>'); 
	$(".nav_k .list").append('<li><a target="_blank" href="http://www.ximalaya.com/29507208/album/10352565/">电台</a></li>');
	$(".nav_k .list").append('<li><a target="_blank" href="http://www.baidu.com/">微信公众</a></li>'); 
	$(".nav_k .list").append('<li><a target="_blank" href="enroll.aspx">我要报名</a></li>'); 
	$(".nav_k .list").append('<li><a target="_blank" href="AboutUs.aspx">关于我们</a></li>');
	
	/*导航鼠标经过效果开始*/
	var id=0;
	var nav =$(".list li a");
	nav.hover(function(){

		$(this).addClass("list-bg");
		$(this).parent("li").siblings("li").find("a").removeClass("list-bg");
	},function(){
		$(this).removeClass("list-bg");

		//$(this).parent("li").siblings("li").eq(id).find("a").addClass("list-bg");
		
	});
	/*导航鼠标经过效果结束*/
});
