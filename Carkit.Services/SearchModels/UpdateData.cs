using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.SearchModels
{
    /// <summary>
    /// Модель выборочного обновления полей сущностей.
    /// </summary>
    public class UpdateData
    {
        /// <summary>
        /// Словарь обновляемых полей.
        /// </summary>
        public Dictionary<string, object> Fields { get; set; } = new Dictionary<string, object>();
    }
}
