using MassTransit;
using MassTransit.MessageData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Sandbox.Shared.Messaging.RabbitMq
{
    public static class ConfigureCommonMessagingExtensions
    {
        public static void AddMessagingServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IMessagingConfiguration messagingConfiguration)
        {


            services.AddScoped<LoggerMessageAuditStore>();
            services.AddScoped(provider =>
                CreateRepository(configuration.GetValue<string>(ConfigurationKeys.RabbitMqBlobRepositoryFolder))
            );

            var loggerMessageAuditStore = services.BuildServiceProvider().GetService<LoggerMessageAuditStore>();
            var messageDataRepository = services.BuildServiceProvider().GetService<IMessageDataRepository>();


            services.AddMassTransit(x =>
            {
                messagingConfiguration.MapEndpointsByConvention();
                messagingConfiguration.AddSagasAction(x);
                messagingConfiguration.AddConsumersAction(x);


                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseMessageData(messageDataRepository);

                    cfg.UseHealthCheck(context);
                    cfg.Host(
                        configuration.GetValue<string>(ConfigurationKeys.RabbitMqHostName),
                        configuration.GetValue<string>(ConfigurationKeys.RabbitMqVirtualHost),
                        h =>
                        {
                            h.Username(configuration.GetValue<string>(ConfigurationKeys.RabbitMqUserName));
                            h.Password(configuration.GetValue<string>(ConfigurationKeys.RabbitMqPassword));
                        });

                    messagingConfiguration.ConfigureEndPointsAction(cfg, context);


                    cfg.ConnectSendAuditObservers(loggerMessageAuditStore);
                    cfg.ConnectConsumeAuditObserver(loggerMessageAuditStore);
                });
            });

            services.AddMassTransitHostedService();
        }

        private static IMessageDataRepository CreateRepository(string path)
        {
            var dataDirectory = new DirectoryInfo(path);

            return new FileSystemMessageDataRepository(dataDirectory);
        }
    }


}