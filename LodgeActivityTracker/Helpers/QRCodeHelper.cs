using System;
using QRCoder;

namespace LodgeActivityTracker.Helpers
{
    public static class QRCodeHelper
    {
        /// <summary>
        /// Generates a QR code in Base64 PNG format from the provided text.
        /// </summary>
        /// <param name="text">The URL or text to encode in the QR code.</param>
        /// <returns>Base64 string of the QR code image.</returns>
        public static string GenerateQRCodeBase64(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Text for QR code cannot be null or empty.", nameof(text));
            }

            try
            {
                using var qrGenerator = new QRCodeGenerator();
                var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q); // qrData is NOT disposable
                using var qrCode = new PngByteQRCode(qrData);

                // Generate QR code bytes (high resolution)
                byte[] qrBytes = qrCode.GetGraphic(20);

                // Convert to Base64 for embedding in <img> tag
                string qrBase64 = "data:image/png;base64," + Convert.ToBase64String(qrBytes);
                return qrBase64;
            } // <-- FIX: close try block here
            catch (Exception ex)
            {
                // Log error if needed
                Console.WriteLine($"QR code generation failed: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
