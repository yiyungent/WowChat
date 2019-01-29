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

        Dictionary<string, string> EmailDic { get; set; }

        public LoginController()
        {
            InitEmailDic();
        }

        #region 初始化邮件地址数据
        private void InitEmailDic()
        {
            this.EmailDic = new Dictionary<string, string>();
            this.EmailDic.Add("126.com", "mail.126.com");
            this.EmailDic.Add("qq.com", "mail.qq.com");
            this.EmailDic.Add("163.com", "www.163.com");
        }
        #endregion

        #region 登录视图
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return Redirect("/");
            }
            return View();
        }
        #endregion

        #region 登录验证
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
                if (user_Info.Password != password)
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
        #endregion

        #region 找回密码视图
        public ActionResult FindPassword()
        {
            return View();
        }
        #endregion

        #region 滑动二次验证
        /// <summary>
        /// 滑动二次验证(目前此方法仅用于找回密码时验证)
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="randStr"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VerifyCode(string ticket, string randStr, string action)
        {
            string[] actions = action.Split('|');
            string ip = Request.UserHostAddress;
            string message = string.Empty;
            if (Common.VerifyCode.SecondVerifyCode(ticket, randStr, ip, out message))
            {
                // 验证通过
                // 根据用户的邮箱类型返回不同的邮箱查看地址
                // ewffnrwf@126.com --->  126.com
                string emailType = actions[1].Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries)[1];
                string emailLoginAddress = EmailDic[emailType];
                // 邮件验证码
                Common.EmailVerifyCode.SendEmailVerifyCode(actions[1], Common.SendReason.RPwd);
                return Json(new { code = 1, message = $"验证码短信/邮件已发出，5分钟内有效，请注意<a target=\"_blank\" href=\"//{emailLoginAddress}\" style=\"font-size: 14px;\">查收</a>" });
            }
            else
            {
                // 验证不通过
                return Json(new { code = -1, message = "滑动验证不通过或失效，请重新验证" });
            }
        }
        #endregion

        #region 重置密码
        [HttpPost]
        public ActionResult ResetPwd(string userName, string password, string vCode)
        {
            // 效验验证码
            string inputVCode = vCode;
            string rightVCode = Session["vCode"] != null ? Session["vCode"].ToString() : "";
            // 使用一次后使其立即失效
            Session["vCode"] = null;
            if (inputVCode == rightVCode)
            {
                // 验证通过
                // 更改密码
                this.User_InfoService.EditPwdByEmail(userName, Common.MD5Helper.MD5Encrypt32(password));
                return Json(new { code = 1, message = "密码重置成功，请前往登录" });
            }
            else
            {
                return Json(new { code = -1, message = "验证码错误，请重新获取并填写" });
            }
        }
        #endregion
    }
}