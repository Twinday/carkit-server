using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    public class OrderDto : BaseIdModel
    {
        /// <summary>
        /// Идентификатор авто.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Идентификатор автомастерской.
        /// </summary>
        public int RepairShopId { get; set; }

        /// <summary>
        /// Дата и время начала обслуживания.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Продолжительность обслуживания.
        /// </summary>
        public double TimePeriod { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Cost { get; set; }
    }
}
