﻿namespace Framework.Application
{
    public interface IEventListener
    {
        void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
    }
}
