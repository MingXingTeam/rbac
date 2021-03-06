﻿using System;
using System.Reflection;
using System.Configuration;
namespace Ncu.jsj.DALFactory
{
	/// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
	/// </summary>
	public sealed class DataAccess 
	{
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];        
		public DataAccess()
		{ }

        #region CreateObject 

		//不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath,string classNamespace)
		{		
			try
			{
				object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);	
				return objType;
			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;// 记录错误日志
				return null;
			}			
			
        }
		//使用缓存
		private static object CreateObject(string AssemblyPath,string classNamespace)
		{			
			object objType = DataCache.GetCache(classNamespace);
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);					
					DataCache.SetCache(classNamespace, objType);// 写入缓存
				}
				catch//(System.Exception ex)
				{
					//string str=ex.Message;// 记录错误日志
				}
			}
			return objType;
		}
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        #region CreateSysManage
        public static Ncu.jsj.IDAL.ISysManage CreateSysManage()
		{
			//方式1			
			//return (Ncu.jsj.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

			//方式2 			
			string classNamespace = AssemblyPath+".SysManage";	
			object objType=CreateObject(AssemblyPath,classNamespace);
            return (Ncu.jsj.IDAL.ISysManage)objType;		
		}
		#endregion
             
        
   
		/// <summary>
		/// 创建City数据层接口。
		/// </summary>
		public static Ncu.jsj.IDAL.ICity CreateCity()
		{

			string ClassNamespace = AssemblyPath +".City";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Ncu.jsj.IDAL.ICity)objType;
		}

		/// <summary>
		/// 创建Student数据层接口。
		/// </summary>
		public static Ncu.jsj.IDAL.IStudent CreateStudent()
		{

			string ClassNamespace = AssemblyPath +".Student";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Ncu.jsj.IDAL.IStudent)objType;
		}

}
}