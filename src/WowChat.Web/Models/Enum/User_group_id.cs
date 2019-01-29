using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WowChat.Web.Models.Enum
{
    /// <summary>
    /// 用户组编号
    /// </summary>
    public enum User_group_id
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        Admin = 1,
        /// <summary>
        /// 网站管理员
        /// </summary>
        Manager = 2,
        /// <summary>
        /// 注册会员
        /// </summary>
        Member = 3,
        /// <summary>
        /// 游客
        /// </summary>
        Guest = 4
    }
}