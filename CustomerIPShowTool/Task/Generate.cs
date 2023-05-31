using System;
using System.Data;
using CustomerIPShowTool.DB;

namespace CustomerIPShowTool.Task
{
    //运算
    public class Generate
    {
        TempDtList tempDtList = new TempDtList();
        SearchDt searchDt = new SearchDt();
        ExportDt exportDt = new ExportDt();
        GetApiRecord getApiRecord = new GetApiRecord();

        /// <summary>
        /// 运算及导出至EXCEL
        /// </summary>
        /// <param name="sdt">开始日期</param>
        /// <param name="edt">结束日期</param>
        /// <param name="clienttype">客户端类型 客户类型=>0:PC  2:Android  3:Phone(Android)  4:Phone(IOS)  5:Web  6:WeChat</param>
        /// <param name="custtype">账号类型 国内=>0 海外=>1</param>
        /// <param name="fileAddress">输出地址</param>
        /// <returns></returns>
        public bool GenerateRdToExcel(string sdt, string edt, string clienttype, string custtype, string fileAddress)
        {
            var result = true;

            try
            {
                //保存从SQL获取的数据集
                var sourcedt = new DataTable();
                //获取输出DT
                GlobalClasscs.RmMessage.ExportDt = tempDtList.MakeExportDtTemp();

                //todo:根据账号类型 开始日期 结束日期 获取指定数据集
                sourcedt = custtype == "0" ? searchDt.GetCustomerLoginRecordCn(sdt, edt, clienttype).Copy() 
                           : searchDt.GetCustomerLoginRecordFor(sdt, edt, clienttype).Copy();

                //todo:返回通过API获取的相关记录输出DT(重)
                if (sourcedt.Rows.Count == 0)
                {
                    result = false;
                }
                else
                {
                    aa(sourcedt);
                    //todo:将输出DT生成EXCEL并输出
                   // result = exportDt.ExportDtToExcel(fileAddress, GlobalClasscs.RmMessage.ExportDt);
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        private void aa(DataTable sourcedt)
        {
            getApiRecord.GetExportDt(sourcedt);
        }
    }
}
