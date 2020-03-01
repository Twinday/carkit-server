using Carkit.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.SearchModels
{
    /// <summary>
    /// Модель поиска для получения времени обслуживания авто.
    /// </summary>
    public class TimePeriodSearchData : SearchData
    {
        public List<LinkedOrderDetailDto> Details { get; set; }

        public int ModelCarId { get; set; }
    }
}
