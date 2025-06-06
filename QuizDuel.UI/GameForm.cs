using Castle.Core.Logging;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class GameForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INotificationService _notificationService;
        private readonly INavigationService _navigationService;
        private readonly IUserSessionService _userSessionService;
        private readonly ILogger _logger;

        private List<ShuffledQuestionDTO> _questions = [];
        private int _currentQuestionIndex = 0;
        private bool _isGameContinued;
        private bool _isAnswered;

        public GameForm(
            IGameService gameService,
            INotificationService notificationService,
            INavigationService navigationService,
            IUserSessionService userSessionService,
            ILogger logger)
        {
            InitializeComponent();

            _gameService = gameService;
            _notificationService = notificationService;
            _navigationService = navigationService;
            _userSessionService = userSessionService;
            _logger = logger;

            selectCategoryLabel.Text = Resources.Game_SelectCategory;

            Font = FontManager.GetCustomFont(15f);
            selectCategoryLabel.Font = FontManager.GetCustomFont(30f);
            questionLabel.Font = FontManager.GetCustomFont(18f);
            roundLabel.Font = FontManager.GetCustomFont(12f);
        }

        private async Task ShowCategorySelectionAsync()
        {
            try
            {
                var categories = await _gameService.GetRandomCategoriesAsync(3);
                btnCategory1.Text = categories[0].Name;
                btnCategory2.Text = categories[1].Name;
                btnCategory3.Text = categories[2].Name;

                btnCategory1.Tag = categories[0].Id.ToString();
                btnCategory2.Tag = categories[1].Id.ToString();
                btnCategory3.Tag = categories[2].Id.ToString();

                categoryPanel.Visible = true;
                gamePanel.Visible = false;
            }
            catch
            {
                _notificationService.ShowError(Resources.Game_LoadCategoryError);
                _isGameContinued = true;
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async void ButtonAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                gamePanel.Enabled = false;
                var button = sender as Button;
                if (!int.TryParse(button.Tag.ToString(), out var selectedIndex))
                {
                    throw new Exception("Ошибка при преобразовании button.Tag в int");
                }

                var question = _questions[_currentQuestionIndex];

                var answerDto = new SubmittedAnswerDTO
                {
                    Id = question.QuestionId,
                    Answers = question.Answers,
                    SelectedIndex = selectedIndex
                };

                _isAnswered = true;

                var result = await _gameService.SubmitAnswerAsync(_userSessionService.UserID, answerDto);

                HighlightAnswers(selectedIndex, result.CorrectOptionIndex);

                await Task.Delay(1500);

                _currentQuestionIndex++;
                if (_currentQuestionIndex < _questions.Count)
                {
                    await ShowQuestion();
                }
                else
                {
                    _notificationService.ShowInfo(Resources.Game_RoundOver);
                    await PassTurnAsync();
                    _isGameContinued = true;
                    _navigationService.NavigateTo<WaitingForm>();
                }
            }
            catch
            {
                _notificationService.ShowError(Resources.Game_AnswerError);
                _isGameContinued = true;
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async void ButtonCategory_Click(object sender, EventArgs e)
        {
            try
            {
                categoryPanel.Enabled = false;
                var button = sender as Button;
                if (!Guid.TryParse(button.Tag.ToString(), out var categoryId))
                {
                    throw new Exception("Ошибка при преобразовании button.Tag в Guid");
                }

                await _gameService.SelectCategoryAsync(categoryId);

                await LoadQuestions();

                categoryPanel.Enabled = true;
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при выборе категории", ex);
                _isGameContinued = true;
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async void GameForm_Load(object sender, EventArgs e)
        {
            await ContinueGameAsync();
        }

        private async Task LoadQuestions()
        {
            try
            {
                _questions = await _gameService.GetShuffledQuestionsAsync(3);
                _currentQuestionIndex = 0;
                await ShowRoundInfo();
                await ShowQuestion();
            }
            catch
            {
                _notificationService.ShowError(Resources.Game_LoadQuestionsError);
                _isGameContinued = true;
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async Task ShowQuestion()
        {
            _isAnswered = false;
            var question = _questions[_currentQuestionIndex];
            questionLabel.Text = question.Text;

            btnAnswer1.Text = question.Answers[0];
            btnAnswer2.Text = question.Answers[1];
            btnAnswer3.Text = question.Answers[2];
            btnAnswer4.Text = question.Answers[3];

            ResetButtonStyles();

            categoryPanel.Visible = false;
            gamePanel.Visible = true;
            gamePanel.Enabled = true;

            await StartTimerAsync(10);
        }

        private async Task ShowRoundInfo()
        {
            var (category, round) = await _gameService.GetCurrentCategoryAndRoundAsync();
            roundLabel.Text = (round + 1).ToString();
            categoryLabel.Text = category;
        }

        private void ResetButtonStyles()
        {
            foreach (var btn in new[] { btnAnswer1, btnAnswer2, btnAnswer3, btnAnswer4 })
            {
                btn.BackColor = SystemColors.Control;
            }
        }

        private async Task StartTimerAsync(int seconds)
        {
            int total = seconds * 100;
            questionTimer.Maximum = total;
            questionTimer.Value = total;

            for (int i = total; i >= 0; i--)
            {
                if (_isAnswered)
                {
                    return;
                }

                questionTimer.Value = i;

                await Task.Delay(10);
            }

            await TimeExpired();
        }

        private async Task TimeExpired()
        {
            try
            {
                gamePanel.Enabled = false;

                var question = _questions[_currentQuestionIndex];

                var answerDto = new SubmittedAnswerDTO
                {
                    Id = question.QuestionId,
                    Answers = question.Answers,
                    SelectedIndex = -1
                };

                var result = await _gameService.SubmitAnswerAsync(_userSessionService.UserID, answerDto);

                HighlightAnswers(-1, result.CorrectOptionIndex);

                await Task.Delay(1500);

                _currentQuestionIndex++;
                if (_currentQuestionIndex < _questions.Count)
                {
                    await ShowQuestion();
                }
                else
                {
                    _notificationService.ShowInfo("Раунд завершён!");
                    await PassTurnAsync();
                    _isGameContinued = true;
                    _navigationService.NavigateTo<WaitingForm>();
                }
            }
            catch
            {
                _notificationService.ShowError(Resources.Game_AnswerError);
                _isGameContinued = true;
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private void HighlightAnswers(int selected, int correct)
        {
            var buttons = new[] { btnAnswer1, btnAnswer2, btnAnswer3, btnAnswer4 };
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == correct)
                    buttons[i].BackColor = Color.LightGreen;
                else if (i == selected)
                    buttons[i].BackColor = Color.IndianRed;
                else
                    buttons[i].BackColor = SystemColors.Control;
            }
        }

        private async Task PassTurnAsync()
        {
            try
            {
                await _gameService.PassTurnAsync();
            }
            catch
            {
                _notificationService.ShowError(Resources.Game_PasTurnError);
                _isGameContinued = true;
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async Task ContinueGameAsync()
        {
            try
            {
                var gameState = await _gameService.GetGameStateAsync();

                if (gameState.IsFinished)
                {
                    _isGameContinued = true;
                    _navigationService.NavigateTo<WaitingForm>();
                    return;
                }

                if (gameState.Turn == 0 && gameState.CurrentRound % 2 == 0
                    || gameState.Turn == 1 && gameState.CurrentRound % 2 != 0)
                {
                    await ShowCategorySelectionAsync();
                }
                else
                {
                    await LoadQuestions();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Не удалось загрузить игру", ex);
                _notificationService.ShowError(Resources.Game_LoadError);
                _isGameContinued = true;
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async void GameForm_FormClosing(object sender, FormClosingEventArgs e)
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

            _isAnswered = true;
            if (!_isGameContinued)
            {
                await _gameService.DeleteGameAsync();
                _navigationService.NavigateTo<MainForm>();
            }
        }
    }
}
