using QuizDuel.DataAccess;
using QuizDuel.DataAccess.Repositories;

namespace QuizDuel.UI
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _db;
        private readonly IUserRepository _userRepository;

        public Form1(AppDbContext db, IUserRepository userRepository)
        {
            _db = db;
            _userRepository = userRepository;

            InitializeComponent();
        }

    }
}
