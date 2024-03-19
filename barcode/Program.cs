using System;
using System.Drawing;
using ZXing;
using ZXing.Common;


namespace barcode
{
    class Program
    {
        static void Main(string[] args)
        {
            string entityName = "entity name";
            string unitName = "unit name";

            // Generate 2D (QR Code) barcode
            GenerateAndSaveBarcode(entityName, unitName, BarcodeFormat.QR_CODE, "2D_Barcode.png");

            // Generate 1D (Code 128) barcode
            GenerateAndSaveBarcode(entityName, unitName, BarcodeFormat.CODE_128, "1D_Barcode.png");
        }

        static void GenerateAndSaveBarcode(string entityName, string unitName, BarcodeFormat barcodeFormat, string fileName)
        {
            string barcodeValue = $"Entity: {entityName}\nUnit: {unitName}";

            var writer = new BarcodeWriter
            {
                Format = barcodeFormat,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 100
                }
            };

            Bitmap barcodeBitmap = writer.Write(barcodeValue);

            // Save the barcode image to a local path
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{fileName}";
            barcodeBitmap.Save(filePath);

            Console.WriteLine($"Barcode generated and saved at: {filePath}");
        }
    }
}
