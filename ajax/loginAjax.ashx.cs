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
    /// loginAjax 的摘要说明
    /// </summary>
    public class loginAjax : IHttpHandler, IRequiresSessionState // 引入 Session !!!!
    {

        ReturnMessage<Object> rm = new ReturnMessage<Object>();//声明对象 测试

        JavaScriptSerializer jss = new JavaScriptSerializer();//json

        //HttpContext context1 = new HttpContext();//用来获取 Session

        HttpContext context;/// !!!!

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;//用来获取 Session !!!!!!
            string parameter = context.Request.Form["parameter"];//获取到处理凭证
            string Email = context.Request.Form["Email"];//Email 邮箱
            string Pwd = context.Request.Form["Pwd"];//获取密码 登录密码 旧密码
            string xpwd = context.Request.Form["xpwd"];//获取密码 



            switch (parameter)//处理类似
            {

                case "login"://登陆

                    string sr = Tologin(Email, Pwd);
                 context.Response.Write(sr);//返回
                 break;

                case "changpwd"://修改密码

                 string srs = changpwd(Pwd, xpwd);
                 context.Response.Write(srs);//返回
                 break;

                case "secede": //退出登录
                 try
                 {
                     context.Session["userkey"] = null;
                     rm.Success = true;
                     rm.Info = "OK";
                     string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                     context.Response.Write(sresult);//返回

                 }
                 catch (Exception)
                 {

                     rm.Success = false;
                     rm.Info = "异常";
                     string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                     context.Response.Write(sresult);//返回
                 }

                 break;

                case "toyztoken": //验证是否登录

                 try
                 {
                     string token = context.Session["userkey"].ToString();
                     if (token!=null)
                     {
                        rm.Success = true;
                        rm.Info = "OK";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        context.Response.Write(sresult);//返回


                     }else{
                        rm.Success = false;
                        rm.Info = "失败";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        context.Response.Write(sresult);//返回

                     }
                 }
                 catch (Exception)
                 {
                     
                     rm.Success = false;
                        rm.Info = "系统异常！";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        context.Response.Write(sresult);//返回
                 }

                 break;



            }
        }


        //修改密码函数
        public string changpwd(string Pwd, string xpwd)
        {
            try
            {
                if (context.Session["userkey"].ToString()!=null)//查有没有登录
                {

                    UserInfor use = UserInforDAL.m_UserInforDal.GetModel("Binding='" + context.Session["userkey"].ToString() + "'");

                    if (use.UserPwd == Pwd)
                    {
                    
                        use.UserPwd = xpwd;

                        UserInforDAL.m_UserInforDal.Update(use);//修改

                        rm.Success = true;
                        rm.Info = "修改成功！";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        return sresult;

                    }
                    else
                    {
                        rm.Success = false;
                        rm.Info = "旧密码不正确！";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        return sresult;
                    }

                    
                }
                else
                {
                    rm.Success = false;
                    rm.Info = "请先登录！";
                    string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                    return sresult;
                }

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //登陆函数

        public string Tologin(string Email, string Pwd)
        {

            try
            {

                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Pwd))//判断是否为空
                {
                    rm.Success = false;
                    rm.Info = "用户名或者密码不能为空！";
                    string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                    return sresult;
                }
                else
                {
                    List<dbParam> list = new List<dbParam>() { 
                           new dbParam(){ ParamName="@UserEmail", ParamValue=Email},
                           new dbParam(){ ParamName="@Pwd", ParamValue=Pwd}
                        };

                    //获取到了这个条件下的一个对象 判断不为空

                    UserInfor user = UserInforDAL.m_UserInforDal.GetModel("UserEmail=@UserEmail and UserPwd=@Pwd", list);
                    if (user != null)//登陆成功
                    {

                        context.Session["userkey"] = user.Binding.ToString();//保存Session key 用户唯一识别码

                        rm.Success = true;
                        rm.Info = "登录成功！";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        return sresult;

                    }
                    else
                    {
                        rm.Success = false;
                        rm.Info = "用户名或密码错误！";
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        return sresult;

                    }

                }
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.Info = "系统异常,请联系客服！";
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