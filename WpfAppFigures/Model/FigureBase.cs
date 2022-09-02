using System;
using System.ComponentModel;

namespace WpfAppFigures.Model
{
    public class FigureBase : INotifyPropertyChanged
    {
        private bool _isMove;
        private string _name;

        public bool IsMove
        {
            get { return _isMove; }
            set
            {
                _isMove = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public Guid Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double DX { get; set; }
        public double DY { get; set; }

        protected FigureBase()
        {
            Id = Guid.NewGuid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
