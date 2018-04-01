/// <reference path="jquery-1.10.2.min.js" />
var i = 0;
var timer;
var lunbow=1200;
$(function () {
	

	/*轮播图*/
    A();
    $(".tab").hover(function () {
        i = $(this).index();
        Move();
        clearInterval(timer);
    }, function () {
        A();
    });
    $(".btn1").click(function () {
        clearInterval(timer);
        i--;
        if (i == -1) {
            $("#igs").css("left", -(lunbow * 5));
            i = 4;
        }
        Move();
        A();
    });
    $(".btn2").click(function () {
        clearInterval(timer);
        i++;
        Move();
        A();
    });

	//轮播图结束

	
	
	/*六法区 颜色切换效果开始*/
	var arrColor = ["#B7B940","#47BF82","#6E8BD6","#AD53C4","#B7B940","#47BF82"];
	
	var s;
	for(s=0;s<=6;s++){

		$(".list-SixLaws").find("li").eq(s).hover(function(){
			var j = $(this).index();
			//$(this).animate({"background":arrColor[i]});
			$(this).find(".list-SixLaws-b").css({"background": arrColor[j],"color":"#fff"});
			
			
		},function(){
		    $(this).find(".list-SixLaws-b").css({"background": '#fff',"color":"#000"});
		});
		
	}
	
	/*六法区 颜色切换效果开始*/
	
	//轮播图切换按钮 显示隐藏
	$(".tabs-bnt").hover(function(){
		if($(this).index(".tabs-bnt")==0){//左边的鼠标经过
			$(this).addClass("btn1bg");
		}else{//左边的鼠标移开
			$(this).addClass("btn2bg");
		}
	},function(){
		if($(this).index(".tabs-bnt")==0){//右边的鼠标经过
			$(this).removeClass("btn1bg");
		}else{////右边的鼠标离开
			$(this).removeClass("btn2bg");
		}
	});


});

//外部函数 轮播开始
function Move() {
    if (i < 5) {
        $("#igs").animate({ "left": -(lunbow * i) }, 300);
    }
    else {
        $("#igs").animate({ "left": -(lunbow * i) }, 300, function () {// 到第五个的时候移动到重复的那个
            $(this).css("left", "0px");//回调函数 立马回到第一个
        });
        i = 0;//索引初始化
    }
    $(".tab").eq(i).addClass("bg").siblings().removeClass("bg");//li跟着变色
}

function A() {
    timer = setInterval(function () {
        i++;
        Move();
    }, 3000);
}
//外部函数 轮播结束