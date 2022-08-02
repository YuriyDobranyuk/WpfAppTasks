using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using WpfAppFigures.ViewModel;
using Figure = WpfAppFigures.Model.Figure;

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
            DataContext = new FiguresViewModel();
        }
    }
}
