using AutoMapper;
using Carkit.Data.Models;
using Carkit.Services.DtoModels;
using Carkit.Services.DtoModels.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carkit.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            RepairShopMap();
            DetailMap();
            WorkMap();
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

            CreateMap<Detail, DetailListView>()
                .ForMember(q => q.ModelCarIds, o => o.MapFrom(s => s.LinkedDetails.Select(e => e.ModelCarId)));
        }

        private void WorkMap()
        {
            CreateMap<WorkEffortDto, WorkEffort>();
            CreateMap<WorkEffort, WorkEffortDto>();

            CreateMap<WorkDto, Work>();
            CreateMap<Work, WorkDto>();

            CreateMap<Work, WorkListView>();
        }
    }
}
