using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.SessionState;

namespace WowChat.Common
{
    /// <summary>
    /// 发送邮件验证码行为 原因
    /// </summary>
    public enum SendReason
    {
        /// <summary>
        /// 重置密码
        /// </summary>
        RPwd,
        /// <summary>
        /// 注册
        /// </summary>
        Reg
    }

    public class EmailVerifyCode : IRequiresSessionState
    {
        public static void SendEmailVerifyCode(string email, SendReason sendReason)
        {
            switch (sendReason)
            {
                case SendReason.RPwd:
                    ForResetPassword(email);
                    break;
                case SendReason.Reg:
                    ForRegAccount(email);
                    break;
                default:
                    break;
            }
        }

        private static void ForResetPassword(string email)
        {
            string mailSubject = email + "正在尝试重置密码";
            string mailContent = string.Empty;
            // 生成随机验证码
            Random r = new Random();
            int vCode = r.Next(11111, 99999);
            mailContent = "您的验证码:" + vCode;
            // 保存到Session["vCode"];
            System.Web.HttpContext.Current.Session["vCode"] = vCode;
            Common.SendEmailAide.SendEmail(email, mailSubject, mailContent);
        }

        private static void ForRegAccount(string email)
        {
            string mailSubject = email + "正在注册账号";
            string mailContent = string.Empty;
            // 生成随机验证码
            Random r = new Random();
            int vCode = r.Next(11111, 99999);
            mailContent = "您的验证码:" + vCode;
            // 保存到Session["vCode"];
            System.Web.HttpContext.Current.Session["vCode"] = vCode;
            Common.SendEmailAide.SendEmail(email, mailSubject, mailContent);
        }
    }
}
