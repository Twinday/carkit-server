using AutoMapper;
using Carkit.Data.Models;
using Carkit.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            RepairShopMap();
        }

        private void RepairShopMap()
        {
            CreateMap<RepairShop, RepairShopDto>();
            CreateMap<RepairShopDto, RepairShop>();
        }
    }
}
