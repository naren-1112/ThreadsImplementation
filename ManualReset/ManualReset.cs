using System.Threading;
using System;
using System.Threading.Tasks;

namespace ThreadImplementation
{
    class ManualReset
    {
        static ManualResetEvent _manual = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            new Thread(Write).Start();
            for (int i = 0; i <= 5; i++)
            {
                new Thread(Read).Start();
            }
            Console.ReadKey();
        }
        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing...");
            _manual.Reset();
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing completed...");
            _manual.Set();

        }
        public static void Read()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is waiting...");
            _manual.WaitOne();
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is reading");

        }
    }
}