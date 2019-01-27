using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowChat.Model;

namespace WowChat.IBLL
{
    public interface IGroup_infoService
    {
        Group_info GetByUserId(string id);
    }
}
