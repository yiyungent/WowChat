using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WowChat.Web.Attribute.AuthenAttribute;

namespace WowChat.Web.Controllers
{
    public class SpaceController : Controller
    {
        #region 个人空间视图
        [AuthenLogin]
        public ActionResult Index()
        {
            return View();
        } 
        #endregion
    }
}