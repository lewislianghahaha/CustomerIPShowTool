using System;
using System.Data;
using System.Data.SqlClient;
using CustomerIPShowTool.DB;

namespace CustomerIPShowTool.Task
{
    public class SearchDt
    {
        ConDb conDb = new ConDb();
        SqlList sqlList = new SqlList();

        /// <summary>
        /// 根据SQL语句查询得出对应的DT
        /// </summary>
        /// <param name="sqlscript"></param>
        /// <returns></returns>
        private DataTable UseSqlSearchIntoDt(string sqlscript)
        {
            var resultdt = new DataTable();

            try
            {
                var sqlDataAdapter = new SqlDataAdapter(sqlscript, conDb.GetK3CloudConn());
                sqlDataAdapter.Fill(resultdt);
            }
            catch (Exception)
            {
                resultdt.Rows.Clear();
                resultdt.Columns.Clear();
            }

            return resultdt;
        }

        /// <summary>
        /// 根据指定条件获取配方系统登录日志信息
        /// </summary>
        /// <param name="sdt"></param>
        /// <param name="edt"></param>
        /// <param name="clienttype"></param>
        /// <returns></returns>
        public DataTable GetCustomerLoginRecord(string sdt, string edt, string clienttype)
        {
            var dt = UseSqlSearchIntoDt(sqlList.GetCustomerLoginRecord(sdt, edt, clienttype));
            return dt;
        }



    }
}
