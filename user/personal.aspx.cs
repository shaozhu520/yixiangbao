using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.ruanmou;
using DAL.ruanmou;
using com.DAL.Base;
using System.Text;
using System.Data;
using com.Utility;

namespace vip20170612.user
{
    public partial class personal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //usersTOhtml();
        }
       
        
        
        //获取用户信息
        public string usersTOhtml()
        {
            StringBuilder xinxi = new StringBuilder();

            try
            {
                List<dbParam> list = new List<dbParam>() { 
                    new dbParam(){ ParamName="@Uid", ParamValue=Uid},//泛型 防止sql 注入
                    
                 };

                UserInfor user = UserInforDAL.m_UserInforDal.GetModel("Binding=@Uid", list);


                xinxi.Append(string.Format(@"<div class='HeadPortrait '><img src='../img/user/{0}.png' alt='' /></div>", user.Binding));//
                xinxi.Append(string.Format(@"<div class='username'>{0}<img src='../img/viplogo.png' alt='' /></div>", user.UserName));//
                xinxi.Append(string.Format(@"<div class='datum col-lg-12 col-md-12 col-sm-12'><div class='chenghao col-lg-2 col-md-2 col-sm-2 hidden-xs'><p class='fsize23 lheight'>初来乍到</p><p class='fsize12 lheight18'>称号</p></div>"));//称号
                xinxi.Append(string.Format(@"<div class='Gender col-lg-2 col-md-2 col-sm-2 hidden-xs'>"));//
                xinxi.Append(string.Format(@"<div class='Gender-ic'>"));//性别
                //
                if(user.Gender){
                    xinxi.Append(string.Format(@"<i class=' layui-icon Gender-icon male'>&#xe662;</i>"));//男
                }else{
                    xinxi.Append(string.Format(@"<i  class=' layui-icon Gender-icon female'>&#xe661;</i>"));//女
                }

                xinxi.Append(string.Format(@"</div><p class='fsize12 lheight18'>性别</p></div>"));//
                xinxi.Append(string.Format(@"<div class='btns col-lg-4 col-md-4 col-sm-4 '>"));//
                xinxi.Append(string.Format(@"<div><a class='fsize23 lheight' href='tencent://Message/?Uin={0}&amp;websiteName=www.qq.com&amp;Menu=yes'>联系Ta</a></div>", user.No_qq));//联系方式
                xinxi.Append(string.Format(@"<div><a class='fsize23' href='../'>返回首页</a></div></div>"));//返回首页
                xinxi.Append(string.Format(@"<div class='Included col-lg-2 col-md-2 col-sm-2 hidden-xs'><p class='fsize23 lheight'> 5篇</p><p class='fsize12 lheight18'>收录投稿</p></div>"));//
                xinxi.Append(string.Format(@"<div class='Read col-lg-2 col-md-2 col-sm-2 hidden-xs'><p class='fsize23 lheight'>8975次</p><p class='fsize12 lheight18'>作品被阅读</p></div></div>"));//


                //xinxi.Append(string.Format(@""));//
               

            }
            catch (Exception)
            {
                
                return "网站正在维护中……";
            }


            return xinxi.ToString();
        }

        
        private string _uid;

        public string Uid//获取用户唯一识别码
        {
            get
            {
                try
                {
                    _uid = Request.QueryString["uid"] == null ? null : Request.QueryString["uid"];
                }
                catch (Exception ex)
                {
                    _uid = null;
                }
                return _uid;
            }
            set { _uid = value; }


        }


    }
}