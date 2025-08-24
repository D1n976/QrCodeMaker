using QrCoder.Models;
using QRCoder.Core;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace QrCoder.Services
{
    public class QrCodeSimpleService : QrCodeService
    {
        public override BitmapImage GenerateQrCode(QrCoderData coderData)
        {
            if (string.IsNullOrEmpty(coderData.Content))
                return null;

            try
            {
                using (var qrGenerator = new QRCodeGenerator())
                using (var qrCodeData = qrGenerator.CreateQrCode(coderData.Content, QRCodeGenerator.ECCLevel.Q))
                using (var qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeBytes = qrCode.GetGraphic(20);

                    // Конвертируем в BitmapImage для WPF
                    return ConvertToBitmapImage(qrCodeBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка генерации QR-кода: {ex.Message}");
                return null;
            }
        }
    }
}
