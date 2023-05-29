namespace CustomerIPShowTool.DB
{
    //SQL语句集合
    public class SqlList
    {
        //根据SQLID返回对应的SQL语句  
        private string _result;

        /// <summary>
        /// 根据指定条件获取配方系统登录日志信息
        /// </summary>
        /// <param name="sdt">开始日期</param>
        /// <param name="edt">结束日期</param>
        /// <param name="clienttype">客户类型=>0:PC  2:Android  3:Phone(Android)  4:Phone(IOS)  5:Web  6:WeChat </param>
        /// <returns></returns>
        public string GetCustomerLoginRecord(string sdt,string edt,string clienttype)
        {
            _result = $@"SELECT  A.ShopCode 账号编码
                                 ,B.ShopName 账号名称
                                ,A.IP,CONVERT(VARCHAR(10),MAX(A.CreateDateTime),23) '创建日期'
                    FROM dbo.ShopLoginLog A
                    INNER JOIN dbo.Shop B ON A.ShopCode=B.ShopCode
                    WHERE CONVERT(VARCHAR(10),CreateDateTime,23)>='{sdt}'
                    AND CONVERT(VARCHAR(10),CreateDateTime,23)<='{edt}'
                    AND A.ClientType='{clienttype}'
                    --AND A.ShopCode='US-05-024'
                    GROUP BY A.ShopCode,A.ClientType,A.IP,B.ShopName
                    ";

            return _result;
        }


    }
}
