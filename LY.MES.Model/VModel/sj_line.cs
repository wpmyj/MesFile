using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Model.VModel
{
   public class sj_line
    {
        /// <summary>
        /// id 主键，自动累加
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 已完成件数
        /// </summary>

        public int serial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int jihao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int types { get; set; }
        /// <summary>
        /// 机号
        /// </summary>
        public int line { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal weightA { get; set; }

        public decimal weightB { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime timeA { get; set; }

        public DateTime timeB { get; set; }

        public string names { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string paichan { get; set; }

        public string shengchan { get; set; }
        /// <summary>
        /// 正品，二级品区分状态
        /// </summary>
        public string qk { get; set; }


        public int fweightused { get; set; }

        public string type { get; set; }
    }
}
