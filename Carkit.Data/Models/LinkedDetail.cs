using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Детали связанные с моделью авто.
    /// </summary>
    public partial class LinkedDetail : BaseModel
    {
        /// <summary>
        /// Идентификатор детали.
        /// </summary>
        public int DetailId { get; set; }

        /// <summary>
        /// Идентификатор модели авто.
        /// </summary>
        public int ModelCarId { get; set; }

        /// <summary>
        /// Оригинал.
        /// </summary>
        public bool IsOriginal { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// Идентификатор единицы измерения.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Деталь.
        /// </summary>
        public virtual Detail Detail { get; set; }

        /// <summary>
        /// Модель авто.
        /// </summary>
        public virtual ModelCar Model { get; set; }

        /// <summary>
        /// Единица измерения.
        /// </summary>
        public Unit Unit { get; set; }
    }
}
