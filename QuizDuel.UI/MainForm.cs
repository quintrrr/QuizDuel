using System.Globalization;
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

            toolStrip.Items.Add(new ToolStripButton("RU", null, (_, _) => SetLanguage("ru")));
            toolStrip.Items.Add(new ToolStripButton("EN", null, (_, _) => SetLanguage("en")));
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

        private void BtnJoinGame_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo<JoinGameForm>();
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (_userSessionService.UserID == default)
            {
                _navigationService.NavigateTo<LoginForm>();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SetLanguage(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

            ApplyLocalization();
        }
    }
}
