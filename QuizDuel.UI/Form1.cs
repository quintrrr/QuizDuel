using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.DataAccess;
using QuizDuel.DataAccess.Repositories;

namespace QuizDuel.UI
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _db;
        private readonly IAuthService _authService;
        private readonly INotificationService _notificationService;

        public Form1(
            AppDbContext db,
            IAuthService authService,
            INotificationService notificationService)
        {
            _db = db;
            _authService = authService;
            _notificationService = notificationService;

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
                _notificationService.ShowError(message);
            }
            else
            {
                _notificationService.ShowSuccess(Resources.Register_Successful);
            }
        }
    }
}
