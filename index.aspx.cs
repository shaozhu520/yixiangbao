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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getNewslist()//今日更新
        {
            StringBuilder newshtml = new StringBuilder();

            try
            {



                List<RNews> Nlist = RNewsDAL.m_RNewsDal.GetList("Auditing='true'", 28, 1, true, "Id,Title,Author,IsClass,ReleaseTime", "ReleaseTime");


                newshtml.Append("<ul>");//加html ul 前面的标签
                foreach (var i in Nlist)
                {
                    if (i.IsClass == "教程软件")//教程是特殊的
                    {
                        newshtml.Append(string.Format(@"<li> <a style='display: inline-block;' class='Article-HeadPortrait fl' target='_blank' href='user/personal.aspx?uid={0}' ><img src='img/user/{0}.png' alt='' /></a><div class='Article-title'><a target='_blank' href='Course.aspx?id={3}' title='{1}'>{1}</a></div><div class='Article-Date'>{2}</div></li>", i.Author, i.Title, i.ReleaseTime.ToShortDateString().ToString(), i.ID));

                    }else {
                        newshtml.Append(string.Format(@"<li> <a style='display: inline-block;' class='Article-HeadPortrait fl' target='_blank' href='user/personal.aspx?uid={0}' ><img src='img/user/{0}.png' alt='' /></a><div class='Article-title'><a target='_blank' href='articleContent.aspx?id={3}' title='{1}'>{1}</a></div><div class='Article-Date'>{2}</div></li>", i.Author, i.Title, i.ReleaseTime.ToShortDateString().ToString(), i.ID));
                    }

                    
                }
                newshtml.Append("</ul>");//加html ul 后面的的标签
            }
            catch (Exception e)
            {
                
                //throw;
            }

            return newshtml.ToString();
        }

        //三个分类共同使用函数
        public string GetPageHtml(string Class,string qianzhui)//分页函数 调用返回拼凑好的集合 传的是分类
        {
            StringBuilder sb1 = new StringBuilder();

            try
            {
                //<li><a href="javascript:;">淘宝退款不退货语音详细教程<span></span></a></li>


                //List<RNews> list = RNewsDAL.m_RNewsDal.GetList("NewsClass= '" + Class + "'", 8, 1, true, "Id,Title,CreatedTime,NewsClass", "Id");

                List<RNews> list = RNewsDAL.m_RNewsDal.GetList("IsClass= '" + Class + "'", 10, 1, true, "Id,Title,IsClass", "ID");

                foreach (var i in list)
                {

                    //DataTime istime = i.CreatedTime;
                    //sb1.Append(string.Format(@"<li><a target='_blank' href=""/RNewsM.aspx?id={0}"" title=""{3}"">{1}</a><span>{2}</span></li>", i.ID, STitle, i.CreatedTime.ToShortDateString().ToString(), i.Title));

                    sb1.Append(string.Format(@"<li><a target='_blank' href='{2}?id={0}'><strong>{1}</strong><span></span></a></li>", i.ID, i.Title, qianzhui));
                }




            }
            catch (Exception ex)
            {
                Response.Write("网站正在维修中...");
            }

            return sb1.ToString();
        }



        

        public string jiaochengGetHtnl()//
        {
            string thml = GetPageHtml("教程软件", "Course.aspx");

            return thml;
        }

        public string xbGetHtnl()//线报活动
        {
            string thml = GetPageHtml("线报活动", "articleContent.aspx");

            return thml;
        }

        public string wzGetHtnl()
        {
            string thml = GetPageHtml("其他文章", "articleContent.aspx");

            return thml;
        }


        public string phbgethtml()//排行榜函数
        {
            StringBuilder ph = new StringBuilder();


            try
            {
                List<UserInfor> listPh = UserInforDAL.m_UserInforDal.GetList("1=1", 12, 1, true, "Binding,UserName", "Included");

                int index = 1;//索引

                foreach (var i in listPh)
                {

                    //<li class="col-lg-1 col-md-2 col-sm-2 col-xs-3" >


                    //DataTime istime = i.CreatedTime;
                    //sb1.Append(string.Format(@"<li><a target='_blank' href=""/RNewsM.aspx?id={0}"" title=""{3}"">{1}</a><span>{2}</span></li>", i.ID, STitle, i.CreatedTime.ToShortDateString().ToString(), i.Title));

                    //ph.Append(string.Format(@"<li><a href='articleContent.html?userid={0}'>{1}<span></span></a></li>", i.ID, i.Title));

                    if (index <= 4)
                    {
                        //<li class="col-lg-1 col-md-2 col-sm-2 col-xs-3" ><img class="InTheList" src="img/0_hate.png" alt="" /><a  href="javascript:;">

                        ph.Append(string.Format(@"<li class='col-lg-1 col-md-2 col-sm-2 col-xs-3' ><img class='InTheList' src='img/{0}_hate.png' alt='' />", (index - 1).ToString()));//拼凑头

                    }else if(index > 4 && index<=6){
                        //<li class="col-lg-1 col-md-2 col-sm-2 col-xs-3">
                        ph.Append(string.Format(@"<li class='col-lg-1 col-md-2 col-sm-2 col-xs-3'>"));//拼凑头
                    }
                    else if (index > 6 && index <= 8)
                    {
                        //<li class="col-lg-1 visible-lg visible-xs col-xs-3">
                        ph.Append(string.Format(@"<li class='col-lg-1 visible-lg visible-xs col-xs-3'>"));//拼凑头
                    }
                    else
                    {
                        //<li class="col-lg-1 visible-lg">
                        ph.Append(string.Format(@"<li class='col-lg-1 visible-lg'>"));//拼凑头
                    }


                    ph.Append(string.Format(@"<a target='_blank'  href='user/personal.aspx?uid={0}'><div class='RankingList-con-img'><img class='tximg' src='img/user/{0}.png' alt='' /></div><div class='RankingList-con-name'><p>{1}</p></div></a></li>", i.Binding, i.UserName));//尾都一样的

                    index++;//递增
                }

            }
            catch (Exception)
            {
                
                //throw;
                return "网站正在维护中……";
            }

            return ph.ToString();
        }


        //排行榜和商品推荐开始
        public string rmphbTOhtml()
        {
            StringBuilder rmph = new StringBuilder();
            try
            {
                List<RNews> listrmph = RNewsDAL.m_RNewsDal.GetList("Auditing='true'", 10, 1, true, "Title,ID", "lrNumber");

                int j = 1;

                foreach (var i in listrmph)
                {
                    rmph.Append(string.Format(@"<li><span>{0}</span><a href='articleContent.html?userid={1}'>{2}</a></li>", j.ToString(),i.ID, i.Title));

                    j++;
                }
            }
            catch (Exception)
            {

                return "网站正在维护中……";
            }
            return rmph.ToString();
        }



        public string gxtxTOhtml()//获取个性头像
        {
            StringBuilder gxtx = new StringBuilder();
            try
            {
                List<RNews> listgxtx = RNewsDAL.m_RNewsDal.GetList("Isclass='唯美头像' and Auditing='true'", 12, 1, true, "ID,Title,Thumbnail", "ReleaseTime");

                int n = 1;

                foreach (var i in listgxtx)
                {
                    //<li class="hidden-md"><a href="javascript:;"><img src="img/489fe2b704be1bf0d6078801675db62e.jpg" alt="" /><p>背影头像女生长头发小清新2018 你的眼睛酷似星辰</p></a></li>
                    
                    if(n<=8){
                        gxtx.Append(string.Format(@"<li><a target='_blank' href='articleContent.aspx?id={0}'><img src='{1}' alt'' /><p>{2}</p></a></li>", i.ID, i.Thumbnail, i.Title));
                    }else{
                        gxtx.Append(string.Format(@"<li class='hidden-md'><a target='_blank' href='articleContent.aspx?id={0}'><img src='{1}' alt'' /><p>{2}</p></a></li>", i.ID, i.Thumbnail, i.Title));
                    }

                    

                    n++;
                }
            }
            catch (Exception)
            {

                return "网站正在维护中……";
            }
            return gxtx.ToString();
        }

        //头像排行榜
        public string txListTOhtml()//获取个性头像
        {
            StringBuilder txList = new StringBuilder();
            try
            {
                List<RNews> listtxList = RNewsDAL.m_RNewsDal.GetList("Isclass='唯美头像' and Auditing='true'", 7, 1, true, "ID,Title", "ReleaseTime");

                int sy = 1;
                

                foreach (var i in listtxList)
                {
                    //<li class="hidden-md"><a href="javascript:;"><img src="img/489fe2b704be1bf0d6078801675db62e.jpg" alt="" /><p>背影头像女生长头发小清新2018 你的眼睛酷似星辰</p></a></li>
                    txList.Append(string.Format(@"<li class='col-lg-12 col-ma-12 col-sm-6'><span>{0}</span><a target='_blank' href='articleContent.aspx?id={1}'>{2}</a></li>", sy.ToString(), i.ID, i.Title));

                    sy++;
                }
            }
            catch (Exception)
            {

                return "网站正在维护中……";
            }
            return txList.ToString();
        }


        //获取友情链接
        
        public string TOlinks()
        {
            StringBuilder linkList = new StringBuilder();

            try
            {
                List<Flink> listtxList = FlinkDAL.m_FlinkDal.GetList("1=1", 10, 1, true, "SerialNumber,Name,URLLink", "SerialNumber");

                foreach (var i in listtxList)
                {

                    linkList.Append(string.Format(@"<li><a target='_blank' href='{0}' title='{1}'>{1}</a></li>", i.URLLink, i.Name));

                   
                }

            }
            catch (Exception)
            {

                return "网站正在维护中……";
            }

            return linkList.ToString();
        }

    }
}