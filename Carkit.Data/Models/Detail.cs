using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Деталь.
    /// </summary>
    public partial class Detail : BaseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Идентификатор производителя детали.
        /// </summary>
        public int ProducerDetailsId { get; set; }

        /// <summary>
        /// Идентификатор вида работы, к которому относится деталь.
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// Производитель детали.
        /// </summary>
        public virtual ProducerDetails Producer { get; set; }

        public virtual List<LinkedDetail> LinkedDetails { get; set; }

        public virtual Work Work { get; set; }
    }
}
