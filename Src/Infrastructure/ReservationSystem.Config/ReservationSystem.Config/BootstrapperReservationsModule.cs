﻿using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Type;
using Reservations.Gateway.Facade;
using ReservationSystem.Application.Reservations;
using ReservationSystem.Persistence.NH.Mapping.Reservations;
using ReservationSystem.Persistence.NH.Repository.Reservations;
using Respect.Application;
using Respect.Domain;
using Respect.NH;

namespace ReservationSystem.Config
{
    public class BootstrapperReservationsModule : Module
    {
        private readonly string _connectionString;
        private readonly string _sessionName;
        public BootstrapperReservationsModule(string connectionString, string sessionName)
        {
            this._connectionString = connectionString;
            this._sessionName = sessionName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var filterDef = new FilterDefinition("Filter", null, new Dictionary<string, IType>
                {{"isDeletedParam", NHibernateUtil.Boolean}}, false);

            var isActiveFilterDef = new FilterDefinition("IsActiveFilter", null, new Dictionary<string, IType>
                {{"isActiveParam", NHibernateUtil.Boolean}}, false);

            //var querySessionFactory = SessionFactoryBuilder.CreateByConnectionString(_connectionString,
            //   typeof(NotificationQueryMapping).Assembly, _sessionName, filterDef, isActiveFilterDef);
            //builder.Register(x =>
            //{
            //    var session = querySessionFactory.OpenSession();
            //    session.EnableFilter("Filter").SetParameter("isDeletedParam", false);
            //    session.EnableFilter("IsActiveFilter").SetParameter("isActiveParam", true);
            //    return session;
            //})
           //.As<ISession>()
           //.Keyed<ISession>("Query")
           //.InstancePerLifetimeScope();

            var commandSessionFactory = SessionFactoryBuilder.CreateByConnectionString(_connectionString, typeof(ReservationMapping).Assembly, _sessionName, filterDef, isActiveFilterDef);
            builder.Register(a =>
                {
                    var session = commandSessionFactory.OpenSession();
                    session.EnableFilter("Filter").SetParameter("isDeletedParam", false);
                    session.EnableFilter("IsActiveFilter").SetParameter("isActiveParam", true);
                    return session;
                })
                .As<ISession>()
                .Keyed<ISession>("Command")
                .InstancePerLifetimeScope()
                .OnRelease(x =>
                {

                });

            //builder.RegisterAssemblyTypes(typeof(NotificationQueryRepository).Assembly)
            //  .As(type => type.GetInterfaces().Where(interfaceType => interfaceType == typeof(IRepository)))
            //  .WithParameter(new ResolvedParameter(
            //      (pi, ctx) => pi.ParameterType == typeof(ISession),
            //      (pi, ctx) => ctx.ResolveKeyed<ISession>("Query")))
            //  .AsImplementedInterfaces()
            //  .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ReservationRepository).Assembly)
           .WithParameter(new ResolvedParameter(
               (pi, ctx) => pi.ParameterType == typeof(ISession),
               (pi, ctx) => ctx.ResolveKeyed<ISession>("Command")))
           .As(type => type.GetInterfaces()
               .Where(interfaceType => interfaceType == typeof(IRepository)))
           .AsImplementedInterfaces()
           .InstancePerLifetimeScope()
           .OnRelease(x =>
            {

            });

            builder.RegisterAssemblyTypes(typeof(ReservationCommandHandler).Assembly)
        .As(type => type.GetInterfaces()
            .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>)))
            .Select(interfaceType => new KeyedService("CommandHandler", interfaceType)))
        .InstancePerLifetimeScope();

            builder.RegisterGenericDecorator(typeof(TransactionalCommandHandlerDecorator<>),
                typeof(ICommandHandler<>), "CommandHandler")
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ReservationFacade).Assembly)
           .As(type => type.GetInterfaces().Where(interfaceType => interfaceType == typeof(IApplicationService)))
           .AsImplementedInterfaces().InstancePerLifetimeScope();

            // builder.RegisterAssemblyTypes(typeof(ImmediateQueryFacade).Assembly)
           //.As(type => type.GetInterfaces().Where(interfaceType => interfaceType == typeof(IApplicationService)))
           //.AsImplementedInterfaces().InstancePerLifetimeScope();

           // builder.RegisterType<KavenegarAcl>().As<IKavenegarAcl>().InstancePerLifetimeScope();
        }
    }
}
