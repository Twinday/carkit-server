﻿using AutoMapper;
using Carkit.Data.Models;
using Carkit.Services.DtoModels;
using Carkit.Services.DtoModels.Auth;
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
            OrderMap();
            CarMap();
            RecomendedWork();
            UserMap();

            CreateMap<Unit, Unit>();
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

            CreateMap<LinkedOrderDetail, LinkedOrderDetailDto>()
                .ForMember(q => q.DetailName, o => o.Ignore())
                .ForMember(q => q.UnitName, o => o.Ignore());
            CreateMap<LinkedOrderDetailDto, LinkedOrderDetail>();
        }

        private void WorkMap()
        {
            CreateMap<WorkEffortDto, WorkEffort>();
            CreateMap<WorkEffort, WorkEffortDto>();

            CreateMap<WorkDto, Work>();
            CreateMap<Work, WorkDto>();

            CreateMap<Work, WorkListView>();
        }

        private void OrderMap()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }

        private void CarMap()
        {
            CreateMap<CarCard, CarCardView>()
                .ForMember(q => q.Name, o => o.MapFrom(s => s.Model.Name))
                .ForMember(q => q.Producer, o => o.MapFrom(s => s.Model.Producer.Name));

            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();
        }

        private void RecomendedWork()
        {
            CreateMap<WorkForCar, WorkForCarDto>();
            CreateMap<WorkForCarDto, WorkForCar>();

            CreateMap<LinkedWorkForCarWork, RecomendedWorkDto>();
            CreateMap<RecomendedWorkDto, LinkedWorkForCarWork>();
        }

        private void UserMap()
        {
            //TO DO: Сделать генерацию пароля вместо "123".
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>()
                .ForMember(q => q.RoleId, o => o.MapFrom(s => s.RoleId == null ? 2 : s.RoleId))
                .ForMember(q => q.Password, o => o.MapFrom(s => s.Password == null || s.Password == string.Empty ? "123" : s.Password));
        }
    }
}
