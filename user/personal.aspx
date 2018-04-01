<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="personal.aspx.cs" Inherits="vip20170612.user.personal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>xxx的个人主页 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../layui/css/layui.css" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/user_personal.css" />
    <link rel="stylesheet" href="../css/main.css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/base.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/index.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--资料头部开始-->   
    <div class="contents  container-fluid">
        <div class="row datumbox">
            <div class="data-top col-lg-12 col-md-12 col-sm-12">
                <!--
                <div class="HeadPortrait ">
                    <img src="../img/99B9BB596E554825487D2CA5FC5097D4.png" alt="" />
                </div>
                <div class="username">小义<img src="../img/viplogo.png" alt="" /></div>
                

                <div class="datum col-lg-12 col-md-12 col-sm-12">
                    <div class="chenghao col-lg-2 col-md-2 col-sm-2 hidden-xs">
                        <p class="fsize23 lheight">初来乍到</p>
                        <p class="fsize12 lheight18">称号</p>
                    </div>
                    <div class="Gender col-lg-2 col-md-2 col-sm-2 hidden-xs">
                        <div class="Gender-ic"><i class=" layui-icon Gender-icon male">&#xe662;</i><i  class=" layui-icon Gender-icon female">&#xe661;</i></div>
                        <p class="fsize12 lheight18">性别</p>
                    </div>
                    <div class="btns col-lg-4 col-md-4 col-sm-4 ">
                        <div><a class="fsize23 lheight" href="javascript:;">联系Ta</a></div>
                        <div><a class="fsize23" href="javascript:;">返回首页</a></div>
                    </div>
                    <div class="Included col-lg-2 col-md-2 col-sm-2 hidden-xs">
                        <p class="fsize23 lheight"> 5篇</p>
                        <p class="fsize12 lheight18">收录投稿</p>
                    </div>
                    <div class="Read col-lg-2 col-md-2 col-sm-2 hidden-xs">
                        <p class="fsize23 lheight">8975次</p>
                        <p class="fsize12 lheight18">作品被阅读</p>
                    </div>
                </div>
                -->
                <%=usersTOhtml() %>
            </div>
            
        </div>
    </div>
    <!--资料头部结束-->
        
     <!--资料下部开始-->
    <div class="contents  container">
        <div class="row">
            <div class="data-bottom ">
                <div class="introduces col-lg-12">
                    <h3 class="jianjie"><i class="layui-icon">&#xe606;</i> 作者简介</h3>
                    <p class="Explain">QQ1241058165少主文字测试QQ1241058165少主文字测试QQ1241058165少主文字测试QQ1241058165少主文字测试QQ1241058165少主文字测试</p>
                </div>
                <div class="col-lg-12 layui-tab layui-tab-brief" lay-filter="docDemoTabBrief">
                    <ul class="layui-tab-title">
                        <li class="layui-this">投稿教程</li>
                        <li>投稿文章</li>
                       
                    </ul>
                    <div class="layui-tab-content" >
                        <div class="layui-tab-item layui-show">
                            <ul class="SubmissionList">
                                <li class="SubmissionList-li">
                                    <div class="SubmissionList-img"><img src="../img/defaultcoverpicture.png" alt="" /></div>
                                    <div class="SubmissionList-title"><span class="sh">已通过</span><span>智仟汇1元撸蓝牙音箱 可接码</span></div>
                                </li>
                                 <li class="SubmissionList-li">
                                    <div class="SubmissionList-img"><img src="../img/defaultcoverpicture.png" alt="" /></div>
                                    <div class="SubmissionList-title"><span class="sh">已通过</span><span>智仟汇1元撸蓝牙音箱 可接码</span></div>
                                </li>
                                 <li class="SubmissionList-li">
                                    <div class="SubmissionList-img"><img src="../img/defaultcoverpicture.png" alt="" /></div>
                                    <div class="SubmissionList-title"><span class="sh">已通过</span><span>智仟汇1元撸蓝牙音箱 可接码</span></div>
                                </li>
                                 <li class="SubmissionList-li">
                                    <div class="SubmissionList-img"><img src="../img/defaultcoverpicture.png" alt="" /></div>
                                    <div class="SubmissionList-title"><span class="sh">已通过</span><span>智仟汇1元撸蓝牙音箱 可接码</span></div>
                                </li>
                            </ul>
                        </div>
                        <div class="layui-tab-item">
                            内容2
                        </div>
                        
                    </div>
                </div> 
            </div>
        </div>
    </div>
    <!--资料下部结束-->

    <!--footer-->
    <div class="footer">
        <div class="container">
            <div class="footer-con row">
                <div class="fl footer-logo col-lg-3 visible-lg">
                    <img src="../img/footerlogo.png" alt="" />
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
    <script src="../bootstrap/js/bootstrap.min.js"></script>
    <script src="../layui/layui.js" charset="utf-8"></script>
    
    <script>
        layui.use('element', function () {
            var $ = layui.jquery
            , element = layui.element; //Tab的切换功能，切换事件监听等，需要依赖element模块
        });
    </script>
    </form>
</body>
</html>
