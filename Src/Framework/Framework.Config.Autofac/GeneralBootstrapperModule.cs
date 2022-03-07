// Decompiled with JetBrains decompiler
// Type: Respect.Config.Autofac.GeneralBootstrapperModule
// Assembly: Respect.Config.Autofac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FFA8BD19-E334-45DE-B8BD-C7C6AC7E86A3
// Assembly location: C:\Users\admin\.nuget\packages\respect.config.autofac\1.0.0\lib\net5.0\Respect.Config.Autofac.dll

using System;
using System.Data;
using System.Data.SqlClient;
using Autofac;
using Autofac.Builder;
using Framework.Application;
using Framework.Core;
using Framework.Core.Clock;
using Framework.NH;
using Microsoft.AspNetCore.Http;

namespace Framework.Config.Autofac
{
    public class GeneralBootstrapperModule : Module
    {
        public string ConnectionString { get; set; }

        public GeneralBootstrapperModule(string connectionString)
        {
            this.ConnectionString = connectionString;
        }



        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope().OnRelease<CommandBus, ConcreteReflectionActivatorData, SingleRegistrationStyle>((Action<CommandBus>)(x => { }));
            builder.RegisterType<SystemClock>().As<IClock>().SingleInstance();
            builder.RegisterType<NhUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<EventLookup>().As<IEventLookup>().InstancePerLifetimeScope();
            builder.RegisterType<ClaimHelper>().As<IClaimHelper>().InstancePerLifetimeScope();
            builder.RegisterType<HttpClientHelper>().As<IHttpClientHelper>().InstancePerLifetimeScope();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<EventAggregator>().As<IEventPublisher>().As<IEventListener>().InstancePerLifetimeScope().OnRelease<EventAggregator, ConcreteReflectionActivatorData, SingleRegistrationStyle>((Action<EventAggregator>)(x => { }));
        }

        public IDbConnection ComponentFactory(IComponentContext context)
        {
            SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            sqlConnection.Open();
            return (IDbConnection)sqlConnection;
        }
    }
}
