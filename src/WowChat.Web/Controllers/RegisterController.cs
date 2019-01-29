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
        private IUser_infoService _user_InfoService = new BLL.User_infoService();

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
            string rightVCode = Session["vCode"] == null ? string.Empty : Session["vCode"].ToString();
            // 效验过一次后失效
            Session["vCode"] = null;
            if (rightVCode == vCode)
            {
                // 邮箱验证码正确
                User_info user_Info = new User_info
                {
                    Name = nickName,
                    Password = Common.MD5Helper.MD5Encrypt32(password),
                    Email = email,
                    Create_time = DateTime.Now,
                    Group_id = (int)Models.Enum.User_group_id.Member,
                    Login_ip = Request.UserHostAddress,
                    Login_time = DateTime.Now,
                    Logins = 1
                };
                bool isSuccess = _user_InfoService.RegUser(user_Info);
                if (isSuccess)
                {
                    return Json(new { code = 1, message = "注册成功" });
                }
                else
                {
                    return Json(new { code = -1, message = "注册失败" });
                }
            }
            else
            {
                // 邮箱验证码不正确
                return Json(new { code = -1, message = "邮箱验证码不正确，请重新获取" });
            }
        }
        #endregion

        #region 检查邮箱
        [HttpPost]
        public ActionResult CheckEmail(string email)
        {
            // 检查邮箱是否可以注册
            WowChat.Web.Attribute.ValidationAttr.AllowEmailAttribute allowEmailAttribute = new Attribute.ValidationAttr.AllowEmailAttribute();
            bool isAllow = allowEmailAttribute.IsValid(email);
            string errorMsg = allowEmailAttribute.ErrorMessage;
            if (isAllow)
            {
                return Json(new { code = 1, message = "此邮箱可以注册" });
            }
            else
            {
                return Json(new { code = -1, message = errorMsg });
            }
        }
        #endregion

        #region 是否已经存在(注册)此邮箱
        /// <summary>
        /// 不存在此邮箱(未被注册)
        /// </summary>
        /// <param name="email"></param>
        /// <returns>不存在(未被注册)返回true</returns>
        public JsonResult NotExistEmail(string email)
        {
            // 查询此邮箱是否已被注册
            if (email == "yiyungent@126.com")
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 获取邮箱验证码
        [HttpPost]
        public ActionResult GetEmailVCode(Models.Request.EmailVCode emailVCode)
        {
            if (ModelState.IsValid)
            {
                // 二次效验 滑动验证票据
                bool isPass = Common.VerifyCode.SecondVerifyCode(emailVCode.Ticket, emailVCode.RandStr, Request.UserHostAddress, out string msg);
                if (isPass)
                {
                    // 效验通过 -- 向邮箱发送邮件验证码---返回提示 "验证码已发送，5分钟内有效"
                    _user_InfoService.SendEmailVCode4Reg(emailVCode.Email);
                    return Json(new { code = 1, message = "验证码已发送，5分钟内有效" });
                }
                else
                {
                    // 效验不通过 -- 返回提示
                    return Json(new { code = -1, message = "验证不通过，或验证已过期，请重新验证" });
                }
            }
            else
            {
                // 1.邮箱已被注册 2.不被允许的邮箱格式
                var emailModelState = ModelState.Where(a => a.Key == "Email").FirstOrDefault();
                string errorMsg = emailModelState.Value.Errors.FirstOrDefault().ErrorMessage;
                return Json(new { code = -1, message = errorMsg });
            }
        }
        #endregion
    }
}