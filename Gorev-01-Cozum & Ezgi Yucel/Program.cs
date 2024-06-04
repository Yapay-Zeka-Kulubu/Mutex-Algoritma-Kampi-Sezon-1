
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Hesap_Makinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sayi1 = 0;
            double sayi2 = 0;
            bool sayiMi = true;

            while (sayiMi)
            {
                try
                {
                    Console.WriteLine("Islem yapacaginiz ilk sayiyi giriniz: ");
                    sayi1 = Convert.ToDouble(Console.ReadLine());
                    sayiMi = false;
                }
                catch 
                {
                    Console.Write("Sayı girmediniz.Lutfen ");
                }
            }


            sayiMi = true;


            while (sayiMi)
            {
                try
                {
                    Console.WriteLine("Islem yapacaginiz ikinci sayiyi giriniz: ");
                    sayi2 = Convert.ToDouble(Console.ReadLine());
                    sayiMi = false;
                }
                catch 
                {
                    Console.WriteLine("Sayı girmediniz.Lutfen ");
                }
            }

            double sonuc = 0;

            
            Console.WriteLine("Isleminizi seciniz -------> ( + , - , / , *)");
            char islem = Convert.ToChar(Console.ReadLine());


            
            while (islem != '+' && islem != '-' && islem != '/' && islem != '*')
            {
                Console.WriteLine("Yanlıs islem girdiniz, tekrar deneyiniz: ");
                islem = Convert.ToChar(Console.ReadLine());
            }

           

            switch (islem)
            {
                case '+':
                    sonuc = sayi1 + sayi2;
                    break;
                case '-':
                    sonuc = sayi1 - sayi2;
                    break;
                case '/':
                    while (sayi2 == 0)
                        Console.WriteLine("Bolen sifir olamaz. Lutfen farkli bir ikinci sayi giriniz: ");
                    try
                    {
                        sayi2 = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Sayi girilmedi. Lutfen bir sayi giriniz.");
                    }

                    sonuc = sayi1 / sayi2;
                      break;
                case '*':
                    sonuc = sayi1 * sayi2;
                    break;
            }

          
            Console.WriteLine("Isleminizin sonucu: " + sonuc);
            Console.ReadLine();
        }
    }
}



