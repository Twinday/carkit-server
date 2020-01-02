using Carkit.Data.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    public partial class RepairShop
    {
        /// <summary>
        /// Спецификация поиска по тексту.
        /// </summary>
        /// <param name="text">Текст.</param>
        public static Specification<RepairShop> FindByText(string text)
        {
            return new Specification<RepairShop>(item =>
                string.IsNullOrWhiteSpace(text)
                || (item.Address ?? string.Empty).ToUpper().Contains(text.ToUpper()));
        }

    }
}
