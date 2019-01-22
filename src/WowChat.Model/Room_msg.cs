using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace WowChat.Model
{
	/// <summary>
	/// 类room_msg。
	/// </summary>
	[Serializable]
	public partial class Room_msg
	{
		public Room_msg()
		{}
		#region Model
		private int _id;
		private int _sender_id;
		private int _room_id;
		private DateTime _send_time;
		private string _sender_ip;
		private int? _reply_id;
		private string _message;
		private int _status=0;
		private string _remark="";
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sender_id
		{
			set{ _sender_id=value;}
			get{return _sender_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int room_id
		{
			set{ _room_id=value;}
			get{return _room_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime send_time
		{
			set{ _send_time=value;}
			get{return _send_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sender_ip
		{
			set{ _sender_ip=value;}
			get{return _sender_ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? reply_id
		{
			set{ _reply_id=value;}
			get{return _reply_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model
	}
}

