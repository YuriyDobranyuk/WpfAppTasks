using System.Windows.Controls;
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
            /*List<Figure> figures = new List<Figure>();
            for (var i = 1; i <= 1; i++)
            {
                Circle elCircle = new Circle(figuresCanvas);
                Figure elFigureCircle = elCircle;
                figures.Add(elFigureCircle);
                Thread.Sleep(50);
            }
            for (var i = 1; i <= 1; i++)
            {
                RectangleFigure elRectangleFigure = new RectangleFigure(figuresCanvas);
                Figure elFigureRectangleFigure = elRectangleFigure;
                figures.Add(elFigureRectangleFigure);
                Thread.Sleep(50);
            }
            for (var i = 1; i <= 1; i++)
            {
                Triangle elTriangle = new Triangle(figuresCanvas);
                Figure elFigureTriangle = elTriangle;
                figures.Add(elFigureTriangle);
                Thread.Sleep(50);
            }*/
            /*for (var i = 1; i <= 5; i++)
            {
                foreach (var figure in figures)
                {
                    figure.Move();
                    figure.Draw(figuresCanvas);
                }
                
            }*/
            
        }
    }
}
