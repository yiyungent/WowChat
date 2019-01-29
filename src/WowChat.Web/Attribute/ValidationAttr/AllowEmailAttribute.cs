using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WowChat.Web.Attribute.ValidationAttr
{
    /// <summary>
    /// 允许的邮箱:1.邮箱未被注册 2.邮箱格式允许
    /// </summary>
    public class AllowEmailAttribute : ValidationAttribute
    {
        /// <summary>
        /// 允许的邮箱后缀
        /// eg: @qq.com
        /// </summary>
        private List<string> _allowEmailExt;

        public AllowEmailAttribute()
        {
            InitEmailExtList();
        }

        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string email = (string)value;
                // 查询邮箱是否已存在(已被注册)
                if (email == "yiyungent@126.com")
                {
                    // 已存在
                    this.ErrorMessage = "邮箱已被注册";
                    return false;
                }
                else
                {
                    // 不存在---邮箱格式是否允许注册
                    this.ErrorMessage = "请使用常见邮箱，如QQ，163邮箱，该邮箱不被允许";
                    // yiyungent@126.com  ----  @126.com
                    return _allowEmailExt.Contains(email.Substring(email.LastIndexOf('@')));
                }
            }
            else
            {
                return false;
            }
        }

        private void InitEmailExtList()
        {
            _allowEmailExt = new List<string>();
            _allowEmailExt.Add("@qq.com");
            _allowEmailExt.Add("@163.com");
            _allowEmailExt.Add("@126.com");
            _allowEmailExt.Add("@gmail.com");
        }
    }
}