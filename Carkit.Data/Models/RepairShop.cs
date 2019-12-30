using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Автомастерская.
    /// </summary>
    public class RepairShop : BaseModel
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}
