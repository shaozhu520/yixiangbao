<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HeadPortrait.aspx.cs" Inherits="vip20170612.HeadPortrait" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>唯美头像 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="layui/css/layui.css" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/articlesList.css" />
    <link rel="stylesheet" href="css/main.css" />
    <script src="js/jquery-1.11.0.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/base.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/HeadPortrait.js" type="text/javascript" charset="utf-8"></script>
    
</head>
<body>
    <form id="form1" runat="server">
     <!--头部-->   
    <!--#include file="include/header.html"-->

    <!--当前位置-->
    <div class="currentLocation  container">
        <div class="currentLocation-con row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">当前位置：<i class="icon-index layui-icon">&#xe68e;</i><span><a href="javascript:;">首页</a></span><span class="not-margin">-</span><span><a href="javascript:;">唯美头像</a></span></div>
        </div>
    </div>
    <!--当前位置结束-->

    <!--文章开始-->
    <div class="Articles container">
        <div class="Articles-con row">
            <div class="Articles-con-l col-lg-8 col-md-8 col-sm-12 col-xs-12">
                <div class="Articles-con-l-title col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <h2><i class="Articles-con-l-title-icon layui-icon">&#xe609;</i>唯美头像</h2>
                </div>
                <ul class="Articles-con-l-main col-lg-12 col-md-12 col-sm-12 col-xs-12" sum="<%=GetPageCount() %>">
                   
                    <%=BindRews() %>
                   
                </ul>
                <div id="demo5"></div>
            </div>
            <div class="Articles-con-r col-lg-4 col-md-4 hidden-sm hidden-xs">
                <div class="ranking">
                    <div class="Articles-con-r-title">
                         <h2>软件教程列表</h2>
                    </div>
                    <ul class="ranking-main">
                       <%=tjgethtml() %>
                    </ul>
                    
                </div>
                <div class="ranking">
                    <div class="Articles-con-r-title">
                         <h2>软件教程列表</h2>
                    </div>
                    <ul class="ranking-main">
                        
                        <%=tjgethtml() %>
                    </ul>
                    
                </div>
                
               
            </div>
        </div>
    </div>
    <!--文章结束--> 
    <script src="layui/layui.js" charset="utf-8"></script>
    <script src="js/touxiang_page.js" type="text/javascript" charset="utf-8"></script>
    



    <!--footer-->
    <!--#include file="include/footer.html"-->
    <!--footer-->

    <script src="bootstrap/js/bootstrap.min.js"></script>
    </form>
</body>
</html>

