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

namespace vip20170612
{
    public partial class activity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string isclass = "线报活动";

        public int GetRNewsCount()//获取多少条数据
        {
            int i = RNewsDAL.m_RNewsDal.GetCount("IsClass='" + isclass + "'", null);
            return i;
        }


        public string BindRews()//查询函数 返回拼凑好的列表
        {
            StringBuilder sb1 = new StringBuilder();
            try
            {
                //List<RNews> list = RNewsDAL.m_RNewsDal.GetList("NewsClass='线报活动'", pagesize, page, true, "*", "Id", para);




                DataTable dt = RNewsDAL.GetUserScoreTop(isclass, page);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sb1.Append(string.Format(@"1={0},2={1},3={2},4={3},5={4},6={5},7={6},8={7}", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString()));

                    sb1.Append(string.Format(@"<li><div class='thumbnail col-lg-3 col-md-3 col-sm-3 col-xs-3'><img src='{0}' alt=''></div>", dt.Rows[i][3].ToString()));
                    sb1.Append(string.Format(@"<div class='detailed col-lg-9 col-md-9 col-sm-9 col-xs-9'><h3><a target='_blank' href='articleContent.aspx?id={0}'>{1}</a></h3>", dt.Rows[i][8].ToString(), dt.Rows[i][1].ToString()));
                    sb1.Append(string.Format(@"<div class='wztime'><span >时间：{0}</span><span class='hidden-xs'>作者：{1}</span><span class='hidden-xs'>星级：<img src='img/s{2}.gif' alt=''></span>", dt.Rows[i][4].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][5].ToString()));
                    sb1.Append(string.Format(@"<p class='wzxiangxi col-lg-12 col-md-12 col-sm-12 hidden-xs'>{0}</p></div></li>", CRegex.FilterHTML(dt.Rows[i][2].ToString())));

                }


                //sb1.Append(string.Format(@"<li><a target='_blank' href=""/RNewsM.aspx?id={0}"" title=""{3}"">{1}</a><span>{2}</span></li>", i.ID, STitle, i.CreatedTime.ToShortDateString().ToString(), i.Title));


                //GridView1.DataSource = list;
                // GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("网站正在维修中...");
            }

            return sb1.ToString();
        }


        private int pagesize = 10;//一页显示多少条数据
        private int _page;
        List<dbParam> para = new List<dbParam>();

        public int page//当前是第几页
        {
            get
            {
                try
                {
                    _page = Request.QueryString["page"] == null ? 1 : Convert.ToInt32(Request.QueryString["page"].ToString());
                }
                catch (Exception ex)
                {
                    _page = 1;
                }
                return _page;
            }
            set { _page = value; }
        }



        public int GetPageCount()//获取多少页函数 计算有多少页
        {
            try
            {
                int icount = RNewsDAL.m_RNewsDal.GetCount("IsClass='" + isclass + "' and Auditing='true'", null);
                int pagecount = 0;
                if (icount % pagesize == 0)
                {
                    pagecount = icount / pagesize;
                }
                else
                {
                    double d = Convert.ToDouble(icount) / Convert.ToDouble(pagesize);
                    pagecount = Convert.ToInt32(Math.Floor(d)) + 1;
                }
                return pagecount;
            }
            catch (Exception)
            {

                throw;
            }


        }

        



        public string tjgethtml()//排行榜函数
        {
            StringBuilder tj = new StringBuilder();


            try
            {
                List<RNews> listPh = RNewsDAL.m_RNewsDal.GetList("IsClass='线报活动' and Auditing='true' ", 10, 1, true, "ID,Title", "lrNumber");

                int indexs = 1;//索引

                foreach (var i in listPh)
                {

                    //<li><span>1</span><a href="javascript:;" title="淘宝退款不退货语音详细教程">淘宝退款不退货语音详细教程</a></li>

                    tj.Append(string.Format(@"<li><span>{0}</span><a href='articleContent.aspx?id={1}' title='{2}'>{2}</a></li>", indexs.ToString(), i.ID, i.Title));//尾都一样的

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