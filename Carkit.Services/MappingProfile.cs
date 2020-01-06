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
            DetailMap();
        }

        private void RepairShopMap()
        {
            CreateMap<RepairShop, RepairShopDto>();
            CreateMap<RepairShopDto, RepairShop>();
        }

        private void DetailMap()
        {
            CreateMap<Detail, DetailDto>();
            CreateMap<DetailDto, Detail>()
                .ForMember(q => q.Producer, o => o.MapFrom(s => s.ProducerDetailsId == null ? new ProducerDetails
                { 
                    Name = s.ProducerDetailsWritten,
                    TrustLevel = s.TrustLevel ?? 0
                } : null));
        }
    }
}
