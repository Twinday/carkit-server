using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Связывающая модель авто с пробегом и рекомендованные работы для него.
    /// </summary>
    public partial class LinkedWorkForCarWork : BaseModel
    {
        /// <summary>
        /// Идентификатор авто с пробегом.
        /// </summary>
        public int WorkForCarId { get; set; }

        /// <summary>
        /// Идентификатор рекомендованной работы.
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// Карточка авто с пробегом.
        /// </summary>
        public virtual WorkForCar WorkForCar { get; set; }

        /// <summary>
        /// Рекомендованная работа.
        /// </summary>
        public virtual Work Work { get; set; }
    }
}
