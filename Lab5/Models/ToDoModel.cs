using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab5.Models
{
    public class ToDoModel: INotifyPropertyChanged
    {
        
        private string _details;

        public string details
        {
            get { return _details; }
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged(nameof(details));
                }
            }
        }  
    public DateTime CreationDate { get; set; } = DateTime.Now;
    private bool _isDone;
    private string _text;

    public bool IsDone
    {
        get { return _isDone; }
        set
        {
            if (_isDone == value)
                return;
            _isDone = value;
            OnPropertyChanged("IsDone");
        }
    }

    public string Text
    {
        get { return _text; }
        set
        {
            if (_text == value)
                return;
            _text = value;
            OnPropertyChanged("Text");
            
        }
    }

    public string Details { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = "")
    {
        PropertyChanged ?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        
    }
    }
}