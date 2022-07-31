using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppFigures.Model
{
    class Triangle : Figure
    {
        public override Brush CurrentColor { get => currentColor; set => currentColor = value; }
        public override Shape Shape { get; set; }
        public override void Move(Canvas canvas)
        {
            if (x < 0 || x > P_X_MAX)
            {
                dx = -dx;
            }
            if (y < 0 || y > P_Y_MAX)
            {
                dy = -dy;
            }
            x += dx;
            y += dy;
            Canvas.SetLeft(this.Shape, x);
            Canvas.SetTop(this.Shape, y);
        }
        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(this.Shape);
            Canvas.SetLeft(this.Shape, x);
            Canvas.SetTop(this.Shape, y);
        }
        public Triangle(Canvas canvas)
        {
            x = rnd.Next(0, P_X_MAX);
            y = rnd.Next(0, P_Y_MAX);
            CurrentColor = new SolidColorBrush(Color.FromRgb((byte) rnd.Next(0, 255),
                            (byte) rnd.Next(0, 255), (byte) rnd.Next(0, 255)));
            PointCollection trianglePointCollection = new PointCollection();
            trianglePointCollection.Add(new Point(0, 20));
            trianglePointCollection.Add(new Point(20, 20));
            trianglePointCollection.Add(new Point(10, 0));
            //trianglePointCollection.Add(new Point(x, y + 20));
            //trianglePointCollection.Add(new Point(x + 20, y + 20));
            //trianglePointCollection.Add(new Point(x + 10, y));
            Polygon myPolygon = new Polygon()
            {
                Fill = CurrentColor,
                Points = trianglePointCollection,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            Shape el = myPolygon;
            this.Shape = el;
            this.Draw(canvas);
        }
    }
}
