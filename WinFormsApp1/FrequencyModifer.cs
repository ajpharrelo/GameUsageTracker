using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUsageTracker
{
    public partial class FrequencyModifer : Form
    {
        public FrequencyModifer()
        {
            InitializeComponent();
        }

        private void FrequencyModifer_Load(object sender, EventArgs e)
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker\settings.json";

            if(File.Exists(settingsPath))
            {
                using (StreamReader sr = File.OpenText(settingsPath))
                {
                    string[]? settings = JsonSerializer.Deserialize<string[]>(sr.ReadToEnd());
                    txtFrequency.Text = settings[0];
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(settingsPath))
                {
                    string[] settings = {"1"};
                    sw.Write(JsonSerializer.Serialize(settings));
                }
            }
        }
    }
}
