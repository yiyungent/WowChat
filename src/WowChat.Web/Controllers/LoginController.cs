using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WowChat.IBLL;
using WowChat.Model;

namespace WowChat.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUser_infoService User_InfoService = new BLL.User_infoService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            //return Json(new { code = -2, message="test" });
            password = Common.MD5Helper.MD5Encrypt32(password);

            // 1.滑动验证码 二次验证
            string message = string.Empty;
            bool isPass = Common.VerifyCode.SecondVerifyCode(Request.Form["ticket"], Request.Form["randStr"], Request.UserHostAddress, out message);
            if (!isPass)
            {
                // 验证码错误
                return Json(new { code = -2, message });
            }
            // 验证通过
            // 2.查询是否存在此用户
            User_info user_Info = this.User_InfoService.GetByPhoneOrEmail(userName);
            if (user_Info == null)
            {
                // 不存在返回提示
                return Json(new { code = -1, message = "用户不存在,检查或前往注册" });
            }
            else
            {
                // 存在此用户 - 效验密码 - 返回结果
                if (user_Info.password != password)
                {
                    return Json(new { code = -1, message = "用户名或密码错误" });
                }
                else
                {
                    Session["User"] = user_Info;
                    return Json(new { code = 1, message = "登录成功" });
                }
            }
        }


        public ActionResult FindPassword()
        {
            return View();
        }
    }
}