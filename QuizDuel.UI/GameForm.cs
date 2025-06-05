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
        private readonly ILogger _logger;

        private List<ShuffledQuestionDTO> _questions = [];
        private int _currentQuestionIndex = 0;

        public GameForm(
            IGameService gameService,
            INotificationService notificationService,
            INavigationService navigationService,
            ILogger logger)
        {
            InitializeComponent();

            _gameService = gameService;
            _notificationService = notificationService;
            _navigationService = navigationService;
            _logger = logger;

            selectCategoryLabel.Text = Resources.Game_SelectCategory;
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
                _navigationService.NavigateTo<WaitingForm>();
            }

        }

        private void ButtonAnswer_Click(object sender, EventArgs e)
        {

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
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async void GameForm_Load(object sender, EventArgs e)
        {
            try
            {
                var gameState = await _gameService.GetGameStateAsync();

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
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async Task LoadQuestions()
        {
            try
            {
                _questions = await _gameService.GetShuffledQuestionsAsync(3);
                _currentQuestionIndex = 0;
                ShowQuestion();
            } 
            catch (Exception ex)
            {
                _logger.Error("Не удалось загрузить вопросы", ex);
                _notificationService.ShowError(Resources.Game_LoadQuestionsError);
                _navigationService.NavigateTo<WaitingForm>();
            }
        }

        private async Task ShowQuestion()
        {
            var question = _questions[_currentQuestionIndex];
            questionLabel.Text = question.Text;

            btnAnswer1.Text = question.Answers[0];
            btnAnswer2.Text = question.Answers[1];
            btnAnswer3.Text = question.Answers[2];
            btnAnswer4.Text = question.Answers[3];

            ResetButtonStyles();

            categoryPanel.Visible = false;
            gamePanel.Visible = true;

            await StartTimerAsync(10);
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
                questionTimer.Value = i;

                await Task.Delay(10); 
            }

            //TimeExpired();
        }
    }
}
