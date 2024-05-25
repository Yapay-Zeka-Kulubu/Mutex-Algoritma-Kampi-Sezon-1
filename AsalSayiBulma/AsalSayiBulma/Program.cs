using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Alt siniri giriniz : ");
        int sayi1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ust siniri giriniz : ");
        int sayi2 = Convert.ToInt32(Console.ReadLine());

        List<int> asalSayilar = AsalSayilariBul(sayi1, sayi2);

        Console.WriteLine($"{sayi1} ile {sayi2} arasındaki asal sayılar:");
        foreach (int asal in asalSayilar)
        { Console.WriteLine(asal); }

        Console.ReadLine();
    }

    static List<int> AsalSayilariBul(int baslangic, int bitis)
    {
        bool[] asalMi = new bool[bitis + 1];
        for (int i = 2; i <= bitis; i++)
        { asalMi[i] = true; }

        for (int p = 2; p * p <= bitis; p++)
        {
            if (asalMi[p])
            {
                for (int i = p * p; i <= bitis; i += p)
                { asalMi[i] = false; }
            }
        }

        List<int> asalSayilar = new List<int>();
        for (int i = baslangic; i <= bitis; i++)
        {
            if (asalMi[i])
            { asalSayilar.Add(i); }
        }
        return asalSayilar;

        Console.ReadLine();
    }
}
