﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfAppFigures.Common;
using WpfAppFigures.Enums;

namespace WpfAppFigures.Model
{
    public class RectangleFigure : Figure
    {
        private Random Random = new Random();

        public RectangleFigure()
        {
            Name = FigureType.Rectangle.ToString();
            
            X = Random.Next(0, Constants.P_X_MAX);
            Y = Random.Next(0, Constants.P_Y_MAX);

            DX = Constants.DELTA_COORDINATES[Random.Next(0, Constants.DELTA_COORDINATES.Length)];
            DY = Constants.DELTA_COORDINATES[Random.Next(0, Constants.DELTA_COORDINATES.Length)];

            Color = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)Random.Next(0, 255), (byte)Random.Next(0, 255), (byte)Random.Next(0, 255)));

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
            var rectangle = new Rectangle()
            {
                Fill = Color,
                Height = 20,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Width = 20,
            };

            Shape = rectangle;

            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
        }
    }
}
