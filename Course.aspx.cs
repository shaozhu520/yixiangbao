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

namespace vip20170612
{
    public partial class Course : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//页面第一次打开的时候调用，后续不会重复调用
            {
                Onew = toobj();//获取文章对象信息
            }
        }

        RNews Onew;//全局用户信息


        //取得标题
        public string totitle() {
            try
            {
                return Onew.Title.ToString();
            }
            catch (Exception)
            {

                return null;
            }

            
        }
        
        //取得大小
        public string toTsize()
        {
            try
            {
                return Onew.Tsize.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        //取得更新日期
        public string toNewTime()
        {
            try
            {
                return Onew.ReleaseTime.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public string ToXingji() //星级
        {
            try
            {
                return Onew.Star.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public string xiazaiSum() //下载数量
        {
            try
            {
                return Onew.NStatistics.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }
        public string tojianjie() //教程简介
        {
            try
            {
                return Onew.Abstract.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public string xiazaiurl() //下载地址
        {
            try
            {
                return Onew.Download.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        //获取用户头像
        public string touxiang() //下载地址
        {
            try
            {
                return Onew.Author.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public string ToUsername() {//获取用户名那些
            StringBuilder sb1 = new StringBuilder();

            try
            {
                UserInfor User = UserInforDAL.m_UserInforDal.GetModel("Binding='" + Onew.Author + "'");


                sb1.Append(string.Format(@"<div class='xiazai-tx-text col-lg-6 col-md-6 col-sm-6 col-xs-6 fr'>"));
                sb1.Append(string.Format(@"<h4 class='neicheng'>{0}", User.UserName));
                if (User.Gender)
                {
                    sb1.Append(string.Format(@"<i class='layui-icon male'>&#xe662;</i>"));//男
                }else{
                    sb1.Append(string.Format(@"<i class='layui-icon female'>&#xe661;</i>"));//女
                }
                sb1.Append(string.Format(@"</h4><a target='_blank' class='chakanzz col-sm-8 col-xs-12' href='user/personal.aspx?uid={0}'>查看作者</a></div>", User.Binding));
                


                //sb1.Append(string.Format(@"<h4 class='neicheng'>初心 <i class='layui-icon male'>&#xe662;</i><i class='layui-icon female'>&#xe661;</i></h4>'>"));


                return sb1.ToString();
            }
            catch (Exception)
            {

                return "网站正在维护中……";
            }
        }


        //缩略图
        public string toThumbnail() {
            try
            {
                return Onew.Thumbnail.ToString();
            }
            catch (Exception)
            {

                return null;
            }
            
        }



        public RNews toobj()//获取文章对象的函数
        {

            try
            {
                //List<RNews> listPh = RNewsDAL.m_RNewsDal.GetModel("ID=@Isid", list);//获取文章对象
                List<dbParam> list = new List<dbParam>() { 
                    new dbParam(){ ParamName="@ID", ParamValue=Isid},//泛型 防止sql 注入
                 };

                RNews NEW = RNewsDAL.m_RNewsDal.GetModel("ID=@ID and Auditing='true'", list);
                return NEW;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string toid() {
            return Isid.ToString();   
        }


        
        private int _Isid;//获取文章ID
        public int Isid//文章ID
        {
            get {
                try
                {
                    _Isid = Request.QueryString["id"] == null ? 2 : Convert.ToInt32(Request.QueryString["id"]);
                }
                catch (Exception)
                {
                    _Isid = 2;
                    throw;
                }

                return _Isid; 
            
            }
            set { _Isid = value; }
        }


        //排行榜
        public string tjgethtml()//排行榜函数
        {
            StringBuilder tj = new StringBuilder();


            try
            {
                List<RNews> listPh = RNewsDAL.m_RNewsDal.GetList("IsClass='教程软件' and Auditing='true'", 10, 1, true, "ID,Title", "lrNumber");

                int indexs = 1;//索引

                foreach (var i in listPh)
                {

                    //<li><span>1</span><a href="javascript:;" title="淘宝退款不退货语音详细教程">淘宝退款不退货语音详细教程</a></li>

                    //tj.Append(string.Format(@"<li><span>{0}</span><a href='articleContent.html?userid={1}' title='{2}'>{2}</a></li>", indexs.ToString(), i.ID, i.Title));//尾都一样的

                    tj.Append(string.Format(@"<li class='col-lg-12 col-md-12 com-sm-12 col-xs-12'><span>{0}</span><a href='Course.aspx?id={1}'>{2}</a></li>", indexs.ToString(),i.ID,i.Title));

                    indexs++;//递增
                }

            }
            catch (Exception)
            {

                //throw;
                return "网站正在维护中……";
            }

            return tj.ToString();
        }

    }
}