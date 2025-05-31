using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class WaitingForm : Form
    {
        private readonly IGameService _gameService;
        private readonly INavigationService _navigationService;
        
        
        /// <summary>
        /// Форма начала игры.
        /// </summary>
        public WaitingForm(
            IGameService gameService,
            INavigationService navigationService)
        {
            InitializeComponent();

            _gameService = gameService;
            _navigationService = navigationService;
        } 
        
        /// <summary>
        /// Обрабатывает нажатие кнопки запуска игры.
        /// </summary>
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            
        }

        private async void WaitingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            await _gameService.DeleteGameAsync();
            _navigationService.NavigateTo<MainForm>();
        }
    }
}
