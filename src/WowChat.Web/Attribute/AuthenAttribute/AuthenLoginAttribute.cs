using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Mvc.Filters;
using WowChat.Model;

namespace WowChat.Web.Attribute.AuthenAttribute
{
    public class AuthenLoginAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.Session["User"];
            if (user == null)
            {
                // 不能直接这样跳转，见 https://www.lanhusoft.com/Article/73.html
                //filterContext.HttpContext.Response.Redirect("/Account/Logon");
                // 请求的url，登录后自动跳转到之前请求的url
                string returnUrl = filterContext.HttpContext.Request.RawUrl;
                returnUrl = HttpUtility.UrlDecode(returnUrl);
                filterContext.Result = new RedirectResult("/login?returnUrl=" + returnUrl);
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // 这个方法是在Action执行之后调用
        }
    }
}