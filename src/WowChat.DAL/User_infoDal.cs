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

        public int EditPwdByEmail(string email, string password)
        {
            string sql = @"UPDATE [dbo].[user_info] SET [password]=@password
                           WHERE [email]=@email";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@password", SqlDbType.VarChar),
                new SqlParameter("@email", SqlDbType.NVarChar)
            };
            pars[0].Value = password;
            pars[1].Value = email;
            return MSSQLAide.ExecuteNonQuery(sql, pars);
        }

        public int Insert(User_info user_Info)
        {
            string sql = @"INSERT INTO [dbo].[user_info]
                       ([group_id],[name],[password],[email],[phone],[avatar],[create_time],[login_time],[login_ip],[logins],[score],[status],[remark])
                            VALUES(@group_id,@name,@password,@email,@phone,@avatar,@create_time,@login_time,@login_ip,@logins,@score,@status,@remark)";
            if (string.IsNullOrEmpty(user_Info.Email))
            {
                user_Info.Email = string.Empty;
            }
            if (string.IsNullOrEmpty(user_Info.Phone))
            {
                user_Info.Phone = string.Empty;
            }
            if (string.IsNullOrEmpty(user_Info.Avatar))
            {
                user_Info.Avatar = string.Empty;
            }
            if (user_Info.Create_time == null)
            {
                user_Info.Create_time = DateTime.Now;
            }
            if (user_Info.Login_time == null)
            {
                user_Info.Login_time = DateTime.Now;
            }
            if (string.IsNullOrEmpty(user_Info.Login_ip))
            {
                user_Info.Login_ip = string.Empty;
            }
            if (string.IsNullOrEmpty(user_Info.Remark))
            {
                user_Info.Remark = string.Empty;
            }
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@group_id", user_Info.Group_id),
                new SqlParameter("@name", user_Info.Name),
                new SqlParameter("@password", user_Info.Password),
                new SqlParameter("@email", user_Info.Email),
                new SqlParameter("@phone", user_Info.Phone),
                new SqlParameter("@avatar", user_Info.Avatar),
                new SqlParameter("@create_time", user_Info.Create_time),
                new SqlParameter("@login_time", user_Info.Login_time),
                new SqlParameter("@login_ip", user_Info.Login_ip),
                new SqlParameter("@logins", user_Info.Logins),
                new SqlParameter("@score", user_Info.Score),
                new SqlParameter("@status", user_Info.Status),
                new SqlParameter("@remark", user_Info.Remark)
            };
            return MSSQLAide.ExecuteNonQuery(sql, pars);
        }
    }
}
