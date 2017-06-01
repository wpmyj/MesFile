using LY.MES.Model;
using LY.MES.Service.Drums;
using LY.MES.Service.FindLeak;
using LY.MES.WCF.Drums;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.FindLeak
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“QCDrumsSet”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 QCDrumsSet.svc 或 QCDrumsSet.svc.cs，然后开始调试。
    public class QCDrumsSetService : IQCDrumsSetService
    {

        //public Server.Utility.CommonResult<QC_FindLeakDrumsSet> AddQCDrumsSet(string sessionId, QC_FindLeakDrumsSet model)
        //{
        //    try
        //    {
        //        return ForQCDrumsSet.GetInstance(sessionId).AddQCDrumsSet(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
        //        {
        //            ErrorCode = ex.HResult,
        //            Message = ex.Message,
        //            StackTrace = ex.StackTrace
        //        }, ex.Message);
        //    }
        //}

        /// 设定转漏转鼓保存
        /// <returns>返回处理结果</returns>

        public Server.Utility.CommonResult<bool> AddQCDrumsSet(string sessionId, QC_FindLeakDrumsSet model, List<QC_FindLeakDrumsSetDetail> detailList)
        {
            try
            {
                var result = ForQCDrumsSetServices.GetInstance(sessionId).AddQCDrumsSet(model, detailList);
                if (result.IsSuccess && result.Data)
                {
                    //启用排配单的检漏流程
                    detailList.ForEach(item =>
                    {
                        var ret = new CfPExecuteService().UpdateCraftsProcessExecute(sessionId, item.ArrangedVouchCode, 2, 1);
                    });
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


        /// <summary>
        /// 根据单据编号来查询信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="AutoId"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<QC_FindLeakDrumsSet, QC_FindLeakDrumsSetDetail> GetQCDrumsSet(string sessionId, int AutoId)
        {
            try
            {
                //  return ForDeviceExecute.GetInstance(sessionId).GetDeviceExecute(strDeviCode);
                return ForQCDrumsSetServices.GetInstance(sessionId).GetQCDrumsSet(AutoId);
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

        //二维码查询检漏鼓号，根据二维码的转鼓号查询信息
        public Server.Utility.CommonResult<QC_FindLeakDrumsSet> GetQCDrumsSetQRCode(string sessionId, string strLeakDrums)
        {
            try
            {

                return ForQCDrumsSetServices.GetInstance(sessionId).GetQCDrumsSetQRCode(strLeakDrums);
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

        //查询全部数据
        public Server.Utility.CommonResult<List<QC_FindLeakDrumsSet>> GetQCDrumsSetQRCodes(string sessionId)
        {
            try
            {

                return ForQCDrumsSetServices.GetInstance(sessionId).GetQCDrumsSetQRCodes();
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

        //转鼓当天待检漏信息
        public Server.Utility.CommonResult<List<vw_QC_FindLeakDrumsSet>> Getvw_QC_FindLeakDrumsSetList(string sessionId, DateTime dCurrDate)
        {
            try
            {
                return ForQCDrumsSetServices.GetInstance(sessionId).Getvw_QC_FindLeakDrumsSetList(dCurrDate);
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

        //弹出列表待设定检漏信息
        public Server.Utility.CommonResult<List<vw_DurmsUpFeeding>> GetQCDrumsList(string sessionId, int iYear, int iMonth, int strWeek)
        {
            try
            {
                return ForQCDrumsSetServices.GetInstance(sessionId).GetQCDrumsList(iYear, iMonth, strWeek);
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




        // <summary>
        // 2016/12/02
        // chenweihua
        // 分页显示
        // </summary>
        // <param name="sessionId"></param>
        // <param name="tWhere"></param>
        // <param name="PageSize"></param>
        // <param name="CurrPage"></param>
        // <returns></returns>
        public CommonResult<List<QC_FindLeakDrumsSet>> GetQCDrumsFindLeakList1(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForQCDrumsSetServices.GetInstance(sessionId).GetQCDrumsFindLeakList(tWhere, PageSize, CurrPage);
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
