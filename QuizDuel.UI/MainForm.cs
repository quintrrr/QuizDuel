using System.Globalization;
using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;
using QuizDuel.UI.UserControls;

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
            toolStrip.Items.Add(new ToolStripButton("TT", null, (_, _) => SetLanguage("tt")));

            Font = FontManager.GetCustomFont(15f);
            toolStrip.Font = FontManager.GetCustomFont(12f);
            titleLabel.Font = FontManager.GetCustomFont(40f);
        }

        private void ApplyLocalization()
        {
            btnCreateGame.Text = Resources.CreateGameButton;
            btnJoinGame.Text = Resources.JoinGameButton;
            gameHistoryLabel.Text = Resources.GameHistoryLabel;
        }

        private async Task LoadGameHistory()
        {
            flowGameHistory.Controls.Clear();

            var games = await _gameService.GetGameHistoryAsync(10);

            foreach (var game in games)
            {
                var item = new GameHistoryItemControl
                {
                    OpponentName = game.OpponentUsername,
                    GameEndTime = game.EndTime
                };
                item.RefreshTimeAgo();
                item.SetResult(game.WinnerId, _userSessionService.UserID);

                flowGameHistory.Controls.Add(item);
            }
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
                return;
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
            _navigationService.CurrentForm = null;
            Hide();
            _navigationService.NavigateTo<MainForm>();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateTo<LeaderboardForm>();
        }

        private async void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && _navigationService.CurrentForm is not MainForm)
            {
                Enabled = false;
                try
                {
                    await LoadGameHistory();
                }
                catch
                {
                    _notificationService.ShowError(Resources.GameHistoryLoadError);
                }

                Enabled = true;
            }
        }
    }
}
