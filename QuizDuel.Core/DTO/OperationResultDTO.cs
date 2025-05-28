namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// Объект передачи данных, представляющий результат выполнения операции.
    /// </summary>
    public class OperationResultDTO
    {
        public bool Success { get; set; }

        public List<string> MessageKeys { get; set; } = [];
    }
}
