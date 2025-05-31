using Castle.Windsor;
using QuizDuel.Core.Interfaces;
using QuizDuel.UI;

namespace QuizDuel.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IWindsorContainer _container;
        private Form? _currentForm;

        public NavigationService(IWindsorContainer container)
        {
            _container = container;
        }

        public void Exit()
        {
            Application.Exit();                         
        }

        public void NavigateTo<T>() where T : Form
        {
            var nextForm = _container.Resolve<T>();

            if (_currentForm is not null && !_currentForm.IsDisposed)
            {
                if (_currentForm is MainForm)
                {
                    _currentForm.Hide();
                }
                else
                {
                    _currentForm.Close();
                }
            }

            _currentForm = nextForm;

            nextForm.FormClosed += (_, _) =>
            { 
                if (_currentForm == nextForm)
                {
                    _currentForm = null;
                    if (Application.OpenForms.Count == 0)
                    {
                        Application.Exit();
                    } 
                } 
            };

            nextForm.Show();
        }

    }
}
