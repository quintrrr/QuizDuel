using System.Threading.Tasks;
using QuizDuel.DataAccess;
using QuizDuel.DataAccess.Repositories;

namespace QuizDuel.UI
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _db;
        private readonly UserRepository _userRepository;

        public Form1(AppDbContext db)
        {
            _db = db;
            _userRepository = new UserRepository(db);

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = "qwerty8790";
            
            var user = await _userRepository.GetByUsername(username);

            Console.WriteLine(user.Username);
        }
    }
}
