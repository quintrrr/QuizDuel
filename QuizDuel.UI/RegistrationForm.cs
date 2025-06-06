using System.Globalization;
using Castle.Core.Logging;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI
{
    public partial class RegistrationForm : Form
    {
        private readonly IAuthService _authService;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;
        private readonly INavigationService _navigationService;

        public RegistrationForm(
            IAuthService authService,
            INotificationService notificationService,
            ILogger logger,
            INavigationService navigationService
            )
        {
            InitializeComponent();
            ApplyLocalization();

            _authService = authService;
            _notificationService = notificationService;
            _logger = logger;
            _navigationService = navigationService;

            toolStrip.Items.Add(new ToolStripButton("RU", null, (_, _) => SetLanguage("ru")));
            toolStrip.Items.Add(new ToolStripButton("EN", null, (_, _) => SetLanguage("en")));
        }

        private void ApplyLocalization()
        {
            usernameLabel.Text = Resources.UsernameLabel;
            birthdateLabel.Text = Resources.BirthdateLabel;
            passwordLabel.Text = Resources.PasswordLabel;
            repeatPasswordLabel.Text = Resources.RepeatPasswordLabel;
            btnRegister.Text = Resources.RegisterButton;
            haveAccountLinkLabel.Text = Resources.Register_HaveAnAccount;
        }
        public void SetLanguage(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

            ApplyLocalization();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки регистрации.
        /// </summary>
        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;

            var registerDTO = new RegisterDTO
            {
                Username = usernameTextBox.Text,
                Birthdate = birthdatePicker.Value,
                Password = passwordTextBox.Text,
                RepeatPassword = repeatPasswordTextBox.Text,
            };

            var result = await _authService.RegisterAsync(registerDTO);
            var message = string.Join("\n", result.MessageKeys
                .Select(k => Resources.ResourceManager.GetString(k) ?? k));

            if (!result.Success)
            {
                _logger.Warn("Регистрация не удалась.");
                _notificationService.ShowError(message);
                btnRegister.Enabled = true;
            }
            else
            {
                _logger.Info("Пользователь успешно зарегистрирован.");
                _notificationService.ShowSuccess(Resources.Register_Successful);
                _navigationService.NavigateTo<MainForm>();
            }
        }

        private void HaveAccountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _navigationService.NavigateTo<LoginForm>();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
