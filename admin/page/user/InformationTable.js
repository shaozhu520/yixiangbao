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


        $.post("../../Handle.ashx", { "parameter": "getUserInfor" }, function (data) {

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
    //$(".search_btn").click(function () {
    //    var newArray = [];
    //    if ($(".search_input").val() != '') {
    //        var index = layer.msg('查询中，请稍候', { icon: 16, time: false, shade: 0.8 });
    //        setTimeout(function () {
    //            $.ajax({
    //                url: "../../json/newsList.json",
    //                type: "get",
    //                dataType: "json",
    //                success: function (data) {
    //                    if (window.sessionStorage.getItem("addNews")) {
    //                        var addNews = window.sessionStorage.getItem("addNews");
    //                        newsData = JSON.parse(addNews).concat(data);
    //                    } else {
    //                        newsData = data;
    //                    }
    //                    for (var i = 0; i < newsData.length; i++) {
    //                        var newsStr = newsData[i];
    //                        var selectStr = $(".search_input").val();
    //                        function changeStr(data) {
    //                            var dataStr = '';
    //                            var showNum = data.split(eval("/" + selectStr + "/ig")).length - 1;
    //                            if (showNum > 1) {
    //                                for (var j = 0; j < showNum; j++) {
    //                                    dataStr += data.split(eval("/" + selectStr + "/ig"))[j] + "<i style='color:#03c339;font-weight:bold;'>" + selectStr + "</i>";
    //                                }
    //                                dataStr += data.split(eval("/" + selectStr + "/ig"))[showNum];
    //                                return dataStr;
    //                            } else {
    //                                dataStr = data.split(eval("/" + selectStr + "/ig"))[0] + "<i style='color:#03c339;font-weight:bold;'>" + selectStr + "</i>" + data.split(eval("/" + selectStr + "/ig"))[1];
    //                                return dataStr;
    //                            }
    //                        }
    //                        //文章标题
    //                        if (newsStr.newsName.indexOf(selectStr) > -1) {
    //                            newsStr["newsName"] = changeStr(newsStr.newsName);
    //                        }
    //                        //发布人
    //                        if (newsStr.newsAuthor.indexOf(selectStr) > -1) {
    //                            newsStr["newsAuthor"] = changeStr(newsStr.newsAuthor);
    //                        }
    //                        //审核状态
    //                        if (newsStr.newsStatus.indexOf(selectStr) > -1) {
    //                            newsStr["newsStatus"] = changeStr(newsStr.newsStatus);
    //                        }
    //                        //浏览权限
    //                        if (newsStr.newsLook.indexOf(selectStr) > -1) {
    //                            newsStr["newsLook"] = changeStr(newsStr.newsLook);
    //                        }
    //                        //发布时间
    //                        if (newsStr.newsTime.indexOf(selectStr) > -1) {
    //                            newsStr["newsTime"] = changeStr(newsStr.newsTime);
    //                        }
    //                        if (newsStr.newsName.indexOf(selectStr) > -1 || newsStr.newsAuthor.indexOf(selectStr) > -1 || newsStr.newsStatus.indexOf(selectStr) > -1 || newsStr.newsLook.indexOf(selectStr) > -1 || newsStr.newsTime.indexOf(selectStr) > -1) {
    //                            newArray.push(newsStr);
    //                        }
    //                    }
    //                    newsData = newArray;
    //                    newsList(newsData);
    //                }
    //            })

    //            layer.close(index);
    //        }, 2000);
    //    } else {
    //        layer.msg("请输入需要查询的内容");
    //    }
    //})


    





    //操作
    $("body").on("click", ".news_edit", function () {  //查看详细
        //layer.alert('您点击了查看详细，但此功能正在研发中，后期会添加，敬请谅解。。。', { icon: 6, title: '资料详细' });

        var Binding, UserEmail, UserName, UserPwd, Balance, Gender, Synopsis, No_qq, Phone, Included, Sign, RegTime, ChengHao;
        var ids = $(this).attr("data-id");

        for (var j = 0; j < newsData.length; j++) {
            //console.log(newsData[i].ID);
            //console.log($(this).attr("data-id"));

            if (newsData[j].ID == ids) {
                Binding = newsData[j].Binding;
                UserEmail = newsData[j].UserEmail;
                UserName = newsData[j].UserName;
                UserPwd = newsData[j].UserPwd;
                Balance = newsData[j].Balance;
                Gender = (newsData[j].Gender==true)? "男":"女";
                Synopsis = newsData[j].Synopsis;
                No_qq = newsData[j].No_qq;
                Phone = newsData[j].Phone;
                Included = newsData[j].Included;
                Sign = newsData[j].Sign;
                RegTime = newsData[j].RegTime;
                var s = RegTime//乱码的时间
                var data1 = s.substring(6, 16)//截取
                var tiems = getLocalTime(data1)//转换
                function getLocalTime(nS) {//时间转换函数
                    return new Date(parseInt(nS) * 1000).toLocaleString().substr(0, 17)
                }
                RegTime = tiems;
                ChengHao = newsData[j].ChengHao;
                
            }
        }


        var strtab = "<table class='layui-table'>"
        strtab += "<tr><td>表单名称</td><td>表单内容</td></tr>";
        strtab += "<tr><td>审核状态</td><td>未审核</td></tr>";
        strtab += "<tr><td>1.唯一识别绑定码</td><td>" + Binding + "</td></tr>";
        strtab += "<tr><td>2.邮箱</td><td>" + UserEmail + "</td></tr>";
        strtab += "<tr><td>3.用户名</td><td>" + UserName + "</td></tr>";
        strtab += "<tr><td>4.密码</td><td>" + UserPwd + "</td></tr>";
        strtab += "<tr><td>5.余额</td><td>" + Balance + "</td></tr>";
        strtab += "<tr><td>6.性别</td><td>" + Gender + "</td></tr>";
        strtab += "<tr><td>7.简介</td><td>" + Synopsis + "</td></tr>";
        strtab += "<tr><td>8.QQ</td><td>" + No_qq + "</td></tr>";
        strtab += "<tr><td>9.手机号码</td><td>" + Phone + "</td></tr>";
        strtab += "<tr><td>10.投稿被收录次数</td><td>" + Included + "</td></tr>";
        strtab += "<tr><td>11.签到状态</td><td>" + Sign + "</td></tr>";
        strtab += "<tr><td>12.注册时间</td><td>" + RegTime + "</td></tr>";
        strtab += "<tr><td>13.称号</td><td>" + ChengHao + "</td></tr>";
        strtab += "</table >"



        layer.tab({
            area: ['600px', '500px'],
            tab: [{
                title: UserEmail + ' 的详细资料',
                content: strtab,

            }]
        });



    })














    
    ////news_State 审核  Stateid
    //$("body").on("click", ".layui-form-switch", function () {  //审核
    //    layer.alert('您点击了审核功能，但此功能正在研发中，后期会添加，敬请谅解。。。', { icon: 6, title: '审核资料' });
    //})


    //审核报名
    form.on('switch(isShow)', function (data) {
        var index = layer.msg('修改中，请稍候', { icon: 16, time: false, shade: 0.8 });

        var ids = $(this).attr("data-id");

        setTimeout(function () {

            $.post("../../Handle.ashx", { "parameter": "Auditing", "id": ids }, function (data) {
                


            for (var i = 0; i < newsData.length; i++) {
                //console.log(newsData[i].ID);
                //console.log($(this).attr("data-id"));
                
                if (newsData[i].ID == ids) {
                        newsData.splice(i, 1);
                        $(this).parents("td").parents("tr").eq(i).hide();
                        newsList(newsData);
                    }
                }


                
                layer.msg(data);
                
                layer.close(index);

            });

        }, 2000);
    })







    $("body").on("click", ".news_del", function () {  //删除
        var _this = $(this);
        layer.confirm('确定删除此信息？', { icon: 3, title: '提示信息' }, function (index) {

            $.post("../../Handle.ashx", { "parameter": "deleteUser", "id": _this.attr("data-id") }, function (data) {
                if (data == "True") {

                    layer.msg('删除成功');

                } else {

                    layer.msg('删除失败');
                }

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

                    var Gender = (currData[i].Gender==true)?"男":"女";

                    dataHtml += '<tr>'
                      + '<td>' + currData[i].UserName + '</td>'
                      + '<td>' + currData[i].UserEmail + '</td>'
                    dataHtml += '<td>' + currData[i].No_qq + '</td>';
                    //}
                    dataHtml += '<td align="left">' + currData[i].Balance + '</td>'
                    //+ '<td><input class="news_State" type="checkbox" name="isShow" lay-skin="switch" Stateid="' + currData[i].ID + '" lay-text="通过|待核"></td>'
                    //+ '<td><input type="checkbox" name="show" lay-skin="switch" lay-text="通过|待核" lay-filter="isShow" data-id=\'' + currData[i].ID + '\'></td>'
                    + '<td>' + currData[i].Binding + '</td>'
                    + '<td>' + Gender + '</td>'
                    //+ '<td>' + currData[i].Pseudonym + '</td>'
                    + '<td><a data-id="' + currData[i].ID + '" class="layui-btn layui-btn-mini news_edit"><i class="iconfont icon-edit"></i> 查看详细</a>'
                    //+ '<a class="layui-btn layui-btn-danger layui-btn-mini news_del" data-id="' + currData[i].ID + '"><i class="layui-icon">&#xe640;</i> 删除</a>'
                    + '</td>'
                    + '</tr>';

                    //alert(dataHtml);
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
