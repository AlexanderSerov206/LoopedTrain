using System;

namespace LoopedTrain
{
    /// <summary>
    /// Класс для генерации случайных значений типа bool. Взят из примера документации с сайта docs.microsoft.com. 
    /// Класс определён как статический для корректной работы генератора случайных чисел.
    /// </summary>
    public static class BooleanGenerator
    {
        static readonly Random rnd = new Random();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Возвращает случайное значение bool.</returns>
        public static bool NextRandomBoolean()
        {
            return rnd.Next(0, 2) == 0;
        }
    }
}
