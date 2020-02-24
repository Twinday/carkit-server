using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    public class CarCardView : BaseIdModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Производитель авто.
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Год.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Идентификатор модели авто.
        /// </summary>
        public int ModelCarId { get; set; }
    }
}
