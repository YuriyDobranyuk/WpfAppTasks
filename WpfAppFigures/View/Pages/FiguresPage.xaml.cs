using System.Windows.Controls;
using WpfAppFigures.ViewModel;

namespace WpfAppFigures.View.Pages
{
    /// <summary>
    /// Interaction logic for FiguresPage.xaml
    /// </summary>
    public partial class FiguresPage : Page
    {
        public FiguresPage()
        {
            InitializeComponent();
            DataContext = new FiguresViewModel(Dispatcher);
        }
    }
}
