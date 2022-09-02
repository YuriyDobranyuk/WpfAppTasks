using System;
using System.Collections.Generic;
using System.Linq;
using WpfAppFigures.Common;
using WpfAppFigures.Model;

namespace WpfAppFigures.Services
{
    public static class FigureManager
    {
        private static List<Figure> Figures { get; set; }
        public static Dictionary<Guid, IEnumerable<CrossedPoint>> CurrentCrossing { get; set; }

        static FigureManager()
        {
            Figures = new List<Figure>();
            CurrentCrossing = new Dictionary<Guid, IEnumerable<CrossedPoint>>();
        }

        public static void AddFigure(Figure figure)
        {
            Figures.Add(figure);
        }
        
        public static List<Figure> GetFiguresByName(string figureName)
        {
            return Figures.Where(x => x.Name == figureName).ToList();
        }
    }
}
