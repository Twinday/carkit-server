using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels.VIN
{
    public class DecodeVIN
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string ModelYear { get; set; }

        public string PlantCountry { get; set; }
    }
}
