using System.Windows;
using WpfAppFigures.View.Pages;

namespace WpfAppFigures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new FiguresPage();
        }
    }
}
