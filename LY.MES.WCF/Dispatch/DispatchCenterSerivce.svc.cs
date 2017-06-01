using LY.MES.Model;
using LY.MES.Service.Drums;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;
using System.Threading;

namespace LY.MES.WCF.Dispatch
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DispatchCenterSerivce”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DispatchCenterSerivce.svc 或 DispatchCenterSerivce.svc.cs，然后开始调试。

    /// <summary>
    /// Author:xxp
    /// Remark:调度中心服务
    /// CreateTime:20161226
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DispatchCenterSerivce : IDispatchCenterSerivce
    {
        private static UserSession CurrUserSession = null;

        private static IDCToDoCallBack _currCallback;

        /// <summary>
        /// 任务对象队列
        /// </summary>
        public static Queue<object> taskQueue = new Queue<object>();

        /// <summary>
        /// 任务时间
        /// </summary>
        private static System.Timers.Timer taskTimer;

        public DispatchCenterSerivce()
        {
            Utils.Logger.Debug(string.Format("当前线程【{0}】连接上", Thread.CurrentThread.ManagedThreadId.ToString()));
            OperationContext.Current.InstanceContext.Faulted += InstanceContext_Faulted;
            OperationContext.Current.InstanceContext.Closed += InstanceContext_Closed;
            if (taskTimer == null)
            {
                taskTimer = new System.Timers.Timer();
                taskTimer.Interval = 100;
                taskTimer.Elapsed += taskTimer_Elapsed;
                taskTimer.AutoReset = true;
            }
        }

        void InstanceContext_Closed(object sender, EventArgs e)
        {
            Utils.Logger.Error("InstanceContext_Closed事件响应！");
        }

        void InstanceContext_Faulted(object sender, EventArgs e)
        {
            Utils.Logger.Error("Channel_Faulted事件响应！");
        }

        void taskTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {

                if (_currCallback != null && taskQueue.Count > 0)
                {
                    object obj = taskQueue.Dequeue();
                    if (obj is ArrangedVouchExecute<CraftsProcessExecute>)
                    {
                        var model = obj as ArrangedVouchExecute<CraftsProcessExecute>;
                        _currCallback.SendCraftsProcess(model);
                    }
                    else if (obj is ArrangedVouchExecute<Model.CraftsProcessExecuteDetail>)
                    {
                        var model = obj as ArrangedVouchExecute<CraftsProcessExecuteDetail>;
                        _currCallback.SendCraftsProcessDetail(model);
                    }
                    else if (obj is List<vw_ArrangedCraftsProcessExecute>)
                    {
                        var model = obj as List<vw_ArrangedCraftsProcessExecute>;
                        _currCallback.StartCraftsProcess(model);
                    }
                    else if (obj is string)
                    {
                        _currCallback.ValveGroupValue(obj.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="sessionId"></param>
        public void OnLine(string sessionId)
        {
            CurrUserSession = Server.Utility.SvrUserSession.GetCurrSession(sessionId);
            _currCallback = OperationContext.Current.GetCallbackChannel<IDCToDoCallBack>();
            Utils.Logger.Error(string.Format("用户:{0}上线了！", CurrUserSession.UserCode));
            taskTimer.Start();
        }

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="sessionId"></param>
        public void OffLine(string sessionId)
        {
            if (CurrUserSession.SessionId.Equals(sessionId))
            {
                Utils.Logger.Debug(string.Format("用户:{0}下线了！", CurrUserSession.UserCode));
                _currCallback = null;
            }
        }


        /// <summary>
        /// 获取工艺流程
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public CommonResult<List<vw_ArrangedCraftsProcessExecute>> GetArrangedCraftsProcessExecuteList(string sessionId)
        {
            try
            {
                return ForArrangedVouchServices.GetInstance(sessionId).GetArrangedCraftsProcessExecuteList();
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

        public CommonResult<List<vw_ArrangedCraftsProcessExecute>> GetArrangedCraftsProcessExecuteListByCode(string sessionId, string ArrangedVouchCode)
        {
            try
            {
                return ForArrangedVouchServices.GetInstance(sessionId).GetArrangedCraftsProcessExecuteList(ArrangedVouchCode);
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
        /// 接收工艺流程
        /// </summary>
        /// <param name="model"></param>
        public void AcceptCraftsProcess(Model.CraftsProcessExecute model)
        {
            try
            {
                //数据同步
                ForCfPExecuteServices.GetInstance(CurrUserSession.SessionId).UpdateCraftsProcessByExID(model.ArrangedVouchCode, model.ExecuteID, model.ExecuteStatus, model.StartTime, model.EndTime);
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
        /// 接受工艺流程参数
        /// </summary>
        /// <param name="model"></param>
        public void AcceptCraftsProcessDetail(Model.CraftsProcessExecuteDetail model)
        {
            try
            {
                //数据同步
                ForCfPExecuteServices.GetInstance(CurrUserSession.SessionId).UpdateCPEDetailExecuteStatusByAutoID(model.AutoID, model.ExecuteStatus, model.StartDateTime, model.EndDateTime);
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
        /// 调度排配单处理方法(异步)
        /// </summary>
        /// <param name="handler">操作对象</param>
        /// <param name="strArrangedVouchCode">排配单号</param>
        /// <param name="ExecuteID">工艺执行主表执行ID</param>
        /// <param name="ParamAutoID">工艺执行子表ID</param>
        /// <param name="ValveGroupValue">主管道阀门组值</param>
        public static async void DispatchArrangedCraftsProcessAsync(DisCenterHandler handler, string strArrangedVouchCode = null, Nullable<int> ExecuteID = null, Nullable<int> ParamAutoID = null, string ValveGroupValue = null)
        {
            try
            {
                switch (handler)
                {
                    case DisCenterHandler.Start:
                        var model = ForArrangedVouchServices.GetInstance(CurrUserSession.SessionId).GetArrangedCraftsProcessExecuteList(strArrangedVouchCode);
                        if (model.Data != null)
                        {
                            taskQueue.Enqueue(model.Data);
                        }
                        break;
                    case DisCenterHandler.UpdateCrafts:

                        if (ExecuteID.HasValue)
                        {
                            var CurrCraftModel = ForCfPExecuteServices.GetInstance(CurrUserSession.SessionId).GetCfPExecuteByExecuteID(ExecuteID.Value);
                            if (CurrCraftModel.Data != null)
                            {
                                var m = new ArrangedVouchExecute<CraftsProcessExecute>();
                                m.Data = CurrCraftModel.Data;
                                m.ArrangedVouchCode = CurrCraftModel.Data.ArrangedVouchCode;
                                taskQueue.Enqueue(m);
                            }
                        }

                        break;
                    case DisCenterHandler.ValveGroup:
                        taskQueue.Enqueue(ValveGroupValue);
                        break;
                    case DisCenterHandler.UpdateParam:

                        break;
                    case DisCenterHandler.Stop:

                        break;
                    case DisCenterHandler.Complete:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

    }
}
