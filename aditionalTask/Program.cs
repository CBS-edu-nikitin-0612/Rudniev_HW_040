using System;
using System.Threading;

namespace aditionalTask
{
    class Program
    {
        static int counter;
        static object obj = new object();
        static void Method()
        {
            lock (obj)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Counter = {++counter},  Thread ID = {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                (threads[i] = new Thread(Method)).Start();
                //threads[i].Join();
            }

        }
    }
}
