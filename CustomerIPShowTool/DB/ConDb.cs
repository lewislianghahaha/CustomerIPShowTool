using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CustomerIPShowTool.DB
{
    //获取连接字符串,并创建SqlConnection
    public class ConDb
    {
        /// <summary>
        /// 获取配方系统数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetCloudConn()
        {
            var sqlcon = new SqlConnection();

            try
            {
                sqlcon = new SqlConnection(GetConnectionString());
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
            return sqlcon;
        }


        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            //读取App.Config配置文件中的Connstring节点
            var pubs = ConfigurationManager.ConnectionStrings["ConnString"];
            var result = pubs.ConnectionString;
            return result;
        }
    }
}
