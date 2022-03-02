using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NServiceBus;
using Reservations.Gateways.Subscriber.JsonNet.PrivateSettersContractResolvers;
using ReservationSystem.Config;
using Respect.Config.Autofac;
using Respect.Core.Events;

namespace Reservations.Gateways.Subscriber
{
    public static class EndpointConfig
    {
        public static IEndpointInstance Config(GeneralBootstrapperModule generalBootstrapperModule, BootstrapperReservationsModule bootstrapperSalesModule, IServiceCollection services)
        {
            var endpointConfiguration = new EndpointConfiguration("Reservations.Subscriber");

            endpointConfiguration.LimitMessageProcessingConcurrencyTo(1);
            var settings = new JsonSerializerSettings { ContractResolver = new PrivateSetterContractResolver() };
            endpointConfiguration.UseSerialization<NewtonsoftSerializer>().Settings(settings);
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.SendHeartbeatTo(
            serviceControlQueue: "Particular.Servicecontrol",
            frequency: TimeSpan.FromSeconds(15),
            timeToLive: TimeSpan.FromSeconds(30));
            endpointConfiguration.ReportCustomChecksTo(
                serviceControlQueue: "Particular.Servicecontrol",
                timeToLive: TimeSpan.FromSeconds(10));
            var metrics = endpointConfiguration.EnableMetrics();
            metrics.SendMetricDataToServiceControl(
                serviceControlMetricsAddress: "Particular.Monitoring",
                interval: TimeSpan.FromSeconds(10),
                instanceId: "Reservations.Subscriber");
            metrics.SetServiceControlMetricsMessageTTBR(TimeSpan.FromHours(1));

            var transport = ConfigTransport(endpointConfiguration);
            transport.Transactions(TransportTransactionMode.ReceiveOnly);

            endpointConfiguration.EnableInstallers();



            //var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            //persistence.ConnectionBuilder(
            //    connectionBuilder: () => new SqlConnection(connectionString));
            //persistence.SqlDialect<SqlDialect.MsSqlServer>();
            //persistence.TablePrefix("NSB_");
            //var subscriptions = persistence.SubscriptionSettings();
            //subscriptions.CacheFor(TimeSpan.FromMinutes(1));

            var recoverability = endpointConfiguration.Recoverability();
            recoverability.Delayed(
                delayed =>
                {
                    delayed.NumberOfRetries(10);
                    delayed.TimeIncrease(TimeSpan.FromMinutes(1));
                });

            endpointConfiguration.UseContainer(new AutofacServiceProviderFactory(containerBuilder =>
            {
                containerBuilder.RegisterModule(generalBootstrapperModule);
                containerBuilder.RegisterModule(bootstrapperSalesModule);
                containerBuilder.Populate(services);
            }));

            endpointConfiguration.Conventions().DefiningEventsAs(a => typeof(DomainEvent).IsAssignableFrom(a));

            return Endpoint.Start(endpointConfiguration).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static TransportExtensions<RabbitMQTransport> ConfigTransport(EndpointConfiguration endpointConfiguration)
        {
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=localhost");
            transport.UseConventionalRoutingTopology();
            return transport;
        }
    }
}
