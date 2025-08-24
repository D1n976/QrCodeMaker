using QrCoder.Models;
using QRCoder.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace QrCoder.Services
{
    public class QrCodeCustomService : QrCodeService
    {
        public override BitmapImage GenerateQrCode(QrCoderData coderData)
        {
            try
            {
                using (var qrGenerator = new QRCodeGenerator())
                using (var qrCodeData = qrGenerator.CreateQrCode(coderData.Content, QRCodeGenerator.ECCLevel.Q))
                using (var qrCode = new QRCode(qrCodeData))
                {
                    using (var image = qrCode.GetGraphic(20, coderData.DarkColor, coderData.LightColor))
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, ImageFormat.Png);
                        memoryStream.Position = 0;

                        // Конвертируем в BitmapImage
                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze(); 

                        return bitmapImage;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка генерации цветного QR-кода: {ex.Message}");
                return null;
            }
        }
    }
}