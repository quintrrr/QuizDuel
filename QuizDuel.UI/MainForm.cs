using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class MainForm : Form
    {
        private readonly IUserSessionService _userSessionService;
        private readonly LoginForm _loginForm;

        public MainForm(
            IUserSessionService userSessionService,
            LoginForm loginForm)
        {
            InitializeComponent();
            ApplyLocalization();

            _userSessionService = userSessionService;
            _loginForm = loginForm;
        }

        private void ApplyLocalization()
        {
            btnCreateGame.Text = Resources.CreateGameButton;
            btnJoinGame.Text = Resources.JoinGameButton;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_userSessionService.UserID is null)
            {
                if (_loginForm.ShowDialog() != DialogResult.OK)
                {
                    Close();
                } 

            }
        }
    }
}
