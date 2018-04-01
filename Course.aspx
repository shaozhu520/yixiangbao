<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="vip20170612.Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title><%=totitle() %> - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="layui/css/layui.css" />
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/Course.css" />
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
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">当前位置：<i class="icon-index layui-icon">&#xe68e;</i><span><a href="javascript:;">首页</a></span><span class="not-margin">-</span><span><a href="javascript:;">教程软件<span>-</span></a></span><%=totitle() %><span></span></div>
                </div>
            </div>
            <!--当前位置结束-->

    <!--教程内容开始-->        
    
    <div class="contents  container">
        
        <div class="row contents-main ">
            <!--标题-->
            <h3 class="contents-main-title col-lg-12 col-md-12 col-sm-12 col-xs-12"><i class="layui-icon">&#xe641;</i> <%=totitle() %></h3>

            <!--详细-->
            <div class="contents-main-detailed col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="detailed col-lg-4 col-md-4 visible-lg visible-md">
                    <img src="<%=toThumbnail() %>" alt="" />
                </div>
                <ul class="xingxi col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>教程大小：</span><span><%=toTsize() %>M</span></li>
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>教程语言：</span><span>简体中文</span></li>
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>更新时间：</span><span><%=toNewTime() %></span></li>
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>教程类别：</span><span>技术教程</span></li>
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>授权方式：</span><span>共享版</span></li>
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>运行环境：</span><span>/WinAll/Android/iOS</span></li>
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>软件等级：</span><span><img src="img/s<%=ToXingji() %>.gif" alt="" /></span></li>
                    <li class="col-lg-6 col-md-6 col-sm-6 col-xs-12"><span>下载统计：</span><span><%=xiazaiSum() %></span></li>
                    <li class="col-lg-6 xzgk col-md-6  hidden-sm hidden-xs"><a href="javascript:;">立即下载/观看</a></li>
                </ul>
                <div class="btnlimk col-lg-2 col-md-2 visible-lg visible-md">
                    <div class="btnlimk-com"><span class="btnlimk-icon fl"></span><a class="fl" href="javascript:;">回到首页</a></div>
                    <div class="btnlimk-com"><span class="btnlimk-icon fl"></span><a class="fl" href="javascript:;">收藏教程</a></div>
                    <div class="btnlimk-com"><span class="btnlimk-icon fl"></span><a class="fl" href="javascript:;">下载教程</a></div>
                    <div class="btnlimk-com"><span class="btnlimk-icon fl"></span><a class="fl" href="javascript:;">网友评论</a></div>
                </div>
            </div>


            <!--简介-->
            <div class="contents-main-abstract col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <fieldset class="layui-elem-field">
                    <legend>教程简介</legend>
                    <div class="layui-field-box">
                        
                        <%=tojianjie() %>
                    </div>
                </fieldset>   
            </div>
            <!--下载和排行榜-->
            <div class="contents-main-Downloads col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <!--下载和头像-->
                <div class="xiazai col-lg-8 col-md-8 col-sm-12 col-xs-12">
                    <div class="xiazai-top col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <p class="col-lg-12 col-md-12 col-sm-12 col-xs-12 xzbt">下载地址</p>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 xzbtn"><i class="fl layui-icon">&#xe61a;</i><a class="fl" target="_blank" href="<%=xiazaiurl() %>">本地下载1</a></div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 xzbtn"><i class="fl layui-icon">&#xe61a;</i><a class="fl" target="_blank" href="<%=xiazaiurl() %>">本地下载2</a></div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 xzbtn"><i class="fl layui-icon">&#xe61a;</i><a class="fl" target="_blank" href="<%=xiazaiurl() %>">备用下载</a></div>
                    </div>
                    <!--作者信息-->
                    <div class="xiazai-tx col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <p class="col-lg-12 col-md-12 col-sm-12 col-xs-12 xiazai-tx-bt">作者信息</p>
                        <div class="xiazai-tx-img col-lg-6 col-md-6 col-sm-6 col-xs-6 fl">
                            <img src="img/user/<%=touxiang() %>.png" alt="" />
                        </div>
                        <!--
                        <div class="xiazai-tx-text col-lg-6 col-md-6 col-sm-6 col-xs-6 fr">
                            <h4 class="neicheng">初心 <i class="layui-icon male">&#xe662;</i><i class="layui-icon female">&#xe661;</i></h4>
                            <a class="chakanzz col-sm-8 col-xs-12" href="javascript:;">查看作者</a>
                        </div>
                        -->
                        <%=ToUsername() %>
                    </div>
                </div>
                 <!--排行榜-->
                <div class="paihang col-lg-4 col-md-4 col-sm-12 col-xs-12">
                    <h2 class="col-lg-12 col-md-12 col-sm-12 col-xs-12 xzbt">本周排行</h2>
                    <ul class="paihang-box col-lg-12 col-md-12 com-sm-12 col-xs-12">
                       <%-- <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>1</span><a href="javascript:;">搭建球战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>2</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>3</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>4</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>5</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>6</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>7</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>8</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>9</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>
                        <li class="col-lg-12 col-md-12 com-sm-12 col-xs-12"><span>10</span><a href="javascript:;">搭建球球大作战代点棒棒糖网站</a></li>--%>
                        <%=tjgethtml() %>
                    </ul>
                </div>
            </div>
        </div>
        
    </div>
    <!--教程内容结束-->

    <!--footer-->
    <div class="footer">
        <div class="container">
            <div class="footer-con row">
                <div class="fl footer-logo col-lg-3 visible-lg">
                    <img src="img/footerlogo.png" alt="" />
                </div>
                <div class="fl foote-link col-lg-9 col-md-12">
                    <ul>
                        <li><a href="javascript:;">关于我们</a></li>
                        <li><a href="javascript:;">广告购买</a></li>
                        <li><a href="javascript:;">投稿联系</a></li>
                        <li><a href="javascript:;">发展历程</a></li>
                        <li><a href="javascript:;">导航天下</a></li>
                        <li><a href="javascript:;">站长统计</a></li>
                        <li><a href="javascript:;">Copyright Qqguoji.Com 国际网络. All Rights Reserved.渝ICP备14000892号-1</a></li>
                    </ul>
                    
                
                </div>    
            </div>
        </div>    
    </div>
    
    <!--footer-->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
