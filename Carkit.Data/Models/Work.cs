using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Вид работ.
    /// </summary>
    public partial class Work : BaseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Базовое время для этого типа работы.
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// Детали.
        /// </summary>
        public virtual List<Detail> Details { get; set; }

        public virtual List<WorkEffort> WorkEfforts { get; set; }
        public virtual List<WorkForCar> WorkForCars { get; set; }
    }
}
