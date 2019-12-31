using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Базовая Id модель.
    /// </summary>
    public class BaseIdModel
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Базовая доменная модель.
    /// </summary>
    public partial class BaseModel : BaseIdModel
    {
        public bool IsDeleted { get; set; }
    }
}
