using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadImplementation
{
    class Program
    {
        static Mutex _mutex = new Mutex();
        static void Main(string[] args)
        {
            for (int i = 0; i <= 5; i++)
            {
                new Thread(Write).Start();
            }
            Console.ReadKey();
        }
        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is waiting...");
            _mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing ...");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing completed");
            _mutex.ReleaseMutex();
        }
    }
}