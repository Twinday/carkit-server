using Carkit.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carkit.Web
{
    public class ModuleStartup : IModule
    {
        private List<IModule> _modules { get; set; }

        public ModuleStartup(List<IModule> modules)
        {
            _modules = modules;
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            foreach(var module in _modules)
            {
                module.ConfigureServices(services, configuration);
            }
        }
    }
}
