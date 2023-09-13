using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsImplementation
{
    class Program
    {
        private static object _Lock = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i <= 5; i++)
            {
                new Thread(Work).Start();
            }
            Console.ReadKey();  
        }
        public static void Work()
        {
            lock (_Lock)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is starting...");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is completed.");
            }
        }
    }
}
