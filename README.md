# metin_dogrulama
ekranın belli bir kısmında bulunan metini algılayıp bu metinin istenilen veri olup olmadığını gösteren kod bloğu



# metin_dogrulama

Bu proje, bir ekran görüntüsünden belirli bir metni otomatik olarak algılayıp doğrulamak için OpenCvSharp ve Tesseract OCR kütüphanelerini kullanır.

## Amaç

Belirtilen bir görsel içerisinden (örneğin bir ekran görüntüsü) "Save successful" metninin bulunup bulunmadığını kontrol eder. Özellikle yazılım testlerinde veya otomasyon işlemlerinde çıktı doğrulama için kullanılabilir.

## Çalışma Prensibi

1. **Görüntüyü Yükleme:** Kodda belirtilen dosya yolundan resmi (`ss3.png`) yükler.
2. **Griye Çevirme:** Görüntü gri tonlamaya dönüştürülür.
3. **Kırpma:** İlgili metnin yer aldığı alan, koordinatlar (x=1402, y=612, w=138, h=18) ile kırpılır.
4. **İyileştirme:** Kırpılan alana threshold uygulanarak siyah-beyaz hale getirilir.
5. **OCR:** Tesseract ile kırpılan ve iyileştirilen alanda metin tanıma işlemi yapılır.
6. **Kontrol:** OCR çıktısında "Save successful" metni aranır ve konsola sonuç yazılır.

## Kullanım

1. OpenCvSharp ve Tesseract kütüphanelerini projeye ekleyin.
2. Kodda belirtilen görsel dosya yolunu kendi bilgisayarınıza göre güncelleyin.
3. Tesseract'ın `tessdata` klasörünün yolunu doğru şekilde belirtin.
4. Projeyi derleyip çalıştırın.

## Örnek Konsol Çıktısı

```
Save successful yazısı bulundu!
```
veya
```
Save successful yazısı bulunamadı. OCR çıktısı: [OCR ile algılanan metin]
```

## Gereksinimler

- .NET (örn: .NET Core veya .NET Framework)
- OpenCvSharp
- Tesseract ve Türkçe/İngilizce dil dosyaları (`tessdata`)

## Lisans

Bu proje açık kaynaklıdır; dilediğiniz gibi kullanabilirsiniz.
