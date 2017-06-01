using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.WFCL.VModel
{
    /// <summary>
    /// 参数对照表
    /// </summary>
    public class CPContrast : SRBase.CraftsParameterContrast
    {
        public CPContrast() { }

        public CPContrast(SRBase.CraftsParameterContrast model)
        {
            this.ParameterID = model.ParameterID;
            this.ParamName = model.ParamName;
            this.DevepName = model.DevepName;
            this.ParamType = model.ParamType;
        }

        public string Editprop { get; set; }
    }
}
