using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataAccessLayerDI(this IServiceCollection services, 
                                                                                        IConfiguration configuration)
        {
            services.AddDbContext<HomeLibraryDbContext>(opt => 
                opt.UseSqlServer(configuration.GetConnectionString("HomeLibrary")));

            return services;
        }
    }
}
