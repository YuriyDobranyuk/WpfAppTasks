using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfAppFigures.Common;
using WpfAppFigures.Enums;
using WpfLibraryParamsFigure;

namespace WpfAppFigures.Model
{
    public class TriangleFigure : Figure
    {
        public TriangleFigure()
        {
            Name = FigureType.Triangle.ToString();

            X = RandomParamsFigure.GetRandomCoordinate(0, Constants.P_X_MAX);
            Y = RandomParamsFigure.GetRandomCoordinate(0, Constants.P_Y_MAX);

            DX = RandomParamsFigure.GetRandomDeltaCoordinate(Constants.DELTA_COORDINATES);
            DY = RandomParamsFigure.GetRandomDeltaCoordinate(Constants.DELTA_COORDINATES);

            Color = RandomParamsFigure.GetRandomColor();

            Draw();
        }

        public override void Move()
        {
            IsMove = true;

            Timer.Tick += (sender, e) =>
            {
                if (X < 0 || X > Constants.P_X_MAX)
                {
                    DX = -DX;
                }

                if (Y < 0 || Y > Constants.P_Y_MAX)
                {
                    DY = -DY;
                }

                X += DX;
                Y += DY;

                Canvas.SetLeft(Shape, X);
                Canvas.SetTop(Shape, Y);
            };

            Timer.Start();
        }

        public override void Draw()
        {
            var polygon = new Polygon()
            {
                Fill = Color,
                Points = new PointCollection { new Point(0, 20),
                                               new Point(20, 20),
                                               new Point(10, 0) },
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };

            Shape = polygon;

            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
        }
    }
}
