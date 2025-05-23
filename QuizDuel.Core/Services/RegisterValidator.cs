using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.DataAccess.Repositories;

namespace QuizDuel.Core.Services
{
    public class RegisterValidator : IRegisterValidator
    {
        private readonly IPasswordValidator _passwordValidator;

        public RegisterValidator(IPasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        public bool ValidateInput(RegisterDTO registerDTO, out string errorMessage)
        {
            var errorMessages = new List<string>();

            if (string.IsNullOrEmpty(registerDTO.Username.Trim()))
            {
                errorMessages.Add("Заполните имя пользователя");
            }
            if (string.IsNullOrEmpty(registerDTO.Password.Trim()))
            {
                errorMessages.Add("Введите пароль");
            }
            if (string.IsNullOrEmpty(registerDTO.RepeatPassword.Trim()))
            {
                errorMessages.Add("Введите повторный пароль");
            }

            if (errorMessages.Count > 0)
            {
                errorMessage = string.Join("\n", errorMessages);
                return false;
            }

            if (CalculateAge(registerDTO.Birthdate) < 4)
            {
                errorMessage = "Вам должно быть не меньше 4 лет";
                return false;
            }

            if (registerDTO.Password != registerDTO.RepeatPassword)
            {
                errorMessage = "Пароли должны совпадать";
                return false;
            }

            if (!_passwordValidator.ValidatePassword(registerDTO.Password, out string passwordErrorMessage))
            {
                errorMessage = passwordErrorMessage;
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }


    }
}
