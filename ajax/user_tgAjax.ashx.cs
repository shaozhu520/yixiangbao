using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ruanmou;
using DAL.ruanmou;
using com.DAL.Base;
using com.Model.Base;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.SessionState;
using com.Utility;//引入  Session !!!!

namespace vip20170612.ajax
{
    /// <summary>
    /// user_tgAjax 的摘要说明
    /// </summary>
    public class user_tgAjax : IHttpHandler, IRequiresSessionState // 引入 Session !!!!
    {
        ReturnMessage<Object> rm = new ReturnMessage<Object>();//声明对象 测试

        JavaScriptSerializer jss = new JavaScriptSerializer();//json

        HttpContext context;/// !!!!

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;//用来获取 Session !!!!!!
            string parameter = context.Request.Form["parameter"];//获取到处理凭证
            string Title = context.Request.Form["Title"];//标题
            string Abstract = context.Request.Form["Abstract"];//内容介绍
            string Download = context.Request.Form["Download"];//下载地址
            string Thumbnail = context.Request.Form["Thumbnail"];//封面

            switch (parameter)//处理类似
            {

                case "aDDjiaocheng"://登陆

                    string sr = Toaddjiaocheng(Title, Abstract, Download, Thumbnail);
                    context.Response.Write(sr);//返回
                    break;


            }
        }


        //登陆函数

        public string Toaddjiaocheng(string Title, string Abstract, string Download, string Thumbnail)
        {

            try
            {

                if ((string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Abstract)) && (string.IsNullOrEmpty(Download) && string.IsNullOrEmpty(Thumbnail)))//判断是否为空
                {
                    rm.Success = false;
                    rm.Info = "必填项不能为空！";
                    string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                    return sresult;
                }
                else
                {
                    List<dbParam> list = new List<dbParam>() { 
                           new dbParam(){ ParamName="@Title", ParamValue=Title},
                           new dbParam(){ ParamName="@Abstract", ParamValue=Abstract},
                           new dbParam(){ ParamName="@Download", ParamValue=Download},
                           new dbParam(){ ParamName="@Thumbnail", ParamValue=Thumbnail}
                        };

                    //获取到了这个条件下的一个对象 判断不为空

                    string key =context.Session["userkey"].ToString();//保存Session key 用户唯一识别码

                    if (key!=null)//如果唯一识别码存在 就可以添加 如果不存在 就不能添加
                    {
                        //UserInfor user = UserInforDAL.m_UserInforDal.GetModel("UserEmail=@UserEmail and UserPwd=@Pwd", list);

                        RNews news = new RNews();

                        Thumbnail = (Thumbnail == null) ? "/img/Rnews/default_cover.png" : Thumbnail;

                        news.Title = Title;//标题
                        news.Abstract = Abstract;//简介
                        news.Download = Download;//下载地址
                        news.Thumbnail = Thumbnail;//缩略图
                        news.Author = key;//用户唯一识别码 作者
                        news.IsClass = "教程软件"; //分类 这里写死了！！
                        news.Tsize = 10.0;//大小
                        news.NStatistics = 0;//下载统计
                        news.lrNumber = 0;//浏览数
                        news.IsContents = null;//内容
                        news.ReleaseTime = DateTime.Now; //提交时间
                        news.Star = 2;//星级
                        news.Auditing = false;//默认的审核状态为false
                        RNewsDAL.m_RNewsDal.Add(news);//添加


                        rm.Success = true;
                        rm.Info = "提交成功！";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        return sresult;

                    }
                    else
                    {
                        rm.Success = false;
                        rm.Info = "请先登录！";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        return sresult;

                    }

                    
                }
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.Info = "请先登录！！";
                string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                return sresult;
            }

        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}