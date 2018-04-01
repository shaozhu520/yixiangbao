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

namespace vip20170612.user
{
    public partial class User_tg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session 方法
            if (Session["userkey"] != null)
            {
                string key = Session["userkey"].ToString();//用户唯一识别码 初始化


                if (!IsPostBack)//页面第一次打开的时候调用，后续不会重复调用
                {
                    //BindRews();
                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}