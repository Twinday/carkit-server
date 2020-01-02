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

			services.AddAutoMapper(typeof(MappingProfile));

			services.AddScoped(typeof(IService<>), typeof(BaseService<>));

		}
	}
}
