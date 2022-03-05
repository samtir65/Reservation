// Decompiled with JetBrains decompiler
// Type: Respect.Core.Events.IEventPublisher
// Assembly: Respect.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30817935-28C5-4679-B52F-F98B1A987C96
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.0\lib\net5.0\Respect.Core.dll

namespace Framework.Application
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventToPublish) where T : IEvent;
    }
}