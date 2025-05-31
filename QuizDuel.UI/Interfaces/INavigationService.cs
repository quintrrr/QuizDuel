namespace QuizDuel.Core.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : Form;
        void Exit();
    }
}