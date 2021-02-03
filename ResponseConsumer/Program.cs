using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResponseConsumer.Data;
using ResponseConsumer.Models;
using ResponseConsumer.Options;
using ResponseConsumer.Processors;
using ResponseConsumer.Receivers;
using ResponseConsumer.Repositories;
using System;
using System.Collections.Generic;

namespace ResponseConsumer
{
    class Program
    {

        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            IConfiguration configuration = BuildConfiguration();
            ConfigureServices(services, configuration);

            var serviceProvider = services.BuildServiceProvider();
            var consumer = serviceProvider.GetService<Consumer>();
            consumer.Start();
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }                


            

        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Consumer>();
            services.AddTransient<IReceiver<ResponseModel>, RabbitMQReceiver<ResponseModel>>();
            services.AddTransient<IResponseRepository, DefaultResponseRepository>();
            services.AddTransient<IProcessor<ICollection<ResponseModel>>, ResponseModelCollectionProcessor>();
            services.AddTransient<ICatalogContext, MongoDbCatalogContext>();
            services.Configure<ReceiverOptions>(configuration.GetSection("Receiver").Bind);
            services.Configure<CatalogDatabaseOptions>(configuration.GetSection("CatalogDatabase").Bind);
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }

        
    }
}
