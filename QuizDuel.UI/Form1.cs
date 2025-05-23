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
        

        public Form1(AppDbContext db, IAuthService authService)
        {
            _db = db;
            _authService = authService;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var registerDTO = new RegisterDTO
            {
                Username = textBox1.Text,
                Birthdate = dateTimePicker1.Value,
                Password = textBox2.Text,
                RepeatPassword = textBox3.Text,
            };
            _authService.RegisterAsync(registerDTO);
        }
    }
}
