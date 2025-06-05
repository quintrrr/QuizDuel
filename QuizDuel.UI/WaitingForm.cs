using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class WaitingForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INavigationService _navigationService;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;
        private readonly IUserSessionService _userSessionService;

        private bool _isGameStarted;

        public WaitingForm(
            IGameService gameService,
            INavigationService navigationService,
            ILogger logger,
            INotificationService notificationService,
            IUserSessionService userSessionService)
        {
            InitializeComponent();

            _gameService = gameService;
            _navigationService = navigationService;
            _logger = logger;
            _notificationService = notificationService;
            _userSessionService = userSessionService;
        }

        private async void BtnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            try
            {
                var gameState = await _gameService.GetGameStateAsync();

                if (!gameState.IsStarted)
                {
                    _notificationService.ShowError(Resources.Game_NotStarted);
                    btnPlay.Enabled = true;
                    await UpdateLabels();
                    return;
                }
                else if (gameState.IsFinished)
                {
                    _notificationService.ShowError(Resources.Game_Finished);
                    _navigationService.NavigateTo<MainForm>();
                }

                _isGameStarted = true;
                if (gameState.CurrentTurnPlayerId != _userSessionService.UserID)
                {
                    _notificationService.ShowInfo(Resources.Game_AnotherTurn);
                    btnPlay.Enabled = true;
                    await UpdateLabels();
                }
                else
                {
                    _navigationService.NavigateTo<GameForm>();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _notificationService.ShowError(Resources.Game_StateError);
                Close();
            }
        }

        private async Task UpdateLabels()
        {
            try
            {
                var (player1, player2) = await _gameService.GetUsernamesAsync();

                player1NameLabel.Text = player1 ?? Resources.Player1Label;
                player2NameLabel.Text = player2 ?? Resources.Player2Label;

                var (score1, score2) = await _gameService.GetScoresAsync();
                scoreLabel.Text = $"{score1} : {score2}";
            } 
            catch {
                _notificationService.ShowError(Resources.Game_LoadError);
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private async void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isGameStarted)
            {
                await _gameService.DeleteGameAsync();
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private async void WaitingForm_Load(object sender, EventArgs e)
        {
            await UpdateLabels();
        }
    }
}
