using Castle.Core.Logging;
using QuizDuel.Core.DTO;
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
        private GameStateDTO _gameState;

        public WaitingForm(
            IGameService gameService,
            INavigationService navigationService,
            ILogger logger,
            INotificationService notificationService,
            IUserSessionService userSessionService)
        {
            InitializeComponent();
            ApplyLocalization();

            _gameService = gameService;
            _navigationService = navigationService;
            _logger = logger;
            _notificationService = notificationService;
            _userSessionService = userSessionService;

            Font = FontManager.GetCustomFont(20f);
            player1NameLabel.Font = FontManager.GetCustomFont(20f);
            player2NameLabel.Font = FontManager.GetCustomFont(20f);
            titleLabel.Font = FontManager.GetCustomFont(40f);
            scoreLabel.Font = FontManager.GetCustomFont(30f);

            btnPlay.Enabled = false;
        }

        private void ApplyLocalization()
        {
            btnPlay.Text = Resources.Game_Play;
        }

        private async Task GetGameState()
        {
            _gameState = await _gameService.GetGameStateAsync();
        }

        private async void BtnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            try
            {
                await GetGameState();

                if (!_gameState.IsStarted)
                {
                    _notificationService.ShowError(Resources.Game_NotStarted);
                    await UpdateLabels();
                    btnPlay.Enabled = true;
                    return;
                }
                else if (_gameState.IsFinished)
                {
                    _notificationService.ShowError(Resources.Game_Finished);
                    await UpdateLabels();
                    return;
                }

                if (_gameState.CurrentTurnPlayerId != _userSessionService.UserID)
                {
                    _notificationService.ShowInfo(Resources.Game_AnotherTurn);
                    await UpdateLabels();
                }
                else
                {
                    _isGameStarted = true;
                    _navigationService.NavigateTo<GameForm>();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _notificationService.ShowError(Resources.Game_StateError);
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private async Task UpdateLabels()
        {
            try
            {
                if (_gameState is null)
                {
                    await GetGameState();
                }

                var (player1, player2) = await _gameService.GetUsernamesAsync();

                player1NameLabel.Text = player1 ?? Resources.Player1Label;
                player2NameLabel.Text = player2 ?? Resources.Player2Label;

                var (score1, score2) = await _gameService.GetScoresAsync();
                scoreLabel.Text = $"{score1} : {score2}";


                if (_gameState.IsFinished)
                {
                    var winner = await _gameService.GetWinnerAsync();
                    _notificationService.ShowInfo(
                        winner == null ? Resources.Game_Draw : $"{Resources.Game_PlayerWon}: {winner}");
                    _navigationService.NavigateTo<MainForm>();
                }

                btnPlay.Enabled = true;
            } 
            catch {
                _notificationService.ShowError(Resources.Game_LoadError);
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private async void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    Resources.ConfirmExitGameMessage,
                    Resources.ConformExitGame,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (!_isGameStarted)
            {
                await _gameService.DeleteGameAsync();
                _navigationService.NavigateTo<MainForm>();
            }
            else if (_gameState.IsFinished) { 
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private async void WaitingForm_Load(object sender, EventArgs e)
        {
            await UpdateLabels();
        }
    }
}
