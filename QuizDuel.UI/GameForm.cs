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

                categoryPanel.Enabled = true;
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при выборе категории");
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

                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task LoadQuestions()
        {

        }
    }
}
