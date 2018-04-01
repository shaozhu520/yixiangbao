<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_tg.aspx.cs" Inherits="vip20170612.user.User_tg" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>投稿教程 - 易线报-不做大多数，别具一格。</title>
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="../layui/css/layui.css" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/User_tg.css" />
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
                      <li class="layui-this">教程投稿</li>
                      <li>文章投稿</li>
                      <li>投稿记录</li>
                    </ul>
                    <!--内容-->
                    <div class="layui-tab-content" >
                        <!--教程投稿-->
                      <div class="layui-tab-item layui-show">
                            <form class="layui-form layui-form-pane" action="">
                                <div class="layui-form-item">
                                    <label class="layui-form-label">教程标题 *</label>
                                    <div class="layui-input-block">
                                      <input type="text" name="title" lay-verify="title" id="title" autocomplete="off" placeholder="请输入文章标题" class="layui-input" />
                                    </div>
                                 </div>
                                <div class="layui-form-item">
                                    <label class="layui-form-label">下载地址 *</label>
                                    <div class="layui-input-block">
                                      <input type="text" name="title" lay-verify="Download" id="Download" autocomplete="off" placeholder="https://pan.baidu.com/" class="layui-input" />
                                    </div>
                                 </div>
                                <div class="layui-form-item">
                                    <label class="layui-form-label">上传封面 *</label>
                                    <div class="layui-upload">
                                    <button type="button" class="layui-btn" id="test1">上传图片</button>
                                    <div class="layui-upload-list">
                                        <img class="layui-upload-img Thumbnails" lay-verify="Thumbnail" id="demo1" />
                                        <p id="demoText"></p>
                                     </div>
                                    </div>  
                                 </div>

                                <div class="layui-form-item layui-form-text">
                                    <label class="layui-form-label">教程介绍</label>
                                    <div class="layui-input-block">
                                      <textarea placeholder="投稿备注" id="Abstract" lay-verify="Introduction" class="layui-textarea"></textarea>
                                    </div>
                                </div>


                                <button id="tgjctj" class="layui-btn tjbtn">提交</button>

                                <div class="layui-form-item layui-form-text">
                                    <label class="layui-form-label">投稿须知</label>

                                    <blockquote class="layui-elem-quote Explain layui-input-block">
                                        <p>1.本页面用于投稿视频教程或者纯软件，您可以将教程打包上传百度云然后提交下载地址。</p>
                                        <p>2.每个作者每天最多只能投稿3次，投稿太多可能会导致教程的质量不足，我们要的是质量而不是数量。</p>
                                        <p>3.为保障教程的清晰度，请使用《屏幕录像专家》这款软件进行录制，手机也可以录制教程并在本页面上传。</p>
                                        <p>4.以上所有的信息请认真填写，我们会在后台第一时间审核，审核通过后可在首页展示您的教程。</p>
                                        <p>5.您可以在 [ 投稿记录 ]中查看是否通过.通过后赠送5 - 500Y币,视教程好坏决定</p>
                                        <p>6.请勿上传病毒木马，否则可能导致您的账号被封，IP段被封 永远无法投稿。</p>
                                    </blockquote>
                               </div>
                                
                               

                            </form>        
                      </div>
                      <div class="layui-tab-item">
                           <!--文章投稿-->
                           <form class="layui-form layui-form-pane" action="">
                                2222
                            </form>
                      </div>

                      <div class="layui-tab-item">
                           <!--文章投稿-->
                           <form class="layui-form layui-form-pane" action="">
                                33333
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

        //上传
        layui.use('upload', function(){
            var $ = layui.jquery
            ,upload = layui.upload;
  
            //普通图片上传
            var uploadInst = upload.render({
                elem: '#test1'
              , url: '/ajax/inageTxAjax.ashx?cmd=uploadImage'
              ,before: function(obj){
                  //预读本地文件示例，不支持ie8
                  
                  obj.preview(function (index, file, result) {
                      console.log(index);
                      console.log(file);
                      $('#demo1').attr('src', result); //图片链接（base64）
                  });
              }
              ,done: function(res){
                  //如果上传失败
                  if(res.code > 0){
                      return layer.msg('上传失败');
                  }
                  //上传成功
              }
              ,error: function(){
                  //演示失败状态，并实现重传
                  var demoText = $('#demoText');
                  demoText.html('<span style="color: #FF5722;">上传失败</span> <a class="layui-btn layui-btn-mini demo-reload">重试</a>');
                  demoText.find('.demo-reload').on('click', function(){
                      uploadInst.upload();
                  });
              }
            });
        });
    </script>

    <!--footer-->
    <!--#include file="../include/footer.html"-->
    <!--footer-->
    <script src="../js/User_tg.js" type="text/javascript" charset="utf-8"></script>
    <script src="../bootstrap/js/bootstrap.min.js"></script>
</body>
</html>

