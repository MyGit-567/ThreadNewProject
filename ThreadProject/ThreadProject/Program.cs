using System;
using System.Diagnostics.Tracing;
using System.Threading;

namespace ThreadProject
{
    class Program
    {
        public static int counter = 0;
        public static int counterMamas = 0;
        public static int counterEmpire = 0;
        public static object locker = new object();
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => Work("Mamas"));
            thread1.IsBackground = false;


            Thread thread2 = new Thread(() => Work("Empire"));
            thread2.IsBackground = false;
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            Console.WriteLine($"We got mamas {counterMamas} times and \nEmpire {counterEmpire} and total counter {counter}");
        }

        static void Work(string word)
        {

            while (counter < 10000)
            {

                if (word == "Mamas" && counter % 2 == 0)
                {
                    counterMamas += 1;
                    Console.WriteLine(word);
                }
                else if (word == "Empire" && counter % 2 == 1)
                {
                    counterEmpire += 1;
                    Console.WriteLine(word);
                }
                counter++;



            }
        }

    }
}
