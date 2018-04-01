//查找要修改的对象

var id = GetQueryString("id");
var Class = GetQueryString("class");

$.post("../../Handle.ashx", { "parameter": "CheckOne", "id": id }, function (data) {

    var data1 = JSON.parse(data);//将json 转换成 对象

    var dat = data1.Data;


    $(".Title").val(dat[0].Title);//标题 Abstract 1
    $(".Pseudonym").val(dat[0].Author);//作者  2 这个不能绑上去 后端绑个唯一识别码

    $(".Abstract").val(dat[0].Abstract);//简介 后期加的 4
    $(".Tsize").val(dat[0].Tsize);//大小 后期加的 5 NStatistics
    $(".NStatistics").val(dat[0].NStatistics);//下载数 后期加的 6 
    $(".Download").val(dat[0].Download);//下载地址 后期加的 7 
    $(".ViewCount").val(dat[0].lrNumber);//浏览数 8
    $("#news_content").val(dat[0].IsContents);//内容
    
    var s = dat[0].ReleaseTime;//乱码的时间

    var istimes = s.substring(6, 16)//截取

    var tiems = getLocalTime(istimes)//转换

    function getLocalTime(nS) {//时间转换函数
        return new Date(parseInt(nS) * 1000).toLocaleString().substr(0, 17)

    }

    $(".CreatedTime").val(tiems)//发布时间

    $(".Thumbnail").val(dat[0].Thumbnail);//缩略图 11 这个要等后面来

});

function GetQueryString(name) {//获取URL上的参数
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}