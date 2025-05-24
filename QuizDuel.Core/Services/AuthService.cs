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
        private readonly IRegisterValidator _registerValidator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AuthService(
            IRegisterValidator registerValidator,
            IUserRepository userRepository,
            IPasswordService passwordService)
        {
            _registerValidator = registerValidator;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<OperationResultDTO> LoginAsync(LoginDTO loginDTO)
        {
            var result = new OperationResultDTO();

            if (!IsUsernameEmpty(loginDTO.Username))
            {
                result.MessageKeys.Add("Login.EmptyUsername");
                return result;
            }
            try
            {
                var user = await _userRepository.GetByUsername(loginDTO.Username);

                if (user == null)
                {
                    result.MessageKeys.Add("Login.NonExistingUser");
                    return result;
                }

                var inputHash = _passwordService.HashPassword(loginDTO.Password, user.Salt);

                if (inputHash != user.PasswordHash)
                {
                    result.MessageKeys.Add("Login.WrongPassword");
                    return result;
                }

                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.MessageKeys.Add(ex.Message);
                return result;
            }
        }

        public async Task<OperationResultDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var result = new OperationResultDTO();

            if (!_registerValidator.ValidateInput(registerDTO, out List<string> errorMessages))
            {
                result.MessageKeys.AddRange(errorMessages);
                return result;
            }
            try
            {
                if (await _userRepository.IsUserExistsByUsername(registerDTO.Username))
                {
                    result.MessageKeys.Add("Register.ExistingUser");
                    return result;
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
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.MessageKeys.Add(ex.Message);
                return result;
            }
        }        

        private bool IsUsernameEmpty(string username)
        {
            return string.IsNullOrEmpty(username);
        }
    }
}
