using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Производитель деталей.
    /// </summary>
    public class ProducerDetails : BaseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Уровень доверия (целое число).
        /// </summary>
        public int TrustLevel { get; set; }
    }
}
