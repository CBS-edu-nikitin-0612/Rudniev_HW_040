using System;
using System.IO;
using System.Threading;

namespace Task2
{
    class Program
    {
        static FileStream stream1 = new FileStream("file1.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        static FileStream stream2 = new FileStream("file2.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
        static FileStream stream3 = new FileStream("file3.txt", FileMode.Append, FileAccess.Write);
        static StreamReader reader;
        static StreamWriter writer;
        static object obj = new object();
        static void Method()
        {
            lock (obj)
            {
                string text = "";
                reader = new StreamReader(stream1);
                text += reader.ReadToEnd();
                text += "\n\n";
                reader.Close();

                reader = new StreamReader(stream2);
                text += reader.ReadToEnd();
                text += "\n\n";
                reader.Close();

                writer = new StreamWriter(stream3);
                writer.Write(text);
                writer.Close();
            }
        }
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[2];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Method);
            }
            foreach (var item in threads)
            {
                item.Start();
            }
        }
    }
}
