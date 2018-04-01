<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articleContent.aspx.cs" Inherits="vip20170612.articleContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title><%=toTitle() %> - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="layui/css/layui.css" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/articleContent.css" />
    <link rel="stylesheet" href="css/main.css" />
    <script src="js/jquery-1.11.0.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/base.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/index.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--头部-->   
    <!--#include file="include/header.html"-->
       
        
            <!--当前位置-->
            <div class="currentLocation container">
                <div class="currentLocation-con row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">当前位置：<i class="icon-index layui-icon">&#xe68e;</i><span><a href="javascript:;">首页</a></span><span class="not-margin">-</span><span><a href="javascript:;"><%=toclass() %><span>-</span></a></span><%=toTitle() %><span></span></div>
                </div>
            </div>
            <!--当前位置结束-->

    <div class="contents  container">
        <div class="contents-main row">
            <div class="contents-main-l col-lg-9 col-md-9 col-sm-12 col-xs-12">
                    <div class="contents-main-l-head col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <h2 class="col-lg-12 col-sm-12 col-xs-12"><%=toTitle() %></h2>
                        <div class="wzxx col-lg-12 col-sm-12 col-xs-12">
                            <%= toTime() %>
                        </div>
                    </div>
                    <div class="contents-main-text col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <%=toCon() %>
                    </div>
            </div>
            <div class="contents-main-r col-lg-3 col-md-3 col-sm-12 col-xs-12">
                <div class="author col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="titles col-lg-12 col-md-12 col-sm-12 col-xs-12"><i class="layui-icon">&#xe612;</i>本文章的作者</div>
                    <div class="author-img col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <img src="img/user/<%=zuozhe() %>.png" alt="" />
                    </div>
                </div>
                <div class="Rankings col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="titles col-lg-12 col-md-12 col-sm-12 col-xs-12"><i class="layui-icon">&#xe62c;</i>本周阅读排行</div>
                    <ul class="Rankings-list col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                    </ul>
                </div>
                <div class="Recommend col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="titles col-lg-12 col-md-12 col-sm-12 col-xs-12"><i class="layui-icon">&#xe62d;</i>文章推荐</div>
                    <ul class="Rankings-list col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                        <li><a class="col-lg-12 col-md-12 col-sm-12 col-xs-12" href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>


    <!--footer-->
    <!--#include file="include/footer.html"-->
    <!--footer-->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
