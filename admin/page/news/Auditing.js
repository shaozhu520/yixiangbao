layui.config({
    base: "js/"
}).use(['form', 'layer', 'jquery', 'laypage'], function () {
    var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage,
		$ = layui.jquery;



    //执行加载页面数据
    Load();

    //加载页面函数
    function Load() {


        $.post("../../Handle.ashx", { "parameter": "Auditing" }, function (data) {

            //data.Data[index].ID

            var data = JSON.parse(data);

            var newArray = [];

            //转换
            newsData = data.Data;

            //正常加载信息
            //执行加载数据的方法
            newsList(newsData);



        });

    };



    //查询
    $(".search_btn").click(function () {
        var newArray = [];
        if ($(".search_input").val() != '') {
            var index = layer.msg('查询中，请稍候', { icon: 16, time: false, shade: 0.8 });
            setTimeout(function () {
                $.ajax({
                    url: "../../json/newsList.json",
                    type: "get",
                    dataType: "json",
                    success: function (data) {
                        if (window.sessionStorage.getItem("addNews")) {
                            var addNews = window.sessionStorage.getItem("addNews");
                            newsData = JSON.parse(addNews).concat(data);
                        } else {
                            newsData = data;
                        }
                        for (var i = 0; i < newsData.length; i++) {
                            var newsStr = newsData[i];
                            var selectStr = $(".search_input").val();
                            function changeStr(data) {
                                var dataStr = '';
                                var showNum = data.split(eval("/" + selectStr + "/ig")).length - 1;
                                if (showNum > 1) {
                                    for (var j = 0; j < showNum; j++) {
                                        dataStr += data.split(eval("/" + selectStr + "/ig"))[j] + "<i style='color:#03c339;font-weight:bold;'>" + selectStr + "</i>";
                                    }
                                    dataStr += data.split(eval("/" + selectStr + "/ig"))[showNum];
                                    return dataStr;
                                } else {
                                    dataStr = data.split(eval("/" + selectStr + "/ig"))[0] + "<i style='color:#03c339;font-weight:bold;'>" + selectStr + "</i>" + data.split(eval("/" + selectStr + "/ig"))[1];
                                    return dataStr;
                                }
                            }
                            //文章标题
                            if (newsStr.newsName.indexOf(selectStr) > -1) {
                                newsStr["newsName"] = changeStr(newsStr.newsName);
                            }
                            //发布人
                            if (newsStr.newsAuthor.indexOf(selectStr) > -1) {
                                newsStr["newsAuthor"] = changeStr(newsStr.newsAuthor);
                            }
                            //审核状态
                            if (newsStr.newsStatus.indexOf(selectStr) > -1) {
                                newsStr["newsStatus"] = changeStr(newsStr.newsStatus);
                            }
                            //浏览权限
                            if (newsStr.newsLook.indexOf(selectStr) > -1) {
                                newsStr["newsLook"] = changeStr(newsStr.newsLook);
                            }
                            //发布时间
                            if (newsStr.newsTime.indexOf(selectStr) > -1) {
                                newsStr["newsTime"] = changeStr(newsStr.newsTime);
                            }
                            if (newsStr.newsName.indexOf(selectStr) > -1 || newsStr.newsAuthor.indexOf(selectStr) > -1 || newsStr.newsStatus.indexOf(selectStr) > -1 || newsStr.newsLook.indexOf(selectStr) > -1 || newsStr.newsTime.indexOf(selectStr) > -1) {
                                newArray.push(newsStr);
                            }
                        }
                        newsData = newArray;
                        newsList(newsData);
                    }
                })

                layer.close(index);
            }, 2000);
        } else {
            layer.msg("请输入需要查询的内容");
        }
    })



    //添加文章
    $(".newsAdd_btn").click(function () {
        var index = layui.layer.open({
            title: "添加文章",
            type: 2,
            content: "newsAdd.html",
            success: function (layero, index) {
                layui.layer.tips('点击此处返回文章列表', '.layui-layer-setwin .layui-layer-close', {
                    tips: 3
                });
            }
        })
        //改变窗口大小时，重置弹窗的高度，防止超出可视区域（如F12调出debug的操作）
        $(window).resize(function () {
            layui.layer.full(index);
        })
        layui.layer.full(index);
    })




    





    //操作
    $("body").on("click", ".news_edit", function () {  //编辑
        //layer.alert('您点击了文章编辑按钮，但此功能正在研发中，后期会添加，敬请谅解。。。', { icon: 6, title: '文章编辑' });


        var index = layui.layer.open({
            title: "修改文章",
            type: 2,
            content: "amend.html?id=" + $(this).attr("data-id"),
            success: function (layero, index) {
                layui.layer.tips('点击此处返回文章列表', '.layui-layer-setwin .layui-layer-close', {
                    tips: 3
                });
            }
        })


        //改变窗口大小时，重置弹窗的高度，防止超出可视区域（如F12调出debug的操作）
        $(window).resize(function () {
            layui.layer.full(index);
        })
        layui.layer.full(index);


    })






    $("body").on("click", ".news_del", function () {  //删除
        var _this = $(this);
        layer.confirm('确定删除此信息？', { icon: 3, title: '提示信息' }, function (index) {

            $.post("../../Handle.ashx", { "parameter": "deleteRNews", "id": _this.attr("data-id") }, function (data) {

                var data = JSON.parse(data);

                layer.msg(data.Info);



                for (var i = 0; i < newsData.length; i++) {
                    if (newsData[i].ID == _this.attr("data-id")) {
                        newsData.splice(i, 1);
                        newsList(newsData);
                    }
                }
                layer.close(index);

            });


        });
    })



    //审核文章
    form.on('switch(isopen)', function (data) {
        var index = layer.msg('修改中，请稍候', { icon: 16, time: false, shade: 0.4 });

        var ids = $(this).attr("data-id");

        setTimeout(function () {

            $.post("../../Handle.ashx", { "parameter": "AuditingOK", "id": ids }, function (data) {

                var data = JSON.parse(data);

                layer.close(index);//关了刷新图标

                if (data.Success) {

                    for (var i = 0; i < newsData.length; i++) {
                        //console.log(newsData[i].ID);
                        //console.log($(this).attr("data-id"));

                        if (newsData[i].ID == ids) {
                            newsData.splice(i, 1);
                            $(this).parents("td").parents("tr").eq(i).hide();
                            newsList(newsData);
                        }
                    }

                    layer.msg(data.Info);

                } else {
                    layer.msg(data.Info);
                }

                

                



            });

        }, 2000);
    })




    function newsList(that) {
        //渲染数据
        function renderDate(data, curr) {
            var dataHtml = '';
            if (!that) {
                currData = newsData.concat().splice(curr * nums - nums, nums);
            } else {
                currData = that.concat().splice(curr * nums - nums, nums);
            }
            if (currData.length != 0) {
                for (var i = 0; i < currData.length; i++) {

                    var s = currData[i].ReleaseTime//乱码的时间

                    var data1 = s.substring(6, 16)//截取

                    var tiems = getLocalTime(data1)//转换
                    function getLocalTime(nS) {//时间转换函数
                        return new Date(parseInt(nS) * 1000).toLocaleString().substr(0, 17)

                    }

                    

                    //" href="amend.html?class=0&id=' + currData[i].ID + '"

                    dataHtml += '<tr>'
                      + '<td>' + currData[i].ID + '</td>'

                       + '<td align="left">' + currData[i].Title + '</td>'
                       + '<td>' + tiems + '</td>';

                    dataHtml += '<td>' + currData[i].IsClass + '</td>'
                    + '<td><input type="checkbox" class="layui-form-onswitch"  name="show" lay-filter="isopen" lay-skin="switch" lay-text="通过|待核" lay-filter="isShow" data-id=\'' + currData[i].ID + '\'></td>'
                    //+ '<td><input type="checkbox" checked="" name="open" lay-skin="switch" lay-filter="isopen"  lay-filter="switchTest" lay-text="通过|待核" data-id=\'' + currData[i].ID + '\'></td>'
                    + '<td>' + currData[i].Author + '</td>'
                    + '<td>'
                    + '<a data-id="' + currData[i].ID + '" class="layui-btn layui-btn-mini news_edit"><i class="iconfont icon-edit"></i> 编辑</a>'
                    //+ '<a data-id="' + currData[i].ID + ' class="layui-btn layui-btn-mini news_edit"><i class="iconfont icon-edit"></i> 编辑</a>'
                    + '<a class="layui-btn layui-btn-danger layui-btn-mini news_del" data-id="' + currData[i].ID + '"><i class="layui-icon">&#xe640;</i> 删除</a>'
                    + '</td>'
                    + '</tr>';
                }
            } else {
                dataHtml = '<tr><td colspan="8">暂无数据</td></tr>';
            }
            return dataHtml;
        }



        //分页
        var nums = 5; //每页出现的数据量
        if (that) {
            newsData = that;
        }
        laypage({
            cont: "page",//ID
            pages: Math.ceil(newsData.length / nums),
            jump: function (obj, first) {
                $(".news_content").html(renderDate(newsData, obj.curr));
                $('.news_list thead input[type="checkbox"]').prop("checked", false);
                form.render();
                //layer.msg('第' + obj.curr + '页');
            }
        })



    }
})
