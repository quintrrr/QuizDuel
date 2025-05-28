using Castle.Core.Logging;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.DataAccess;

namespace QuizDuel.UI
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _db;
        private readonly IAuthService _authService;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;

        public Form1(
            AppDbContext db,
            IAuthService authService,
            INotificationService notificationService,
            ILogger logger)
        {
            _db = db;
            _authService = authService;
            _notificationService = notificationService;
            _logger = logger;

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var registerDTO = new RegisterDTO
            {
                Username = textBox1.Text,
                Birthdate = dateTimePicker1.Value,
                Password = textBox2.Text,
                RepeatPassword = textBox3.Text,
            };

            var result = await _authService.RegisterAsync(registerDTO);
            var message = string.Join("\n", result.MessageKeys
                .Select(k => Resources.ResourceManager.GetString(k) ?? k));

            if (!result.Success)
            {
                _logger.Info("Успех");
                _notificationService.ShowError(message);
            }
            else
            {
                _logger.Info("Не_успех");
                _notificationService.ShowSuccess(Resources.Register_Successful);
            }
        }
    }
}
