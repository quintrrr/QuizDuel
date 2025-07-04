﻿using System.Globalization;
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
        private readonly INavigationService _navigationService;

        public LoginForm(
            IAuthService authService,
            INotificationService notificationService,
            ILogger logger,
            INavigationService navigationService)
        {
            InitializeComponent();
            ApplyLocalization();
            _authService = authService;
            _notificationService = notificationService;
            _logger = logger;
            _navigationService = navigationService;

            toolStrip.Items.Add(new ToolStripButton("RU", null, (_, _) => SetLanguage("ru")));
            toolStrip.Items.Add(new ToolStripButton("EN", null, (_, _) => SetLanguage("en")));
            toolStrip.Items.Add(new ToolStripButton("TT", null, (_, _) => SetLanguage("tt")));

            Font = FontManager.GetCustomFont(15f);
            toolStrip.Font = FontManager.GetCustomFont(12f);
            titleLabel.Font = FontManager.GetCustomFont(30f);
        }


        private void ApplyLocalization()
        {
            usernameLabel.Text = Resources.UsernameLabel;
            passwordLabel.Text = Resources.PasswordLabel;
            btnLogin.Text = Resources.Login_BtnLogin;
            regLabel.Text = Resources.Login_NoAccount;
            titleLabel.Text = Resources.Login_Label;
        }

        public void SetLanguage(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

            ApplyLocalization();
        }

        private void RegLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _navigationService.NavigateTo<RegistrationForm>();
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
                _logger.Info("Пользователь успешно вошел в аккаут.");
                _notificationService.ShowSuccess(Resources.Login_Success);
                _navigationService.NavigateTo<MainForm>();
            }

            btnLogin.Enabled = true;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
