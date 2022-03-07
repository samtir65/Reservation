// Decompiled with JetBrains decompiler
// Type: Respect.Config.Autofac.CommandBus
// Assembly: Respect.Config.Autofac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FFA8BD19-E334-45DE-B8BD-C7C6AC7E86A3
// Assembly location: C:\Users\admin\.nuget\packages\respect.config.autofac\1.0.0\lib\net5.0\Respect.Config.Autofac.dll

using Autofac;

namespace Framework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CommandBus(ILifetimeScope lifetimeScope)
        {
            this._lifetimeScope = lifetimeScope;
        }


        public void Dispatch<T>(T command)
        {
            this._lifetimeScope.Resolve<ICommandHandler<T>>().Handle(command);
        }
    }
}