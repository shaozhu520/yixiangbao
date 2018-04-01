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
using com.Utility;
using System.Web.SessionState;//引入  Session

namespace vip20170612.admin
{
    /// <summary>
    /// Handle 的摘要说明
    /// </summary>
    public class Handle : IHttpHandler, IRequiresSessionState // 引入 Session
    {

        //ReturnMessage<Enroll> getEnroll = new ReturnMessage<Enroll>();
        ReturnMessage<admin_table> getAdmin_table = new ReturnMessage<admin_table>();
        ReturnMessage<Flink> rmLinks = new ReturnMessage<Flink>();//声明对象
        ReturnMessage<UserInfor> rtuser = new ReturnMessage<UserInfor>();//声明对象
        ReturnMessage<RNews> rm = new ReturnMessage<RNews>();//声明对象
        JavaScriptSerializer jss = new JavaScriptSerializer();//声明对象
        ReturnMessage<Object> rt = new ReturnMessage<Object>();//响应对象

        HttpContext context;//用来获取 Session

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;//用来获取 Session
            string parameter = context.Request.Form["parameter"];//入口


            //登陆
            if (parameter == "adminLogin")
            {
                string UserName = context.Request.Form["newsName"];//获取name
                string UserPwd = context.Request.Form["Pwd"];//获取密码
                
                try
                {

                    if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPwd))//判断是否为空
                    {
                        //context.Response.Write("用户名或者密码不能为空");
                        rt.Info = "用户名或者密码不能为空";
                        rt.Success = false;
                        string sresult = jss.Serialize(rt);//吧 rt 对象 转换
                        context.Response.Write(sresult);//返回

                    }
                    else
                    {
                        List<dbParam> list = new List<dbParam>() { 
                           new dbParam(){ ParamName="@UserName", ParamValue=UserName},
                           new dbParam(){ ParamName="@pwd", ParamValue=UserPwd}
                        };

                        //获取到了这个条件下的一个对象 判断不为空

                        admin_table user = admin_tableDAL.m_admin_tableDal.GetModel("admin_Name=@UserName and admin_Pwd=@pwd and state='true' ", list);
                        if (user != null)
                        {
                            

                            user.LGtime = DateTime.Now;//直接修改上面获取的那个对象
                            admin_tableDAL.m_admin_tableDal.Update(user);//修改登录时间

                           

                            context.Session["token"] = user.admin_Name;//保存Session 当前对象的用户名
                            rt.Info = "登录成功";
                            rt.Success = true;
                            rt.Redirect = user.admin_Name;
                            string sresult = jss.Serialize(rt);//吧 rt 对象 转换
                            context.Response.Write(sresult);//返回

                            
                        }
                        else
                        {
                           
                            rt.Info = "登录失败";
                            rt.Success = false;
                            string sresult = jss.Serialize(rt);//吧 rt 对象 转换
                            context.Response.Write(sresult);//返回
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    rt.Info = "系统异常";
                    rt.Success = false;
                    string sresult = jss.Serialize(rt);//吧 rt 对象 转换
                    context.Response.Write(sresult);//返回
                }
                
            }


            //验证Token 验证管理登录
            if (parameter == "adminyz")
            {
                
                try
                {
                    string UserName = context.Request.Form["newsName"];//获取name
                    

                    List<dbParam> Slist = new List<dbParam>() { 
                           new dbParam(){ ParamName="@UserName", ParamValue=UserName},
                           
                        };


                    admin_table user = admin_tableDAL.m_admin_tableDal.GetModel("admin_Name=@UserName", Slist);

                    if (user.admin_Name == context.Session["token"].ToString())
                    {


                        rt.Info = "验证成功！";
                        rt.Success = true;
                        string sresult673 = jss.Serialize(rt);//吧 rt 对象 转换
                        context.Response.Write(sresult673);//返回

                        

                    }
                    else
                    {
                        rt.Info = "请先登录！";
                        rt.Success = false;
                        string sresult671 = jss.Serialize(rt);//吧 rt 对象 转换
                        context.Response.Write(sresult671);//返回

                        
                    }



                }
                catch (Exception)
                {

                    rt.Info = "系统异常";
                    rt.Success = false;
                    string sresult672 = jss.Serialize(rt);//吧 rt 对象 转换
                    context.Response.Write(sresult672);//返回

                    
                }
                 

            }

           /////////////////////////////////////////////////// 

