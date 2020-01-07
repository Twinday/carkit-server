using Carkit.Services.DtoModels.Work;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.SearchModels
{
    public class WorkSearchResult
    {
        public int TotalCount { get; set; }

        /// <summary>
        /// Работы, рекомендованные для текущего авто.
        /// </summary>
        public List<WorkListView> WorksForCar { get; set; }

        /// <summary>
        /// Все остальные работы.
        /// </summary>
        public List<WorkListView> OtherWorks { get; set; }
    }
}
