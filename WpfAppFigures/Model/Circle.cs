﻿using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppFigures.Model
{
    class Circle : Figure
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
        public Circle(Canvas canvas)
        {
            x = rnd.Next(0, P_X_MAX);
            y = rnd.Next(0, P_Y_MAX);
            dx = deltaCoordinate[rnd.Next(0, deltaCoordinate.Length)];
            dy = deltaCoordinate[rnd.Next(0, deltaCoordinate.Length)];
            CurrentColor = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255),
                            (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
            Ellipse el = new Ellipse()
            {
                Stroke = Brushes.Black,
                Fill = CurrentColor,
                StrokeThickness = 1,
                Width = 20,
                Height = 20
            };
            Shape elShape = el;
            this.Shape = elShape;
            this.Draw(canvas);
        }
    }
}