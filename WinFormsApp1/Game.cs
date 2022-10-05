using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Game
    {
        public enum GameStatus
        { 
            Running,
            Exited,
            NotRunning
        }

        public string Title { get; set; }
        public string ExecutablePath { get; set; }
        public GameStatus status;

        public Game(string title, string executablePath)
        {
            Title = title;
            ExecutablePath = executablePath;
            status = GameStatus.NotRunning;
        }
    }

    public class GameSession
    {
        public string GameExecutable { get; set; }
        public TimeSpan? TotalRuntime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExitTime { get; set; }
        public DateTime Timestamp { get; set; }

        public GameSession(string gameExecutable, DateTime startTime, DateTime exitTime, DateTime timestamp)
        {
            GameExecutable = gameExecutable;
            StartTime = startTime;
            ExitTime = exitTime;
            Timestamp = timestamp;
        }

        public TimeSpan GetGameSessionRuntime(GameSession session)
        {
            TimeSpan Runtime = session.ExitTime - session.StartTime;
            return Runtime;
        }
    }
}
