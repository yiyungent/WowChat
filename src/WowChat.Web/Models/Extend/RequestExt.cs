using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WowChat.Web.Models.Extend
{
    public static class RequestExt
    {
        /// <summary>
        /// 指定的HTTP 请求是否是一个 PJAX请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns>是 PJAX返回 True</returns>
        public static bool IsPjaxRequest(this HttpRequestBase request)
        {
            if (!string.IsNullOrEmpty(request.Headers["X-PJAX"]) && Convert.ToBoolean(request.Headers["X-PJAX"]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}