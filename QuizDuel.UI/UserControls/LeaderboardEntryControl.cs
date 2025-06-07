namespace QuizDuel.UI.UserControls
{
    public partial class LeaderboardEntryControl: UserControl
    {
        public LeaderboardEntryControl(int rank, string username, int correctAnswers)
        {
            InitializeComponent();

            placeLabel.Font = FontManager.GetCustomFont(15f);
            usernameLabel.Font = FontManager.GetCustomFont(15f);
            answersLabel.Font = FontManager.GetCustomFont(15f);

            placeLabel.Text = $"#{rank}";
            usernameLabel.Text = username;
            answersLabel.Text = $"{correctAnswers} {Resources.Leaderboard_Answers}";

        }
    }
}
