using System;
using System.Text;
using System.Threading;

namespace ArrayOperationsMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Random rdn = new Random();
            int[] mass = new int[5];
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rdn.Next(1, 100);
            }
            Console.Write("Начальный массив: " + string.Join(", ", mass) + "\n");
            
            var operation = new ArrayOperations(mass);

            const int totalThreads = 4;
            Thread[] threads = new Thread[totalThreads];
                      
            threads[0] = new Thread(() => operation.AddElement(1, 0));           
            threads[1] = new Thread(() => operation.MultiElement(2, 1));            
            threads[2] = new Thread(() => operation.AddElement(1, 2));            
            threads[3] = new Thread(() => operation.MultiElement(2, 3));

            foreach (var t in threads)
            {
                t.Start();
            }
            foreach (var t in threads)
            {
                t.Join();
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("Работа потоков завершена");
            Console.WriteLine($"Финальный массив: [{string.Join(", ", operation.Number)}]");
            Console.WriteLine("========================================");
        }
    }
}
