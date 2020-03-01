using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    public class CarDto : BaseIdModel
    {
        /// <summary>
        /// Идентификатор карточки авто.
        /// </summary>
        public int? CarCardId { get; set; }

        /// <summary>
        /// Пробег авто.
        /// </summary>
        public int Kilometrage { get; set; }

        /// <summary>
        /// Полный ВИН номер авто.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int? UserId { get; set; }
    }
}
