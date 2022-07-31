using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppFigures.Model;
using WpfAppFigures.Services.Commands;

namespace WpfAppFigures.ViewModel 
{
    internal class FiguresViewModel : BaseViewModel
    {
        #region Props
        public List<Figure> figures = new List<Figure>();
        public LinkedList<Figure> ListFigures = new LinkedList<Figure>();
      
        #endregion

        #region Commands
        #region ToolbarButtonClickCommand
        public ICommand ToolbarButtonClickCommand { get; }
        private bool CanToolbarButtonClickCommandExecute(object p) => true;
        private void OnToolbarButtonClickCommandExecute(object p)
        {
            //var content = Application.Current.MainWindow.Content;
            Canvas figuresCanvas = (Canvas)p;
            Triangle elTriangle = new Triangle(figuresCanvas);
            Figure elFigureTriangle = elTriangle;
            figures.Add(elFigureTriangle);
            ListFigures.AddLast(elFigureTriangle);

            //string typeFigure = p.ToString();
            /*switch (typeFigure)
            {
                case "triangle":
                    Triangle elTriangle = new Triangle(figuresCanvas);
                    Figure elFigureTriangle = elTriangle;
                    figures.Add(elFigureTriangle);
                    ListFigures.AddLast(elFigureTriangle);
                    break;
                case "rectangle":
                    RectangleFigure elRectangleFigure = new RectangleFigure(figuresCanvas);
                    Figure elFigureRectangleFigure = elRectangleFigure;
                    figures.Add(elFigureRectangleFigure);
                    ListFigures.AddLast(elFigureRectangleFigure);
                    break;
                case "circle":
                    Circle elCircle = new Circle(figuresCanvas);
                    Figure elFigureCircle = elCircle;
                    figures.Add(elFigureCircle);
                    ListFigures.AddLast(elFigureCircle);
                    break;
            }*/
        }
        #endregion
        #region OnWindowLoaded
        public ICommand OnWindowLoaded { get; }
        private bool CanOnWindowLoadedExecute(object p) => true;
        private void OnOnWindowLoadedExecute(object p)
        {
            //var content = Application.Current.MainWindow.Content;
            Canvas figuresCanvas = (Canvas)p;
            Triangle elTriangle = new Triangle(figuresCanvas);
            Figure elFigureTriangle = elTriangle;
            figures.Add(elFigureTriangle);
            ListFigures.AddLast(elFigureTriangle);

            //string typeFigure = p.ToString();
            /*switch (typeFigure)
            {
                case "triangle":
                    Triangle elTriangle = new Triangle(figuresCanvas);
                    Figure elFigureTriangle = elTriangle;
                    figures.Add(elFigureTriangle);
                    ListFigures.AddLast(elFigureTriangle);
                    break;
                case "rectangle":
                    RectangleFigure elRectangleFigure = new RectangleFigure(figuresCanvas);
                    Figure elFigureRectangleFigure = elRectangleFigure;
                    figures.Add(elFigureRectangleFigure);
                    ListFigures.AddLast(elFigureRectangleFigure);
                    break;
                case "circle":
                    Circle elCircle = new Circle(figuresCanvas);
                    Figure elFigureCircle = elCircle;
                    figures.Add(elFigureCircle);
                    ListFigures.AddLast(elFigureCircle);
                    break;
            }*/
        }
        #endregion
        #endregion

        public FiguresViewModel()
        {
            //List<Figure> figures = new List<Figure>();
            LinkedList<Figure> ListFigures = new LinkedList<Figure>();
            #region Comands
            ToolbarButtonClickCommand = new LambdaCommand(OnToolbarButtonClickCommandExecute, 
                                        CanToolbarButtonClickCommandExecute);
            OnWindowLoaded = new LambdaCommand(OnToolbarButtonClickCommandExecute, 
                                        CanToolbarButtonClickCommandExecute);
            #endregion
        }
    }
}


