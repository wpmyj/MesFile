using Client.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



//单页面调试
namespace LY.MES.WFCL
{
    class Class1
    {

        [STAThread]
        static void Main(string[] args)
        {

            // Application.Run(new CLParamSet.frmCLParamSet());

            // Application.Run(new CLParamSet.frmCLParamSet(new UserContext() { SessionID = "test" }));
            //Application.Run(new LY.MES.WFCL.Base.List.frmDeviceClassList(new UserContext() { SessionID = "test" }));

         //  Application.Run(new LY.MES.WFCL.Drums.Frm.frmDrums(new UserContext() { SessionID = "test" }));

            Application.Run(new LY.MES.WFCL.Drums.Frm.frmIPRegitForm(new UserContext("test")));
        }
    }
}


