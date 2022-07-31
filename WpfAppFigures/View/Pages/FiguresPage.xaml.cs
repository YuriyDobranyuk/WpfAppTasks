using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppFigures.Model;
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
            //DataContext = new FiguresViewModel();
            List<Figure> figures = new List<Figure>();
            for (var i = 1; i <= 5; i++)
            {
                Circle elCircle = new Circle(figuresCanvas);
                Figure elFigureCircle = elCircle;
                figures.Add(elFigureCircle);
                Thread.Sleep(50);
            }
            for (var i = 1; i <= 5; i++)
            {
                RectangleFigure elRectangleFigure = new RectangleFigure(figuresCanvas);
                Figure elFigureRectangleFigure = elRectangleFigure;
                figures.Add(elFigureRectangleFigure);
                Thread.Sleep(50);
            }
            for (var i = 1; i <= 5; i++)
            {
                Triangle elTriangle = new Triangle(figuresCanvas);
                Figure elFigureTriangle = elTriangle;
                figures.Add(elFigureTriangle);
                Thread.Sleep(50);
            }
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
