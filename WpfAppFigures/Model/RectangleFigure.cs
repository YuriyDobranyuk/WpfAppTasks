﻿using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppFigures.Model
{
    class RectangleFigure : Figure
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
        public RectangleFigure(Canvas canvas)
        {
            x = rnd.Next(0, P_X_MAX);
            y = rnd.Next(0, P_Y_MAX);
            CurrentColor = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255),
                            (byte) rnd.Next(0, 255), (byte) rnd.Next(0, 255)));
            Shape el = new Rectangle
            {
                Stroke = Brushes.Black,
                Fill = CurrentColor,
                StrokeThickness = 1,
                Width = 20,
                Height = 20
            };
            this.Shape = el;
            this.Draw(canvas);
        } 
    }
}