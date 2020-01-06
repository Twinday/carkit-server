using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Производитель авто.
    /// </summary>
    public partial class Producer : BaseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public string County { get; set; }
    }
}
