/// <reference path="jquery-1.11.0.js" />
layui.config({
    base: "js/"
}).use(['form', 'layer', 'jquery', 'layedit', 'laydate'], function () {
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


    var id = GetQueryString("id");//ID
    var Class = GetQueryString("class");//分类



    $(function () {


        //提交修改
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
                $.post("../../Handle.ashx", { "parameter": "modifyRnews", "id": id, "Title": Title, "Author": Author, "IsClass": IsClass, "Abstract": Abstract, "Tsize": Tsize, "NStatistics": NStatistics, "Download": Download, "lrNumber": lrNumber, "IsContents": IsContents, "ReleaseTime": ReleaseTime, "Thumbnail": Thumbnail, "Star": Star }, function (data) {

                    var data = JSON.parse(data);

                    if (data.Success == true) {

                        layer.open({
                            title: '温馨提示', content: data.Info
                        });
                        layer.msg(data.Info);
                        window.location.href = "newsList.html?class=3"

                        //alert("登陆成功");
                    } else {
                        layer.msg(data.Info);
                        layer.open({
                            title: '温馨提示', content: data.Info
                        });
                        // alert("用户名或密码错误");
                    }
                });



            } else {

                layer.open({
                    title: '温馨提示', content: '必填项必须要填哦，亲！'
                });


            }
        });




    })


})
var Name = $.cookie("Token-Name");//获取 用户名
$(".Pseudonym").val(Name);


function GetQueryString(name) {//获取URL上的参数
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}







