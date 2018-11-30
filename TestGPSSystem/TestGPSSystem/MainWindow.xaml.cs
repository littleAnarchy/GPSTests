using MahApps.Metro;
using TestGPSSystem.ViewModels;

namespace TestGPSSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel(this);
            ThemeManager.ChangeAppStyle(this,
                ThemeManager.GetAccent("Blue"),
                ThemeManager.GetAppTheme("BaseDark"));
            InitializeComponent();
        }
    }
}
