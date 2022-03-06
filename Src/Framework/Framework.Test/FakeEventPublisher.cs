// Decompiled with JetBrains decompiler
// Type: Respect.Test.Doubles.FakeEventPublisher
// Assembly: Respect.Test.Doubles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E3EE3AA9-3493-42F4-870B-E3D7DDDC9B7F
// Assembly location: C:\Users\admin\.nuget\packages\respect.test.doubles\1.0.0\lib\net5.0\Respect.Test.Doubles.dll

using System.Collections.Generic;
using Framework.Application;

namespace Framework.Test
{
    public class FakeEventPublisher : IEventPublisher
    {
        private readonly List<object> _publishedEvents;

        public FakeEventPublisher()
        {
            this._publishedEvents = new List<object>();
        }

        public void ClearHistory()
        {
            this._publishedEvents.Clear();
        }

        public List<object> GetPublishedEvents()
        {
            return this._publishedEvents;
        }

        public TEvent GetIndex<TEvent>(int index) where TEvent : class, IEvent
        {
            return this._publishedEvents[index] as TEvent;
        }

        public TEvent GetLastEvent<TEvent>() where TEvent : class, IEvent
        {
            return this._publishedEvents[this._publishedEvents.Count - 1] as TEvent;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            this._publishedEvents.Add((object)@event);
        }
    }
}