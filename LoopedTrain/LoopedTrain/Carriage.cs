namespace LoopedTrain
{
    /// <summary>
    /// Класс вагон, в котором может быть включен или выключен свет. 
    /// </summary>
    public class Carriage
    {
        public bool IsLightOn { get; private set; }

        /// <summary>
        /// При создании экземпляра класса, состояние света в вагоне определяется случайным образом.
        /// </summary>
        /// <param name="isLightOn">Значение bool, определяющее, включён свет в вагоне или нет.</param>
        public Carriage()
        {
            IsLightOn = BooleanGenerator.NextRandomBoolean();
        }

        /// <summary>
        /// Включает свет в текущем вагоне.
        /// </summary>
        public void TurnLightOn()
        {
            IsLightOn = true;
        }

        /// <summary>
        /// Выключает свет в текущем вагоне.
        /// </summary>
        public void TurnLightOff()
        {
            IsLightOn = false;
        }
    }
}
