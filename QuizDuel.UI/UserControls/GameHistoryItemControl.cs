namespace QuizDuel.UI.UserControls
{
    public partial class GameHistoryItemControl: UserControl
    {
        public GameHistoryItemControl()
        {
            InitializeComponent();

            Font = FontManager.GetCustomFont(10f);
            resultLabel.Font = FontManager.GetCustomFont(14f);
        }

        public string OpponentName
        {
            get => opponentLabel.Text;
            set => opponentLabel.Text = value;
        }

        public DateTime GameEndTime { get; set; }

        public void RefreshTimeAgo()
        {
            timeAgoLabel.Text = FormatTimeAgo(DateTime.Now.ToUniversalTime() - GameEndTime);
        }
        public void SetResult(Guid? playerId, Guid userId)
        {
            if (playerId == null) {
                resultLabel.Text = Resources.Game_Draw;
                resultLabel.ForeColor = Color.Gray;
            } 
            else if (playerId == userId) {
                resultLabel.Text = Resources.Game_Win;
                resultLabel.ForeColor = Color.Green;
            }
            else
            {
                resultLabel.Text = Resources.Game_Lose;
                resultLabel.ForeColor = Color.Red;
            }
        }

        private static string FormatTimeAgo(TimeSpan ts)
        {
            if (ts.TotalMinutes < 1)
            {
                return $"1 {Resources.Minutes}";
            }
            else if (ts.TotalHours < 1)
            {
                int minutes = (int)Math.Floor(ts.TotalMinutes);
                return $"{minutes} {Resources.Minutes}";
            }
            else
            {
                int hours = (int)Math.Floor(ts.TotalHours);
                int minutes = ts.Minutes; 
                if (minutes == 0)
                    return $"{hours} {Resources.Hours}";
                else
                    return $"{hours} {Resources.Hours} {minutes} {Resources.Minutes}";
            }
        }
    }
}
