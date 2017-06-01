using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LY.MES.WFCL.Drums.List
{
    public partial class DrumsMangerList : BaseForm
    {
        
        public DrumsMangerList(UserContext context)
            : base(context)
        {
            InitializeComponent();
        }

        private void DrumsMangerList_Load(object sender, EventArgs e)
        {
         

          
            for (int i = 0; i < 35; i++)
            {

                //var p = new SingleDrumsControl() { Width = 80, Height = 120 };
                //p.Name = i.ToString();
                //p.TabIndex = i;
                //p.labelControl1.Text = i.ToString();
                //sthis.flpDrums.Controls.Add(p);
            }
        }
    }
}
