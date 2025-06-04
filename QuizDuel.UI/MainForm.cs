using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class MainForm : Form
    {
        private readonly IUserSessionService _userSessionService;
        private readonly IGameService _gameService;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;
        private readonly INavigationService _navigationService;

        public MainForm(
            IUserSessionService userSessionService,
            IGameService gameService,
            ILogger logger,
            INotificationService notificationService,
            INavigationService navigationService)
        {
            InitializeComponent();
            ApplyLocalization();

            _userSessionService = userSessionService;
            _gameService = gameService;
            _logger = logger;
            _notificationService = notificationService;
            _navigationService = navigationService;
        }

        private void ApplyLocalization()
        {
            btnCreateGame.Text = Resources.CreateGameButton;
            btnJoinGame.Text = Resources.JoinGameButton;
        }

        private async void BtnCreateGame_Click(object sender, EventArgs e)
        {
            btnCreateGame.Enabled = false;
            try
            {
                var gameId = await _gameService.CreateGameAsync(_userSessionService.UserID);
                _gameService.GameId = gameId;
                _navigationService.NavigateTo<WaitingForm>();
            }
            catch (Exception ex)
            {
                _notificationService.ShowError(Resources.Game_CreateError);
            }
            btnCreateGame.Enabled = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _navigationService.Exit();
        }

        private void BtnJoinGame_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo<JoinGameForm>();
        }

    }
}
