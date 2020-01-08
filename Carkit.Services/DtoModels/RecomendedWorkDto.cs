using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    /// <summary>
    /// Дто - модель рекомендованной работы.
    /// </summary>
    public class RecomendedWorkDto : BaseIdModel
    {
        /// <summary>
        /// Идентификатор рекомендованной работы.
        /// </summary>
        public int WorkId { get; set; }
    }
}
