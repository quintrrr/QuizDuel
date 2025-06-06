using QuizDuel.Core.Interfaces;
using QuizDuel.UI.UserControls;

namespace QuizDuel.UI
{
    public partial class LeaderboardForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INavigationService _navigationService;
        public LeaderboardForm(IGameService gameService, INavigationService navigationService)
        {
            InitializeComponent();

            _gameService = gameService;
            _navigationService = navigationService;

        }

        private async void LeaderboardForm_Load(object sender, EventArgs e)
        {
            leaderboardLabel.Text = Resources.Leaderboard_Label;

            var leaderboard = await _gameService.GetLeaderboardAsync();

            flowLeaders.Controls.Clear();

            int rank = 1;
            foreach (var entry in leaderboard)
            {
                var card = new LeaderboardEntryControl(rank++, entry.Username, entry.CorrectAnswers);

                flowLeaders.Controls.Add(card);
            }
        }

        private void LeaderboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _navigationService.NavigateTo<MainForm>();
        }
    }
}
