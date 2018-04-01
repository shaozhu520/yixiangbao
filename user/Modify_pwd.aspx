<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify_pwd.aspx.cs" Inherits="vip20170612.user.Modify_pwd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>修改密码 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="../layui/css/layui.css" />
    <link rel="stylesheet" href="/layer/mobile/need/layer.css" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/Modify_pwd.css" />
    <link rel="stylesheet" href="../css/main.css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/base.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/index.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>

    <!--头部-->   
    <!--#include file="../include/header.html"-->

    <!--当前位置-->
    <div class="currentLocation  container">
        <div class="currentLocation-con row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">当前位置：<i class="icon-index layui-icon">&#xe68e;</i><span><a href="javascript:;">首页</a></span><span class="not-margin">-</span><span><a href="javascript:;">个人中心</a></span></div>
        </div>
    </div>
    <!--当前位置结束-->

    <div class="userbox container">
        <div class="userbox-con row">
            <!--左侧资料开始-->
            <div class="userbox-con-l col-lg-2 col-md-2 col-sm-12 col-xs-12">
                <!--#include file="include/leftNav.html"-->
            </div>
            <!--左侧资料结束-->

            <!--右侧资料开始-->
            <div class="userbox-con-r col-lg-10 col-md-10 col-sm-12 col-xs-12">
                <!--充值--> 
                <div class="rechargebox layui-tab layui-tab-brief col-lg-6 col-md-6 col-sm-10 col-xs-12" lay-filter="docDemoTabBrief">
                    <form class="layui-form changePwd">
		                <div style="margin:0 0 15px 110px;color:#f00;">如果出现问题请联系系统管理员，新密码必须输入正确才能修改</div>
		                
		                <div class="layui-form-item">
		                    <label class="layui-form-label">旧密码</label>
		                    <div class="layui-input-block">
		    	                <input type="password" value="" placeholder="请输入旧密码" lay-verify="required|oldPwd" class="layui-input jpwd pwd">
		                    </div>
		                </div>
		                <div class="layui-form-item">
		                    <label class="layui-form-label">新密码</label>
		                    <div class="layui-input-block">
		    	                <input type="password" value="" placeholder="请输入新密码" lay-verify="required|newPwd" id="oldPwd" class="layui-input pwd">
		                    </div>
		                </div>
		                
		                <div class="layui-form-item">
		                    <div class="layui-input-block">
		    	                <button class="layui-btn changePwdBTN" lay-submit="" lay-filter="changePwd">立即修改</button>
				                <button type="reset" class="layui-btn layui-btn-primary">重置</button>
		                    </div>
		                </div>
	                </form>

                        
                    
                </div> 
            </div>
        </div>
    </div>

    <script src="../layui/layui.js" charset="utf-8"></script>
    <script src="../layui/layui.js" charset="utf-8"></script>
    

    <!--footer-->
    <!--#include file="../include/footer.html"-->
    <!--footer-->
    <script src="../layer/layer.js"></script>
    <script src="js/changpwd.js" type="text/javascript" charset="utf-8"></script>
    <script src="../bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
