using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.DTO;
using QuizDuel.DataAccess.Models;
using QuizDuel.DataAccess.Repositories;

namespace QuizDuel.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IErrorService _errorService;
        private readonly IRegisterValidator _registerValidator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AuthService(
            IErrorService errorService,
            IRegisterValidator registerValidator,
            IUserRepository userRepository,
            IPasswordService passwordService)
        {
            _errorService = errorService;
            _registerValidator = registerValidator;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public Task LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            if (!_registerValidator.ValidateInput(registerDTO, out string errorMessage))
            {
                _errorService.SendError(errorMessage);
                return;
            }

            if (await _userRepository.IsUserExistsByUsername(registerDTO.Username))
            {
                _errorService.SendError("Такой пользователь уже существует.");
                return;
            }

            var salt = _passwordService.GenerateSalt();
            var passwordHash = _passwordService.HashPassword(registerDTO.Password, salt);
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = registerDTO.Username,
                PasswordHash = passwordHash,
                Salt = salt,
                Birthdate = registerDTO.Birthdate,
            };

            await _userRepository.AddUser(newUser);
        }        
    }
}
