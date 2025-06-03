namespace QuizDuel.Core.Interfaces
{
    public interface INavigationService
    {
        Form CurrentForm { set; }

        void NavigateTo<T>() where T : Form;

        void Exit();
    }
}