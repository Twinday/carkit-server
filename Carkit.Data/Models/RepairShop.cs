using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Автомастерская.
    /// </summary>
    public partial class RepairShop : BaseModel
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Список заказов для автомастерской.
        /// </summary>
        public virtual List<Order> Orders { get; set; }
    }
}
