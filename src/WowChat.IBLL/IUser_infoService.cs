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
    }
}
