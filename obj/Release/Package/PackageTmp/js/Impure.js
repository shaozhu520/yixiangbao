$(function(){
	
	/*导航鼠标经过效果开始*/
	var id=3;
	var nav =$(".list li a");
	nav.hover(function(){

		$(this).addClass("list-bg");
		$(this).parent("li").siblings("li").find("a").removeClass("list-bg");
	},function(){
		$(this).removeClass("list-bg");
		//$(this).parent("li").siblings("li").eq(id).find("a").addClass("list-bg");
	});
    /*导航鼠标经过效果结束*/
	$("#search").click(function () {

	    var search = $(".inputs").val();

	    if (search != "") {
	        window.location.href = "/Impure.aspx?Keyword=" + search;
	    }

	    //$.get("/RNewsM.ashx", "id=" + sid, function (data) {

	    //});
	});
	
});
