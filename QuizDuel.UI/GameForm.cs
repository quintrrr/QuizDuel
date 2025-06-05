using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class GameForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INotificationService _notificationService;
        private readonly INavigationService _navigationService;

        public GameForm(
            IGameService gameService,
            INotificationService notificationService,
            INavigationService navigationService)
        {
            InitializeComponent();

            _gameService = gameService;
            _notificationService = notificationService;
            _navigationService = navigationService;

            selectCategoryLabel.Text = Resources.Game_SelectCategory;

            ShowCategorySelection();
        }

        private async void ShowCategorySelection()
        {
            try
            {
                var categories = await _gameService.GetRandomCategoriesAsync(3);
                btnCategory1.Text = categories[0].Name;
                btnCategory2.Text = categories[1].Name;
                btnCategory3.Text = categories[2].Name;

                btnCategory1.Tag = categories[0].Id;
                btnCategory2.Tag = categories[1].Id;
                btnCategory3.Tag = categories[2].Id;

                categoryPanel.Visible = true;
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

        private void ButtonCategory_Click(object sender, EventArgs e)
        {

        }
    }
}
