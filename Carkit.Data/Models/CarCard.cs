using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Карточка автомобиля.
    /// </summary>
    public partial class CarCard : BaseModel
    {
        /// <summary>
        /// Год.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Маска VIN номера.
        /// </summary>
        public string VINMask { get; set; }

        /// <summary>
        /// Идентификатор модели авто.
        /// </summary>
        public int ModelCarId { get; set; }

        /// <summary>
        /// Модель авто.
        /// </summary>
        public virtual ModelCar Model { get; set; }

        public virtual List<WorkForCar> WorkForCars { get; set; }
    }
}
