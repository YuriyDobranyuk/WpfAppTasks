﻿using System.ComponentModel;

namespace WpfAppFigures.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, string PropertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;

            OnPropertyChanged(PropertyName);

            return true;
        }
    }
}
