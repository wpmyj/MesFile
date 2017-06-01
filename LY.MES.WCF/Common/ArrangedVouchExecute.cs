using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LY.MES.WCF
{
    public class ArrangedVouchExecute<T>
    {
        /// <summary>
        /// 排配单号
        /// </summary>
        public string ArrangedVouchCode
        {
            get;
            set;
        }

        public T Data { get; set; }
    }
}