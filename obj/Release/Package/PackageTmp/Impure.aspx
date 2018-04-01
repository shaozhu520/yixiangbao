<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Impure.aspx.cs" Inherits="vip20170612.Impure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>不净观-星火传承</title>
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/index.css" />
    <link href="css/Buddhism.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.11.0.js"></script>
    <script type="text/javascript" src="js/Impure.js"></script>
</head>
<body>
    <!--头部-->
    <div class="head">
        <div class="head-con">
            <div class="h_login">
                <a href="javascript:;">登陆</a>
                <span></span>
                <a href="javascript:;">注册</a>
            </div>
        </div>
    </div>


    <!--logo-->
    <div class="jb_top_k_j">
        <div class="jb_top_nr_k_j">
            <div class="logo">
                <a href="javascript:;">
                    <img src="img/logo.png" alt="" />
                </a>
                <!--<a href="javascript:;">logo</a>-->
            </div>
            <div class="banners">
                <a href="javascript:;">
                    <img src="img/banner1.gif" alt="" /></a>
            </div>
        </div>
    </div>

    <!--导航-->
    <div class="nav_k">
        <ul class="list">
            <script type="text/javascript" src="js/nav.js"></script>
        </ul>
    </div>




    <%--<!--banner2-->
    <div class="barrers">
        <div class="SixLaws-con-b banner2 banner-center">
            <div class="SixLaws-con-b-banner banner2">
                <a href="javascript:;"><img src="img/banner1.gif" alt="" /></a>
            </div>
        </div>
    </div>--%>

    <!-- 分页内容-->
    <div class="Content-Main-tetx">
        <!-- 头-->
        <div class="Content-Main">
            <div class="nav_s">
                <div class="nav_s-title">
                    <img src="img/sy.png" alt="" /><a href="index.aspx">首页</a> &gt; <a href="Impure.aspx">不净观</a>
                </div>
            </div>
            <div class="Content-Main-s">
                <div class="search">
                    <div class="search-title">
                        <p>不净观</p>
                    </div>
                    
                    <div class="search-main">
                        <input type="text" class="inputs"  />
                        <a id="search" href="javascript:;">栏目下搜索</a>
                        <%--<a href="javascript:;">全站搜索</a>--%>
                    </div>
                </div>
            </div>
        </div>
        <!--列表 -->
        <div class="list-main">
            <%=BindRews() %>

            <div class="paging">
                <%=GetPageHtml() %>
            </div>
        </div>

    </div>










    <!--footer-->
    <div class="footer">

        <div class="footer-content">
            <div class="footer-content-div1">
                <div class="inforitem">
                    <ul>
                        <li>友情链接</li>
                        <li><a target="_blank" href="javascript:;">星火传承</a></li>
                        <li><a target="_blank" href="javascript:;">星火传承</a></li>
                        <li><a target="_blank" href="javascript:;">星火传承</a></li>
                        <li><a target="_blank" href="javascript:;">星火传承</a></li>
                    </ul>
                </div>
                <div class="inforitem-last">
                    <div class="contactinfor">
                        <div class="d-wx">
                            <img src="img/wx1.png" alt="Alternate Text" />

                        </div>
                        <div class="d-wx">
                            <img src="img/wx2.png" alt="Alternate Text" />

                        </div>
                        <div class="d-wx">
                            <img src="img/wx3.png" alt="Alternate Text" />
                            <p>扫一扫，关注我们</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer-content-div2">
                Copyright 星火传承公益 2016-2017 Edu Inc.<a href="javascript:;"> 赣ICP备17004253号-2</a>
            </div>


        </div>

    </div>

</body>
</html>
