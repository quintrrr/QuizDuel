using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;
using QuizDuel.UI.UserControls;

namespace QuizDuel.UI
{
    public partial class JoinGameForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;

        private bool _isJoining;

        public JoinGameForm(
            IGameService gameService,
            INavigationService navigationService,
            INotificationService notificationService,
            ILogger logger)
        {
            InitializeComponent();

            _gameService = gameService;
            _navigationService = navigationService;
            _notificationService = notificationService;
            _logger = logger;

            btnUpdateGames.Text = Resources.Join_UpdateGames;
        }

        private async void JoinGameForm_Load(object sender, EventArgs e)
        {
            await LoadGames();
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
                await LoadGames();
            }
            else
            {
                _navigationService.NavigateTo<WaitingForm>();
            }

            btnJoinGame.Enabled = true;
        }

        private void JoinGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isJoining)
            {
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private async void BtnUpdateGames_Click(object sender, EventArgs e)
        {
            await LoadGames();
        }

        private async Task LoadGames()
        {
            btnUpdateGames.Enabled = false;

            try
            {
                var games = await _gameService.GetOpenedGamesAsync();

                flowGames.Controls.Clear();
                foreach (var game in games)
                {
                    var card = new GameCardControl(game);
                    card.OnJoinClicked += OnJoinButtonClick;
                    flowGames.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Не удалось загрузить игры", ex);
                _notificationService.ShowError(Resources.Join_UpdateError);
            }

            btnUpdateGames.Enabled = true;
        }
    }
}
