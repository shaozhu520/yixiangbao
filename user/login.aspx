<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="vip20170612.user.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>用户登录 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="../layui/css/layui.css" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/login.css" />
    <link rel="stylesheet" href="../css/main.css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/login.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    
        <div id="login" class="container">
        <div class="row">
            <img src="../img/footer_bar_logo.png" class="beijing hidden-xs" />
            <form class="login-main-wai layui-form layui-form-pane col-lg-5 col-md-6 col-sm-6 col-xs-12 fr " action="">
                <div class="login-main">
                    <img class="loginbox-top-tu visible-lg visible-md" src="../img/tou.png" alt="" />
                    <img class=" left_hand-tu visible-lg visible-md" src="../img/left_hand.png" alt="" />
                    <img class=" right_hand-tu visible-lg visible-md" src="../img/right_hand.png" alt="" />
                    <div class="layui-form-item">
                        <label class="layui-form-label "><span class="  glyphicon glyphicon-user" aria-hidden="true"></span></label>
                            <div class="layui-input-block">
                                <input type="Email" name="mail" lay-verify="required" placeholder="请输入账号" autocomplete="off" class="layui-input Email" />
                            </div>
                    </div>
                            
                    <div class="layui-form-item">
                        <label class="layui-form-label"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></label>
                        <div class="layui-input-block">
                            <input type="password" name="mail" lay-verify="required" placeholder="请输入登录密码" autocomplete="off" class="layui-input pwd">
                        </div>
                    </div>

                    <div class="layui-form-item">
                            <div class="layui-inline fl kuaijiedl">
                                <i class="inco-qq"></i><i class="inco-wx"></i><i class="inco-wb"></i> 
                            </div>
                            <div class="layui-inline fr r-link">
                                <a href="reg.aspx">我要注册</a>
                                <a href="javascript:;">找回密码</a>
                            </div>
                        </div>
                            
                    <div class="layui-form-item ">
                        <button  id="tologin" class="layui-btn layui-block w-100" lay-submit="" lay-filter="demo2">登录</button>
                        
                    </div>
                </div>         
            </form>
        </div>
    </div>
                
    <script src="../bootstrap/js/bootstrap.min.js"></script>         
    <script src="../layui/layui.js" charset="utf-8"></script>
                
    <script>
        layui.use(['form', 'layedit', 'laydate'], function () {
            var form = layui.form
            , layer = layui.layer
            , layedit = layui.layedit
            , laydate = layui.laydate;



            //监听提交
            form.on('submit(demo1)', function (data) {
                layer.alert(JSON.stringify(data.field), {
                    title: '最终的提交信息'
                })
                return false;
            });


        });
    </script>
    
</body>
</html>
