using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAppFigures.Enums;
using WpfAppFigures.Model;
using WpfAppFigures.Services.Commands;

namespace WpfAppFigures.ViewModel 
{
    internal class FiguresViewModel : BaseViewModel
    {
        #region Props
        public ObservableCollection<Figure> Figures { get; set; }
        public ObservableCollection<Shape> FiguresShape { get; set; }

        public DispatcherTimer timer;
        #endregion

        #region Commands
        #region SelectFigureCommand
        public ICommand SelectFigureCommand { get; }
        private bool CanSelectFigureCommandExecute(object p) => true;
        private void OnSelectFigureCommandExecute(object p)
        {
            Enum.TryParse(p.ToString(), out FigureType selectedFigure);
            if (selectedFigure == FigureType.Circle)
            {
                var figure = new Circle();
                var item = figure.Shape;
                figure.Move(timer);
                FiguresShape.Add(item);
                Figures.Add(figure);
            }
            else if (selectedFigure == FigureType.Rectangle)
            {
                var figure = new RectangleFigure();
                var item = figure.Shape;
                figure.Move(timer);
                FiguresShape.Add(item);
                Figures.Add(figure);
            }
            else if (selectedFigure == FigureType.Triangle)
            {
                var figure = new Triangle();
                var item = figure.Shape;
                figure.Move(timer);
                FiguresShape.Add(item);
                Figures.Add(figure);
            }
        }
        #endregion
        #endregion

        public FiguresViewModel()
        {
            Figures = new ObservableCollection<Figure>();
            FiguresShape = new ObservableCollection<Shape>();

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };
            timer.Start();

            #region Comands
            SelectFigureCommand = new LambdaCommand(OnSelectFigureCommandExecute,
                             CanSelectFigureCommandExecute);
            #endregion
        }
    }
}


