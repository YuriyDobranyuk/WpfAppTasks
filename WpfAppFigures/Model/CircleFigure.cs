using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfAppFigures.Common;
using WpfAppFigures.Enums;
using WpfAppFigures.Services;
using WpfLibraryParamsFigure;

namespace WpfAppFigures.Model
{
    public class CircleFigure : Figure
    {
        public CircleFigure()
        {
            Name = FigureType.Circle.ToString();

            X = RandomParamsFigure.GetRandomCoordinate(0, Common.Common.P_X_MAX);
            Y = RandomParamsFigure.GetRandomCoordinate(0, Common.Common.P_Y_MAX);

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

                if (X > Common.Common.P_X_MAX || Y > Common.Common.P_Y_MAX)
                {
                    throw new FigurePositionException("Figures on the not canvas", this);
                }
                //try
                //{
                //    if (X > Common.Common.P_X_MAX || Y > Common.Common.P_Y_MAX)
                //    {
                //        throw new FigurePositionException("Figures in first block", this);
                //    }
                //}
                ///*catch (FigurePositionException ex)
                //{
                //    //Console.WriteLine();
                //    //throw;
                //    //throw new FigurePositionException("Figures in first block", this);

                //    /*var path = "noteFigurePositionException.txt";
                //    using (StreamWriter writer = new StreamWriter(path, true))
                //    {
                //        writer.WriteLineAsync($"Exception: {ex.ParamName}. Name: {ex.Figure.Name}. Id: {ex.Figure.Id}. Point: {ex.PositionFigure.ToString()}. Date: {DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy")}.");
                //    }
                //    ex.Figure.SetVisibleCoordinate();*//*
                //}*/
                
                Canvas.SetLeft(Shape, X);
                Canvas.SetTop(Shape, Y);
            };

            Timer.Start();

        }

        public override void Draw()
        {
            var ellipse = new Ellipse()
            {
                Fill = Color,
                Height = 20,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Width = 20,
            };

            Shape = ellipse;

            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
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
            IsMove = true;
        }

    }
}
