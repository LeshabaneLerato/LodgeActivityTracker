using QRCoder;
using System;
using System.Drawing;
using System.IO;

public static class QRCodeHelper
{
    public static string GenerateQRCodeBase64(string text, int pixelsPerModule = 20)
    {
        using (var qrGenerator = new QRCodeGenerator())
        using (var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
        using (var qrCode = new QRCode(qrData))
        using (var bitmap = qrCode.GetGraphic(pixelsPerModule))
        using (var ms = new MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            var base64 = Convert.ToBase64String(ms.ToArray());
            return $"data:image/png;base64,{base64}";
        }
    }
}
