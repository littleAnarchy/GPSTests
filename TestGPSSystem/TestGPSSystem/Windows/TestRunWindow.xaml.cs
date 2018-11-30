using TestGPSSystem.ViewModels;

namespace TestGPSSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для TestRunWindow.xaml
    /// </summary>
    public partial class TestRunWindow
    {
        public TestRunWindow()
        {
            DataContext = new TestRunViewModel();
            InitializeComponent();
        }
    }
}