            try
            {

            

            if (context.Session["token"].ToString() != null)
            {
                switch (parameter)
                {
                    case "addNEws"://添加

                        try
                        {

                            string Title = context.Request.Form["Title"];//标题
                            string Author = context.Request.Form["Author"];//作者
                            string IsClass = context.Request.Form["IsClass"];//分类
                            string Abstract = context.Request.Form["Abstract"];//简介
                            double Tsize = Convert.ToDouble(context.Request.Form["Tsize"]);//大小  double
                            int NStatistics = Convert.ToInt32(context.Request.Form["NStatistics"]);//下载统计 int
                            string Download = context.Request.Form["Download"];//下载地址
                            int lrNumber = Convert.ToInt32(context.Request.Form["lrNumber"]);//浏览数 int
                            string IsContents = context.Request.Form["IsContents"];//内容
                            string ReleaseTime = context.Request.Form["ReleaseTime"];//发布时间
                            string Thumbnail = context.Request.Form["Thumbnail"];//缩略图
                            int Star = Convert.ToInt32(context.Request.Form["Star"]);//星级 int

                            RNews news = new RNews();
                            news.Title = Title;
                            news.Author = "xxxcccvvvbbbnnnmmm";
                            news.IsClass = IsClass;
                            news.Abstract = Abstract;//这个估计要写死 不然要死
                            news.Tsize = Tsize;//?
                            news.NStatistics = NStatistics;
                            news.Download = Download;
                            news.lrNumber = lrNumber;
                            news.IsContents = IsContents;
                            news.ReleaseTime = Convert.ToDateTime(ReleaseTime);

                            Thumbnail = (Thumbnail == null) ? "/img/Rnews/default_cover.png" : Thumbnail;

                            news.Thumbnail = Thumbnail;
                            news.Star = Star;
                            news.Auditing = true;
                            

                            int bp =  RNewsDAL.m_RNewsDal.Add(news);

                            rm.Info = "添加成功！";//赋值
                            rm.Success = true;
                            string sresultpp = jss.Serialize(rm);//吧 rm 对象 转换
                            context.Response.Write(sresultpp);//返回

                        }
                        catch (Exception)
                        {

                            rm.Info = "添加失败！";//赋值
                            rm.Success = false;
                            string sresultpp1 = jss.Serialize(rm);//吧 rm 对象 转换
                            context.Response.Write(sresultpp1);//返回
                        }

                        
                        
                        break;

                    case "CheckList"://查询
                        
                        ////int PageNumber = Convert.ToInt32(context.Request.Form["PageNumber"]);//页码

                        try
                        {
                            string nesclass = context.Request.Form["NEWSclass"];//分类


                            List<dbParam> para = new List<dbParam>() { 
                          new dbParam(){ ParamName="@NEWSclass", ParamValue=nesclass}
                        };
                            string ssql = "IsClass=@NEWSclass";

                            List<RNews> list = RNewsDAL.m_RNewsDal.GetList(ssql, 999999999, 1, true, "*", "ID", para);//获取集合
                            rm.Data = list;//赋值

                            string sresult = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresult);//返回
                        }
                        catch (Exception)
                        {

                            rm.Data = null;//赋值
                            rm.Success = false;
                            string sresultB = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresultB);//返回
                        }


                        break;

                    case "Auditing"://查询审核的文章

                        try
                        {
                            string ssql1 = "Auditing='false'";

                            List<RNews> list1 = RNewsDAL.m_RNewsDal.GetList(ssql1, 999999999, 1, true, "*", "ID");//获取集合
                            rm.Data = list1;//赋值
                            rm.Success = true;//赋值
                            rm.Info = "查询成功！";
                            string sresult11 = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresult11);//返回
                        }
                        catch (Exception)
                        {

                            rm.Success = false;//赋值
                            rm.Info = "系统异常！";
                            string sresultsss = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresultsss);//返回
                        }

                        break;
                    case "AuditingOK"://修改文章审核状态
                        
