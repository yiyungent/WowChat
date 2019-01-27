using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WowChat.Model;
using WowChat.IBLL;

namespace WowChat.Web.ModelExt
{
    public static class User_infoExt
    {
        public static Group_info Group_Info(this User_info user_Info, IGroup_infoService group_InfoService)
        {
            //IGroup_infoService group_InfoService = new BLL.Group_infoService();
            return group_InfoService.GetByUserId(user_Info.Id.ToString());
        }
    }
}