using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
