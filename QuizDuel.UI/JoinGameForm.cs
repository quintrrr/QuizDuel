using QuizDuel.Core.Interfaces;
using QuizDuel.UI.UserControls;

namespace QuizDuel.UI
{
    public partial class JoinGameForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INavigationService _navigationService;

        public JoinGameForm(
            IGameService gameService,
            INavigationService navigationService)
        {
            InitializeComponent();

            _gameService = gameService;
            _navigationService = navigationService;
        }

        private async void JoinGameForm_Load(object sender, EventArgs e)
        {
            var games = await _gameService.GetOpenedGamesAsync();
            foreach (var game in games)
            {
                var card = new GameCardControl(game);
                card.OnJoinClicked += OnJoinButtonClick;
                flowGames.Controls.Add(card);
            }
        }

        private void JoinGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_navigationService.NavigateTo<MainForm>();
        }

        public async void OnJoinButtonClick(object? sender, Guid gameId)
        {
            _gameService.GameId = gameId;
            await _gameService.JoinGameAsync();
            _navigationService.NavigateTo<WaitingForm>();
        }
    }
}
