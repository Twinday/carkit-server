﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Модель авто с пробегом и рекомендованными работами.
    /// </summary>
    public partial class WorkForCar : BaseModel
    {
        /// <summary>
        /// Идентификатор карточки авто.
        /// </summary>
        public int CarCardId { get; set; }

        /// <summary>
        /// Пробег авто.
        /// </summary>
        public int Kilometrage { get; set; }

        /// <summary>
        /// Виды работ, которые рекомендуется провести.
        /// </summary>
        public virtual List<LinkedWorkForCarWork> RecomendedWorks { get; set; }

        /// <summary>
        /// Карточка авто.
        /// </summary>
        public virtual CarCard CarCard { get; set; }
    }
}
