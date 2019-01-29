using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WowChat.Web.Attribute.ValidationAttr;

namespace WowChat.Web.Models.Request
{
    public class EmailVCode
    {
        [Required(ErrorMessage = "邮箱不能为空")]
        // 不知为何Remote 无效,所以启用此方法
        //[Remote("NotExistEmail", "Register", ErrorMessage = "该邮箱已被注册")]
        [AllowEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "请通过滑动验证")]
        public string Ticket { get; set; }

        [Required(ErrorMessage = "请通过滑动验证")]
        public string RandStr { get; set; }
    }
}