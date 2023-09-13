using System.Threading;
using System;
using System.Threading.Tasks;

namespace ThreadImplementation
{
    class AutoReset
    {
        static AutoResetEvent _auto = new AutoResetEvent(true);
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
            _auto.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing ...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing completed");
            _auto.Set();
        }
    }
}