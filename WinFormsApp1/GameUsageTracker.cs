using GameUsageTracker;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace WinFormsApp1
{
    public partial class GameUsageTracker : Form
    {
        #region Globals
        private List<Game> GameList = new List<Game>();
        private List<GameSession> GameSessionList = new List<GameSession>(); 
        private Process? runningProcess = new Process();
        private int FrequencyRate;

        private static string saveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker";
        private string sessionFile = saveDirectory + @"\sessions.json";
        private string settingsPath = saveDirectory + @"\settings.json";
        private string listFile = saveDirectory + @"\games.json";
        private string outputLogFile = saveDirectory + @"/output.log";

        private void addLog(string log)
        {
            if(File.Exists(outputLogFile))
            {
                using (StreamWriter sw = File.AppendText(outputLogFile))
                {
                    sw.WriteLine(log);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(outputLogFile))
                {
                    sw.WriteLine(log);
                    sw.Close();
                }
            }
        }

        private string GetSelectedGame()
        {
            if (listView2.SelectedIndices.Count > 0)
            {
                string gameTitle = listView2.SelectedItems[0].Text;
                addLog(gameTitle + " removed from watch list.");
                return gameTitle;
            }

            return "";
        }

        #endregion

        #region Application Startup

        public GameUsageTracker()
        {
            InitializeComponent();
        }

        private void CreateSettingsFile(string[] settings)
        {
            if(Directory.Exists(saveDirectory))
            {
                using (StreamWriter sw = File.CreateText(settingsPath))
                {
                    sw.Write(JsonSerializer.Serialize(settings));
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                addLog("Game usage directory not found");
            }

        }

        private string GetFrequencySetting()
        {
            if (Directory.Exists(saveDirectory) && File.Exists(settingsPath))
            {
                using (StreamReader sr = File.OpenText(settingsPath))
                {
                    string[]? settings = JsonSerializer.Deserialize<string[]>(sr.ReadToEnd());
                    if (settings != null)
                    {
                        sr.Close();
                        return settings[0];
                    }
                    else
                    {
                        return "1";
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(saveDirectory);
                string[] defaultSettings = { "1" };
                CreateSettingsFile(defaultSettings);
            }

            MessageBox.Show("Using default check frequency (1 Minute)", "Using default settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return "1";
        }

        private void GameUsageTracker_Load(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;

            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.MouseClick += ListView2_MouseClick;

            Resize += GameUsageTracker_Resize;
            Application.ApplicationExit += Application_ApplicationExit;

            LoadGameSessions();
            LoadGameList();

            BackgroundWorker.RunWorkerAsync();
            // Set user setfrequency
            FrequencyRate = int.Parse(GetFrequencySetting());

            lblFrequency.Text = "Refresh frequency: " + FrequencyRate.ToString();

            //Set column width for ListView
            int width = listView2.Width;
            for (int i = 0; i < listView2.Columns.Count; i++)
            {
                listView2.Columns[i].Width = width / listView2.Columns.Count;
            }

        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            BackgroundWorker.Dispose();
            File.Delete(outputLogFile);
        }

        private void GameUsageTracker_Resize(object? sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                TrayIcon.Visible = true;
            }
        }

        #endregion

        #region Game & Game sessions

        private void LoadGameList()
        {
            if(File.Exists(listFile))
            {
                GameList.Clear();
                using (StreamReader sr = File.OpenText(listFile))
                {
                    Game[]? fileData = JsonSerializer.Deserialize<Game[]>(sr.ReadToEnd());
                    if(fileData != null)
                        foreach (Game game in fileData)
                        {
                            GameList.Add(game);
                        }
                        sr.Close();
                }

                listView2.Items.Clear();
                foreach (Game game in GameList)
                {
                    List<GameSession> gameSessions = GameSessionList.FindAll(gs => gs.GameExecutable == game.ExecutablePath);
                    TimeSpan runtime = TimeSpan.Parse("00:00:00");

                    foreach (GameSession session in gameSessions)
                    {
                        TimeSpan sessionRuntime = session.GetGameSessionRuntime(session);
                        runtime = runtime.Add(sessionRuntime);
                    }
                    

                    var newItem = new ListViewItem(new[] { game.Title, game.ExecutablePath, runtime.ToString("hh'h 'mm'm 'ss's'") });
                    listView2.Items.Add(newItem);
                }
            }
        }

        private void SaveGameList()
        {
            string jsonData = JsonSerializer.Serialize(GameList, new JsonSerializerOptions { WriteIndented = true });

            string saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker\";
            if (!Directory.Exists(saveLocation))
                Directory.CreateDirectory(saveLocation);

            using (StreamWriter sw = File.CreateText(saveLocation + @"\games.json"))
            {
                sw.WriteLine(jsonData);
                sw.Close();
            }
        }

        private Process? CheckGameStatus(Game game)
        {
            string? ExecPath = Path.GetDirectoryName(game.ExecutablePath);
            string FileName = Path.GetFileNameWithoutExtension(game.ExecutablePath).ToLower();

            Process[] list = Process.GetProcessesByName(FileName);

            foreach (Process p in list)
            {
                if (p.MainModule != null && p.MainModule.FileName != null && ExecPath != null)
                {
                    try
                    {
                        if (p.MainModule.FileName.StartsWith(ExecPath, StringComparison.InvariantCulture))
                        {
                            return p;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        throw;
                    }
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        private void LoadGameSessions()
        {
            if(File.Exists(sessionFile))
            {
                using(StreamReader sr = File.OpenText(sessionFile))
                {
                    GameSessionList.Clear();
                    GameSession[]? fileData = JsonSerializer.Deserialize<GameSession[]>(sr.ReadToEnd());
                    if(fileData != null)
                        foreach (GameSession session in fileData)
                        {
                            GameSessionList.Add(session);
                        }
                        sr.Close();
                }
            }
        }

        private void LogGameSession(GameSession session)
        {
            GameSessionList.Add(session);

            string jsonOut = JsonSerializer.Serialize(GameSessionList, new JsonSerializerOptions { WriteIndented = true });

            using (StreamWriter sw = File.CreateText(sessionFile))
            {
                sw.Write(jsonOut);
                sw.Close();
            }
        }

        private bool CheckIfGameAdded(string path)
        {
            Game? foundGame = GameList.Find(g => g.ExecutablePath == path);
            if (foundGame != null)
                return true;

            return false;
        }

        #endregion

        #region Background Processess

        private async void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool GameRunning = false;

            while (!GameRunning)
            {
                foreach (Game game in GameList)
                {
                    Process? p = CheckGameStatus(game);

                    if (p != null)
                    {
                        runningProcess = p;
                        addLog(game.Title + " started running at: " + runningProcess.StartTime.ToShortTimeString());
                        runningProcess.EnableRaisingEvents = true;
                        runningProcess.Exited += RunningProcess_Exited;
                        GameRunning = true;
                        game.status = Game.GameStatus.Running;
                        break;
                    }
                    else
                    {
                       // Game is not running
                    }
                }
                
                // Check every x amount of minutes if a game is running 
                await Task.Delay(FrequencyRate * 60 * 1000);
            }
        }

        private void RunningProcess_Exited(object? sender, EventArgs e)
        {
            Game? CurrentGame = GameList.Find(g => g.status == Game.GameStatus.Running);
            if (runningProcess != null && CurrentGame != null)
            {
                TimeSpan Runtime = runningProcess.ExitTime - runningProcess.StartTime;

                addLog(CurrentGame.Title + " exited at: " + runningProcess.ExitTime.ToShortTimeString() + " - Runtime: " + Runtime.ToString(@"hh\:mm\:ss"));
                GameSession session = new GameSession(CurrentGame.ExecutablePath, runningProcess.StartTime, runningProcess.ExitTime, DateTime.Now);
                session.TotalRuntime = session.GetGameSessionRuntime(session);
                LogGameSession(session);
                LoadGameSessions();
                Invoke(() =>
                {
                    LoadGameList();
                });

                runningProcess = null;
                CurrentGame.status = Game.GameStatus.NotRunning;
                BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                addLog("A game exited but could not find process of game.");
                //throw new Exception("Could not find running process");
            }
        }

        #endregion

        #region Form Components

        private void BtnAddGame_Click(object sender, EventArgs e)
        {
            string Title = TxtGameTitle.Text;
            string GameExe = TxtGameExec.Text;

            if(Title == "" || GameExe == "")
            {
                MessageBox.Show("You must specify a game title and valid executable.", "Missing Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(CheckIfGameAdded(GameExe))
                {
                    MessageBox.Show("Game already added to list.", "Duplicate game path", default, MessageBoxIcon.Information);
                }
                else
                {
                    GameList.Add(new Game(Title, GameExe));
                    SaveGameList();
                    LoadGameList();
                }
            }

        }

        private void BtnFindExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog findExecutable = new OpenFileDialog();
            findExecutable.Filter = "Executable Files|*.exe";
            findExecutable.Title = "Locate game executable";
            findExecutable.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            findExecutable.ShowDialog();

            string path = findExecutable.FileName;

            if(path == null || !Path.GetFileName(path).EndsWith(".exe"))
            {
                MessageBox.Show("You must choose a valid executable file.", "Invalid Executable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TxtGameExec.Text = path;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView2_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView2.SelectedIndices.Count > 0)
                {
                    string gameTitle = listView2.SelectedItems[0].Text;

                    listViewMenu.Show(Cursor.Position);
                }
            }
        }

        private void removeGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedGame = GetSelectedGame();

            Game? gameRemove = GameList.Find(g => g.Title == selectedGame);
            if (gameRemove != null)
                GameList.Remove(gameRemove);
            SaveGameList();
            LoadGameList();
        }
        

        private void changeCheckFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frequencyFrm = new FrequencyModifer();
            frequencyFrm.Show();
        }

        private void viewOutputLogs_Click(object sender, EventArgs e)
        {
            Form openLogs = new OutputLog();
            openLogs.Show();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
            ShowInTaskbar = true;
        }
        #endregion

        private void viewGameSessions_Click(object sender, EventArgs e)
        {
            string gameTitle = GetSelectedGame();
            string execLocation = GameList.Find(g => g.Title == gameTitle).ExecutablePath;
            IEnumerable<GameSession> sessions = from x in GameSessionList
                                                where x.GameExecutable == execLocation
                                                select x;

            Form sessionViewer = new SessionViewer(sessions);
            sessionViewer.StartPosition = FormStartPosition.CenterScreen;
            sessionViewer.Text = gameTitle + " | Sessions";
            sessionViewer.Show();
        }
    }
}