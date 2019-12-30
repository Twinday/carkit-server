using Carkit.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data
{
	/// <summary>
	/// Модуль для реализации внедрения зависимостей.
	/// </summary>
	public interface IModule
	{
		/// <summary>
		/// Настраивает коллекцию сервисов.
		/// </summary>
		/// <param name="services">Коллекция сервисов.</param>
		/// <param name="configuration">Конфигурация приложения.</param>
		void ConfigureServices(IServiceCollection services, IConfiguration configuration);
	}

	public class DataModule : IModule
    {
		public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddDbContext<CarkitContext>(optionsBuilder => optionsBuilder.UseSqlServer(configuration.GetConnectionString(typeof(CarkitContext).Name)));
		}
	}
}
