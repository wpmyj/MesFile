using LY.MES.Model.VModel;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.ThirdSystem
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IQZDataService”。
    [ServiceContract]
    public interface IQZDataService
    {
        /// <summary>
        /// 获取车间班次表质检数据
        /// </summary>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetQualityInspector(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetOrderSchData(string sessionId, DataTable dtFilter, int PageSize, int CurrPage, ref int iTotalNum);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        void GetOrderSchData1(string sessionId, int PageSize, int CurrPage, ref int iTotalNum);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetPullCompute(string sessionId);

        /// <summary>
        /// 获取工艺信息表
        /// </summary>
        /// <returns>返回DataTable对象:WorkShop(车间)、CraftsCode(工艺编号)、CraftsName(工艺名称)</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetCraftsTable(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetQZRFIDCodeData(string sessionId, string RFIDCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetNewQZRFIDCodeData(string sessionId, string RFIDCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetQZZGData(string sessionId, DateTime SysTime);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetQZWeight(string sessionId, DateTime StartTime, DateTime EndTime, string VarietyName, string Type);


        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetRFIDWeight(string sessionId, string FormulaCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetZGStatus(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetColorData(string sessionId, string FormulaCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetQZFunColor(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetRFIDData(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetNullZGColor(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetL4Data1(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetL5Data1(string sessionId);


        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        object UpdateRFIDStatus(string sessionId, string RFIDNum);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetQZPcDataByJH(string sessionId, string JiHao);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetQZPcDataByOrder(string sessionId, string Order);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetSJDataByJH(string sessionId, string line);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        object InsertSJData(string sessionId, sj_line model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetSJDataByPC(string sessionId);

    }
}
