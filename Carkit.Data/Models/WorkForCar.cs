using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Связанные виды работ для конкретного авто.
    /// </summary>
    public partial class WorkForCar : BaseModel
    {
        /// <summary>
        /// Идентификатор работы.
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// Идентификатор карточки авто.
        /// </summary>
        public int CarCardId { get; set; }

        /// <summary>
        /// Пробег авто.
        /// </summary>
        public int Kilometrage { get; set; }

        /// <summary>
        /// Вид работы.
        /// </summary>
        public virtual Work Work { get; set; }

        /// <summary>
        /// Карточка авто.
        /// </summary>
        public virtual CarCard CarCard { get; set; }
    }
}
