using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WowChat.Web.Models
{
    public class EmailVCode
    {
        [Required(ErrorMessage = "邮箱不能为空")]
        public string Email { get; set; }

        [Required(ErrorMessage = "请通过滑动验证")]
        public string Ticket { get; set; }

        [Required(ErrorMessage = "请通过滑动验证")]
        public string RandStr { get; set; }
    }
}