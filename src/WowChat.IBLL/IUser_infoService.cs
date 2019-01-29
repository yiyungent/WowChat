using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowChat.Model;

namespace WowChat.IBLL
{
    public interface IUser_infoService
    {
        List<User_info> GetList();

        User_info GetByPhoneOrEmail(string phoneOrEmail);

        bool EditPwdByEmail(string email, string password);

        void SendEmailVCode4Reg(string email);

        bool RegUser(User_info user_Info);
    }
}
