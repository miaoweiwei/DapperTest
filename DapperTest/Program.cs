using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Newtonsoft.Json;

namespace DapperTest
{
    class Program
    {
        static MySqlDataHper mysqlData = new MySqlDataHper();
        static void Main(string[] args)
        {
            mysqlData.ConnString = "Data Source=127.0.0.1;Database=dpper;User Id=miao;Password=123456;";
            string errorLog=null;
            if (mysqlData.TestConn(out errorLog))
            {
                //插入
                int obj = mysqlData.Insert("INSERT INTO Book(Id,Name)VALUES(@Id,@name)", new Book() { Id = 12, Name = "英语14" }, out errorLog);
                if (obj == 1 && string.IsNullOrEmpty(errorLog))
                {
                    Console.WriteLine("成功插入一条数据！");
                    obj = 0;
                }
                //更新
                obj = mysqlData.Update("UPDATE Book SET  Name=@name WHERE id =@id", new Book() { Id = 12, Name = "哈哈" }, out errorLog);
                if (obj == 1 && string.IsNullOrEmpty(errorLog))
                {
                    Console.WriteLine("成功更新一条数据！");
                    obj = 0;
                }
                //查询
                List<dynamic> data = mysqlData.Query("SELECT * FROM Book",out errorLog);
                if (data!=null)
                {
                    Console.WriteLine("成功查询到数据数据！");
                    Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
                    data = null;
                }
                //删除
                obj = mysqlData.Delete("DELETE FROM Book WHERE id = @id", new Book() { Id = 12 }, out errorLog);
                if (obj == 1 && string.IsNullOrEmpty(errorLog))
                {
                    Console.WriteLine("成功删除一条数据！");
                    obj = 0;
                }
            }
            else
            {
                Console.WriteLine("连接失败！发生错误，错误信息：");
                Console.WriteLine(errorLog + "\r\n");
            }
            Console.ReadKey();
        }

    }
}
