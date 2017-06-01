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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IQCDrumsSet”。
    [ServiceContract]
    public interface IQCDrumsSetService
    {

      ////  检漏报告提交新增
      
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<bool> AddQCDrumsSet(string sessionId, QC_FindLeakDrumsSet model, List<QC_FindLeakDrumsSetDetail> detailList);
      
        //查询
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<QC_FindLeakDrumsSet, QC_FindLeakDrumsSetDetail> GetQCDrumsSet(string sessionId, int AutoId);

        //根据转鼓号查询
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<QC_FindLeakDrumsSet> GetQCDrumsSetQRCode(string sessionId, string strLeakDrums);

        //查询全部数据
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<QC_FindLeakDrumsSet>> GetQCDrumsSetQRCodes(string sessionId);

        //转鼓当天待检漏信息
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<vw_QC_FindLeakDrumsSet> >Getvw_QC_FindLeakDrumsSetList(string sessionId, DateTime dCurrDate);

        //弹出列表待设定检漏信息
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<vw_DurmsUpFeeding>> GetQCDrumsList(string sessionId, int iYear, int iMonth, int strWeek);

        //分页查询显示
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<QC_FindLeakDrumsSet>> GetQCDrumsFindLeakList1(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage);


    }
}
