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
        public string NameButtonStop { get; set; }

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
                var figure = new CircleFigure();
                var item = figure.Shape;
                //figure.Move(timer);
                figure.MoveNew();
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
                var figure = new TriangleFigure();
                var item = figure.Shape;
                figure.Move(timer);
                FiguresShape.Add(item);
                Figures.Add(figure);
            }
        }
        #endregion
        #region StopMoveShapeCommand
        public ICommand ClickStopMoveShapeCommand { get; }
        private bool CanClickStopMoveShapeCommandExecute(object p) => true;
        private void OnClickStopMoveShapeCommandExecute(object p)
        {
            if (timer.IsEnabled)
            {
                timer.IsEnabled = false;
                NameButtonStop = "MoveFigures";
            }
            else
            {
                timer.IsEnabled = true;
                NameButtonStop = "StopFigures";
            }
            OnPropertyChanged("NameButtonStop");
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

            NameButtonStop = "Stop";

            #region Comands
            SelectFigureCommand = new LambdaCommand(OnSelectFigureCommandExecute,
                             CanSelectFigureCommandExecute);
            ClickStopMoveShapeCommand = new LambdaCommand(OnClickStopMoveShapeCommandExecute,
                             CanClickStopMoveShapeCommandExecute);
            #endregion
        }
    }
}


