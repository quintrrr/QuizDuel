using QuizDuel.Core.DTO;

namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для проверки данных регистрации пользователя.
    /// </summary>
    public interface IRegisterValidator
    {
        /// <summary>
        /// Проверяет корректность введённых данных при регистрации.
        /// </summary>
        bool ValidateInput(RegisterDTO registerDTO, out List<string> errorMessage);
    }
}
