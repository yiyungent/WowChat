using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WowChat.DAL
{
    public class MSSQLAide
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        #region 执行非查询
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 查询
        /// <summary>
        /// 参数化SQL查询语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static DataTable Query(string sql, params SqlParameter[] parms)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in parms)
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = p.ParameterName,
                        SqlDbType = p.SqlDbType,
                        Value = p.Value
                    });
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region 执行指定存储过程
        /// <summary>
        /// 执行指定存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public static DataTable ExecProc(string procName, IDataParameter[] parms)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parms)
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = p.ParameterName,
                        SqlDbType = p.SqlDbType,
                        Value = p.Value
                    });
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}