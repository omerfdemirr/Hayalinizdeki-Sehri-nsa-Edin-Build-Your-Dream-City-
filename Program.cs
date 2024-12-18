namespace Hayalinizdeki_Sehri_İnsa_Edin_Build_Your_Dream_City_
{
    using System;
    using System.Collections.Generic;

    namespace SehirInsaa
    {
        class Program
        {
            static int butce = 1000000; // Başlangıç bütçesi
            static int toplamNufus = 0;
            static List<Bina> binalar = new List<Bina>();

            static void Main()
            {
                Console.WriteLine("=== Hayalinizdeki Şehri İnşa Edin ===");

                bool devam = true;
                while (devam)
                {
                    Console.WriteLine("\nMenü:");
                    Console.WriteLine("1. Yeni Bina İnşa Et");
                    Console.WriteLine("2. Mevcut Şehri Görüntüle");
                    Console.WriteLine("3. Şehir Raporu");
                    Console.WriteLine("4. Çıkış");
                    Console.Write("Seçiminiz: ");

                    string secim = Console.ReadLine();
                    switch (secim)
                    {
                        case "1":
                            YeniBinaInsaaEt();
                            break;
                        case "2":
                            SehirGoruntule();
                            break;
                        case "3":
                            SehirRaporu();
                            break;
                        case "4":
                            devam = false;
                            Console.WriteLine("Programdan çıkılıyor...");
                            break;
                        default:
                            Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                            break;
                    }
                }
            }

            static void YeniBinaInsaaEt()
            {
                Console.WriteLine("\nİnşa Edilebilecek Binalar:");
                Console.WriteLine("1. Konut (10.000 TL, 4 kişi)");
                Console.WriteLine("2. İş Merkezi (50.000 TL, 20 kişi)");
                Console.WriteLine("3. Hastane (200.000 TL, 50 kişi)");
                Console.WriteLine("4. Okul (150.000 TL, 30 kişi)");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        BinaEkle("Konut", 10000, 4);
                        break;
                    case "2":
                        BinaEkle("İş Merkezi", 50000, 20);
                        break;
                    case "3":
                        BinaEkle("Hastane", 200000, 50);
                        break;
                    case "4":
                        BinaEkle("Okul", 150000, 30);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }

            static void BinaEkle(string ad, int maliyet, int nufusArtisi)
            {
                if (butce >= maliyet)
                {
                    binalar.Add(new Bina(ad, maliyet, nufusArtisi));
                    butce -= maliyet;
                    toplamNufus += nufusArtisi;
                    Console.WriteLine($"{ad} başarıyla inşa edildi!");
                }
                else
                {
                    Console.WriteLine($"Yetersiz bütçe! {ad} inşa edebilmek için {maliyet - butce} TL daha gerekiyor.");
                }
            }

            static void SehirGoruntule()
            {
                if (binalar.Count == 0)
                {
                    Console.WriteLine("Şehrinizde henüz bir bina yok.");
                    return;
                }

                Console.WriteLine("\n--- Şehrinizdeki Binalar ---");
                foreach (var bina in binalar)
                {
                    Console.WriteLine(bina);
                }
            }

            static void SehirRaporu()
            {
                Console.WriteLine("\n=== Şehir Raporu ===");
                Console.WriteLine($"Toplam Nüfus: {toplamNufus}");
                Console.WriteLine($"Mevcut Bütçe: {butce} TL");
                Console.WriteLine($"Toplam Bina Sayısı: {binalar.Count}");
            }

            class Bina
            {
                public string Ad { get; }
                public int Maliyet { get; }
                public int NufusArtisi { get; }

                public Bina(string ad, int maliyet, int nufusArtisi)
                {
                    Ad = ad;
                    Maliyet = maliyet;
                    NufusArtisi = nufusArtisi;
                }

                public override string ToString()
                {
                    return $"{Ad} - Maliyet: {Maliyet} TL, Nüfus Artışı: {NufusArtisi}";
                }
            }
        }
    }

}
