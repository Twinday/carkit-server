using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels.Work
{
    /// <summary>
    /// Реестр детали.
    /// </summary>
    public class DetailListView : BaseIdModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификаторы авто, к которым подходит деталь.
        /// </summary>
        public List<int> ModelCarIds { get; set; }
    }
}
