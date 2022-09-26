using Microsoft.VisualBasic.Logging;
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

        private static string saveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker";

        public OutputLog()
        {
            InitializeComponent();
        }

        public void AddLog(string log)
        {
            if (Visible == true)
            {
                outputList.Items.Add(log);
            }
        }

        private async void OutputLog_Load(object sender, EventArgs e)
        {
            Clipboard.SetText("Hey");

            while (true)
            {
                outputList.Items.Clear();

                string outputLogFile = saveDirectory + @"/output.log";
                if(File.Exists(outputLogFile))
                {
                    using (StreamReader reader = File.OpenText(outputLogFile))
                    {
                        if (reader != null)
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                outputList.Items.Add(line);
                            }
                        }

                        reader.Close();
                    }
                }
                await Task.Delay(2500);
            }
        }
    }
}
