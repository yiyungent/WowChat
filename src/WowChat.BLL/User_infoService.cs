using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowChat.IBLL;
using WowChat.IDAL;
using WowChat.Model;

namespace WowChat.BLL
{
    public class User_infoService : IUser_infoService
    {
        private IUser_infoDal _dal;

        public User_infoService(IUser_infoDal dal)
        {
            _dal = dal;
        }

        public List<User_info> GetList()
        {
            return _dal.GetList();
        }
    }
}
