using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WowChat.IBLL;
using WowChat.Model;
using WowChat.Web.Models;

namespace WowChat.Web.Controllers
{
    public class RegisterController : Controller
    {
        #region 注册视图
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 注册API
        [HttpPost]
        public ActionResult Index(string nickName, string password, string email, string vCode)
        {
            User_info user_Info = new User_info();
            return Json(new { code = 1, message = "" });
        }
        #endregion

        #region 存在邮箱吗
        [HttpPost]
        public ActionResult CheckEmail(string email)
        {
            if (email == "yiyungent@126.com")
            {
                return Json(new { code = -1, message = "此邮箱已被注册" });
            }
            else
            {
                return Json(new { code = 1, message = "此邮箱可以注册" });
            }
        }
        #endregion

        #region 获取邮箱验证码
        [HttpPost]
        public ActionResult GetEmailVCode(EmailVCode emailVCode)
        {
            if (ModelState.IsValid)
            {
                // 效验 滑动验证票据
                // 效验通过 -- 向邮箱发送邮件验证码
                // 效验不通过 -- 返回提示
            }
            else
            {
                // 返回错误提示
            }
            return Json(new { code = 1, message = "测试" });
        }
        #endregion
    }
}