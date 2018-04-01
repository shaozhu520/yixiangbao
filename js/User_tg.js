$("#tgjctj").on("click", function (e) {//添加教程软件
    e.preventDefault();//阻止默认提交

    var Title = $.trim($("#title").val());
    var Abstract = $.trim($("#Abstract").val());
    var Download = $.trim($("#Download").val());
    var Thumbnail = $(".Thumbnails").attr("src");
    if ((Title!= "" && Abstract != "") && (Download != "" && Thumbnail!="")) {
        $.post("/ajax/user_tgAjax.ashx", { "parameter": "aDDjiaocheng", "Title": Title, "Abstract": Abstract, "Download": Download, "Thumbnail": Thumbnail }, function (data) {//添加教程
            var data = JSON.parse(data)
            layer.open({
                title: '温馨提示', content: data.Info
            });

        });
    } else {
            layer.open({
                title: '温馨提示', content:"必填项不能为空!"
            });
        }
    
});