
//$(function () {

    var ID =  GetQueryString("id");

    //var id = "10";


    fn1(ID);


   
//});




function fn1(sid) {//ajax //修改内容


    $.get("/RNewsM.ashx", "id=" + sid, function (data) {//提交get




        var data = JSON.parse(data);//将json 转换成 对象

        //alert(data.Data[0].Text);
        $("#Pseudonym").append(data.Data[0].Pseudonym);//笔名
        $("title").append(data.Data[0].Title+"--星火公益传承");//首页标题
        $("#Titles").append(data.Data[0].Title);//标题
        $("#Texts").append(data.Data[0].Text);//内容
        $("#NewsClass").append(data.Data[0].NewsClass);//分类
        $("#ViewCount").append(" 一共被浏览了" + data.Data[0].ViewCount + "次");//浏览数


        //alert(data.Data[0].CreatedTime);

        var s = data.Data[0].CreatedTime//乱码的时间

        var data1 = s.substring(6, 16)//截取

        var tiems =  getLocalTime(data1)//转换
        

        $("#CreatedTime").html(tiems);

        //$("#son").append(data.Data[0].NewsClass)

        $("#son").html(data.Data[0].NewsClass);
        
        //二级菜单
        var link = { "楞严咒": "Buddhism.aspx", "戒色文章": "Article.aspx", "不净观": "Impure.aspx" };//对象
        var url;
        switch (data.Data[0].NewsClass) {
            case "楞严咒":
                url = link.楞严咒;
                break;
            case "戒色文章":
                url = link.戒色文章;
                break;
            case "不净观":
                url = link.不净观;
                break;

            default:
                url = "index.aspx";
                break;
        }
        $("#son").attr('href', url);



    });
};

function GetQueryString(name) {//获取URL上的参数
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function getLocalTime(nS) {//时间转换函数
    return new Date(parseInt(nS) * 1000).toLocaleString().substr(0, 17)
}