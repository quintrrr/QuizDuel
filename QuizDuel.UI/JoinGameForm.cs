using QuizDuel.Core.Interfaces;
using QuizDuel.UI.UserControls;

namespace QuizDuel.UI
{
    public partial class JoinGameForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;


        public JoinGameForm(
            IGameService gameService,
            INavigationService navigationService,
            INotificationService notificationService)
        {
            InitializeComponent();

            _gameService = gameService;
            _navigationService = navigationService;
            _notificationService = notificationService;
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

        public async void OnJoinButtonClick(object? sender, Guid gameId, Button btnJoinGame)
        {
            btnJoinGame.Enabled = false;

            _gameService.GameId = gameId;
            var result = await _gameService.JoinGameAsync();

            if (!result.Success)
            {
                var message = string.Join("\n", result.MessageKeys
                    .Select(k => Resources.ResourceManager.GetString(k) ?? k));
                _notificationService.ShowError(message);
            }
            else
            {
                _navigationService.NavigateTo<WaitingForm>();
            }

            btnJoinGame.Enabled = true;
        }
    }
}
