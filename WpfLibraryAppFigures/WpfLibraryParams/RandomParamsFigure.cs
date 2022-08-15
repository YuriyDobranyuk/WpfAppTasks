using System;
using System.Windows.Media;

namespace WpfLibraryParamsFigure
{
    public static class RandomParamsFigure
    {
        private static Random Random = new Random();
        public static int GetRandomCoordinate(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value must be less than max.");
            }
            return Random.Next(min, max);
        }
        public static int GetRandomDeltaCoordinate(int[] coordinates)
        {
            if (coordinates.Length < 0)
            {
                throw new ArgumentException("No coordinates found.");
            }
            return coordinates[Random.Next(0, coordinates.Length)];
        }
        public static Brush GetRandomColor()
        {
            return new SolidColorBrush(Color.FromRgb((byte)Random.Next(0, 255), (byte)Random.Next(0, 255), (byte)Random.Next(0, 255)));
        }
    }
}