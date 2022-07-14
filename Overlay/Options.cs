namespace Overlay
{
    internal class Options
    {
        /// <summary>
        /// Скорость обновления выделенного окна
        /// В миллисекундах
        /// </summary>
        public int WindowUpdateInterval { get; set; } = 100;

        /// <summary>
        /// Скорость обновления данных в окне
        /// В миллисекундах
        /// (Пока не используется)
        /// </summary>
        public int DataUpdateInterval { get; set; } = 100;
    }
}
