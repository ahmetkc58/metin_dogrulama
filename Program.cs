using System;
using OpenCvSharp;
using Tesseract;

class Program
{
    static void Main(){
        // 1. Görüntüyü yükle
        Mat image = Cv2.ImRead(@"C:\Users\Ahmet\Desktop\ss3.png");

        // 2. Griye çevir
        Mat gray = new Mat();
        Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

        // 3. İlgili alanı kırp
        int x = 1402, y = 612, w = 138, h = 18;
        OpenCvSharp.Rect roiRect = new OpenCvSharp.Rect(x, y, w, h);
        Mat roi = new Mat(gray, roiRect);

        // 4. Görüntüyü iyileştir (threshold)
        Mat thresh = new Mat();
        Cv2.Threshold(roi, thresh, 150, 255, ThresholdTypes.Binary);

        // 5. OCR ile metni tanı

        string text;
        using (var engine = new TesseractEngine(@"C:\\Program Files\\Tesseract-OCR\\tessdata", "eng", EngineMode.Default))
        {
            using (var ms = thresh.ToMemoryStream())
            using (var pix = Pix.LoadFromMemory(ms.ToArray()))
            {
                using (var page = engine.Process(pix))
                {
                    text = page.GetText();
                }
            }
        }

        // 6. "Save successful" yazısını kontrol et
        if (text.Contains("Save successful"))
        {
            Console.WriteLine("Save successful yazısı bulundu!");
        }
        else
        {
            Console.WriteLine($"Save successful yazısı bulunamadı. OCR çıktısı: {text}");
        }
    }

}

// Yardımcı fonksiyon:
public static class MatExtensions
{
    public static System.IO.MemoryStream ToMemoryStream(this Mat mat)
    {
        var data = mat.ImEncode(".png");
        return new System.IO.MemoryStream(data);
    }
}

