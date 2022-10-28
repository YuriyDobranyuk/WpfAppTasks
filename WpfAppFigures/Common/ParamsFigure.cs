namespace WpfAppFigures.Common
{
    public class ParamsFigure<T>
    {
        public T SizeHalfFigure { get; set; }
        public T[] DeltaCoordinates { get; set; }

        public ParamsFigure(T value, T[] arrayValue) 
        {
            SizeHalfFigure = value;
            DeltaCoordinates = arrayValue;
        }
    }
}
