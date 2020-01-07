using Carkit.Data.Models;
using Carkit.Services.DtoModels.Work;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels
{
    public class WorkDto : BaseIdModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Базовое время для этого типа работы.
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// Дополнения к работам.
        /// </summary>
        public List<WorkEffortDto> WorkEfforts { get; set; }
    }
}
