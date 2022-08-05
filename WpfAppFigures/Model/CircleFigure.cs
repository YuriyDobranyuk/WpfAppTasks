﻿using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAppFigures.Services.Commands;

namespace WpfAppFigures.Model
{
    internal class CircleFigure : Figure
    {
        public override string Name { get; set; }
        public override Brush CurrentColor { get => currentColor; set => currentColor = value; }
        public override Shape Shape { get; set; }
        public override int X { get => x; set => x = value; }
        public override int Y { get => y; set => y = value; }
        public override int DX { get => dx; set => dx = value; }
        public override int DY { get => dy; set => dy = value; }
        public override string NameButton { get => nameButton; set => nameButton = value; }
        public override DispatcherTimer Timer { get; set; }
        public override void Move()
        {
            double x_val = X;
            double y_val = Y;
            double dx = DX;
            double dy = DY;
            
            var timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };
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
            timer.Start();
            Timer = timer;
        }
        public override void Draw()
        {
            Ellipse ellipse = new Ellipse()
            {
                Fill = CurrentColor,
                Height = 20,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Width = 20,
            };
            Shape shapeElement = ellipse;
            Shape = shapeElement;
            double x_val = X;
            double y_val = Y;
            Canvas.SetLeft(Shape, x_val);
            Canvas.SetTop(Shape, y_val);
        }
        public CircleFigure()
        {
            Name = "Circle";
            X = rnd.Next(0, P_X_MAX);
            Y = rnd.Next(0, P_Y_MAX);
            DX = deltaCoordinate[rnd.Next(0, deltaCoordinate.Length)];
            DY = deltaCoordinate[rnd.Next(0, deltaCoordinate.Length)];
            CurrentColor = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255),
                            (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
            Draw();
        }
    }
}
