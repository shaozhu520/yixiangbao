layui.config({
	base : "js/"
}).use(['form','layer','jquery','laypage'],function(){
	var form = layui.form(),
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		laypage = layui.laypage,
		$ = layui.jquery;





    //执行加载页面数据
	Load();

    //加载页面函数
	function Load() {

	    
	    $.post("../../Handle.ashx", { "parameter": "Links" }, function (data) {

	        //data.Data[index].ID

	        var data = JSON.parse(data);

	        var newArray = [];

	        //转换
	        newsData = data.Data;

	        //正常加载信息
	        //执行加载数据的方法
	        linksList(newsData);

	    });

	};






	//添加友情链接
	$(".linksAdd_btn").click(function(){
		var index = layui.layer.open({
			title : "添加友情链接",
			type : 2,
			content : "linksAdd.html",
			success : function(layero, index){
				layui.layer.tips('点击此处返回友情链接列表', '.layui-layer-setwin .layui-layer-close', {
					tips: 3
				});
			}
		})
		//改变窗口大小时，重置弹窗的高度，防止超出可视区域（如F12调出debug的操作）
		$(window).resize(function(){
			layui.layer.full(index);
		})
		layui.layer.full(index);
	})





	


	


	//操作
	$("body").on("click",".links_edit",function(){  //修改

	    var webID, webUrl, webName, webEmail,sort;

	    var Eq = $(this).parent("td").parent("tr").index();

	    Eq = Eq + 1;

	    //var Eq = 0;

	    sort = $("tr").eq(Eq).find(".sort").text();

	    webID = $("tr").eq(Eq).find(".webid").text();

	    webUrl = $("tr").eq(Eq).find(".webUrl").text();

	    webName = $("tr").eq(Eq).find(".webName").text();

	    webEmail = $("tr").eq(Eq).find(".ContactEMail").text();
	    //console.log(Eq);
	    //console.log(webID);
	    //console.log(webUrl);
	    //console.log(webName);
	    //console.log(webEmail);

	    //revise

	    $.post("../../Handle.ashx", { "parameter": "ReviseLinks", "webID": webID, "webUrl": webUrl, "webName": webName, "webEmail": webEmail, "sort": sort }, function (data) {


	        //layer.alert('您点击了友情链接编辑按钮，但系统正在开发中，所以暂时不存在编辑内容，后期会添加，敬请谅解。。。', { icon: 6, title: '友链编辑' });
	        
	        var data = JSON.parse(data);

	        layer.msg(data.Info);
	    });



	    
	})



	$("body").on("click",".links_del",function(){  //删除
		var _this = $(this);
		layer.confirm('确定删除此信息？', { icon: 3, title: '提示信息' }, function (index) {


		    $.post("../../Handle.ashx", { "parameter": "deleteLinks", "id": _this.attr("data-id") }, function (data) {

		        var data = JSON.parse(data);

		        layer.msg(data.Info);


		        //_this.parents("tr").remove();
		        for (var i = 0; i < linksData.length; i++) {
		            if (linksData[i].webID == _this.attr("data-id")) {
		                linksData.splice(i, 1);
		                linksList(linksData);
		            }
		        }
		        layer.close(index);

		    });






			
		});
	})


	function linksList(that){
		//渲染数据
		function renderDate(data,curr){
			var dataHtml = '';
			if(!that){
				currData = linksData.concat().splice(curr*nums-nums, nums);
			}else{
				currData = that.concat().splice(curr*nums-nums, nums);
			}
			if(currData.length != 0){
			    for (var i = 0; i < currData.length; i++) {

			        var s = currData[i].tjtime//乱码的时间

			        var data1 = s.substring(6, 16)//截取

			        var tiems = getLocalTime(data1)//转换
			        function getLocalTime(nS) {//时间转换函数
			            return new Date(parseInt(nS) * 1000).toLocaleString().substr(0, 17)

			        }

				    dataHtml += '<tr>'
                    + '<td class="webid">' + currData[i].ID + '</td>'
                    + '<td class="webUrl" contenteditable="true">' + currData[i].URLLink + '</td>'
                    + '<td class="webName"  align="left" contenteditable="true">' + currData[i].Name + '</td>'
                    + '<td class="sort" contenteditable="true">' + currData[i].SerialNumber + '</td>'
			    	+ '<td class="ContactEMail" contenteditable="true">' + currData[i].ContactEMail + '</td>'
			    	+ '<td>' + tiems + '</td>'//时间
                    //+ '<td>' + currData[i].Switch + '</td>'//启用 要改
			    	+'<td>'
					+  '<a class="layui-btn layui-btn-mini links_edit"><i class="iconfont icon-edit"></i> 修改</a>'
					+ '<a class="layui-btn layui-btn-danger layui-btn-mini links_del" data-id="' + data[i].ID + '"><i class="layui-icon">&#xe640;</i> 删除</a>'
			        +'</td>'
			    	+'</tr>';
				}
			}else{
				dataHtml = '<tr><td colspan="7">暂无数据</td></tr>';
			}
		    return dataHtml;
		}



		//分页
		var nums = 8; //每页出现的数据量
		if(that){
			linksData = that;
		}
		laypage({
			cont : "page",
			pages : Math.ceil(linksData.length/nums),
			jump : function(obj){
				$(".links_content").html(renderDate(linksData,obj.curr));
				$('.links_list thead input[type="checkbox"]').prop("checked",false);
		    	form.render();
			}
		})
	}
})
