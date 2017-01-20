using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;

namespace DapperTest
{
    class MySqlDataHper
    {
        public string ConnString { get; set; }
        private IDbConnection _connection;
        public IDbConnection Session
        {
            get
            {
                if (_connection == null)
                {
                    var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                    conn.Open();
                    _connection = conn;
                }
                return _connection;
            }
        }
        /// <summary>
        /// 测试连接是否成功：
        /// </summary>
        /// <returns>bool</returns>
        public bool TestConn(out string errorLog)
        {
            errorLog = null;
            MySqlConnection myConn = null;
            bool bResult = false;
            try
            {
                myConn = new MySqlConnection(ConnString);
                myConn.Open();
            }
            catch (Exception ex)
            {
                errorLog = ex.Message;
            }
            finally
            {
                if (myConn != null && myConn.State.ToString() == "Open")
                    bResult = true;
            }
            myConn.Close();
            return bResult;
        }
        public int Insert(string query, object param,out string errorLog)
        {
            errorLog = null;
            int num=0;
            try
            {
                //对对象进行操作
                num=Session.Execute(query, param);
            }
            catch (Exception e)
            {
                errorLog = e.Message;
            }
            return num;
        }
        public int Update(string query, object param, out string errorLog)
        {
            errorLog = null;
            int num = 0;
            try
            {
                //对对象进行操作
                num = Session.Execute(query, param);
            }
            catch (Exception e)
            {
                errorLog = e.Message;
            }
            return num;
        }
        public List<dynamic> Query(string query, out string errorLog)
        {
            //无参数查询，返回列表，带参数查询和之前的参数赋值法相同。
            errorLog = null;
            List<dynamic> obj=null;
            try
            {
                //无参数查询，返回列表，带参数查询和之前的参数赋值法相同。
                obj= Session.Query<dynamic>(query).ToList();
            }
            catch (Exception e)
            {
                errorLog = e.Message;
            }
            return obj;
        }
        public int Delete(string query, object param, out string errorLog)
        {
            errorLog = null;
            int num = 0;
            try
            {
                //对对象进行操作
                num = Session.Execute(query, param);
            }
            catch (Exception e)
            {
                errorLog = e.Message;
            }
            return num;
        }
        
    }
}
