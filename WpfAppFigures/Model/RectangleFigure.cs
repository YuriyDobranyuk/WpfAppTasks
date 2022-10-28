using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfAppFigures.Enums;
using WpfAppFigures.Services;
using WpfLibraryParamsFigure;

namespace WpfAppFigures.Model
{
    public class RectangleFigure : Figure
    {
        public RectangleFigure()
        {
            Name = FigureType.Rectangle.ToString();

            X = RandomParamsFigure.GetRandomCoordinate(0, Common.Common.P_X_MAX);
            Y = RandomParamsFigure.GetRandomCoordinate(0, Common.Common.P_Y_MAX);

            DX = RandomParamsFigure.GetRandomDeltaCoordinate(HalfParamsFigure.DeltaCoordinates);
            DY = RandomParamsFigure.GetRandomDeltaCoordinate(HalfParamsFigure.DeltaCoordinates);

            Color = RandomParamsFigure.GetRandomColor();

            Draw();
        }

        public override void Move()
        {
            IsMove = true;

            Timer.Tick += (sender, e) =>
            {
                SetCoordinate();

                if (X > Common.Common.P_X_MAX || Y > Common.Common.P_Y_MAX)
                {
                    throw new FigurePositionException("Figures on the not canvas", this);
                }

                SetPositionOnCanvas();
            };

            Timer.Start();
        }

        public override void Draw()
        {
            var rectangle = new Rectangle()
            {
                Fill = Color,
                Height = 20,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Width = 20,
            };

            Shape = rectangle;

            SetPositionOnCanvas();
        }

        public override void SetVisibleCoordinate()
        {
            if (X > Common.Common.P_X_MAX)
            {
                X = Common.Common.P_X_MAX;
            }
            if (Y > Common.Common.P_Y_MAX)
            {
                Y = Common.Common.P_Y_MAX;
            }
            Timer.IsEnabled = false;
            Timer.IsEnabled = true;
        }

        public override void SetCoordinate()
        {
            if (X <= 0 || X >= Common.Common.P_X_MAX)
            {
                DX = -DX;
            }

            if (Y <= 0 || Y >= Common.Common.P_Y_MAX)
            {
                DY = -DY;
            }

            X += DX;
            Y += DY;
        }

        public override void SetPositionOnCanvas()
        {
            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
        }

    }
}
