using System;
using System.Data;
using System.Timers;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CustomerIPShowTool.Task
{
    //通过API获取相关记录,并返回导出DT
    public class GetApiRecord
    {
        //定义通讯字段
        private string _contect = "";
        //定义城市(地区)字段
        private string _city = "";

        //定义数据集
        private DataTable _tempsourcedt;
        //定义行ID，当要跳出TIME时使用,每次执行完成后会自增
        private int _rowid=0;

        private static Timer _timer;

        /// <summary>
        /// 根据相关值获取API并返回导出DT
        /// todo:执行（20230530:API为普通用户,QPS(每秒查询率)=1,故需要设置时间间隔来执行调用API的方法）
        /// </summary>
        /// <param name="sourcedt"></param>
        /// <returns></returns>
        public void GetExportDt(DataTable sourcedt)
        {
            try
            {
                _tempsourcedt = sourcedt.Copy();

                //设置时间间隔为100000毫秒(1分钟)
                _timer = new Timer(100000);
                //设置启动计时器(可不需要)
                //_timer.Start();
                //Elapsed事件,用于定义要执行的代码(重)
                _timer.Elapsed += Timer_Elapsed;
                //设置Timer自动重置 
                _timer.AutoReset = true;
                //启用Timer 
                _timer.Enabled = true;
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        /// <summary>
        /// 执行调用API 及 整合DT(主体执行方法)
        /// 注:此方法除了正常执行外。还要设置以指定条件STOP TIME
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //todo:当出现ROWID 与 SOURCE的行数一致时,跳出TIME
            if (_rowid == _tempsourcedt.Rows.Count)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            else
            {
                //循环获取IP相关值
                var ip = Convert.ToString(_tempsourcedt.Rows[_rowid][3]);

                //todo:一定要这一句,不然会出现:"未能创建SSL/TLS安全通道"异常
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                //设置API所需的固定值
                var appid = "smoqhweyvektrngi";
                var appsecret = "Q3hJam9qRHJyTStqSmlMU2xyNlFuUT09";

                var serviceUrl = $"https://www.mxnzp.com/api/ip/aim_ip?ip={ip}&app_id={appid}&app_secret={appsecret}";

                var client = new RestClient(serviceUrl);
                var request = new RestRequest();

                //请求方式
                request.Method = Method.Get;
                //执行调用API
                var response = client.Execute(request);

                //todo:返回状态(OK是正常,再继续)
                if (Convert.ToString(response.StatusCode) == "OK")
                {
                    //todo:返回内容并进行分析,获取需要的值(重)
                    AnalysisJson(response.Content);
                    //todo:将相关记录收集至GlobalClasscs.RmMessage.ExportDt内
                    var newrow = GlobalClasscs.RmMessage.ExportDt.NewRow();
                    newrow[0] = Convert.ToString(_tempsourcedt.Rows[_rowid][0]);    //账号编码
                    newrow[1] = Convert.ToString(_tempsourcedt.Rows[_rowid][1]);    //账号名称
                    newrow[2] = Convert.ToString(_tempsourcedt.Rows[_rowid][2]);    //客户端类型
                    newrow[3] = ip;                                                 //访问IP
                    newrow[4] = Convert.ToString(_tempsourcedt.Rows[_rowid][4]);    //访问日期
                    newrow[5] = _city;                                              //IP所属地区(城市)
                    newrow[6] = _contect;                                           //IP所属通讯服务商
                    GlobalClasscs.RmMessage.ExportDt.Rows.Add(newrow);
                }
                _rowid += 1;
                var a1 = GlobalClasscs.RmMessage.ExportDt.Copy();
            }
        }

        /// <summary>
        /// 对API返回的字符串进行解析
        /// </summary>
        /// <param name="jrecord"></param>
        private void AnalysisJson(string jrecord)
        {
            try
            {
                var obj = JObject.Parse(jrecord);
                //获取通讯记录
                _contect = obj["data"]["isp"].ToString();
                //获取城市(地区)记录
                _city = string.IsNullOrEmpty(obj["data"]["city"].ToString()) ? obj["data"]["desc"].ToString()
                    : obj["data"]["city"].ToString();
            }
            catch (Exception ex)
            {
                var a1 = ex.Message;
            }
        }

    }
}
