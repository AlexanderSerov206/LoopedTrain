using System.Collections.Generic;

namespace LoopedTrain
{
    public class Train
    {
        public List<Carriage> Carriages { get; private set; }

        /// <summary>
        /// Класс поезд. При создании экземпляра класса, поезд заполняется вагонами в указанном количестве.
        /// </summary>
        public Train(int numberOfCarriages)
        {
            Carriages = new List<Carriage>();

            for (int i = 0; i < numberOfCarriages; i++)
            {              
                Carriages.Add(new Carriage());
            }
        }
    }
}
