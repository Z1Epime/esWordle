using DataAccess.JSON;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DependencyContainer
    {
        public static ServiceProvider ServiceProvider;

        static DependencyContainer()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<WordAccessor>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
