using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels.Work
{
    /// <summary>
    /// Реестр вида работ.
    /// </summary>
    public class WorkListView : BaseIdModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Детали.
        /// </summary>
        public List<DetailListView> Details { get; set; }
    }
}
