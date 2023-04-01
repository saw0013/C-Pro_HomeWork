using System;
using System.Threading.Tasks;

namespace Unit15
{
    internal class Program
    {
        static Random random = new Random();

        /// <summary>
        /// Асинхронный метод
        /// </summary>
        /// <param name="name"></param>
        async static void AsyncMethod(object name)
        {
            int id = (int)Task.CurrentId; // id выполняющейся задачи

            await Task.Delay(random.Next(100, 1000)); // Рандомная задержка
            Console.WriteLine($"Задача_{id} : Имя Задачи {name}"); // Выводим информацию в консоль
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количества запускаемых потоков...");
            int countTriggeredThreads = int.Parse(Console.ReadLine()); // Количество запускаемых потоков

            for (int i = 0; i < countTriggeredThreads; i++)
            {
                var task = new Task(AsyncMethod, $"AsyncMethod_{i}"); // Создаем задачу
                task.Start(); // Запускаем задачу
            }

            Console.ReadKey();
        }
    }
}
