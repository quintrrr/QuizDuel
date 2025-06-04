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

        private bool _isGameStarted;
        
        /// <summary>
        /// Форма начала игры.
        /// </summary>
        public WaitingForm(
            IGameService gameService,
            INavigationService navigationService,
            ILogger logger,
            INotificationService notificationService)
        {
            InitializeComponent();

            _gameService = gameService;
            _navigationService = navigationService;
            _logger = logger;
            _notificationService = notificationService;

            UpdateUsernameLabels();
        } 
        
        /// <summary>
        /// Обрабатывает нажатие кнопки запуска игры.
        /// </summary>
        private async void BtnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            try
            {
                var gameState = await _gameService.GetGameStateAsync();

                if (!gameState.IsStarted)
                {
                    _notificationService.ShowError(Resources.Game_NotStarted);
                    return;
                }
                else if (gameState.IsFinished)
                {
                    _notificationService.ShowError(Resources.Game_Finished);
                    _navigationService.NavigateTo<MainForm>();
                }

                _isGameStarted = true;
                btnPlay.Enabled = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _notificationService.ShowError(Resources.Game_StateError);
                Close();
            }
        }

        private async void WaitingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isGameStarted)
            {
                await _gameService.DeleteGameAsync();   
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private async void UpdateUsernameLabels()
        {
            var usernames = await _gameService.GetUsernamesAsync();

            player1NameLabel.Text = usernames.Player1 ?? Resources.Player1Label;
            player2NameLabel.Text = usernames.Player2 ?? Resources.Player2Label;
        }
    }
}
