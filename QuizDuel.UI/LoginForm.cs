using Castle.Core.Logging;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;

        public LoginForm(
            IAuthService authService, 
            INotificationService notificationService,
            ILogger logger)
        {
            InitializeComponent();
            ApplyLocalization();
            _authService = authService;
            _notificationService = notificationService;
            _logger = logger;
        }

        private void ApplyLocalization()
        {
            usernameLabel.Text = Resources.UsernameLabel;
            passwordLabel.Text = Resources.PasswordLabel;
            btnLogin.Text = Resources.Login_BtnLogin;
            regLabel.Text = Resources.Login_NoAccount;
        }

        private void RegLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private async void BtnLogin_ClickAsync(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;

            var loginDTO = new LoginDTO
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text,
            };

            var result = await _authService.LoginAsync(loginDTO);

            var message = string.Join("\n", result.MessageKeys
                 .Select(k => Resources.ResourceManager.GetString(k) ?? k));

            if (!result.Success)
            {
                _logger.Warn("Неудачная попытка входа в аккаунт");
                _notificationService.ShowError(message);
            }
            else
            {
                DialogResult = DialogResult.OK;
                _logger.Info("Пользователь успешно вошел в аккаут.");
                _notificationService.ShowSuccess(Resources.Login_Success);
            }

            btnLogin.Enabled = true;
        }
    }
}
