using QrCoder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace QrCoder.Services
{
    abstract public class QrCodeService : IQrCodeService
    {
        virtual public BitmapImage GenerateQrCode(QrCoderData coderData)
        {
            throw new NotImplementedException();
        }
        protected BitmapImage ConvertToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            var bitmapImage = new BitmapImage();

            using (var stream = new MemoryStream(imageData))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }

            return bitmapImage;
        }
    }
}
