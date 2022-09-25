using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAppFigures.Common;
using WpfAppFigures.Services;
using WpfAppFigures.Services.Events;

namespace WpfAppFigures.Model
{
    public abstract class Figure : FigureBase
    {
        public Shape Shape { get; set; }
        public DispatcherTimer Timer { get; set; }
        public Brush Color { get; set; }

        public ObservableCollection<Point> IntersectionPoints { get; set; }
        public List<Figure> CrossingFigures { get; set; }
        
        protected Figure()
        {
            IntersectionPoints = new ObservableCollection<Point>();
        }
        
        public void AddTimerFigure()
        {
            Timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, CheckFigureCrossing, Dispatcher.CurrentDispatcher);
        }
        public void AddFigureToManagerFigure()
        {
            FigureManager.AddFigure(this);
        }

        /*secound stage event by Righter*/
        public event EventHandler<NewIntersectionFiguresEventArgs> NewIntersectionFigures;

        //third stage event by Righter
        public virtual void OnNewIntersectionFigures(NewIntersectionFiguresEventArgs e)
        {
            EventHandler<NewIntersectionFiguresEventArgs> temp = Volatile.Read(ref NewIntersectionFigures);
            if (temp != null) temp(this, e);
        }

        //four stage event by Righter
        public void CheckFigureCrossing(object sender, EventArgs e)
        {
            var minXValue = X - Constants.SIZE_HALF_FIGURE;
            var maxXValue = X + Constants.SIZE_HALF_FIGURE;
            var minYValue = Y - Constants.SIZE_HALF_FIGURE;
            var maxYValue = Y + Constants.SIZE_HALF_FIGURE;

            var crossedFigures = FigureManager.GetFiguresByName(Name).Where(x => (x.X > minXValue && x.X < maxXValue && x.Y > minYValue && x.Y < maxYValue && x.Id != Id)).ToList();

            var crossedWithCurrentFigure = FigureManager.CurrentCrossing.FirstOrDefault(x => x.Key == Id).Value;

            if (crossedFigures.Any())
            {
                var isCrossFigure = false;
                if (crossedWithCurrentFigure == null)
                {
                    FigureManager.CurrentCrossing.Add(Id, crossedFigures.Select(x => new CrossedPoint { Id = x.Id, Point = new Point(x.X, x.Y) }));

                    isCrossFigure = true;
                }
                else
                {
                    var newCrossedPoints = crossedWithCurrentFigure;
                    foreach (var item in crossedFigures)
                    {
                        var prevCrossed = crossedWithCurrentFigure.FirstOrDefault(x => x.Id == item.Id);
                        
                        if (prevCrossed != null && !(prevCrossed.Point.X > minXValue && prevCrossed.Point.X < maxXValue && prevCrossed.Point.Y > minYValue && prevCrossed.Point.Y < maxYValue))
                        {
                            FigureManager.CurrentCrossing.Remove(Id);
                        }
                        else if(prevCrossed == null)
                        {
                            newCrossedPoints.ToList().Add(new CrossedPoint { Id = item.Id, Point = new Point(item.X, item.Y) });
                        }

                    }
                    if (newCrossedPoints.Count() > crossedWithCurrentFigure.Count())
                    {
                        FigureManager.CurrentCrossing[Id] = newCrossedPoints;
                    }
                }
                if (isCrossFigure)
                {
                    IntersectionPoints.Add(new Point(X, Y));
                    NewIntersectionFiguresEventArgs e1 = new NewIntersectionFiguresEventArgs(X, Y, Name);
                    OnNewIntersectionFigures(e1);
                }
            }
            else
            {
                FigureManager.CurrentCrossing.Remove(Id);
            }

        }

        public abstract void Move();
        public abstract void Draw();
        public abstract void SetVisibleCoordinate();
    }
}
