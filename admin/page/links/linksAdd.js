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
    var editIndex = layedit.build('links_content');
    var addLinksArray = [], addLinks;


    //$("#addLinks").


    $("#addLinks").click(function () {
        if ((($(".linksName").val() != "" && $(".linksUrl").val() != "") && ($(".linksTime").val() != "" && $(".masterEmail").val() != ""))) {
            //alert($(".Title").val());

            //获取编辑器页面的内容

            var WebName = $(".linksName").val();//网站名称
            var WebUrl = $(".linksUrl").val();//网站地址
            var CreatedTime = $(".linksTime").val();//发布时间
            var ContactEMail = $(".masterEmail").val();//站长邮箱


            //parameter
            $.post("../../Handle.ashx", { "parameter": "AddLinks", "WebName": WebName, "WebUrl": WebUrl, "CreatedTime": CreatedTime, "ContactEMail": ContactEMail }, function (data) {

                //刷新父页面
                //parent.location.reload();

                var data = JSON.parse(data);

                layer.open({
                    title: '温馨提示', content: data.Info
                });

                    //window.location.href = "newsList.html"

            });
        } 
    });



})
