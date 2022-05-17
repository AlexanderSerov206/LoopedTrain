using System;

namespace LoopedTrain
{
    /// <summary>
    /// Класс наблюдатель, который будет осуществлять движение по поезду и считать вагоны.
    /// </summary>
    public class Observer
    {
        private int CurrentCarriageNumber { get; set; } // Номер текущего вагона.
        private int PassedCarriages { get; set; } // Количество пройденных вагонов.
        private Carriage CurrentCarriage { get; set; } // Текущий вагон.
        private int LastPassedCarriages { get; set; } // Используется для запоминания последнего количества пройденных вагонов и возврата значения.
        private int CountOfPasses { get; set; } // Количество возвратов к первому вагону.
        private Train Train { get; set; }

        /// <summary>
        /// Класс наблюдатель. При объявлении экземпляра класса наблюдатель случайным образом помещается в один из вагонов и включает там свет.
        /// </summary>
        /// <param name="train">Класс поезд, по которому будет передвигаться наблюдатель.</param>
        public Observer(Train train)
        {
            Train = train;
            PassedCarriages = 0;
            LastPassedCarriages = 0;
            CountOfPasses = 0;
            CurrentCarriageNumber = new Random().Next(0, Train.Carriages.Count);
            CurrentCarriage = Train.Carriages[CurrentCarriageNumber];
            CurrentCarriage.TurnLightOn();
        }

        /// <summary>
        /// Движение по поезду. Наблюдатель будет двигаться по поезду и считать вагоны до тех пор, пока не обнаружит вагон с включённым светом, затем выключит его
        /// и вернётся в вагон, с которого начал. Если свет в нём не горит, значит последний вагон, в котором он выключил свет является тем, с которого он начал 
        /// и количество вагонов равно тому числу, которое он прошёл.
        /// </summary>
        /// <returns>Возвращает кортеж из чисел. Первое число - количество вагонов, которое подсчитал наблюдатель. Второе - количество раз, которое ему пришлось вернуться в первый вагон.</returns>
        public (int, int) MoveThroughTrain()
        {
            bool isInitialCarriageLightOn = true;            

            while (isInitialCarriageLightOn)
            {
                MoveToNextCarriage();

                if (CurrentCarriage.IsLightOn)
                {
                    LastPassedCarriages = PassedCarriages;
                    CurrentCarriage.TurnLightOff();
                    isInitialCarriageLightOn = ReturnToInitialCarriage();
                }
                else
                {
                    continue;
                }
            }

            return (LastPassedCarriages, CountOfPasses);
        }

        /// <summary>
        /// Движение в следующий вагон. Этим методом реализована зацикленность коллекции.
        /// </summary>
        private void MoveToNextCarriage()
        {
            if (CurrentCarriageNumber < Train.Carriages.Count - 1) 
            {
                CurrentCarriageNumber++;                
            }
            else
            {
                CurrentCarriageNumber = 0;
            }

            CurrentCarriage = Train.Carriages[CurrentCarriageNumber];

            PassedCarriages++;
        }

        /// <summary>
        /// Возврат в первый вагон исходя из запомненного количества пройденных вагонов. Проверка, включён ли в нём свет. 
        /// </summary>
        /// <returns>Возвращает значение false для выхода из цикла, если свет в первом вагоне погас. Возвращает true, если свет продолжает гореть.</returns>
        private bool ReturnToInitialCarriage()
        {
            CountOfPasses++;

            for (int i = PassedCarriages; i > 0; i--)
            {
                if (CurrentCarriageNumber > 0)
                {
                    CurrentCarriageNumber--;
                }
                else
                {
                    CurrentCarriageNumber = Train.Carriages.Count - 1;
                }
            }

            CurrentCarriage = Train.Carriages[CurrentCarriageNumber];
            PassedCarriages = 0;

            if (!CurrentCarriage.IsLightOn)
            {
                return false;
            }

            return true;
        }
    }
}
