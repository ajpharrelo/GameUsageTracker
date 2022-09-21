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

        private string sessionFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker\sessions.json";
        private string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker\settings.json";
        private string listFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GameUsageTracker\games.json";


        #endregion

        #region Application Startup

        public GameUsageTracker()
        {
            InitializeComponent();
        }

        private void CreateSettingsFile(string[] settings)
        {
            using (StreamWriter sw = File.CreateText(settingsPath))
            {
                sw.Write(JsonSerializer.Serialize(settings));
                sw.Flush();
                sw.Close();
            }
        }

        private string GetFrequencySetting()
        {
            if (File.Exists(settingsPath))
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
                        return "";
                    }
                }
            }
            else
            {

                string[] settings = { "1" };
                CreateSettingsFile(settings);
            }

            return "";
        }

        private void GameUsageTracker_Load(object sender, EventArgs e)
        {
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.MouseClick += ListView2_MouseClick;

            FormClosing += GameUsageTracker_FormClosing;

            LoadGameSessions();
            LoadGameList();

            BackgroundWorker.RunWorkerAsync();

            // Set user setfrequency
            FrequencyRate = int.Parse(GetFrequencySetting());

            //Set column width for ListView
            int width = listView2.Width;
            for (int i = 0; i < listView2.Columns.Count; i++)
            {
                listView2.Columns[i].Width = width / listView2.Columns.Count;
            }

        }

        private void GameUsageTracker_FormClosing(object? sender, FormClosingEventArgs e)
        {
            BackgroundWorker.Dispose();
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
                    

                    var newItem = new ListViewItem(new[] { game.Title, game.ExecutablePath, runtime.ToString() });
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
                        Debug.WriteLine(game.Title + " Started running at " + runningProcess.StartTime);
                        runningProcess.EnableRaisingEvents = true;
                        runningProcess.Exited += RunningProcess_Exited;
                        GameRunning = true;

                        //Invoke(() =>
                        //{

                        //});

                        break;
                    }
                    else
                    {
                        // Do nothing
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

                Debug.WriteLine(CurrentGame.Title + " Exited at: " + runningProcess.ExitTime + " Game ran for: " + Runtime.ToString(@"hh\:mm\:ss"));
                GameSession session = new GameSession(CurrentGame.ExecutablePath, runningProcess.StartTime, runningProcess.ExitTime, DateTime.Now);
                LogGameSession(session);
                LoadGameSessions();
                Invoke(() =>
                {
                    LoadGameList();
                });

                runningProcess = null;
                BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                throw new Exception("Could not find running process");
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
            if (listView2.SelectedIndices.Count > 0)
            {
                string gameTitle = listView2.SelectedItems[0].Text;

                Game? gameRemove = GameList.Find(g => g.Title == gameTitle);
                if(gameRemove != null)
                    GameList.Remove(gameRemove);
                    SaveGameList();
                    LoadGameList();
            }
        }

        private void changeCheckFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frequencyFrm = new FrequencyModifer();
            frequencyFrm.Show();
        }

        #endregion
    }
}