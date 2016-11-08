using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckTheConnectedPID;
namespace CheckSystemSecurity
{
    public partial class ProcessUtility : Form
    {
        public ProcessUtility()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckUnwantedConnectedProcess objproce = new CheckUnwantedConnectedProcess();

            MessageBox.Show(objproce.GetCurrectProcessData());
        }
    }
}
