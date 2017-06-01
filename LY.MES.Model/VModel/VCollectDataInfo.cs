using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Model.VModel
{
    /// <summary>
    /// 采集数据表扩展
    /// </summary>
    /// 
    ///
    public class VCollectDataInfo : CollectDataInfo
    {
        /// <summary>
        /// 接口编码
        /// </summary>
        public string DeviCode { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string DeviName { get; set; }

        /// <summary>
        /// 参数编码
        /// </summary>
        public string DevpCode { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string DevpName { get; set; }

        /// <summary>
        /// 接口设备编码
        /// </summary>
        public string IFDevCode { get; set; }

        /// <summary>
        /// 接口设备名称
        /// </summary>
        public string IFDevName { get; set; }

        /// <summary>
        /// 参数设备编码
        /// </summary>
        public string PDevCode { get; set; }
        /// <summary>
        /// 参数设备名称
        /// </summary>
        public string PDevName { get; set; }
    }
}
