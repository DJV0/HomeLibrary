using AutoMapper;
using HomeLibrary.BLL.Interfaces;
using HomeLibrary.BLL.Services;
using HomeLibrary.DAL.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureBusinessLogicLayerDI(this IServiceCollection services, 
                                                                                                IConfiguration configuration)
        {
            services.ConfigureDataAccessLayerDI(configuration);

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfigurator(config));
            });
            services.AddSingleton(mapperConfiguration.CreateMapper());

            return services;
        }
    }
}
