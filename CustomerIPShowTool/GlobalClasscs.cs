using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerIPShowTool
{
    public class GlobalClasscs
    {
        public struct RestMessage
        {
            public DataTable ExportDt;   //设置整合完成的DT(导出EXCEL时使用)
        }

        public static RestMessage RmMessage;
    }
}
