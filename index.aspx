<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="vip20170612.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>易线报 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="layui/css/layui.css" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/index.css" />
    <link rel="stylesheet" href="css/main.css" />
    <script src="js/jquery-1.11.0.js" type="text/javascript" charset="utf-8"></script>
    <%--<script src="js/Verification.js" type="text/javascript" charset="utf-8"></script>--%>
    <script src="js/base.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/index.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--头部-->   
        <!--#include file="include/header.html"-->
       
    <!--
    <iframe id="header" width="100%"  frameborder=0 scrolling=auto src="header.html"></iframe>
    -->
    

    <!--投稿排行榜开始-->
    <div class="RankingList container">
        <div class="RankingList-con row">
            <div class="RankingList-con-icon-l"></div>
            <div class="RankingList-con-icon-r"></div>
            <ul class=" paihang">
            
                <%=phbgethtml() %>

             </ul>
        </div>
    </div>
    <!--投稿排行榜结束-->

    <!--今日更新开始-->
    
    <div class="UpdateToday container">
        <div class="UpdateToday-con row">
            <div class="UpdateToday-con-l col-lg-8 col-md-8 col-sm-12 col-xs-12">
                <div class="UpdateToday-con-l-title">
                    <div class="title-text fl"><span class="layui-icon">&#xe637;</span>今日更新</div>
                    <div class="title-More fr">更多</div>
                </div>

                <div class="Article">
                    <!--<ul>
                        <li>
                            <a href="javascript:;" class="Article-HeadPortrait"><img src="img/default_head.png" alt="" /></a>
                            <div class="Article-title"><a href="javascript:;">每日走心精选淘宝天猫无门槛优惠券</a></div>
                            <div class="Article-Date">11-29</div>
                        </li>
                    </ul>
                    -->
                    <%=getNewslist() %>
                    
                </div>
            </div>
            
            <div class="UpdateToday-con-r col-lg-4 col-md-4 hidden-sm hidden-xs">
                <div class="login-box">
                    <a class="yzbtn1" id="fillet" href="/user/login.aspx">立即登录</a>
                    <a class="yzbtn2 secedeBtn" href="/user/reg.aspx">注册/加入我们</a>

                    <p><span></span><span>拥有账号特权</span><span></span></p>
                </div>
                <div class="service">
                	<ul>
                		<li><i></i><span>上传教程</span></li>
                		<li><i></i><span>投递文章</span></li>
                		<li><i></i><span>积分兑换</span></li>
                		<li><i></i><span>每日签到</span></li>
                	</ul>
                </div>
                <div class="privilege">
                	<ul>
                		<li>
                			<i></i>
                			<p>过滤部分广告</p>
                		</li>
                		<li>
                			<i></i>
                			<p>免费领赞</p>
                		</li>
                		<li>
                			<i></i>
                			<p>投稿优先审核</p>
                		</li>
                		<li>
                			<i></i>
                			<p>下载提速</p>
                		</li>
                	</ul>
                </div>
            </div>
        </div>
    </div>
    <!--今日更新结束-->
    
    <!--banner开始-->
    <div class="banner container visible-lg">
    	<div class="banner-con row">
            <div class="col-lg-4 "><img  src="img/index_2_1.png" alt="" /></div>
            <div class="col-lg-4 "><img src="img/index_2_2.png" alt="" /></div>
            <div class="col-lg-4 "><img src="img/index_2_3.png" alt="" /></div>
            <!--
            <img class="col-lg-4"  src="img/index_2_1.png" alt="" />
            <img class="col-lg-4"  src="img/index_2_1.png" alt="" />
            <img class="col-lg-4"  src="img/index_2_1.png" alt="" />
            -->
            
    	</div>
    </div>
    <!--banner结束-->
    	
    <div class="ClassificationList container">
    	<div class="ClassificationList-con row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                <div class="List ">
                    <div class="title">
                        <i></i><a href="javascript:;">教程软件</a><i></i>
                    </div>
                    <div class="ClassificationList-List-main">
                        <ul>
                           <%=jiaochengGetHtnl() %>
                        </ul>
                    </div>
                </div>
            </div>    
    		<div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                <div class="List ">
                    <div class="title">
                        <i></i><a href="javascript:;">线报活动</a><i></i>
                    </div>
                    <div class="ClassificationList-List-main">
                        <ul>
                            <%=xbGetHtnl() %>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                <div class="List ">
                    <div class="title">
                        <i></i><a href="javascript:;">其他文章</a><i></i>
                    </div>
                    <div class="ClassificationList-List-main">
                        <ul>
                           <%= wzGetHtnl() %>
                        </ul>
                    </div>
                </div>
            </div>    
    	</div>
    </div>
    
    <!--banner2开始-->
    <div class="banner container visible-lg visible-md ">
    	<div class="banner-con banner2 row">
    		<div class="penguin"></div>
    		<div class="banner2-text col-lg-3 col-md-2">
    			嗨!我是小义,很高兴见到你 给你送了几张优惠券,点击右边福袋抽取吧!
    			<i></i>
    		</div>
    		<ul class="RedEnvelopes col-lg-7 col-md-9">
    			<li></li>
    			<li></li>
    			<li></li>
    			<li></li>
    		</ul>
    	</div>
    </div>
    <!--banner2结束-->
    
    <!--头像开始-->
    <div class="HeadPortrait">
    	<div class="HeadPortrait-con container">
    		<div class="HeadPortrait-con-title">
    			<div class="HeadPortrait-con-title-l">
    				<i class="layui-icon">&#xe634;</i><span>QQ个性头像</span>
    			</div>
    			<div class="HeadPortrait-con-title-r">
    				<span><a href="javascript:;">更多</a></span>
    			</div>
    		</div>
    		<div class="HeadPortrait-con-main row">
    			<div class="HeadPortrait-con-main-l col-lg-8 col-md-7 col-sm-12 col-xs-12">
    				<ul>
    					<%=gxtxTOhtml() %>
    				</ul>
    			</div>
    			<div class="HeadPortrait-con-main-r col-lg-4 col-md-5 col-sm-12  hidden-xs">
    				<div class="HeadPortrait-con-main-r-list">
    					<ul>
    						<%=txListTOhtml() %>
    					</ul>
    				</div>
    			</div>
    		</div>
    	</div>
    </div>
    <!--头像结束-->
    
    <!--排行榜和商品推荐开始-->
    <div class="commodity container">
    	<div class="commodity-con row">
            <div class="col-lg-4 col-md-4 col-sm-12">
                <div class="commodity-con-l ">
                    <div class="commodity-con-l-title">
                        <div class="title-text fl"><span class="layui-icon">&#xe600;</span>热门排行榜</div>
                        <div class="title-More fr">
                            <a class="phbbtn month rmph-bg" href="javascript:;">月</a>
                            <a class="phbbtn total" href="javascript:;">总</a>
                        </div>
                    </div>
                    <div class="commodity-con-l-main">
                        <ul class="commodity-con-l-main-list commodity-con-l-main-list1">
                           <%=rmphbTOhtml() %>
                        </ul>
                        <ul class="commodity-con-l-main-list commodity-con-l-main-list2">
                            <%=rmphbTOhtml() %>
                        </ul>
                        </div>
                </div>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-12">
                <div class="commodity-con-r">
                    <div class="commodity-con-r-title">
                        <div class="title-text fl"><span class="layui-icon">&#xe61b;</span>今日淘宝天猫优惠商品</div>
                        <div class="title-More fr">更多</div>
                    </div>
                    <div class="commodity-con-r-main">
                        <ul>
                            <li>
                                <div class="thumbnails" >
                                    <img src="img/TB1DietXo6FK1Jjy1XdXXblkXXa_!!0-item_pic.jpg_310x310.jpg" alt="">
                                </div>
                                <div class="introduce">
                                    <h3 class="CommodityName">邦海自慧古树滇红茶 古树红茶</h3>
                                    <h3 class="Price">价格：19.9元</h3>
                                    <a class="GoTo" target="_blank"  href="javascript:;">立即前往</a>
                                </div>
                            </li>
                            <li>
                                <div class="thumbnails" >
                                    <img src="img/TB1DietXo6FK1Jjy1XdXXblkXXa_!!0-item_pic.jpg_310x310.jpg" alt="">
                                </div>
                                <div class="introduce">
                                    <h3 class="CommodityName">邦海自慧古树滇红茶 古树红茶</h3>
                                    <h3 class="Price">价格：19.9元</h3>
                                    <a class="GoTo" target="_blank"  href="javascript:;">立即前往</a>
                                </div>
                            </li>
                            <li>
                                <div class="thumbnails" >
                                    <img src="img/TB1DietXo6FK1Jjy1XdXXblkXXa_!!0-item_pic.jpg_310x310.jpg" alt="">
                                </div>
                                <div class="introduce">
                                    <h3 class="CommodityName">邦海自慧古树滇红茶 古树红茶</h3>
                                    <h3 class="Price">价格：19.9元</h3>
                                    <a class="GoTo" target="_blank"  href="javascript:;">立即前往</a>
                                </div>
                            </li>
                            <li>
                                <div class="thumbnails" >
                                    <img src="img/TB1DietXo6FK1Jjy1XdXXblkXXa_!!0-item_pic.jpg_310x310.jpg" alt="">
                                </div>
                                <div class="introduce">
                                    <h3 class="CommodityName">邦海自慧古树滇红茶 古树红茶</h3>
                                    <h3 class="Price">价格：19.9元</h3>
                                    <a class="GoTo" target="_blank"  href="javascript:;">立即前往</a>
                                </div>
                            </li>
                            <li>
                                <div class="thumbnails" >
                                    <img src="img/TB1DietXo6FK1Jjy1XdXXblkXXa_!!0-item_pic.jpg_310x310.jpg" alt="">
                                </div>
                                <div class="introduce">
                                    <h3 class="CommodityName">邦海自慧古树滇红茶 古树红茶</h3>
                                    <h3 class="Price">价格：19.9元</h3>
                                    <a class="GoTo" target="_blank"  href="javascript:;">立即前往</a>
                                </div>
                            </li>
                            <li>
                                <div class="thumbnails" >
                                    <img src="img/TB1DietXo6FK1Jjy1XdXXblkXXa_!!0-item_pic.jpg_310x310.jpg" alt="">
                                </div>
                                <div class="introduce">
                                    <h3 class="CommodityName">邦海自慧古树滇红茶 古树红茶</h3>
                                    <h3 class="Price">价格：19.9元</h3>
                                    <a class="GoTo" target="_blank"  href="javascript:;">立即前往</a>
                                </div>
                            </li>
                            
                        </ul>
                    </div>
                </div>
            </div>    
    	</div>
    </div>
    <!--排行榜和商品推荐结束-->

    <!--友情链接开始-->
    <div class="FriendshipLink container">
        <div class="FriendshipLink-com row">
            <div class="FriendshipLink-title col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="FriendshipLink-title-l fl">
                    <i class="layui-icon" style="color:#63B73D">&#xe64c;</i>
                    友情链接
                </div>
                <div class="FriendshipLink-title-r fr">
                    <a href="javascript:;">申请友链</a>
                </div>
            </div>
            <div class="FriendshipLink-main col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <ul>
                    
                    <%=TOlinks() %>
                </ul>    
            </div>
        </div>
    </div>
    <!--友情链接结束-->

    <!--footer-->
    <!--#include file="include/footer.html"-->
    <!--footer-->
    <script src="bootstrap/js/bootstrap.min.js"></script>

    </form>
</body>
</html>
