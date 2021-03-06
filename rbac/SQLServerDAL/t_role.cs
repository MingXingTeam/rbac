﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ncu.mao.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace ncu.mao.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:t_role
	/// </summary>
	public partial class t_role:It_role
	{
		public t_role()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("roleid", "t_role"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int roleid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_role");
			strSql.Append(" where roleid=@roleid");
			SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,4)
			};
			parameters[0].Value = roleid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ncu.mao.Model.t_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_role(");
			strSql.Append("rolename,description)");
			strSql.Append(" values (");
			strSql.Append("@rolename,@description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@rolename", SqlDbType.NVarChar,20),
					new SqlParameter("@description", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.rolename;
			parameters[1].Value = model.description;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ncu.mao.Model.t_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_role set ");
			strSql.Append("rolename=@rolename,");
			strSql.Append("description=@description");
			strSql.Append(" where roleid=@roleid");
			SqlParameter[] parameters = {
					new SqlParameter("@rolename", SqlDbType.NVarChar,20),
					new SqlParameter("@description", SqlDbType.NVarChar,50),
					new SqlParameter("@roleid", SqlDbType.Int,4)};
			parameters[0].Value = model.rolename;
			parameters[1].Value = model.description;
			parameters[2].Value = model.roleid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int roleid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_role ");
			strSql.Append(" where roleid=@roleid");
			SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,4)
			};
			parameters[0].Value = roleid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string roleidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_role ");
			strSql.Append(" where roleid in ("+roleidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ncu.mao.Model.t_role GetModel(int roleid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 roleid,rolename,description from t_role ");
			strSql.Append(" where roleid=@roleid");
			SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,4)
			};
			parameters[0].Value = roleid;

			ncu.mao.Model.t_role model=new ncu.mao.Model.t_role();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ncu.mao.Model.t_role DataRowToModel(DataRow row)
		{
			ncu.mao.Model.t_role model=new ncu.mao.Model.t_role();
			if (row != null)
			{
				if(row["roleid"]!=null && row["roleid"].ToString()!="")
				{
					model.roleid=int.Parse(row["roleid"].ToString());
				}
				if(row["rolename"]!=null)
				{
					model.rolename=row["rolename"].ToString();
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select roleid,rolename,description ");
			strSql.Append(" FROM t_role ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" roleid,rolename,description ");
			strSql.Append(" FROM t_role ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_role ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.roleid desc");
			}
			strSql.Append(")AS Row, T.*  from t_role T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_role";
			parameters[1].Value = "roleid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

