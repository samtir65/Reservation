// Decompiled with JetBrains decompiler
// Type: Respect.Core.Events.EventAggregator
// Assembly: Respect.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30817935-28C5-4679-B52F-F98B1A987C96
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.0\lib\net5.0\Respect.Core.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Application
{
    public class EventAggregator : IEventListener, IEventPublisher
    {
        private readonly List<object> _subscriber = new List<object>();

        public void Publish<T>(T eventToPublish) where T : IEvent
        {
            this._subscriber.OfType<IEventHandler<T>>().ToList<IEventHandler<T>>().ForEach((Action<IEventHandler<T>>)(x => x.Handle(eventToPublish)));
        }

        public void Subscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            this._subscriber.Add((object)handler);
        }

        public void UnSubscribe<T>(T eventToPublish) where T : IEvent
        {
            this._subscriber.Remove((object)eventToPublish);
        }
    }
}