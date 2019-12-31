using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Роль.
    /// </summary>
    public partial class Role : BaseModel
    {
        /// <summary>
        /// Название роли.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
