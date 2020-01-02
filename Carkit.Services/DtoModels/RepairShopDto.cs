using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Services.DtoModels
{
    /// <summary>
    /// Dto модель автомастерской.
    /// </summary>
    public class RepairShopDto : BaseIdModel
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}
