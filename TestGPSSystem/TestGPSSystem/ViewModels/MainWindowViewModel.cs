using System.Windows;
using System.Windows.Input;
using ReactiveUI;
using TestGPSSystem.Windows;

namespace TestGPSSystem.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly Window _owner;

        public ICommand BtnTestRunCommand { get; }
        public ICommand BtnTheoryCommand { get; }
        public ICommand BtnExitCommand { get; }

        public MainWindowViewModel(Window owner)
        {
            _owner = owner;

            BtnTestRunCommand = new CommandHandler(OpenTestRunWindow, true);
            BtnExitCommand = new CommandHandler(Exit, true);
        }

        private void OpenTestRunWindow()
        {
            var window = new TestRunWindow
            {
                Owner = _owner
            };

            window.Show();
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

    }
}
