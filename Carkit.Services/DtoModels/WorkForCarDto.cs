using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    /// <summary>
    /// Дто - модель авто с пробегом.
    /// </summary>
    public class WorkForCarDto : BaseIdModel
    {
        /// <summary>
        /// Идентификатор карточки авто.
        /// </summary>
        public int CarCardId { get; set; }

        /// <summary>
        /// Пробег авто.
        /// </summary>
        public int Kilometrage { get; set; }

        /// <summary>
        /// Виды работ, которые рекомендуется провести.
        /// </summary>
        public virtual List<RecomendedWorkDto> RecomendedWorks { get; set; }
    }
}
