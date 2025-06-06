namespace QuizDuel.UI.UserControls
{
    public partial class LeaderboardEntryControl: UserControl
    {
        public LeaderboardEntryControl(int rank, string username, int correctAnswers)
        {
            InitializeComponent();

            placeLabel.Text = $"#{rank}";
            usernameLabel.Text = username;
            answersLabel.Text = $"{correctAnswers} {Resources.Leaderboard_Answers}";
        }
    }
}
