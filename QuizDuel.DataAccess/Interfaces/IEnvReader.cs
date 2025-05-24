namespace QuizDuel.DataAccess.Interfaces
{
    public interface IEnvReader
    {
        bool TryLoad(string filePath);
    }
}
