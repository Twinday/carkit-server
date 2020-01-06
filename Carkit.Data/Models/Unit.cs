using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Единицы измерения.
    /// </summary>
    public partial class Unit : BaseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Полное название.
        /// </summary>
        public string FullName { get; set; }
    }
}
