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

        public bool ValidateInput(RegisterDTO registerDTO, out List<string> errorMessages)
        {
            errorMessages = [];

            if (string.IsNullOrEmpty(registerDTO.Username.Trim()))
            {
                errorMessages.Add("Register.EmptyUsername");
            }
            if (string.IsNullOrEmpty(registerDTO.Password.Trim()))
            {
                errorMessages.Add("Register.EmptyPassword");
            }
            if (string.IsNullOrEmpty(registerDTO.RepeatPassword.Trim()))
            {
                errorMessages.Add("Register.EmptyRepeatPassword");
            }

            if (errorMessages.Count > 0)
            {
                return false;
            }

            if (CalculateAge(registerDTO.Birthdate) < 4)
            {
                errorMessages.Add("Register.InvalidAge");
                return false;
            }

            if (registerDTO.Password != registerDTO.RepeatPassword)
            {
                errorMessages.Add("Register.InvalidRepeatPassword");
                return false;
            }

            if (!_passwordValidator.ValidatePassword(registerDTO.Password, out List<string> passwordErrorMessage))
            {
                errorMessages.AddRange(passwordErrorMessage);
                return false;
            }

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
