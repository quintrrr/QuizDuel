using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class JoinGameForm : Form
    {
        private readonly IGameService _gameService;
        public JoinGameForm(IGameService gameService)
        {
            InitializeComponent();

            _gameService = gameService;
        }

        private void JoinGameForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
