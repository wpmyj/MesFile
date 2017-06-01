using LY.MES.Model;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.FindLeak
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IQCDrumsFindLeakReportService1”。
    [ServiceContract]
    public interface IQCDFindLeakService
    {
        
       
        //增加
      [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<QC_DrumsFindLeakReport> AddQCDrumsFindLeakReport(string sessionId, QC_DrumsFindLeakReport model);

        //查询
      [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<QC_DrumsFindLeakReport> GetQCDrumsFindLeak(string sessionId, string strFLVCode);


        //分页
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<QC_DrumsFindLeakReport>> GetQCDrumsFindLeakList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage);
    }
}
