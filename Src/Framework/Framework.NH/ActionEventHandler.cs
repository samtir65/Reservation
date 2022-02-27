using Framework.Application;
using System;

namespace Framework.NH
{
    public class ActionEventHandler<T> : IEventHandler<T> where T : IEvent
    {
        private readonly Action<T> _action;

        public ActionEventHandler(Action<T> action)
        {
            this._action = action;
        }

        public void Handle(T @event)
        {
            this._action(@event);
        }
    }
}
