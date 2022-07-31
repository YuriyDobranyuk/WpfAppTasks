using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppFigures.Model
{
    abstract class Figure
    { 
        public int[] deltaCoordinate = { -5, -4, -3, -2, -1, 1, 2, 3, 4, 5 };
        public const int P_X_MAX = 680;
        public const int P_Y_MAX = 390;
        protected int x, y, dx, dy;
        protected Brush currentColor;
        protected Random rnd = new Random();
        public abstract Shape Shape { get; set; }
        public abstract Brush CurrentColor {get; set;}
        public abstract void Move(Canvas canvas);
        public abstract void Draw(Canvas canvas);
    }
}
