using System;
using System.Linq;

namespace odev3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------ŞİFRELEME SİSTEMİNE HOŞ GELDİNİZ!---------------------------------------------");
            // alfabe degıskenı tanımı
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

            // dongunun dısında tanımladım çünkü içinde tanımlayınca hata olabiliyor
            string anahtarKelime;
            
            string cevap;
            int i = 0;
            do
            {
                
                // Anahtar kelimenin sadece harflerden oluştuğunu ve tüm harflerin birbirinden farklı olduğunu kontrol eden döngü
                do
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Lütfen Yalnızca Harflerden Oluşan Ve Tüm Harfleri Birbirinden Farklı Bir Anahtar Sözcük Girin : ");
                    }
                    else
                    {
                        Console.WriteLine("************************************************************************************************************************");
                        Console.WriteLine("GEÇERSİZ ANAHTAR KELİME!\nNOT: Anahtar Kelime Birbirinden Farklı Harflerden Oluşmalıdır ve Boş Bırakılamaz.");
                        Console.WriteLine("************************************************************************************************************************");
                        Console.WriteLine("\nLütfen Anahtar Kelimeyi Tekrar Giriniz: ");
                    }
                    i++;
                    anahtarKelime = Console.ReadLine().ToUpper();

                    // Kontrolleri burada sağladım
                } while (!anahtarKelime.All(char.IsLetter) || String.IsNullOrEmpty(anahtarKelime) || anahtarKelime.Distinct().Count() != anahtarKelime.Length);

                // Şifreleme tablosu
                string sifrelemeSatiri = string.Concat(anahtarKelime.Distinct());
                sifrelemeSatiri += string.Concat(alfabe.Where(harf => !sifrelemeSatiri.Contains(harf)));

                Console.WriteLine("Şifreleme Tablosu:");
                Console.WriteLine(alfabe);
                Console.WriteLine(sifrelemeSatiri);
                Console.WriteLine();

                // Kullanıcıdan şifrelenecek metni al
                Console.Write("Şifrelenecek metni girin: ");
                string sifrelenecekMetin = Console.ReadLine().ToUpper();

                // Giriş kontrolü
                while (true)
                {
                    if (sifrelenecekMetin.Any(char.IsDigit))
                    {
                        Console.WriteLine("---------------------------------------------------------UYARI!---------------------------------------------------------");
                        Console.WriteLine("Şifrelenecek metinde rakam bulunamaz.\n");

                        Console.Write("Şifrelenecek metni girin: ");
                        sifrelenecekMetin = Console.ReadLine().ToUpper();
                    }
                    if (!sifrelenecekMetin.All(j => alfabe.Contains(j) || j == ' '))
                    {
                        Console.WriteLine("---------------------------------------------------------UYARI!---------------------------------------------------------");
                        Console.WriteLine("Şifrelenecek metinde yalnızca Türk Alfabesindeki harfler ve boşluk karakteri bulunabilir.");

                        Console.Write("Şifrelenecek metni girin: ");
                        sifrelenecekMetin = Console.ReadLine().ToUpper();
                    }
                    else
                    {
                        break; // Giriş doğruysa döngüden çık
                    }
                }

                // Şifreleme kısmı
                string sifrelenmisMetin = "";
                foreach (char karakter in sifrelenecekMetin)
                {
                    if (karakter == ' ')
                    {
                        sifrelenmisMetin += ' ';
                    }
                    else
                    {
                        int index = alfabe.IndexOf(karakter);
                        sifrelenmisMetin += sifrelemeSatiri[index];
                    }
                }

                Console.WriteLine("Şifrelenmiş Metin: " + sifrelenmisMetin);

                // Kullanıcıya tekrar şifrelemek isteyip istemediğini sor
                Console.Write("\nBaşka bir metin şifrelemek ister misiniz? (E/H): ");
                cevap = Console.ReadLine().ToUpper();

                if (cevap == "H")
                {
                    Console.WriteLine("Şifreleme sistemi sonlandırıldı. Teşekkür ederiz!");
                    Environment.Exit(0); // Program tamamen sonlanır
                }
                else if (cevap != "E")
                {
                    Console.WriteLine("Geçersiz giriş! Varsayılan olarak devam ediliyor.\n");
                }
                i = 0;
            } while (cevap == "E");
        }
    }
}