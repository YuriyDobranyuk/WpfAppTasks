using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppFigures.Model
{
    public abstract class Figure : INotifyPropertyChanged
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

        protected double X { get; set; }
        protected double Y { get; set; }
        protected double DX { get; set; }
        protected double DY { get; set; }

        public Shape Shape { get; set; }
        public DispatcherTimer Timer { get; set; }
        public Brush Color { get; set; }

        protected Figure()
        {
            Timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public abstract void Move();
        public abstract void Draw();
    }
}
