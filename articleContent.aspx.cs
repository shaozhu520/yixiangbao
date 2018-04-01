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
    public partial class articleContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//页面第一次打开的时候调用，后续不会重复调用
            {
                Onew = toobj();//获取文章对象信息
                Users = toUobj();//user
            }
        }
        RNews Onew;//全局用户信息
        UserInfor Users;

        public string toclass()//分类
        {
            try
            {

                return Onew.IsClass.ToString();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public string toTitle()//标题
        {
            try
            {

                return Onew.Title.ToString();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public string zuozhe()//作者
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

        public string toTime()//时间
        {
            StringBuilder tj = new StringBuilder();
            try
            {
                tj.Append(string.Format(@"<span >时间：{0}</span><span >作者：{1}</span><span >围观：{2}</span>", Onew.ReleaseTime, Users.UserName, Onew.lrNumber));

                return tj.ToString();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string toCon()//内容
        {
            try
            {

                return Onew.IsContents.ToString();
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


        public UserInfor toUobj()//获取发帖人 信息
        {

            try
            {

                UserInfor NEW = UserInforDAL.m_UserInforDal.GetModel("Binding='" + Onew.Author + "'");
                return NEW;
            }
            catch (Exception)
            {
                return null;
            }
        }





        private int _Isid;//获取文章ID
        public int Isid//文章ID
        {
            get
            {
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


    }
}