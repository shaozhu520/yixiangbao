/// <reference path="jquery-1.11.0.js" />

$(function(){
	//鼠标经过输入框变成圆角 
    fillet();

    phbqh();



    $(".secedeBtn").click(function () {//退出登录请求
        $.post("/ajax/loginAjax.ashx", { "parameter": "secede" }, function (data) {

            var timestamp = Date.parse(new Date());//获取一个时间戳

            var data = JSON.parse(data);
            if (data.Success) {
                window.location.href = "/index.aspx" + "?xiaoyi=" + timestamp;
            } else {
                window.location.href = window.location.href + "?xiaoyi=" + timestamp;
            }
        })
    });
	
})

//鼠标经过输入框变成圆角 border-radius:10px;
 function fillet(){
	$("#fillet").hover(function(){
		 $(this).animate({'border-radius':'25px'});
	},function(){
		 $(this).animate({'border-radius':'10px'});
	});
}

//热门排行榜切换效果
 function phbqh() {
     $(".phbbtn").click(function () {
         var indexs = $(this).index();
         $(this).addClass("rmph-bg").siblings(".phbbtn").removeClass("rmph-bg");//切换样式
         $(".commodity-con-l-main-list").eq(indexs).show().siblings(".commodity-con-l-main-list").hide();
     });
 }