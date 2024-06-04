using System.Diagnostics;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Enter the beginning of the range.");
        bool isNum1 = int.TryParse(Console.ReadLine(), out int num1);
        System.Console.WriteLine("Enter the end of the range.");
        bool isNum2 = int.TryParse(Console.ReadLine(), out int num2);
        System.Console.WriteLine("--------------------");

        if (!isNum1 && !isNum2)
        {
            System.Console.WriteLine("Please enter a number.");
            return;
        }

        if (num1 > num2)
        {
            System.Console.WriteLine("The beginning of the range must be less than the end of the range.");
            return;
        }

        if (num1 < 3)
        {
            num1 = 3;
            System.Console.Write("2 ");
        }

        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        //elle girmek yerine sayının büyüklüğüne göre ayarlanabilir.
        float threadCount = 30;

        CountdownEvent cd = new CountdownEvent((int)threadCount);

        float rangeStep = (num2 - num1) / threadCount;

        //forda beginninge + 1 ekliyorum aynı sayıları kontrol etmesinler diye ama ilk sayıyı kaçırıyor o yüzden burda sadece ilk sayıyı kontrol ediyorum.
        PrintIfPrime(num1, num1, cd);
        for (int i = 0; i < threadCount; i++)
        {
            //mesela 1000-2000 arasında 2 thread çalışacaksa 1000-1500 ve 1500-2000 aralıklarında çalışacak şekilde ayarlanır
            //float kullanmamın sebebi rangeStep'in tam sayı olmaması durumunda da sayı kaçırmaması
            //local variable yapmazsak valuesunu değil referansını alıyormuş
            float beginning = num1 + i * rangeStep + 1;
            float end = num1 + rangeStep + i * rangeStep;
            Thread checkPrimeThread = new Thread(() => PrintIfPrime(beginning, end, cd));
            checkPrimeThread.Start();
        }

        cd.Wait();
        watch.Stop();
        Console.WriteLine($"Runtime: {watch.ElapsedMilliseconds} ms");
    }

    static void PrintIfPrime(float beginning, float end, CountdownEvent cd)
    {
        beginning = (int)beginning % 2 == 0 ? beginning + 1 : beginning;
        for (int i = (int)beginning; i <= end; i += 2)
        {
            bool isPrime = true;
            int sqrtNum = (int)Math.Sqrt(i);
            for (int j = 3; j <= sqrtNum; j += 2)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                }
            }

            if (isPrime)
            {
            }
        }

        if (beginning != end)
            cd.Signal();
    }
}