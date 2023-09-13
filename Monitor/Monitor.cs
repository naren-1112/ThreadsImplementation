using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
            try
            {
                Monitor.Enter(_Lock);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is starting...");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is completed.");
            }
            catch (Exception e)
            {
            }
            finally
            {
                Monitor.Exit(_Lock);
            }
        }      
    }
}