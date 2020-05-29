using AutoMapper;
using Carkit.Data;
using Carkit.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services
{
	public class ServiceModule : IModule
	{
		public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IRepairShopService, RepairShopService>();
			services.AddScoped<IDetailService, DetailService>();
			services.AddScoped<IWorkService, WorkService>();
			services.AddScoped<ICarCardService, CarCardService>();
			services.AddScoped<IRecomendedWorkService, RecomendedWorkService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IUnitService, UnitService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICarService, CarService>();

			services.AddScoped<IVINService, VINService>();
			services.AddHttpClient("VINClient", c =>
			{
				c.BaseAddress = new System.Uri($"https://vpic.nhtsa.dot.gov/api/vehicles/decodevinvaluesextended/");
			});

			services.AddScoped<ITimeService, TimeService>();

			services.AddAutoMapper(typeof(MappingProfile));

			services.AddScoped(typeof(IService<>), typeof(BaseService<>));

		}
	}
}
