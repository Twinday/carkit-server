using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Дополнение вида работ к модели авто.
    /// </summary>
    public partial class WorkEffort :BaseModel
    {
        /// <summary>
        /// Идентификатор вида работы.
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// Идентификатор модели авто.
        /// </summary>
        public int ModelCarId { get; set; }

        /// <summary>
        /// Время выполнения работы для модели авто.
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// Вид работы.
        /// </summary>
        public virtual Work Work { get; set; }

        /// <summary>
        /// Модель авто.
        /// </summary>
        public virtual ModelCar Model { get; set; }
    }
}
