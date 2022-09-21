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

        private string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker\settings.json";

        private bool CreateSettingsFile(string[] settings)
        {
            using (StreamWriter sw = File.CreateText(settingsPath))
            {
                sw.Write(JsonSerializer.Serialize(settings));
                sw.Flush();
                sw.Close();
                return true;
            }
        }

        private void ReadSettings()
        {
            if (File.Exists(settingsPath))
            {
                using (StreamReader sr = File.OpenText(settingsPath))
                {
                    string[]? settings = JsonSerializer.Deserialize<string[]>(sr.ReadToEnd());
                    if (settings != null)
                    {
                        txtFrequency.Text = settings[0];
                        sr.Close();
                    }
                }
            }
            else
            {

                string[] settings = {"1"};
                if (CreateSettingsFile(settings))
                {
                    // Okay
                }
            }
        }

        private void FrequencyModifer_Load(object sender, EventArgs e)
        {
            ReadSettings();
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            string refreshFrequency = txtFrequency.Text;
            int frequency = 0;

            // Convert to string to check if integer.
            if (int.TryParse(refreshFrequency, out frequency))
            {
                if(frequency >= 1)
                {
                    string[] settings = { refreshFrequency };
                    CreateSettingsFile(settings);
                    Close();
                }
                else
                {
                    MessageBox.Show("Frequency value must be greater than or equal to 1 minute", "Out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
