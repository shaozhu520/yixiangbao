//验证权限的JS

var Name = $.cookie("Token-Name");//获取

if (Name != null) {


} else {
    window.location.href = "../admin_login.html";
}



