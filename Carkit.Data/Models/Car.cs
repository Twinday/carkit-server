using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Авто, привязанное к пользователю.
    /// </summary>
    public partial class Car : BaseModel
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
        /// Полный ВИН номер авто.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Карточка авто.
        /// </summary>
        public virtual CarCard CarCard { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Список заказов для авто.
        /// </summary>
        public virtual List<Order> Orders { get; set; }
    }
}
