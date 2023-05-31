namespace CustomerIPShowTool.DB
{
    //SQL语句集合
    public class SqlList
    {
        //根据SQLID返回对应的SQL语句  
        private string _result;

        /// <summary>
        /// 根据指定条件获取配方系统登录日志信息(国内)-注:20230530:因目前API的账号只是普通用户,每天可调用API为1000次,故修正为一天的输出行数只有900行
        /// </summary>
        /// <param name="sdt">开始日期</param>
        /// <param name="edt">结束日期</param>
        /// <param name="clienttype">客户类型=>0:PC  2:Android  3:Phone(Android)  4:Phone(IOS)  5:Web  6:WeChat </param>
        /// <returns></returns>
        public string GetCustomerLoginRecord_CN(string sdt,string edt,string clienttype)
        {
            _result = $@"SELECT  TOP 900 A.ShopCode 账号编码
                                 ,B.ShopName 账号名称
                                ,CASE A.ClientType WHEN '0' THEN 'PC' WHEN '2' THEN 'Android' WHEN '3' THEN 'Phone(Android)' 
			                                       WHEN '4' THEN 'Phone(IOS)' WHEN '5' THEN 'Web' WHEN '6' THEN 'WeChat' END 客户端类型
                                ,A.IP,CONVERT(VARCHAR(10),MAX(A.CreateDateTime),23) '创建日期'
                    FROM dbo.ShopLoginLog A
                    INNER JOIN dbo.Shop B ON A.ShopCode=B.ShopCode
                    WHERE CONVERT(VARCHAR(10),CreateDateTime,23)>='{sdt}'
                    AND CONVERT(VARCHAR(10),CreateDateTime,23)<='{edt}'
                    AND A.ClientType='{clienttype}'
                    AND SUBSTRING(A.SHOPCODE,1,2)='CN'
                    --AND A.ShopCode='US-05-024'
                    GROUP BY A.ShopCode,A.ClientType,A.IP,B.ShopName
                    ";

            return _result;
        }

        /// <summary>
        /// 根据指定条件获取配方系统登录日志信息(海外)-注:20230530:因目前API的账号只是普通用户,每天可调用API为1000次,故修正为一天的输出行数只有900行
        /// </summary>
        /// <param name="sdt">开始日期</param>
        /// <param name="edt">结束日期</param>
        /// <param name="clienttype">客户类型=>0:PC  2:Android  3:Phone(Android)  4:Phone(IOS)  5:Web  6:WeChat </param>
        /// <returns></returns>
        public string GetCustomerLoginRecord_For(string sdt, string edt, string clienttype)
        {
            _result = $@"SELECT  TOP 900 A.ShopCode 账号编码
                                 ,B.ShopName 账号名称
                                 ,CASE A.ClientType WHEN '0' THEN 'PC' WHEN '2' THEN 'Android' WHEN '3' THEN 'Phone(Android)' 
			                                        WHEN '4' THEN 'Phone(IOS)' WHEN '5' THEN 'Web' WHEN '6' THEN 'WeChat' END 客户端类型
                                ,A.IP,CONVERT(VARCHAR(10),MAX(A.CreateDateTime),23) '创建日期'
                    FROM dbo.ShopLoginLog A
                    INNER JOIN dbo.Shop B ON A.ShopCode=B.ShopCode
                    WHERE CONVERT(VARCHAR(10),CreateDateTime,23)>='{sdt}'
                    AND CONVERT(VARCHAR(10),CreateDateTime,23)<='{edt}'
                    AND A.ClientType='{clienttype}'
                    AND SUBSTRING(A.SHOPCODE,1,2) !='CN'
                    --AND A.ShopCode='US-05-024'
                    GROUP BY A.ShopCode,A.ClientType,A.IP,B.ShopName
                    ";

            return _result;
        }
    }
}
