using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels.Work
{
    /// <summary>
    /// Дто - модель дополнения вида работ к модели авто.
    /// </summary>
    public class WorkEffortDto : BaseIdModel
    {
        /// <summary>
        /// Идентификатор модели авто.
        /// </summary>
        public int ModelCarId { get; set; }

        /// <summary>
        /// Время выполнения работы для модели авто.
        /// </summary>
        public double Hours { get; set; }
    }
}
