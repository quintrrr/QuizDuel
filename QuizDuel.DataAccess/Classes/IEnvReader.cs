namespace QuizDuel.DataAccess.Classes
{
    public interface IEnvReader
    {
        bool TryLoad(string filePath);
    }
}
