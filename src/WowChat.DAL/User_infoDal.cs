using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowChat.IDAL;
using WowChat.Model;
using System.Data.SqlClient;
using System.Data;

namespace WowChat.DAL
{
    public class User_infoDal : BaseDal<User_info>, IUser_infoDal
    {
        public int Add()
        {
            throw new NotImplementedException();
        }

        public List<User_info> GetList()
        {
            throw new NotImplementedException();
        }

        public User_info GetByPhoneOrEmail(string phoneOrEmail)
        {
            string sql = @"SELECT [id]
                                ,[group_id]
                                ,[name]
                                ,[password]
                                ,[email]
                                ,[phone]
                                ,[avatar]
                                ,[create_time]
                                ,[login_time]
                                ,[login_ip]
                                ,[logins]
                                ,[score]
                                ,[status]
                                ,[remark]
                            FROM [dbo].[user_info]
                            WHERE [email] = @phoneOrEmail OR [phone] = @phoneOrEmail";
            SqlParameter par = new SqlParameter("@phoneOrEmail", SqlDbType.VarChar);
            par.Value = phoneOrEmail;
            DataTable dt = MSSQLAide.Query(sql, par);
            User_info user_Info = null;
            if (dt.Rows.Count > 0)
            {
                user_Info = Utils.dataTable2List<User_info>(dt)[0];
            }
            return user_Info;
        }
    }
}
