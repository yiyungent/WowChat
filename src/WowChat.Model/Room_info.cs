using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace WowChat.Model
{
	/// <summary>
	/// 类room_info。
	/// </summary>
	[Serializable]
	public partial class Room_info
	{
		public Room_info()
		{}
		#region Model
		private int _id;
		private string _name;
		private int _rank=0;
		private string _brief="";
		private string _announcement="";
		private int _creator_id;
		private DateTime _create_time;
		private string _icon="";
		private int _read_status=0;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int rank
		{
			set{ _rank=value;}
			get{return _rank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string announcement
		{
			set{ _announcement=value;}
			get{return _announcement;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int creator_id
		{
			set{ _creator_id=value;}
			get{return _creator_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int read_status
		{
			set{ _read_status=value;}
			get{return _read_status;}
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

