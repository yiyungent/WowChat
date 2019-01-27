using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowChat.Model
{
    /// <summary>
	/// user_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class User_info
    {
        public User_info()
        { }
        #region Model
        private int _id;
        private int _group_id;
        private string _name;
        private string _password;
        private string _email;
        private string _phone;
        private string _avatar;
        private DateTime _create_time;
        private DateTime _login_time;
        private string _login_ip;
        private int _logins = 0;
        private int _score = 0;
        private int _status = 0;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Group_id
        {
            set { _group_id = value; }
            get { return _group_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Avatar
        {
            set { _avatar = value; }
            get { return _avatar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Login_time
        {
            set { _login_time = value; }
            get { return _login_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Login_ip
        {
            set { _login_ip = value; }
            get { return _login_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Logins
        {
            set { _logins = value; }
            get { return _logins; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}
