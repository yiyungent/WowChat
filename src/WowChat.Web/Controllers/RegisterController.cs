using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}