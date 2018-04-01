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

namespace vip20170612.user.js
{
    public partial class index : System.Web.UI.Page
    {
        string key;//唯一识别码
        UserInfor newUsrer;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session 方法
            if (Session["userkey"] != null)
            {
                key = Session["userkey"].ToString();//用户唯一识别码 初始化


                if (!IsPostBack)//页面第一次打开的时候调用，后续不会重复调用
                {
                    //BindRews();
                }
                //Response.Write(GetRNewsCount());


                toUser();//初始化用户信息
                

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }


        public void toUser() //初始化用户信息
        {
            try
            {

                UserInfor Use = UserInforDAL.m_UserInforDal.GetModel("Binding='" + key + "'", null);//获取用户对象

                newUsrer = Use;//赋值给全局

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public string tonicheng() //获取用户名
        {
            try
            {

                return newUsrer.UserName.ToString();//返回用户名
            }
            catch (Exception)
            {
                return "游客";//返回用户名
                
            }
        }


        public string toBalance() //获取余额
        {
            try
            {

                return newUsrer.Balance.ToString();//返回余额
            }
            catch (Exception)
            {

                return "0";//返回用户名
            }
        }

        public string toqiandao() //签到状态
        {
            
            try
            {
                //立即签到
                bool isqiandao = newUsrer.Sign;

                if (isqiandao) { 
                    return "立即签到";//返回签到的状态
                }else{
                    return "已签到";//返回签到的状态
                }

                
            }
            catch (Exception)
            {

                return "立即签到";//返回用户名
            }
        }


        public string tojianjie() //签到状态
        {

            try
            {
                
                string SynopsisTex = newUsrer.Synopsis;

                if (SynopsisTex != null)
                {
                    return SynopsisTex;//返回
                }
                else
                {
                    return "什么也没有留下";//返回
                }


            }
            catch (Exception)
            {

                return "什么也没有留下";//返回用户名
            }
        }


        public string toGender() //性别
        {
            StringBuilder sb1 = new StringBuilder();
            try
            {

                bool xingbie = newUsrer.Gender;

                if (xingbie)
                {
                    sb1.Append(string.Format(@"<i class='fr layui-icon Gender-icon male'>&#xe662;</i>"));//女
                }
                else
                {
                    sb1.Append(string.Format(@"<i  class='fr layui-icon Gender-icon female'>&#xe661;</i>"));//男
                }

                return sb1.ToString();//返回代码

            }
            catch (Exception)
            {
                sb1.Append(string.Format(@"<i  class='fr layui-icon Gender-icon female'>&#xe661;</i>"));//男
                return sb1.ToString();//返回代码
            }
        }

        public string toEmail() //返回邮箱号码
        {

            try
            {
                //UserEmail
                //
               
                return newUsrer.UserEmail.ToString();//邮箱

            }
            catch (Exception)
            {

                return "奇怪你怎么没有绑定邮箱?";//返回用户名
            }
        }

        //返回QQ 
        public string toQQ() //返回邮箱号码
        {
            StringBuilder sb2 = new StringBuilder();
            try
            {
                //No_qq
                string qq = newUsrer.No_qq.ToString();

                if (qq == null)
                {
                    sb2.Append(string.Format(@"<a class='fr' href='javascript:;'>立即绑定</a>"));//没有设置的情况下
                    
                }else{
                    sb2.Append(string.Format(@"<p class='fr'>{0}</p>", qq));//设置的去情况下

                }


                return sb2.ToString();//QQ

            }
            catch (Exception)
            {
                sb2.Append(string.Format(@"<a class='fr' href='javascript:;'>立即绑定</a>"));//没有设置的情况下
                return sb2.ToString();//QQ
            }
        }


        public string toRegTime() //返回注册时间
        {

            try
            {

                return newUsrer.RegTime.ToString();//返回注册的时间

            }
            catch (Exception)
            {

                return null;//返回null
            }
        }

    }
}