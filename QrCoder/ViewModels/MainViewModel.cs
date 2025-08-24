using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrCoder.Models;
using QrCoder.Services;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using QRCoder.Core;
using Xceed.Wpf.Toolkit;

namespace QrCoder.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IQrCodeService _qrCodeService;
        private QrCoderData _qrCodeData;
        private BitmapImage _qrCodeImage;

        public MainViewModel(IQrCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
            _qrCodeData = new QrCoderData();
            GenerateQrCodeCommand = new RelayCommand(GenerateQrCode, CanGenerateQrCode);
        }

        public QrCoderData QrCodeData
        {
            get => _qrCodeData;
            set
            {
                _qrCodeData = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage QrCodeImage
        {
            get => _qrCodeImage;
            set
            {
                _qrCodeImage = value;
                OnPropertyChanged();
                Console.WriteLine($"QrCodeImage set: {value != null}");
            }
        }

        public ICommand GenerateQrCodeCommand { get; }

        private void GenerateQrCode()
        {
            var result = _qrCodeService?.GenerateQrCode(QrCodeData);

            if (result == null)
            {
                System.Windows.MessageBox.Show("Не удалось сгенерировать QR-код. Проверьте консоль для деталей.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            QrCodeImage = result;
        }

        private bool CanGenerateQrCode()
        {
            bool canExecute = !string.IsNullOrEmpty(QrCodeData.Content) && QrCodeData.Size > 0;
            Console.WriteLine($"CanGenerateQrCode: {canExecute}");
            return canExecute;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
