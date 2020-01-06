using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    /// <summary>
    /// Дто - модель детали.
    /// </summary>
    public class DetailDto : BaseIdModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Идентификатор вида работы.
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// Идентификатор производителя детали.
        /// </summary>
        public int? ProducerDetailsId { get; set; }

        /// <summary>
        /// Производитель детали (ручной ввод).
        /// </summary>
        public string ProducerDetailsWritten { get; set; }

        /// <summary>
        /// Уровень доверия производителя детали (целое число).
        /// </summary>
        public int? TrustLevel { get; set; }
    }
}
