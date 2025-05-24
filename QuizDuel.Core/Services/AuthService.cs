using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.DataAccess.Models;
using QuizDuel.DataAccess.Repositories;

namespace QuizDuel.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly INotificationService _errorService;
        private readonly IRegisterValidator _registerValidator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AuthService(
            INotificationService errorService,
            IRegisterValidator registerValidator,
            IUserRepository userRepository,
            IPasswordService passwordService)
        {
            _errorService = errorService;
            _registerValidator = registerValidator;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task LoginAsync(LoginDTO loginDTO)
        {
            if (!IsUsernameEmpty(loginDTO.Username))
            {
                _errorService.ShowError("Заполните имя пользователя");
                return;
            }
            try
            {
                var user = await _userRepository.GetByUsername(loginDTO.Username);

                if (user == null)
                {
                    _errorService.ShowError("Такого пользователя не существует");
                    return;
                }

                var inputHash = _passwordService.HashPassword(loginDTO.Password, user.Salt);

                if (inputHash != user.PasswordHash)
                {
                    _errorService.ShowError("Неверный пароль");
                    return;
                }
            }
            catch (Exception ex)
            {
                _errorService.ShowError(ex.Message);
            }

        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            if (!_registerValidator.ValidateInput(registerDTO, out string errorMessage))
            {
                _errorService.ShowError(errorMessage);
                return;
            }
            try
            {
                if (await _userRepository.IsUserExistsByUsername(registerDTO.Username))
                {
                    _errorService.ShowError("Такой пользователь уже существует.");
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
                    Birthdate = registerDTO.Birthdate.ToUniversalTime(),
                };

                await _userRepository.AddUser(newUser);
            }
            catch (Exception ex)
            {
                _errorService.ShowError(ex.Message);
            }
        }        

        private bool IsUsernameEmpty(string username)
        {
            return string.IsNullOrEmpty(username);
        }
    }
}
