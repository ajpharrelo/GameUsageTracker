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
using WinFormsApp1;

namespace GameUsageTracker
{
    public partial class SessionViewer : Form
    {
        private IEnumerable<GameSession> gameSessions;

        public SessionViewer(IEnumerable<GameSession> sessions)
        {
            InitializeComponent();
            gameSessions = sessions;
        }

        private void SessionViewer_Load(object sender, EventArgs e)
        {
            foreach (GameSession session in gameSessions)
            {
                string[] newRow = { session.Timestamp.ToString("dd/MM/yyyy"), session.StartTime.ToString("HH:mm tt"), session.ExitTime.ToString("HH:mm tt"), session.TotalRuntime.ToString("hh'h 'mm'm 'ss's'") };
                sessionGridView.Rows.Add(newRow);
            }

        }
    }
}
