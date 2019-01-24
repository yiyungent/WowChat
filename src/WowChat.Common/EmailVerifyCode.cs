using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.SessionState;

namespace WowChat.Common
{
    public class EmailVerifyCode : IRequiresSessionState
    {
        public static void SendEmailVerifyCode(string email, string action)
        {
            switch (action)
            {
                case "rpwd":
                    ForResetPassword(email);
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
    }
}
