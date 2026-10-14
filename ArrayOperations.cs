using System;
using System.Threading;

namespace ArrayOperationsMonitor
{
    public class  ArrayOperations
    {
        public int[] Number { get; private set; }
        public ArrayOperations(int[] numberArray)
        {
            Number = numberArray;
        }
        private readonly object lokerObj = new object();

        public void AddElement(int value, int threadId)
        {
            Console.WriteLine($"Поток [{threadId}] прибавляет: {value}");
            Monitor.Enter(lokerObj);
            try
            {
                for (int i = 0; i < Number.Length; i++)
                {
                    Thread.Sleep(500);
                    Number[i] += value;
                }
                Console.WriteLine($"Поток [{threadId}] завершил сложение, массив: [{string.Join(", ", Number)}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в потоке {threadId}: {ex.Message}");
            }
            finally
            {
                Monitor.Exit(lokerObj);
                Console.WriteLine($"Поток {threadId}, вышел из критической секции");
            }
        }

        public void MultiElement(int multi, int threadId)
        {
            Console.WriteLine($"Поток [{threadId}] умножает: {multi}");
            Monitor.Enter(lokerObj);
            try
            {
                for (int i = 0; i < Number.Length; i++)
                {
                    Thread.Sleep(500);
                    Number[i] *= multi;
                }
                Console.WriteLine($"Поток [{threadId}] завершил умножение, массив: [{string.Join(", ", Number)}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в потоке {threadId}: {ex.Message}");
            }
            finally
            {
                Monitor.Exit(lokerObj);
                Console.WriteLine($"Поток {threadId}, вышел из критической секции");
            }
        }

    }
}
