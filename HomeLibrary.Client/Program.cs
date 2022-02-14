using HomeLibrary.Client.HttpClients;
using HomeLibrary.Client.Infrastructure;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;
using AutoMapper;

namespace HomeLibrary.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMudServices();

            builder.Services.AddHttpClient<OpenLibraryClient>();
            builder.Services.AddHttpClient<AuthorClient>();
            builder.Services.AddHttpClient<ImageClient>();
            builder.Services.AddHttpClient<BookClient>();
            builder.Services.AddHttpClient<TagClient>();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfigurator(config));
            });
            builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

            await builder.Build().RunAsync();
        }
    }
}
