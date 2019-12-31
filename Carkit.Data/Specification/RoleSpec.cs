using Carkit.Data.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data.Models
{
    public partial class Role
    {
        /// <summary>
        /// Спецификация поиска по тексту.
        /// </summary>
        /// <param name="text">Текст.</param>
        public static Specification<Role> FindByText(string text)
        {
            return new Specification<Role>(item =>
                string.IsNullOrWhiteSpace(text)
                || (item.Name ?? string.Empty).ToUpper().Contains(text.ToUpper()));
        }

    }
}
