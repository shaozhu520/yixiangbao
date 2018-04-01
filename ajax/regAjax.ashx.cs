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
using com.Utility;//引入  Session


namespace vip20170612.ajax
{
    /// <summary>
    /// UserAccess 的摘要说明
    /// </summary>
    /// 


    public class regAjax : IHttpHandler, IRequiresSessionState // 引入 Session
    {

        ReturnMessage<Object> rm = new ReturnMessage<Object>();//声明对象 测试

        JavaScriptSerializer jss = new JavaScriptSerializer();//json

        HttpContext context;//用来获取 Session
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;//用来获取 Session
            string parameter = context.Request.Form["parameter"];//获取到处理凭证
            string Email = context.Request.Form["Email"];//Email 邮箱
            string UserPwd = context.Request.Form["Pwd"];//获取密码 
            string yzm = context.Request.Form["proving"];//邮箱验证码 客户的的
            /*
            string tupyanzm = context.Session["CheckCode"].ToString();//图片验证码 系统的
            string imgtoken = context.Request.Form["imgtoken"];//图片验证码 用户输入的
            
            string UserName = context.Request.Form["UserName"];//获取name
            string UserPwd = context.Request.Form["Pwd"];//获取密码 此处的密码 指新密码
            string JPwd = context.Request.Form["Jpwd"];//获取密码 此处的密码 指设置的旧密码
            string Email = context.Request.Form["Email"];//Email 邮箱
            string Token = context.Request.Form["token"];//token 
            int classnum = Convert.ToInt32(context.Request.Form["Package"]);//分类 
            string textcard = context.Request.Form["Card"];//卡密

            //下面是添加接口需要获取的参数 如果有一天添加接口功能删除 那个下面的获取的参数 也可以删除
            string GetUrl = context.Request.Form["GetUrl"];//获取地址
            string Method = context.Request.Form["Method"];//获取提交方式
            string TJConTent = context.Request.Form["TJConTent"];//获取提交的内容
            string Voucher = context.Request.Form["Voucher"];//获取凭证
            string Agreement = context.Request.Form["Agreement"];//获取协议头
            string Remarks = context.Request.Form["Remarks"];//获取备注
            string adminName = context.Request.Form["adminName"];//获取备注
            */

            switch (parameter)//处理类似
            {

                case "Login"://登陆

                   /* string sr = Tologin(UserName, UserPwd);
                    context.Response.Write(sr);//返回
                    break;*/


                case "Register"://注册

                    string rt = getRegister(UserPwd, Email, yzm);
                    context.Response.Write(rt);//返回*/
                    break;

                case "toMail"://发送邮箱验证码


                     context.Response.Write(TOmain(Email));//返回
                    

                    break;

            }

        }


        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        ///


        //string TOKEN = GetRandomString(18, true, true, true, false, null);

        //随机生成TOKen
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }






        //发送邮箱验证码

        public string TOmain(string mail)
        {
            
            try
            {


              //string sto = "1241058165@qq.com";

                //string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

                string chars = "0123456789";

                Random randrom = new Random((int)DateTime.Now.Ticks);

                string str = "";
                for (int i = 0; i < 6; i++)
                {
                    str += chars[randrom.Next(chars.Length)];//随机生成验证码
                }


                string mtitle = "欢迎您注册！";
                string mcon = "您的验证码为：" + str + "打死也不要告诉别人。(恶意注册封号封IP，请自重。)";


                context.Session[mail] = str;//保存Session key 是邮箱名字


                CEmailSend cs = new CEmailSend();
                bool bol = cs.SendEmail(mail, mtitle, mcon, "", "");

                //收集人地址 标题 内容  “”这个是上传文件的  抄送

                rm.Success = bol;
                if (bol) {
                    rm.Success = true;
                    rm.Info = "发送成功！";
                }
                else
                {
                    rm.Success = false;
                    rm.Info = "发送失败！";
                }

                
                string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                return sresult;

            

                
            }
            catch (Exception)
            {

                rm.Success = false;
                rm.Info = "系统异常！";
                string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                return sresult;

            }


        }


        
        //注册函数
        public string getRegister(string UserPwd, string Email,string yzm)
        {

            try
            {
                //泛型
                List<dbParam> list1 = new List<dbParam>() { 
                      new dbParam(){ ParamName="@UserPwd", ParamValue=UserPwd},//防止sql 注入 
                      new dbParam(){ ParamName="@Email", ParamValue=Email},
                      new dbParam(){ ParamName="@yzm", ParamValue=yzm},
                   };

                if ((string.IsNullOrEmpty(UserPwd) || string.IsNullOrEmpty(Email)) || string.IsNullOrEmpty(yzm))//判断是否为空
                {
                    rm.Info = "必填项不能为空呀，亲！";
                    rm.Success = false;
                    string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                    return sresult;//返回

                }
                else
                { // 都不为空
                    if (yzm.ToString() != context.Session[Email].ToString())//验证邮箱验证码
                    {
                        rm.Info = "邮箱验证码错误了，亲！";
                        rm.Success = false;
                        string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                        return sresult;//返回

                    }
                    else
                    {//正确的情况下


                        //检测用户名是否存在
                        UserInfor Users = UserInforDAL.m_UserInforDal.GetModel("UserEmail=@Email", list1);


                        if (Users == null)//如果不存在
                        {

                            //提交注册开始

                            UserInfor user = new UserInfor();
                            user.Binding = GetRandomString(18, true, true, true, false, null);//随机生成18位
                            user.UserEmail = Email;//用户名
                            user.UserPwd = UserPwd;//密码
                            user.Balance = 0;//余额
                            user.Gender = true;//性别
                            user.Synopsis = "支持小义！！！";//简介
                            user.ChengHao = 0;//称号
                            user.RegTime = DateTime.Now; //注册时间

                            int Num = UserInforDAL.m_UserInforDal.Add(user);//添加


                            rm.Info = "注册成功";
                            rm.Success = true;
                            string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                            return sresult;//返回
                            
                        }
                        else
                        {
                            rm.Info = "该用户名已注册，亲！";
                            rm.Success = false;
                            string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                            return sresult;//返回
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                rm.Info = "系统正在维护中，请稍后再试...";
                rm.Success = false;
                string sresult = jss.Serialize(rm);//吧 rm 对象 转换
                return sresult;//返回

               
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
