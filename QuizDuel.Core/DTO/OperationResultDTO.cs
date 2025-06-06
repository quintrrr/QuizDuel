namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// DTO, представляющий результат выполнения операции.
    /// Используется для обозначения успешности действия и передачи сообщений.
    /// </summary>
    public class OperationResultDTO
    {
        /// <summary>
        /// Указывает, была ли операция выполнена успешно.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Список ключей сообщений, связанных с результатом операции.
        /// Ключи используются для локализации сообщений на клиенте.
        /// </summary>
        public List<string> MessageKeys { get; set; } = [];
    }
}