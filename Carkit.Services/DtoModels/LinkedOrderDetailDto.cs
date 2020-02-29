using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    /// <summary>
    /// Связынные детали с заказом.
    /// </summary>
    public class LinkedOrderDetailDto : BaseIdModel
    {
        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Идентификатор детали.
        /// </summary>
        public int DetailId { get; set; }

        /// <summary>
        /// Название детали.
        /// </summary>
        public string DetailName { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// Идентификатор единицы измерения.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Название единицы измерения.
        /// </summary>
        public string UnitName { get; set; }

        //public string Status { get; set; }
    }
}
