<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RNewsM.aspx.cs" Inherits="vip20170612.RNewsM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/index.css" />
    <link href="css/RNewsM.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.11.0.js"></script>
    <script type="text/javascript" src="js/Impure.js"></script>
    <script type="text/javascript" src="js/RNewsM.js"></script>
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

    <div class="RnewsM clearfix">
        <div class="RnewsM-content">

            <!--二级导航-->
            <div class="nav_er">
                <img src="img/sy.png" alt="" />
                <a href="index.aspx">首页</a>&gt;
                <a id="son" href="Article.aspx">文章中心</a>
            </div>
            <div class="content-main">
                <div class="content-main-l">
                    <div class="content-main-l-title">
                        <h2 id="Titles"></h2>
                        <div class="post-meta">
                            <span class="pauthor">
                                <i></i>
                                <a  href="javascript:;"><span id="Pseudonym"></span></a>
                            </span>
                            <span class="ptime">
                                <i></i>
                                <a id="CreatedTime" href="javascript:;"></a>
                            </span>


                            <span class="pcate">
                                <i></i>
                                <a id="NewsClass" href="javascript:;"></a>
                            </span>

                            <%--<span class="pview" id="ViewCount">--%>
                            <span class="pview">
                                <i></i>
                                <span id="ViewCount"></span>
                            </span>

                        </div>
                    </div>
                    <div class="content-main-l-txt" id="Texts"></div>
                </div>
                <%--<div class="content-main-r"></div>--%>
            </div>
        </div>
    </div>




    <!--banner2-->
    <%--<div class="barrers">
        <div class="SixLaws-con-b banner2 banner-center">
            <div class="SixLaws-con-b-banner banner2">
                <a href="javascript:;"><img src="img/banner1.gif" alt="" /></a>
            </div>
        </div>
    </div>--%>

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
