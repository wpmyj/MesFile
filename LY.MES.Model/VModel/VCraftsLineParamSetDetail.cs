using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Model.VModel
{
    
    public class VCraftsLineParamSetDetail : CraftsLineParamSetDetail
    {
        /// <summary>
        /// 编辑属性：A表新增，M表修改，D表删除，string类型
        /// </summary>
        public string Editprop { set; get; }
    }
}
