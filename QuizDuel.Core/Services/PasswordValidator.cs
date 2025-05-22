using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizDuel.Core.Services
{
    public class PasswordValidator: IPasswordValidator
    {
        public bool ValidatePassword(string password, out string errorMessage)
        {
            var errorMessages = new List<string>();

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,20}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasMiniMaxChars.IsMatch(password))
            {
                errorMessages.Add("Пароль должен быть не менее 8 и не более 20 символов.");
            }
            if (!hasLowerChar.IsMatch(password))
            {
                errorMessages.Add("Пароль должен содержать хотя бы одну строчную букву.");
            }
            if (!hasUpperChar.IsMatch(password))
            {
                errorMessages.Add("Пароль должен содержать хотя бы одну заглавную букву.");
            }
            if (!hasNumber.IsMatch(password))
            {
                errorMessages.Add("Пароль должен содержать хотя бы одну цифру.");
            }
            if (!hasSymbols.IsMatch(password))
            {
                errorMessages.Add("Пароль должен содержать хотя бы один специальный символ.");
            }

            if (errorMessages.Count > 0)
            {
                errorMessage = string.Join("\n", errorMessages);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
