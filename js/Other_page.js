/// <reference path="jquery-1.11.0.js" />

layui.use(['laypage', 'layer'], function () {
    var laypage = layui.laypage
    , layer = layui.layer;

    var mysun = $(".Articles-con-l-main").attr("sum");//总共多少页

    var mycurr = Number(GetQueryString("page"));


    laypage.render({
        elem: 'demo5'
    , count: Number(mysun) * 10 //数据总数
    , curr: mycurr
    , jump: function (obj, first) {

        if (!first) {
            //do something
            window.location.href = "Other.aspx?page=" + obj.curr;
        }

    }
    });
});


function GetQueryString(name) {//获取URL上的参数
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

