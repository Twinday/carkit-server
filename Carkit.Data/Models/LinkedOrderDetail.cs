using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Детали для заказа.
    /// </summary>
    public partial class LinkedOrderDetail : BaseModel
    {
        // To Do context

        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Идентификатор детали.
        /// </summary>
        public int DetailId { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// Идентификатор единицы измерения.
        /// </summary>
        public int UnitId { get; set; }

        //public string Status { get; set; }

        /// <summary>
        /// Единица измерения.
        /// </summary>
        public virtual Unit Unit { get; set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Деталь.
        /// </summary>
        public virtual Detail Detail { get; set; }
    }
}
