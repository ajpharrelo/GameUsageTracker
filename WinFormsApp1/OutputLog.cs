using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUsageTracker
{
    public partial class OutputLog : Form
    {
        private List<string> logList = new List<string>();

        public OutputLog(List<string> logList)
        {
            InitializeComponent();
            this.logList = logList;
        }

        public void AddLog(string log)
        {
            if (Visible == true)
            {
                outputList.Items.Add(log);
            }
        }

        private void OutputLog_Load(object sender, EventArgs e)
        {
            foreach (string log in logList)
            {
                outputList.Items.Add(log);
            }
        }
    }
}
