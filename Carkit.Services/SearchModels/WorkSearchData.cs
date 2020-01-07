using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.SearchModels
{
    /// <summary>
    /// Параметры поиска для работ.
    /// </summary>
    public class WorkSearchData : SearchData
    {
        /// <summary>
        /// Идентификатор модели авто.
        /// </summary>
        public int? ModelCarId { get; set; }

        /// <summary>
        /// Пробег авто.
        /// </summary>
        public int Kilometrage { get; set; }
    }
}
