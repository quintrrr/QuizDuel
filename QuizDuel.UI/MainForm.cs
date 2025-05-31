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
        private readonly LoginForm _loginForm;

        public MainForm(
            IUserSessionService userSessionService,
            IGameService gameService,
            ILogger logger,
            INotificationService notificationService,
            INavigationService navigationService,
            LoginForm loginForm)
        {
            InitializeComponent();
            ApplyLocalization();

            _userSessionService = userSessionService;
            _gameService = gameService;
            _logger = logger;
            _notificationService = notificationService;
            _navigationService = navigationService;
            _loginForm = loginForm;
        }

        private void ApplyLocalization()
        {
            btnCreateGame.Text = Resources.CreateGameButton;
            btnJoinGame.Text = Resources.JoinGameButton;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_userSessionService.UserID == default)
            {
                if (_loginForm.ShowDialog() != DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private async void BtnCreateGame_Click(object sender, EventArgs e)
        {
            try
            {
                var gameId = await _gameService.CreateGameAsync(_userSessionService.UserID);
                _gameService.SetGameId(gameId);
                _navigationService.NavigateTo<WaitingForm>();
            }
            catch (Exception ex)
            {
                _notificationService.ShowError(Resources.Game_CreateError);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _navigationService.Exit();
        }
    }
}
