using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QrCoder.Models
{
    public class QrCoderData : INotifyPropertyChanged
    {
        private string _content = "";
        private int _size = 200;
        string darkColor = "";
        string lightColor = "";

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }
        public string DarkColor
        {
            get => darkColor;
            set
            {
                darkColor = value;
                OnPropertyChanged();
            }
        }
        public string LightColor
        {
            get => lightColor;
            set
            {
                lightColor = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
