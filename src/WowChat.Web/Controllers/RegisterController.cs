using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WowChat.IBLL;
using WowChat.Model;

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
        public ActionResult ExistEmail(string email)
        {
            return Json(new { code = 1, message = "此邮箱已被注册" });
        }
        #endregion
    }
}