layui.config({
    base: "js/"
}).use(['form', 'layer', 'jquery', 'laypage'], function () {
    var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage,
		$ = layui.jquery;

    //加载页面数据
    var usersData = '';

    $.post("../../Handle.ashx", { "parameter": "Query_admin" }, function (data) {//查询管理员列表

        var data = JSON.parse(data);//将json 转换成 对象

        //alert(data.Success);
        usersData = data.Data;
        //执行加载数据的方法
        usersList();


    });




    //添加管理员
    $(".usersAdd_btn").click(function () {
        var index = layui.layer.open({
            title: "添加管理员",
            type: 2,
            content: "addAdminUser.html",
            success: function (layero, index) {
                layui.layer.tips('点击此处返回管理员列表', '.layui-layer-setwin .layui-layer-close', {
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



    




    $("body").on("click", ".users_del", function () {  //删除
        var Name = $.cookie("Token-Name");//获取

        if (Name != "admin") {//前端后验证 后端也写了 不是admin 删不了！
            layer.msg("权限不足");
        }
        else {
            var _this = $(this);
            layer.confirm('确定删除此管理？', { icon: 3, title: '提示信息' }, function (index) {
                var ID = _this.attr("data-id");

                $.post("../../Handle.ashx", { "parameter": "del_admin", "adminID": ID }, function (data) {//删除指定管理员

                    var data = JSON.parse(data);

                    layer.msg(data.Info);

                    _this.parents("tr").remove();
                });

            });

        }

    })




    function usersList() {
        //渲染数据
        function renderDate(data, curr) {
            var dataHtml = '';
            currData = usersData.concat().splice(curr * nums - nums, nums);
            if (currData.length != 0) {
                for (var i = 0; i < currData.length; i++) {

                    //处理下时间
                    var s = currData[i].LGtime;//乱码的时间

                    var data1 = s.substring(6, 16);//截取

                    var tiems = getLocalTime(data1)//转换
                    function getLocalTime(nS) {//时间转换函数
                        return new Date(parseInt(nS) * 1000).toLocaleString().substr(0, 17)

                    }

                    var Sex = (currData[i].Sex == true) ? "男" : "女";

                    dataHtml += '<tr>'

			    	+ '<td>' + currData[i].admin_Name + '</td>'
			    	+ '<td>' + currData[i].Contact + '</td>'
			    	+ '<td>' + Sex + '</td>'
			    	+ '<td>' + currData[i].Status + '</td>'
			    	+ '<td>' + tiems + '</td>'
			    	+ '<td>' + currData[i].state + '</td>'
			    	+ '<td>'
					+ '<a class="layui-btn layui-btn-danger layui-btn-mini users_del" data-id="' + currData[i].ID + '"><i class="layui-icon">&#xe640;</i> 删除</a>'
                    //+ '<input type="checkbox" class="users_edit" name="zzz" lay-skin="switch" lay-text="启用|禁用">'
                    //+ '<input type="checkbox" name="show" lay-skin="switch" lay-text="启用|禁用" lay-filter="isShow"' + currData[i].isShow + '>'
			        + '</td>'


                    

			    	+ '</tr>';
                }
            } else {
                dataHtml = '<tr><td colspan="8">暂无数据</td></tr>';
            }
            return dataHtml;
        }

        //分页
        var nums = 13; //每页出现的数据量
        laypage({
            cont: "page",
            pages: Math.ceil(usersData.length / nums),
            jump: function (obj) {
                $(".users_content").html(renderDate(usersData, obj.curr));
                $('.users_list thead input[type="checkbox"]').prop("checked", false);
                form.render();
            }
        })
    }

})