using QrCoder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace QrCoder.Services
{
    public interface IQrCodeService
    {
        public BitmapImage GenerateQrCode(QrCoderData coderData);
    }
}
