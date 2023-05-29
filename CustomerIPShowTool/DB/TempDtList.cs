using System;
using System.Data;

namespace CustomerIPShowTool.DB
{
    //临时表
    public class TempDtList
    {
        /// <summary>
        /// 导出使用
        /// </summary>
        /// <returns></returns>
        public DataTable MakeExportDtTemp()
        {
            var dt = new DataTable();
            for (var i = 0; i < 6; i++)
            {
                var dc = new DataColumn();
                switch (i)
                {
                    case 0:
                        dc.ColumnName = "账号编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "账号名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "订问IP";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 3:
                        dc.ColumnName = "访问日期";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 4:
                        dc.ColumnName = "IP所属地区(城市)";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 5:
                        dc.ColumnName = "IP所属通讯服务商";
                        dc.DataType = Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }
    }
}
