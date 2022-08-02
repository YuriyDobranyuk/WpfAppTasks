using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppFigures.Model
{
    internal abstract class Figure
    { 
        public int[] deltaCoordinate = { -5, -4, -3, -2, -1, 1, 2, 3, 4, 5 };
        public const int P_X_MAX = 650;
        public const int P_Y_MAX = 390;
        protected int x, y, dx, dy;
        protected Brush currentColor;
        protected Random rnd = new Random();
        public abstract string Name { get; set; }
        public abstract Shape Shape { get; set; }
        public abstract Brush CurrentColor {get; set;}
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract int DX { get; set; }
        public abstract int DY { get; set; }
        public abstract void Move(DispatcherTimer timer);
        public abstract void Draw();
    }
}
