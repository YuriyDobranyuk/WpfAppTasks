using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using System.Windows.Shapes;
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
                figure.Move();
                FiguresShape.Add(item);
                Figures.Add(figure);
            }
            else if (selectedFigure == FigureType.Rectangle)
            {
                var figure = new RectangleFigure();
                var item = figure.Shape;
                figure.Move();
                FiguresShape.Add(item);
                Figures.Add(figure);
            }
            else if (selectedFigure == FigureType.Triangle)
            {
                var figure = new TriangleFigure();
                var item = figure.Shape;
                figure.Move();
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
            Figure currentFigure = (Figure)p;
            var timer = currentFigure.Timer;
            if (timer.IsEnabled)
            {
                timer.IsEnabled = false;
                currentFigure.Name = "terMove";
                currentFigure.NameButton = "Move";
            }
            else
            {
                timer.IsEnabled = true;
                currentFigure.Name = "retStop";
                currentFigure.NameButton = "Stop";
            }
            var t = Figures;
            
            //listView.Items.Refresh();
            //Thread.Sleep(1000);
            //OnPropertyChanged("NameButton");
            //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        #endregion
        #endregion

        public FiguresViewModel()
        {
            Figures = new ObservableCollection<Figure>();
            FiguresShape = new ObservableCollection<Shape>();

            #region Comands
            SelectFigureCommand = new LambdaCommand(OnSelectFigureCommandExecute,
                             CanSelectFigureCommandExecute);
            ClickStopMoveShapeCommand = new LambdaCommand(OnClickStopMoveShapeCommandExecute,
                             CanClickStopMoveShapeCommandExecute);
            #endregion
        }
    }
}


