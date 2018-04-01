<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="vip20170612.user.js.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title><%=tonicheng() %>的个人中心 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="../layui/css/layui.css" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/user_index.css" />
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
                <!--头像和余额开始-->
                <div class="balancebox">
                    <div class="balancebox-l col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <div class="HeadPortrait">
                            <div></div>
                            <img class="tximg" src="../img/userPic.png" alt="" />
                            <p><img class="v-icon" src="../img/viplogo.png" alt="" /><%=tonicheng() %></p>
                        </div>
                    </div>
                    <div class="balancebox-r col-lg-6 coll-md-6 col-sm-6 col-xs-6">
                        <div class="balance">
                            <p class="balance-tex1">账户余额<span class="balance-icon1 glyphicon glyphicon-yen"></span></p>
                            <p class="balance-tex2"><span class="balance-integer"><%=toBalance() %></span><span class="balance-decimal">.0</span>Y币</p>
                            <a class="Recharge-bnt" href="javascript:;">充值</a>
                        </div>
                    </div>
                </div>
                <!--头像和余额结束-->

                <!--详细资料开始-->
                <div class="datum-box col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <ul class="datum">
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12 Reminder">请如实填写资料信息，我们承诺不会泄露任何关于您的资料，以下信息只为小编发货商品或找回密码等所用</li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">签到状态</span><a class="fr Sign-btn" href="javascript:;"><%=toqiandao() %></a></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">我的昵称</span><span class="fr"><%=tonicheng() %></span></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">我的性别</span><%=toGender() %></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">我的简介</span><span class="fr"><%=tojianjie() %></span></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">邮箱号码</span><span class="fr"><%=toEmail() %></span></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">Q&nbsp;Q&nbsp;账号</span><%=toQQ() %></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">手机号码</span><a class="fr" href="javascript:;">立即绑定</a></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">投稿被收录次数</span><span class="fr">0次</span></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">注册时间</span><span class="fr"><%=toRegTime() %></span></li>
                        <li class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="fl">个人主页</span><a href="javascript:;" class="fr PersonalCenter">/user/person.html?uid=971d4295584f78874262c2ae673ad245</a></li>
                        <li class="modify-btn col-lg-12 col-md-12 col-sm-12 col-xs-12"><a class="" href="javascript:;">修改资料</a></li>
                    </ul>
                </div>
                 <!--详细资料结束-->
            </div>
        </div>
    </div>

    <script src="../layui/layui.js" charset="utf-8"></script>
    
    <script>
        layui.use(['laypage', 'layer'], function () {
            var laypage = layui.laypage
            , layer = layui.layer;

            //自定义每页条数的选择项
            laypage.render({
                elem: 'demo11'
              , count: 1000
              , limit: 100
              , limits: [100, 300, 500]
            });

        });
    </script>



    <!--footer-->
    <!--#include file="../include/footer.html"-->
    <!--footer-->

    <script src="../bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
