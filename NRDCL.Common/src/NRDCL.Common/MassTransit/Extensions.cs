using System;
using System.Reflection;
using GreenPipes;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NRDCL.Common.Settings;

namespace NRDCL.Common.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(rabbitmq =>
             {
                 //RabbitMQ configuration
                 rabbitmq.AddConsumers(Assembly.GetEntryAssembly());
                 rabbitmq.UsingRabbitMq((context, configurator) =>
                 {
                     var configuration = context.GetService<IConfiguration>();
                     var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                     var rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

                     configurator.Host(rabbitMQSettings.Host);
                     configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                     configurator.UseHealthCheck(context);
                     configurator.UseMessageRetry(retryConfigurator =>
                     {
                         retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
                     });
                 });
             });

            //Mass Transit Hosted Service
            services.AddMassTransitHostedService();
            return services;
        }
    }
}