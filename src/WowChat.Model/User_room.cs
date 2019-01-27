using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace WowChat.Model
{
	/// <summary>
	/// 类user_room。
	/// </summary>
	[Serializable]
	public partial class User_room
	{
		public User_room()
		{}
		#region Model
		private int _user_id;
		private int _room_id;
		private DateTime _join_time;
		private int _room_role=0;
		private bool _allow_send= false;
		private DateTime? _ban_send_expiry;
		private string _remark="";
		/// <summary>
		/// 
		/// </summary>
		public int User_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Room_id
		{
			set{ _room_id=value;}
			get{return _room_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Join_time
		{
			set{ _join_time=value;}
			get{return _join_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Room_role
		{
			set{ _room_role=value;}
			get{return _room_role;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Allow_send
		{
			set{ _allow_send=value;}
			get{return _allow_send;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Ban_send_expiry
		{
			set{ _ban_send_expiry=value;}
			get{return _ban_send_expiry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model
	}
}

