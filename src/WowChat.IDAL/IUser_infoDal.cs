using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowChat.Model;

namespace WowChat.IDAL
{
    public interface IUser_infoDal : IBaseDal<User_info>
    {
        List<Model.User_info> GetList();

        int Add();
    }
}
