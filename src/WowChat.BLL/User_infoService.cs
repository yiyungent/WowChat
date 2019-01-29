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
        private IUser_infoDal _dal = new DAL.User_infoDal();

        public User_infoService()
        {
        }

        public List<User_info> GetList()
        {
            return _dal.GetList();
        }

        public User_info GetByPhoneOrEmail(string phoneOrEmail)
        {
            return this._dal.GetByPhoneOrEmail(phoneOrEmail);
        }

        public bool EditPwdByEmail(string email, string password)
        {
            return _dal.EditPwdByEmail(email, password) > 0;
        }

        public void SendEmailVCode4Reg(string email)
        {
            Common.EmailVerifyCode.SendEmailVerifyCode(email, Common.SendReason.Reg);
        }

        public bool RegUser(User_info user_Info)
        {
            return _dal.Insert(user_Info) > 0;
        }
    }
}
