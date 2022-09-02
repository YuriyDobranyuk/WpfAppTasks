using System;
using System.Diagnostics;

namespace WpfAppFigures.Services.Events
{
    public class NewIntersectionFiguresEventArgs : EventArgs
    {
        private string s_name;
        private double s_x, s_y;
      
        public NewIntersectionFiguresEventArgs(double x, double y, string name)
        {
            s_name = name;
            s_x = x;
            s_y = y;
        }
        public string Name { get => s_name; }
        public double X { get => s_x; }
        public double Y { get => s_y; }
    }
}
