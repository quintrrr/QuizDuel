using QuizDuel.Core.DTO;

namespace QuizDuel.UI.UserControls
{
    public partial class GameCardControl: UserControl
    {
        private readonly OpenedGameDTO _game;
        public event EventHandler<Guid>? OnJoinClicked;

        public GameCardControl(OpenedGameDTO game)
        {
            InitializeComponent();

            _game = game;
            btnJoin.Text = Resources.Game_JoinButton;
            hostUsernameLabel.Text = _game.HostUsername;
            btnJoin.Click += (_, _) => OnJoinClicked?.Invoke(this, _game.GameId);
        }
    }
}
