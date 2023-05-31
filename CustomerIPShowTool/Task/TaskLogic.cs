using System.Data;

namespace CustomerIPShowTool.Task
{
    //任务分布(中转站)
    public class TaskLogic
    {
        Generate generate = new Generate();

        #region 变量定义
        private string _sdt;             //开始日期
        private string _edt;             //结束日期
        private string _clienttype;      //客户端类型 客户类型=>0:PC  2:Android  3:Phone(Android)  4:Phone(IOS)  5:Web  6:WeChat
        private string _custtype;        //账号类型  国内=>0 海外=>1
        private string _fileAddress;     //文件地址
        private bool _resultMark;        //返回是否成功标记
        #endregion

        #region Set
        /// <summary>
        /// 开始日期
        /// </summary>
        public string Sdt { set { _sdt = value; } }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string Edt { set { _edt = value; } }

        /// <summary>
        /// 客户端类型
        /// </summary>
        public string Clienttype { set { _clienttype = value; } }

        /// <summary>
        /// 账号类型
        /// </summary>
        public string Custtype { set { _custtype = value; } }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string FileAddress { set { _fileAddress = value; } }

        #endregion

        #region Get
        /// <summary>
        /// 返回结果标记
        /// </summary>
        public bool ResultMark => _resultMark;
        #endregion

        /// <summary>
        /// 导出
        /// </summary>
        public void GenerateRecordToExcel()
        {
            _resultMark = generate.GenerateRdToExcel(_sdt,_edt,_clienttype,_custtype,_fileAddress);
        }


    }
}
