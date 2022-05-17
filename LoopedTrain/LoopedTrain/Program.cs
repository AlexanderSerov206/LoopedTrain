using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopedTrain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите количество вагонов. Числа более 20000 отрабатывают долго :). ");

                string answer = Console.ReadLine();

                Console.WriteLine();

                if (int.TryParse(answer, out int result))
                {
                    Train train = new Train(result);

                    Observer observer = new Observer(train);

                    (int countedCarriages, int countOfPasses) = observer.MoveThroughTrain();

                    Console.WriteLine($"Наблюдатель сообщает, что максимальное количество вагонов, которое он прошел равно: {countedCarriages}. \nВозвращался в начало он {countOfPasses} раз.");

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Введено некорректное значение.");
                    continue;
                }
            }
        }
    }
}
