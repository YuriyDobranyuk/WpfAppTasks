using System;
using System.Windows;
using WpfAppFigures.Model;

namespace WpfAppFigures.Services
{
    class FigurePositionException : ArgumentOutOfRangeException
    {
        public Point PositionFigure { get; }
        public Figure Figure { get; }
        public FigurePositionException(string message, Figure figure)
            : base(message)
        {
            PositionFigure = new Point(figure.X, figure.Y);
            Figure = figure;
        }
    }
}