                        try
                        {
                            int Lid = Convert.ToInt32(context.Request.Form["id"]);//id


                            List<dbParam> paras = new List<dbParam>() { 
                                new dbParam(){ ParamName="@ID", ParamValue=Lid}
                            };


                            RNews Enro = RNewsDAL.m_RNewsDal.GetModel("ID=@ID", paras);//获取要修改的数据对象


                            if (Enro.Auditing == false)
                            {
                                Enro.Auditing = true;
                            }else{
                                Enro.Auditing = false;
                            }



                            RNewsDAL.m_RNewsDal.Update(Enro);//修改


                            rm.Success = true;//赋值
                            rm.Info = "修改成功！";
                            string sresultsss0 = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresultsss0);//返回

                           

                        }
                        catch (Exception)
                        {
                            rm.Success = false;//赋值
                            rm.Info = "系统异常！";
                            string sresultsss1 = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresultsss1);//返回
                            
                        }
                        
                        break;

                    case "deleteRNews"://删除

                        try
                        {
                            int newid = Convert.ToInt32(context.Request.Form["id"]);//id


                            string sql1 = "ID=@ID";

                            List<dbParam> para1 = new List<dbParam>() { 
                          new dbParam(){ ParamName="@ID", ParamValue=newid}
                        };

                            RNewsDAL.m_RNewsDal.Delete(sql1, para1);

                            rm.Success = true;//赋值
                            rm.Info = "删除成功！";
                            string sresulk = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresulk);//返回



                        }
                        catch (Exception)
                        {

                            rm.Success = false;//赋值
                            rm.Info = "系统异常！";
                            string sresulkk = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresulkk);//返回
                        }

                        
                        
                        break;

                    case "CheckOne"://查找要修改的对象
                        
                        try
                        {
                            int id = Convert.ToInt32((context.Request.Form["id"]));//ID


                            List<dbParam> pAra = new List<dbParam>() { 
                          new dbParam(){ ParamName="@ID", ParamValue=id}
                        };
                            string ssqlV = "ID=@ID";

                            List<RNews> listV = RNewsDAL.m_RNewsDal.GetList(ssqlV, 999999999, 1, true, "*", "ID", pAra);//获取集合
                            rm.Data = listV;//赋值
                            rm.Success = true;
                            rm.Info = "查询成功";
                            string sresultV = jss.Serialize(rm);//吧 rm 对象 转换

                            context.Response.Write(sresultV);//返回

                        }
                        catch (Exception)
                        {

                            rm.Success = false;//赋值
                            rm.Info = "查询失败";
                            string sresultV1 = jss.Serialize(rm);//吧 rm 对象 转换
                            context.Response.Write(sresultV1);//返回
                        }

                        
                        break;

                    case "modifyRnews"://修改文章
                        
                        try
                        {
                            int idS = Convert.ToInt32(context.Request.Form["id"]);//ID

                            string Title = context.Request.Form["Title"];//标题
                            string Author = context.Request.Form["Author"];//作者
                            string IsClass = context.Request.Form["IsClass"];//分类
                            string Abstract = context.Request.Form["Abstract"];//简介
                            double Tsize = Convert.ToDouble(context.Request.Form["Tsize"]);//大小  double
                            int NStatistics = Convert.ToInt32(context.Request.Form["NStatistics"]);//下载统计 int
                            string Download = context.Request.Form["Download"];//下载地址
                            int lrNumber = Convert.ToInt32(context.Request.Form["lrNumber"]);//浏览数 int
                            string IsContents = context.Request.Form["IsContents"];//内容
                            string ReleaseTime = context.Request.Form["ReleaseTime"];//发布时间
                            string Thumbnail = context.Request.Form["Thumbnail"];//缩略图
                            int Star = Convert.ToInt32(context.Request.Form["Star"]);//星级 int


                            List<dbParam> paras = new List<dbParam>() { 
                                new dbParam(){ ParamName="@ID", ParamValue=idS}
                            };


                            RNews news = RNewsDAL.m_RNewsDal.GetModel("ID=@ID", paras);//获取要修改的数据对象

                            //RNews news = new RNews();
                            news.Title = Title;
                            //news.Author = Author;//本来的 这个估计要写死 不然要死 不该作者
                            news.IsClass = IsClass;
                            news.Abstract = Abstract;
                            news.Tsize = Tsize;//?
                            news.NStatistics = NStatistics;
                            news.Download = Download;
                            news.lrNumber = lrNumber;
                            news.IsContents = IsContents;
                            //news.ReleaseTime = Convert.ToDateTime(ReleaseTime); 不该时间

                            Thumbnail = (Thumbnail == null) ? "/img/Rnews/default_cover.png" : Thumbnail;

                            news.Thumbnail = Thumbnail;
                            news.Star = Star;

                            RNewsDAL.m_RNewsDal.Update(news);//修改


                            rm.Success = true;//赋值
                            rm.Info = "修改成功";
                            string sresultV16 = jss.Serialize(rm);//吧 rm 对象 转换
                            context.Response.Write(sresultV16);//返回

                        }
                        catch (Exception)
                        {
                            rm.Success = false;//赋值
                            rm.Info = "修改失败";
                            string sresultV16 = jss.Serialize(rm);//吧 rm 对象 转换
                            context.Response.Write(sresultV16);//返回
                        }
                        
                        break;

                    case "ListLength"://获取文章长度
                        
                        string Nesclass = context.Request.Form["NEWSclass"];//分类

                        if (Nesclass == "admin_table")//获取管理员的个数 5
                        {

                            int iLength = admin_tableDAL.m_admin_tableDal.GetCount("1=1");
                            context.Response.Write(iLength);//返回
                        }
                        else if (Nesclass == "Rnews")//查询待审核的文章个数
                        {

                            int mLength = RNewsDAL.m_RNewsDal.GetCount("Auditing='False'");
                            context.Response.Write(mLength);//返回

                        }
                        else if (Nesclass == "Users")//查询用户列表个数
                        {
                            int mLength = UserInforDAL.m_UserInforDal.GetCount("1=1");
                            context.Response.Write(mLength);//返回
                        }
                        else//获取文章类的数量 这里包括 教程软件 唯美头像 线报活动 1-3
                        {
                            List<dbParam> para3 = new List<dbParam>() { 
                            new dbParam(){ ParamName="@NEWSclass", ParamValue=Nesclass}
                            };
                            string ssql2 = "IsClass=@NEWSclass";

                            int iLength = RNewsDAL.m_RNewsDal.GetCount(ssql2, para3);
                            context.Response.Write(iLength);//返回
                        }
                        
                        break;





                    case "Links"://友情链接查询

                        try
                        {
                            List<Flink> list1 = FlinkDAL.m_FlinkDal.GetList("1=1", 999999999, 1, true, "*", "ID", null);//获取集合

                            rmLinks.Data = list1;//赋值

                            string sresult1 = jss.Serialize(rmLinks);//吧 rm 对象 转换

                            context.Response.Write(sresult1);//返回

                        }
                        catch (Exception)
                        {
                            rmLinks.Info = "系统异常";//赋值
                            rmLinks.Success = false;
                            string sresult1 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                            context.Response.Write(sresult1);//返回
                        }

                        break;

                    case "deleteLinks"://删除链接
                        
                        try
                        {

                            int dleID = Convert.ToInt32(context.Request.Form["id"]);//获取要删除的ID
                            string sql2 = "ID=@ID";

                            List<dbParam> para2 = new List<dbParam>() { 
                                new dbParam(){ ParamName="@ID", ParamValue=dleID}
                            };
                            //rmLinks

                            FlinkDAL.m_FlinkDal.Delete(sql2, para2);

                        }
                        catch (Exception)
                        {
                            rmLinks.Info = "系统异常";//赋值
                            rmLinks.Success = false;
                            string sresult2 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                            context.Response.Write(sresult2);//返回

                            throw;
                        }

                        rmLinks.Info = "删除成功";//赋值
                        rmLinks.Success = true;
                        string sresult3 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                        context.Response.Write(sresult3);//返回

                         
                        

                        break;



                    case "AddLinks"://添加友情链接
                        
                        try
                        {

                            string WebName = context.Request.Form["WebName"];//网站名称
                            string WebUrl = context.Request.Form["WebUrl"];//URL
                            string CreatedTimeS = context.Request.Form["CreatedTime"];//添加时间
                            string ContactEMail = context.Request.Form["ContactEMail"];//站长邮箱

                            Flink News = new Flink();

                            News.Name = WebName;
                            News.URLLink = WebUrl;
                            News.tjtime = Convert.ToDateTime(CreatedTimeS);
                            News.ContactEMail = ContactEMail;

                            FlinkDAL.m_FlinkDal.Add(News);

                        }
                        catch (Exception)
                        {
                            rmLinks.Info = "添加失败";//赋值
                            rmLinks.Success = false;
                            string sresult44 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                            context.Response.Write(sresult44);//返回
                        }


                        rmLinks.Info = "添加成功";//赋值
                        rmLinks.Success = true;
                        string sresult4 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                        context.Response.Write(sresult4);//返回
                        

                        break;


                    case "ReviseLinks"://修改友情链接
                        
                        try
                        {

                            int WEBid = Convert.ToInt32(context.Request.Form["webID"]);//id 

                            int sort = Convert.ToInt32(context.Request.Form["sort"]);//sort

                            string webUrl = context.Request.Form["webUrl"];//URl

                            string webName = context.Request.Form["webName"];//名称

                            string webEmail = context.Request.Form["webEmail"];//邮箱
                            


                            List<dbParam> paras = new List<dbParam>() { 
                                new dbParam(){ ParamName="@webID", ParamValue=WEBid}
                            };


                            Flink Links = FlinkDAL.m_FlinkDal.GetModel("ID=@webID", paras);//获取要修改的数据对象

                            Links.Name = webName;//修改 名称
                            Links.URLLink = webUrl;//修改 url
                            Links.ContactEMail = webEmail;// 修改 邮箱
                            Links.SerialNumber = sort;//修改排序优先级

                            FlinkDAL.m_FlinkDal.Update(Links);//修改


                            rmLinks.Info = "修改成功";//赋值
                            rmLinks.Success = true;
                            string sresult5 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                            context.Response.Write(sresult5);//返回

                           

                        }
                        catch (Exception)
                        {
                            rmLinks.Info = "修改失败";//赋值
                            rmLinks.Success = false;
                            string sresult5 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                            context.Response.Write(sresult5);//返回
                            
                        }
                        
                        break;


                    case "getUserInfor"://用户列表
                        
                        try
                        {
                            List<UserInfor> list2 = UserInforDAL.m_UserInforDal.GetList("1=1", 999999999, 1, true, "*", "ID", null);//获取集合

                            rtuser.Data = list2;//赋值
                            rtuser.Success = true;
                            string sresult2 = jss.Serialize(rtuser);//吧 rm 对象 转换

                            context.Response.Write(sresult2);//返回

                        }
                        catch (Exception)
                        {
                            rtuser.Data = null;//赋值
                            rtuser.Success = false;
                            string sresult66 = jss.Serialize(rtuser);//吧 rm 对象 转换

                            context.Response.Write(sresult66);//返回
                        }
                        
                        break;

                    case "TgetEnroll"://报名人员表查询 待审核
                        /*
                        try
                        {
                            List<Enroll> list2 = EnrollDAL.m_EnrollDal.GetList("State='true'", 999999999, 1, true, "*", "ID", null);//获取集合

                            getEnroll.Data = list2;//赋值

                            string sresult2 = jss.Serialize(getEnroll);//吧 rm 对象 转换

                            context.Response.Write(sresult2);//返回

                        }
                        catch (Exception)
                        {
                            context.Response.Write("很抱歉系统异常");//返回

                            throw;
                        }
                        */
                        break;

                    case "deleteUser"://删除恶意提交的
                        /*
                        try
                        {
                            int Nid = Convert.ToInt32(context.Request.Form["id"]);//id


                            string sqlH = "ID=@ID";

                            List<dbParam> paras = new List<dbParam>() { 
                                new dbParam(){ ParamName="@ID", ParamValue=Nid}
                            };

                            EnrollDAL.m_EnrollDal.Delete(sqlH, paras);

                            context.Response.Write(true);//返回

                        }
                        catch (Exception)
                        {
                            context.Response.Write(false);//返回
                            throw;
                        }


                        */
                        break;


                    case "modifyPwd"://修改管理用户名密码
                        
                        try
                        {
                            string myName = context.Request.Form["myname"];//用户名
                            string myPwd = context.Request.Form["myPwd"];//旧密码
                            string NewPwd = context.Request.Form["newPwd"];//新密码


                            List<dbParam> list66 = new List<dbParam>() { 
                               new dbParam(){ ParamName="@myName", ParamValue=myName},
                               new dbParam(){ ParamName="@myPwd", ParamValue=myPwd},

                            };


                            admin_table admin = admin_tableDAL.m_admin_tableDal.GetModel("admin_Name=@myName and admin_Pwd=@myPwd", list66);//获取要修改的数据对象

                            if (admin == null)
                            {
                                
                                getAdmin_table.Success = false;
                                getAdmin_table.Info = "用户名不存在!";
                                string sresult251 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                                context.Response.Write(sresult251);//返回
                            }
                            else
                            {
                                admin.admin_Pwd = NewPwd;//修改

                                admin_tableDAL.m_admin_tableDal.Update(admin);//修改

                                getAdmin_table.Success = true;
                                getAdmin_table.Info = "修改成功!";
                                string sresult252 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                                context.Response.Write(sresult252);//返回
                            }

                        }
                        catch (Exception)
                        {
                            getAdmin_table.Success = false;
                            getAdmin_table.Info = "系统异常!";
                            string sresult256 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                            context.Response.Write(sresult256);//返回
                        }
                        
                        break;

                    case "Query_admin"://查询管理员列表
                        
                        try
                        {
                            //admin_tableDAL.m_admin_tableDALDal.GetList("1=1", 999999999, 1, true, "admin_Name,Sex,Status,Contact,LGtime", "ID", null)
                            List<admin_table> list3 = admin_tableDAL.m_admin_tableDal.GetList("1=1", 999999999, 1, true, "ID,admin_Name,Sex,Status,state,Contact,LGtime", "ID", null);//获取集合

                            getAdmin_table.Data = list3;//赋值
                            getAdmin_table.Success = true;
                            string sresult36 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                            context.Response.Write(sresult36);//返回

                        }
                        catch (Exception)
                        {

                            getAdmin_table.Success = false;
                            string sresult360 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                            context.Response.Write(sresult360);//返回
                        }
                        
                        break;

                    case "add_admin"://添加管理员
                        
                        try
                        {
                            string admin_Name = context.Request.Form["admin_Name"];//用户名
                            string admin_Pwd = context.Request.Form["admin_Pwd"];//密码
                            string state = context.Request.Form["state"];//启用状态
                            string Sex = context.Request.Form["Sex"];//性别
                            string Status = context.Request.Form["Status"];//职务/身份
                            string Contact = context.Request.Form["Contact"];//联系方式

                            List<dbParam> Plist = new List<dbParam>() { 
                            new dbParam(){ ParamName="@admin_Name", ParamValue=admin_Name},
                            
                            };

                            admin_table userS = admin_tableDAL.m_admin_tableDal.GetModel("admin_Name=@admin_Name ", Plist);

                            if (userS!=null)//如果查询到了这个用户名 那么说明已经存在
                            {

                                getAdmin_table.Info = "该用户已存在！";
                                getAdmin_table.Success = false;
                                string sresult350 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                                context.Response.Write(sresult350);//返回

                            }else{

                            admin_table News = new admin_table();

                                News.admin_Name = admin_Name;//用户名
                                News.admin_Pwd = admin_Pwd;//密码
                                News.LGtime = DateTime.Now;//最后登陆时间
                                News.state = Convert.ToBoolean(state);//启用状态
                                News.Sex = true;//性别
                                News.Status = Status;//职务/身份
                                News.Contact = Contact;//联系方式

                                admin_tableDAL.m_admin_tableDal.Add(News);

                                getAdmin_table.Info = "添加成功!";
                                getAdmin_table.Success = true;
                                string sresult351 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                                context.Response.Write(sresult351);//返回
                            }

                            

                        }
                        catch (Exception)
                        {

                            getAdmin_table.Info = "系统异常!";
                            getAdmin_table.Success = false;
                            string sresult311 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                            context.Response.Write(sresult311);//返回
                        }
                        
                        break;

                    case "del_admin"://删除管理员
                        
                        try
                        {
                            
                            string names = context.Session["token"].ToString();

                            if (names =="admin")
                            {

                                int Bid = Convert.ToInt32(context.Request.Form["adminID"]);//id


                            string sqlH = "ID=@ID";

                            List<dbParam> parasS = new List<dbParam>() { 
                                new dbParam(){ ParamName="@ID", ParamValue=Bid}
                            };

                            admin_tableDAL.m_admin_tableDal.Delete(sqlH, parasS);


                            getAdmin_table.Success = true;
                            getAdmin_table.Info = "删除成功!";
                            string sresult361 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                            context.Response.Write(sresult361);//返回

                            }
                            else
                            {
                                getAdmin_table.Success = false;
                                getAdmin_table.Info = "您没有删除管理员的权限，只有admin才可以!";
                                string sresult366 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换
                                context.Response.Write(sresult366);//返回
                            }

                            
                        }
                        catch (Exception)
                        {
                            getAdmin_table.Success = false;
                            getAdmin_table.Info = "系统异常!";
                            string sresult367 = jss.Serialize(getAdmin_table);//吧 rm 对象 转换

                            context.Response.Write(sresult367);//返回
                           
                        }
                        

                        break;

                    case "SystemSwitch"://报名系统开关
                        /*
                        try
                        {
                            SwitchButton Switch = SwitchButtonDAL.m_SwitchButtonDal.GetModel("IsFunction='报名系统'", null);

                            if (Switch.IsOpen)
                            {
                                Switch.IsOpen = false;//修改
                            }
                            else
                            {
                                Switch.IsOpen = true;//修改
                            }


                            SwitchButtonDAL.m_SwitchButtonDal.Update(Switch);//修改

                            context.Response.Write(true);//返回


                        }
                        catch (Exception)
                        {

                            context.Response.Write(false);//返回
                        }
                        */

                        break;

                    case "chaSwitch"://查询开关状态
                        /*
                        try
                        {
                            SwitchButton Switch = SwitchButtonDAL.m_SwitchButtonDal.GetModel("IsFunction='报名系统'", null);

                            if (Switch.IsOpen)
                            {
                                 context.Response.Write(true);//返回
                            }
                            else
                            {
                                context.Response.Write(false);//返回
                            }
                        }
                        catch (Exception)
                        {
                            
                            context.Response.Write(false);//返回
                        }
                        */
                        break;

                }
               



            }
            else
            {
                //context.Response.Write("小伙子，你没有权限，别瞎搞！");
                rmLinks.Info = "权限不足！";//赋值
                rmLinks.Success = false;
                string sresult55 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                context.Response.Write(sresult55);//返回

            }
            }

            catch (Exception)
            {

                rmLinks.Info = "请先登录！";//赋值
                rmLinks.Success = false;
                string sresult50 = jss.Serialize(rmLinks);//吧 rm 对象 转换
                context.Response.Write(sresult50);//返回
            }

        }
        
            
            //其它方式




        //public  CheckList(int s)
        //{
        //    // List<RNews> list = RNewsDAL.m_RNewsDal.GetList(GetSql(), pagesize, page, true, "*", "Id", para);
        //    List<RNews> list = RNewsDAL.m_RNewsDal.GetList("1=1", 10, s, true, "*", "Id", null);//获取集合



        //    rm.Data = list;//赋值

        //    string sresult = jss.Serialize(rm);//吧 rm 对象 转换

        //    return sresult;

        //}



        //public int GetRNewsCount()//获取多少条数据
        //{
        //    int i = RNewsDAL.m_RNewsDal.GetCount("1=1", null);
        //    return i;
        //}





        //private int pagesize = 10;//一页显示多少条数据
        //private int _page;
        //List<dbParam> para = new List<dbParam>();

        //public string GetSql()//获取查询语句
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("1=1");
        //    //sb.Append("NewsClass='不净观'");
        //    if (Keyword != "")//通过关键字查询
        //    {
        //        sb.Append(" and Title like @title");
        //        para.Add(new dbParam() { ParamName = "@title", ParamValue = "%" + Keyword.Trim() + "%" });
        //    }

        //    return sb.ToString();
        //}




        //public int GetPageCount()//获取总共有多少页函数
        //{
        //    int icount = RNewsDAL.m_RNewsDal.GetCount("1=1", null);
        //    int pagecount = 0;
        //    if (icount % pagesize == 0)
        //    {
        //        pagecount = icount / pagesize;
        //    }
        //    else
        //    {
        //        double d = Convert.ToDouble(icount) / Convert.ToDouble(pagesize);
        //        pagecount = Convert.ToInt32(Math.Floor(d)) + 1;
        //    }
        //    return pagecount;
        //}




        //添加函数
        //sTitle,sText,sCreatedTime,sNewsClass,sViewCount,sPseudonym
        /*
        public bool addcontent(string sTitle, string sText, string sCreatedTime, string sNewsClass, string sViewCount, string sPseudonym)
        {
            try
            {
                RNews news = new RNews();

                news.Title = sTitle;
                news.Text = sText;
                news.CreatedTime = Convert.ToDateTime(sCreatedTime);
                news.NewsClass = sNewsClass;
                news.ViewCount = Convert.ToInt32(sViewCount); ;
                news.Pseudonym = sPseudonym;


                RNewsDAL.m_RNewsDal.Add(news);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
           

        } */


        //public string toLink() { 
        
        
        //}


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
     
         
    }

}