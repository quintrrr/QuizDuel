using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.Core.Services
{
    public class PasswordValidator: IPasswordValidator
    {
        public bool ValidatePassword(string password, out List<string> errorMessages)
        {
            errorMessages = [];

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,20}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            var isLatinOnly = new Regex(@"^[\x21-\x7E]+$");

            if (!hasMiniMaxChars.IsMatch(password))
            {
                errorMessages.Add("Password.MinMaxChar");
            }
            if (!hasLowerChar.IsMatch(password))
            {
                errorMessages.Add("Password.HasLowerChar");
            }
            if (!hasUpperChar.IsMatch(password))
            {
                errorMessages.Add("Password.HasUpperChar");
            }
            if (!hasNumber.IsMatch(password))
            {
                errorMessages.Add("Password.HasNumber");
            }
            if (!hasSymbols.IsMatch(password))
            {
                errorMessages.Add("Password.HasSymbols");
            }
            if (!isLatinOnly.IsMatch(password))
            {
                errorMessages.Add("Password.IsLatinOnly");
            }

            return errorMessages.Count == 0;
        }
    }
}
