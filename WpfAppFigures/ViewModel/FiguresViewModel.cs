using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using WpfAppFigures.Model;
using WpfAppFigures.Services.Commands;

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
        }

        #region Commands
        #region SelectFigureCommand
        public ICommand SelectFigureCommand { get; }
        private bool CanSelectFigureCommandExecute(object p) => true;
        private void OnSelectFigureCommandExecute(object p)
        {
            var figure = p as Figure;

            figure.Move();
            Figures.Add(figure);
            FiguresShape.Add(figure.Shape);

            ResetParameters();
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
        }
        #endregion
        #region ChangeCurrentCultureCommand
        public ICommand ChangeCurrentCultureCommand { get; }
        private bool CanChangeCurrentCultureCommandExecute(object p) => true;
        private void OnChangeCurrentCultureCommandExecute(object p)
        {
            var currentCulture = p.ToString();
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentCulture);
            //Thread.CurrentThread.CurrentCulture = new CultureInfo(currentCulture);

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
        #endregion

        private void ResetParameters()
        {
            Circle = new CircleFigure();
            Rectangle = new RectangleFigure();
            Triangle = new TriangleFigure();

            OnPropertyChanged(nameof(Circle));
            OnPropertyChanged(nameof(Rectangle));
            OnPropertyChanged(nameof(Triangle));
        }
        
    }
}


