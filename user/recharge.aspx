<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recharge.aspx.cs" Inherits="vip20170612.user.recharge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>我要充值 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="../layui/css/layui.css" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/user_recharge.css" />
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
                <div class="rechargebox layui-tab layui-tab-brief" lay-filter="docDemoTabBrief">
                    <!--选项卡-->
                    <ul class="layui-tab-title">
                      <li class="layui-this">卡密充值</li>
                      <li>快捷支付</li>
                    </ul>
                    <!--内容-->
                    <div class="layui-tab-content" style="height: 100px;">
                        <!--卡密充值-->
                      <div class="layui-tab-item layui-show">
                            <form class="layui-form layui-form-pane" action="">
                                <div class="layui-form-item">
                                    <label class="layui-form-label">卡号</label>
                                    <div class="layui-input-block">
                                        <input type="text" name="title" autocomplete="off" placeholder="请输入32位的卡号" class="layui-input">
                                    </div>
                                </div>
                                <div class="layui-form-item">
                                    <label class="layui-form-label">卡密</label>
                                    <div class="layui-input-block">
                                        <input type="text" name="title" autocomplete="off" placeholder="请输入32位的卡密" class="layui-input">
                                    </div>
                                </div>
                                <p>卡密购买地址：http://953ka.com/ 购买后请到本页面输入充值,支付宝微信在线支付正在完善中</p>
                                <p><a  class="fr col-lg-3 col-md-3 col-sm-12 col-xs-12 czbtn" href="javascript:;">立即充值</a></p>
                            </form>        
                      </div>
                      <div class="layui-tab-item">
                           <!--快捷充值-->
                           <form class="layui-form layui-form-pane" action="">
                                <div class="layui-form-item">
                                    <label class="layui-form-label">金额</label>
                                    <div class="layui-input-block">
                                        <input type="text" name="title" autocomplete="off" placeholder="充值的金额（元）" class="layui-input">
                                    </div>
                                </div>
                                
                                <fieldset class="layui-elem-field">
                                    <legend style="font-size:15px;">充值方式选择</legend>
                                    <ul class="pay_list clearfix">
                                        <li class="col-xs-12 col-sm-6 col-md-6 col-lg-4">
                                             <input type="radio" disabled="disabled" name="paytype" value="1" title="支付宝"><div class="layui-unselect layui-form-radio layui-radio-disbaled layui-disabled"><i class="layui-anim layui-icon"></i><span><img src="../img/zfbpay.png" "="" title="支付宝"></span></div>
                                        </li>
                                        <li class="col-xs-12 col-sm-6 col-md-6 col-lg-4">
                                            <input type="radio" disabled="disabled" name="paytype" value="2" title="<img src=&quot;/img/imgpay/weixinpay.png&quot; title=&quot;微信&quot; />"><div class="layui-unselect layui-form-radio layui-radio-disbaled layui-disabled"><i class="layui-anim layui-icon"></i><span><img src="../img/weixinpay.png" title="微信"></span></div>
                                        </li>
                                        <li class="col-xs-12 col-sm-6 col-md-6 col-lg-4">
                                            <input type="radio" disabled="disabled" name="paytype" value="3" title="<img src=&quot;/img/imgpay/yinlanpaty.png&quot; title=&quot;银联钱包&quot; />"><div class="layui-unselect layui-form-radio layui-radio-disbaled layui-disabled"><i class="layui-anim layui-icon"></i><span><img src="../img/yinlanpaty.png" title="银联钱包"></span></div>
                                        </li>
                                    </ul>
                                </fieldset>

                                <p>充值比例：支付：1.00元可获得 100.00个学院币，（若充值成功却未到账请联系客服Qq1241058165）</p>
                                <p><a  class="fr col-lg-3 col-md-3 col-sm-12 col-xs-12 czbtn" href="javascript:;">立即充值</a></p>
                            </form>
                      </div>
                    </div>
                </div> 
            </div>
        </div>
    </div>

    <script src="../layui/layui.js" charset="utf-8"></script>
    <script>
        layui.use('element', function () {
            var $ = layui.jquery
            , element = layui.element; //Tab的切换功能，切换事件监听等，需要依赖element模块
        });
</script>

    <!--footer-->
    <!--#include file="../include/footer.html"-->
    <!--footer-->

    <script src="../bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
