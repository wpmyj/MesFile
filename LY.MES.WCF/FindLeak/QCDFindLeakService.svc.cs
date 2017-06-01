using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


using LY.MES.Model;
using LY.MES.Service.FindLeak;
using Server.Utility;
using LY.MES.WCF.Drums;
namespace LY.MES.WCF.FindLeak
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“QCDrumsFindLeakReportService1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 QCDrumsFindLeakReportService1.svc 或 QCDrumsFindLeakReportService1.svc.cs，然后开始调试。
    public class QCDFindLeakService : IQCDFindLeakService
    {
        public Server.Utility.CommonResult<QC_DrumsFindLeakReport> AddQCDrumsFindLeakReport(string sessionId, QC_DrumsFindLeakReport model)
        {
            try
            {
           
                var result = ForQCDFindLeakServices.GetInstance(sessionId).AddQCDrumsFindLeakReport(model);

                if (result.IsSuccess)
                {
                    var srv = new CfPExecuteService();
                    srv.UpdateCraftsProcessExecute(sessionId, result.Data.SourceCode, 2, 2);

                    if (result.Data.FLResult.Equals("不合格")) //不合格，将排配单设定为设备故障，将工艺空鼓设定完成。
                    {
                        var ret = new ArrangedVService().UdateArrUserStatusByArrCode(sessionId, result.Data.SourceCode, 99);
                        srv.UpdateCraftsProcessExecute(sessionId, result.Data.SourceCode, 8, 2);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        //查询
        public Server.Utility.CommonResult<QC_DrumsFindLeakReport> GetQCDrumsFindLeak(string sessionId, string strFLVCode)
        {
            try
            {
                //  return ForDeviceExecute.GetInstance(sessionId).GetDeviceExecute(strDeviCode);
                return ForQCDFindLeakServices.GetInstance(sessionId).GetQCDrumsFindLeak(strFLVCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }




        /// <summary>
        /// 2016/12/02
        /// chenweihua
        /// 分页显示
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="tWhere"></param>
        /// <param name="PageSize"></param>
        /// <param name="CurrPage"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<List<QC_DrumsFindLeakReport>> GetQCDrumsFindLeakList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForQCDFindLeakServices.GetInstance(sessionId).GetQCDrumsFindLeakList(tWhere, PageSize, CurrPage);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }


        }

    }
}
