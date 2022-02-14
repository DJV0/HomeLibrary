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
            services.AddScoped<ITagService, TagService>();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfigurator(config));
            });
            services.AddSingleton(mapperConfiguration.CreateMapper());

            return services;
        }

        public static void UpdateData<T>(this ICollection<T> dbCollection, ICollection<T> updatedCollection, string idPropertyName = "Id")
        {
            var itemsToDelete = dbCollection
                .Select(item => item.GetType().GetProperty(idPropertyName).GetValue(item))
                .Except(updatedCollection.Select(item => item.GetType().GetProperty(idPropertyName).GetValue(item)));
            var itemsToAdd = updatedCollection
                .Select(item => item.GetType().GetProperty(idPropertyName).GetValue(item))
                .Except(dbCollection.Select(item => item.GetType().GetProperty(idPropertyName).GetValue(item)));
            if (itemsToDelete.Any())
            {
                foreach (var itemId in itemsToDelete)
                {
                    var itemToDelele = dbCollection
                        .First(item => item.GetType().GetProperty(idPropertyName).GetValue(item).Equals(itemId));
                    dbCollection.Remove(itemToDelele);
                }
            }
            if (itemsToAdd.Any())
            {
                foreach (var itemId in itemsToAdd)
                {
                    var itemToAdd = updatedCollection
                        .First(item => item.GetType().GetProperty(idPropertyName).GetValue(item).Equals(itemId));
                    dbCollection.Add(itemToAdd);
                }
            }
        }      
    }
}
