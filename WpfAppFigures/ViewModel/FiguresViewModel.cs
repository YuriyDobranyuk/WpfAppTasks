using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using WpfAppFigures.Model;
using WpfAppFigures.Services.Commands;
using WpfAppFigures.Services.Events;

namespace WpfAppFigures.ViewModel
{
    public class FiguresViewModel : BaseViewModel
    {
        public ObservableCollection<Figure> Figures { get; set; }
        public ObservableCollection<Shape> FiguresShape { get; set; }

        public CircleFigure Circle { get; set; } = new CircleFigure();
        public RectangleFigure Rectangle { get; set; } = new RectangleFigure();
        public TriangleFigure Triangle { get; set; } = new TriangleFigure();

        public FiguresViewModel()
        {
            Figures = new ObservableCollection<Figure>();
            FiguresShape = new ObservableCollection<Shape>();

            SelectFigureCommand = new LambdaCommand(OnSelectFigureCommandExecute, CanSelectFigureCommandExecute);
            ClickStopMoveShapeCommand = new LambdaCommand(OnClickStopMoveShapeCommandExecute, CanClickStopMoveShapeCommandExecute);
            ChangeCurrentCultureCommand = new LambdaCommand(OnChangeCurrentCultureCommandExecute, CanChangeCurrentCultureCommandExecute);
            AddFunctionForEventCrossingCommand = new LambdaCommand(OnAddFunctionForEventCrossingCommandExecute, CanAddFunctionForEventCrossingCommandExecute);
            RemoveFunctionForEventCrossingCommand = new LambdaCommand(OnRemoveFunctionForEventCrossingCommandExecute, CanRemoveFunctionForEventCrossingCommandExecute);

        }

        #region Commands
        #region SelectFigureCommand
        public ICommand SelectFigureCommand { get; }
        private bool CanSelectFigureCommandExecute(object p) => true;
        private void OnSelectFigureCommandExecute(object p)
        {
            var figure = p as Figure;
            var nameFigure = figure.Name;

            figure.AddTimerFigure();
            //figure.NewIntersectionFigures += OnFigureCross;

            figure.Move();
            figure.AddFigureToManagerFigure();

            Figures.Add(figure);
            FiguresShape.Add(figure.Shape);

            ResetParameters(nameFigure);
        }
        #endregion
        #region StopMoveShapeCommand
        public ICommand ClickStopMoveShapeCommand { get; }
        private bool CanClickStopMoveShapeCommandExecute(object p) => true;
        private void OnClickStopMoveShapeCommandExecute(object p)
        {
            var currentFigure = p as Figure;

            currentFigure.Timer.IsEnabled = currentFigure.Timer.IsEnabled ? false : true;
            currentFigure.IsMove = currentFigure.Timer.IsEnabled;

            //RenderedIntersect(currentFigure, Figures);
        }
        #endregion
        #region ChangeCurrentCultureCommand
        public ICommand ChangeCurrentCultureCommand { get; }
        private bool CanChangeCurrentCultureCommandExecute(object p) => true;
        private void OnChangeCurrentCultureCommandExecute(object p)
        {
            var currentCulture = p.ToString();

            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(String.Format(@"Resources\Dictionary.{0}.xaml", currentCulture), UriKind.Relative);
            var oldDict = Application.Current.Resources.MergedDictionaries.Where(x => x.Source != null && x.Source.OriginalString.StartsWith(@"Resources\Dictionary.")).FirstOrDefault();

            if (oldDict != null)
            {
                int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }

        }
        #endregion
        #region AddFunctionForEventCrossingCommand
        public ICommand AddFunctionForEventCrossingCommand { get; }
        private bool CanAddFunctionForEventCrossingCommandExecute(object p)
        {
            var figure = p as Figure;
            return figure != null;
        }
        private void OnAddFunctionForEventCrossingCommandExecute(object p)
        {
            var figure = p as Figure;
            figure.NewIntersectionFigures += OnFigureCross;
        }
        #endregion
        #region RemoveFunctionForEventCrossingCommand
        public ICommand RemoveFunctionForEventCrossingCommand { get; }
        private bool CanRemoveFunctionForEventCrossingCommandExecute(object p)
        {
            var figure = p as Figure;
            return figure != null;
        }
        private void OnRemoveFunctionForEventCrossingCommandExecute(object p)
        {
            var figure = p as Figure;
            figure.NewIntersectionFigures -= OnFigureCross;
        }
        #endregion
        #endregion

        private void ResetParameters(string name)
        {
            switch (name)
            {
                case "Circle":
                    Circle = new CircleFigure();
                    OnPropertyChanged(nameof(Circle));
                    break;
                case "Rectangle":
                    Rectangle = new RectangleFigure();
                    OnPropertyChanged(nameof(Rectangle));
                    break;
                case "Triangle":
                    Triangle = new TriangleFigure();
                    OnPropertyChanged(nameof(Triangle));
                    break;
            } 
        }

        public void OnFigureCross(object sender, NewIntersectionFiguresEventArgs e)
        {
            Debug.WriteLine($"Figure {e.Name} crossed. Coordinates X - ({e.X}), Y - ({e.Y})");
            SystemSounds.Beep.Play();
        }


    }
}


