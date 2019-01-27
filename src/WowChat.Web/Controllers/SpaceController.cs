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
            if (!string.IsNullOrEmpty(Request.Headers["X-PJAX"]) && Convert.ToBoolean(Request.Headers["X-PJAX"]))
            {
                // pjax
                string htmlStr = $"<h3>Headers[\"X-PJAX\"]：{Request.Headers["X-PJAX"]}</h3>";
                htmlStr += $"<h5>测试pjax---{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}</h5>";
                return Content(htmlStr);
            }
            return View();
        }
        #endregion
    }
}