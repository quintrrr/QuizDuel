using Castle.Windsor;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IWindsorContainer _container;
        private Form? _currentForm;
        public Form? CurrentForm
        {
            get
            {
                return _currentForm;
            }
            set 
            { 
                _currentForm = value;
            }
        } 

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
            nextForm.Show();

            if (_currentForm is not null && !_currentForm.IsDisposed && !_currentForm.Disposing)
            {
                _currentForm.Hide();
            }

            _currentForm = nextForm;
        }
    }
}
