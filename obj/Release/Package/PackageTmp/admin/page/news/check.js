/// <reference path="jquery-1.11.0.js" />
$(function () {
    

});

check();

function getLocalTime(nS) {//时间转换函数
    return new Date(parseInt(nS) * 1000).toLocaleString().substr(0, 17)
}

function check(){
    $.post("../../Handle.ashx", { "parameter": "CheckList" }, function (data) {
      

        var data = JSON.parse(data);

        var str = ""


        $(data.Data).each(function (index) {
            //str += data.Data[index].Title ;
            //data.Data[index].RealName
            //index

            var s = data.Data[0].CreatedTime//乱码的时间

            var data1 = s.substring(6, 16)//截取

            var tiems = getLocalTime(data1)//转换

            str += '<tr><th>' + data.Data[index].ID + '</th>';
            str += '<td>' + data.Data[index].Title + '</td><td>' + tiems + '</td><td>' + data.Data[index].NewsClass + '</td><td>' + data.Data[index].ViewCount + '</td><td>' + data.Data[index].Pseudonym + '</td>';
            str += '<td><a class="layui-btn layui-btn-mini news_edit"><i class="iconfont icon-edit"></i> 编辑</a><a class="layui-btn layui-btn-danger layui-btn-mini news_del" data-id="1"><i class="layui-icon"></i> 删除</a></td></tr>';


        });




       
        $("#list").append(str);
       
        //$("#list").html(str);

        //alert(str);

        //alert(data.Data[0].Title);
        //data.Data.

    });
}