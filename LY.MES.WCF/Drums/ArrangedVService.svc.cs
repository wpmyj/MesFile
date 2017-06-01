using LY.MES.Model;
using LY.MES.Service.Drums;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Drums
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ArrangedVService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ArrangedVService.svc 或 ArrangedVService.svc.cs，然后开始调试。
    public class ArrangedVService : IArrangedVService
    {

        /// <summary>
        /// 获取单个排配单
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="ArrangedVouchCode"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<ArrangedVouch> GetArrangedVouchByCode(string sessionId, string ArrangedVouchCode)
        {
            try
            {

                return ForArrangedVouchServices.GetInstance(sessionId).GetArrangedVouchByCode(ArrangedVouchCode);
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
        // 2016/12/19
        // chenweihua
        // 分页显示
        // </summary>
        // <param name="sessionId"></param>
        // <param name="tWhere"></param>
        // <param name="PageSize"></param>
        // <param name="CurrPage"></param>
        // <returns></returns>
        public CommonResult<List<ArrangedVouch>> GetArrangedVouchList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForArrangedVouchServices.GetInstance(sessionId).GetArrangedVouchList(tWhere, PageSize, CurrPage);
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
        /// 20170111XCQ用于修改排配单执行状态，传入值为排配单号以及要修改成的执行状态UserStatus，暂定用于转鼓工艺流转，因为转鼓空鼓上料默认上料之后执行状态为1
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="ArrangedVouchCode"></param>
        /// <param name="UserStatus"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<ArrangedVouch> UdateArrUserStatusByArrCode(string sessionId, string ArrangedVouchCode, int UserStatus)
        {
            try
            {
                return ForArrangedVouchServices.GetInstance(sessionId).UdateArrUserStatusByArrCode(ArrangedVouchCode, UserStatus);
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

        public Server.Utility.CommonResult<List<ArrangedVouch>> GetArrangedVouchByMulaCode(string sessionId, string ForMulaCode, int UserStatus)
        {
            try
            {
                return ForArrangedVouchServices.GetInstance(sessionId).GetArrangedVouchByMulaCode(ForMulaCode, UserStatus);
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
