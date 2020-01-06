using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Модель авто.
    /// </summary>
    public partial class ModelCar : BaseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор производителя авто.
        /// </summary>
        public int ProducerId { get; set; }

        /// <summary>
        /// Производитель авто.
        /// </summary>
        public virtual Producer Producer { get; set; }

        public virtual List<WorkEffort> WorkEfforts { get; set; }
        public virtual List<LinkedDetail> LinkedDetails { get; set; }
    }
}
