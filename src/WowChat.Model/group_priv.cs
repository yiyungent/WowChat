using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace WowChat.Model
{
	/// <summary>
	/// 类group_priv。
	/// </summary>
	[Serializable]
	public partial class Group_priv
	{
		public Group_priv()
		{}
		#region Model
		private int _group_id;
		private int _priv_id;
		/// <summary>
		/// 
		/// </summary>
		public int Group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Priv_id
		{
			set{ _priv_id=value;}
			get{return _priv_id;}
		}
		#endregion Model
	}
}

