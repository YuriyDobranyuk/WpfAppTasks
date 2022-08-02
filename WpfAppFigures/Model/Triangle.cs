using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppFigures.Model
{
    internal class Triangle : Figure
    {
        public override string Name { get; set; }
        public override Brush CurrentColor { get => currentColor; set => currentColor = value; }
        public override Shape Shape { get; set; }
        public override int X { get => x; set => x = value; }
        public override int Y { get => y; set => y = value; }
        public override int DX { get => dx; set => dx = value; }
        public override int DY { get => dy; set => dy = value; }
        public override void Move(DispatcherTimer timer)
        {
            double x_val = X;
            double y_val = Y;
            double dx = DX;
            double dy = DY;
            timer.Tick += (sender, e) =>
            {
                if (x_val < 0 || x_val > P_X_MAX)
                {
                    dx = -dx;
                }
                if (y_val < 0 || y_val > P_Y_MAX)
                {
                    dy = -dy;
                }
                x_val += dx;
                y_val += dy;
                Canvas.SetLeft(Shape, x_val);
                Canvas.SetTop(Shape, y_val);
            };
        }
        public override void Draw()
        {
            Polygon myPolygon = new Polygon()
            {
                Fill = CurrentColor,
                Points = new PointCollection { new Point(0, 20),
                                               new Point(20, 20),
                                               new Point(10, 0) },
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            Shape shapeElement = myPolygon;
            Shape = shapeElement;
        }
        
        public Triangle()
        {
            Name = "Triangle";
            X = rnd.Next(0, P_X_MAX);
            Y = rnd.Next(0, P_Y_MAX);
            DX = deltaCoordinate[rnd.Next(0, deltaCoordinate.Length)];
            DY = deltaCoordinate[rnd.Next(0, deltaCoordinate.Length)];
            CurrentColor = new SolidColorBrush(Color.FromRgb((byte) rnd.Next(0, 255),
                            (byte) rnd.Next(0, 255), (byte) rnd.Next(0, 255)));
            Draw();
        }
    }
}
