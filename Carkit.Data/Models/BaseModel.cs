using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Базовая модель.
    /// </summary>
    public class BaseModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
