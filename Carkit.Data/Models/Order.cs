using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public partial class Order : BaseModel
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

        //public string Status { get; set; }

        /// <summary>
        /// Авто.
        /// </summary>
        public virtual Car Car { get; set; }

        /// <summary>
        /// Автомастерская.
        /// </summary>
        public virtual RepairShop RepairShop { get; set; }
    }
}
